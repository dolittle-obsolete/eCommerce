using Dolittle.Commands.Handling;
using Dolittle.Domain;
namespace Domain.Products.Store
{
    public class StoreCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<Store>  _aggregateRootRepoForStore;

        public StoreCommandHandler(
            IAggregateRootRepositoryFor<Store>  aggregateRootRepoForStore            
        )
        {
             _aggregateRootRepoForStore =  aggregateRootRepoForStore;
        }

        public void Handle(AddItemToStore cmd)
        {
            var aggregate = _aggregateRootRepoForStore.Get(cmd.ProductId);
            aggregate.AddItemToStore(cmd.Article, cmd.Description, cmd.Category, cmd.Stock, cmd.Price);
        }
        
        public void Handle(RemoveItemFromStore cmd)
        {
            var aggregate = _aggregateRootRepoForStore.Get(cmd.ProductId);
            aggregate.RemoveItemFromStore(cmd.Article);
        }
        
    }
}
