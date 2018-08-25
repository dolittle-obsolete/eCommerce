using Concepts;
using Dolittle.ReadModels;

namespace Read.Catalog.Listing
{
    public class Product : IReadModel
    {
        public Article Article { get; set; }

        public int Stock { get; set; }

        public Price Price { get; set; }
    }
}