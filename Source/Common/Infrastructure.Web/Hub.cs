using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Dolittle.Collections;
using Dolittle.Logging;
using Dolittle.Reflection;
using Dolittle.Serialization.Json;
using Dolittle.Strings;

namespace Infrastructure.Web
{
    public class Hub
    {
        public Hub(ISerializer serializer)
        {
            _serializer = serializer;
        }

        const string PING = "ping";
        const string PONG = "pong";

        class MethodCall
        {
            public string Method;
            public object[] Arguments;
        }

        readonly ConcurrentQueue<MethodCall> _methodsToSendToClient;
        readonly List<WebSocket> _webSockets = new List<WebSocket>();

        public void Invoke(Expression<Action> p)
        {
            var methodInfo = p.GetMethodInfo();
            var call = new MethodCall
            {
                Method = methodInfo.Name.ToCamelCase(),
                Arguments = p.GetMethodArguments()
            };

            _logger.Information($"Add '{call.Method}' for call to the client");

            var json = _serializer.ToJson(call, SerializationOptions.CamelCase);
            Send(json, "Invoked");

            //_methodsToSendToClient.Enqueue(call);
        }


        void Send(string payload, string logMessage)
        {
            var bytes = Encoding.UTF8.GetBytes(payload);
            lock(_webSockets)
            {
                _webSockets.ForEach(webSocket =>
                {
                    webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None).ContinueWith(o =>
                    {
                        _logger.Information(logMessage);
                    });

                });
            }

        }

        void Ping()
        {
            Send(PONG, "ping - pong");
        }

        readonly ILogger _logger;
        private readonly ISerializer _serializer;

        public Hub(ILogger logger)
        {
            // Idea: Make the system rely on virtual methods - we override these methods at runtime and call into the client, so you don't have to have the explicit call
            _methodsToSendToClient = new ConcurrentQueue<MethodCall>();

            _logger = logger;
        }

        void CleanupConnections() 
        {
            lock( _webSockets)
            {
                var socketsToRemove = _webSockets.Where(
                    webSocket => 
                        (webSocket.State != WebSocketState.Open && webSocket.State != WebSocketState.Connecting) ||
                        webSocket.CloseStatus.HasValue
                    );
                
                socketsToRemove.ForEach(webSocket => _webSockets.Remove(webSocket));
            }
        }

        public async Task Run(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var receivedDataBuffer = new System.ArraySegment<byte>(buffer);

            var result = await webSocket.ReceiveAsync(receivedDataBuffer, CancellationToken.None);
            lock(_webSockets) _webSockets.Add(webSocket);

            while (!result.CloseStatus.HasValue)
            {
                CleanupConnections();

                _logger.Information("Data from client");
                /*
                MethodCall methodCall;

                var hasMethod = _methodsToSendToClient.TryDequeue(out methodCall);
                if (hasMethod)
                {
                    _logger.Information($"Calling '{methodCall.Method.Name}' on client");
                }
                */
                receivedDataBuffer = new ArraySegment<byte>(buffer);
                result = await webSocket.ReceiveAsync(receivedDataBuffer, CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text && result.EndOfMessage)
                {
                    var payload = receivedDataBuffer.Array.Where(b => b != 0).ToArray();
                    var receivedString = System.Text.Encoding.UTF8.GetString(payload, 0, payload.Length);
                    if (receivedString == PING)
                    {
                        this.Ping();
                    }
                    else
                    {
                        //not sure what this could be?
                        _logger.Information($"Received string from client: {receivedString}");
                    }
                }
            }

            lock(_webSockets) _webSockets.Remove(webSocket);

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}