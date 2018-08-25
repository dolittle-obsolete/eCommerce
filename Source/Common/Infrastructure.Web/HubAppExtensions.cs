using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Web
{
    public static class HubAppExtensions
    {
        public static void AddHubs(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(IHubs), typeof(Hubs));
        }
        
        public static IApplicationBuilder UseHub<THub>(this IApplicationBuilder app, string route) where THub : Hub
        {

            app.Use(async(context, next) =>
            {
                if (context.Request.Path == route )
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        var hubs = app.ApplicationServices.GetService(typeof(IHubs)) as IHubs;
                        var hub = hubs.Get<THub>();
                        await hub.Run(context, webSocket);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await next();
                }

            });

            return app;
        }
    }
}