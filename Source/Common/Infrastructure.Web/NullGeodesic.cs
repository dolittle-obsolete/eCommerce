using Dolittle.Runtime.Events.Relativity;

namespace Infrastructure.Web
{
    public class NullGeodesic : IGeodesics
    {
        public void Dispose()
        {
        }

        public ulong GetOffset(EventHorizonKey key)
        {
            return 0;
        }

        public void SetOffset(EventHorizonKey key, ulong offset)
        {
        }
    }
}