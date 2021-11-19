using System.Threading.Tasks;

namespace Marketplace
{
    public interface IHandleCommand<in T>
    {
        Task Handle(T command);
    }

    public interface IEntityStore
    {
        Task<T> Load<T>(string d);
        Task SAve<T>(T entity);
    }
    public class CreateClassifiedAdHandler:IHandleCommand<Contracts.ClassifiedAds.V1.Create>
    {
        private readonly IEntityStore _store;
        public CreateClassifiedAdHandler(IEntityStore store) => _store = store;

        public Task Handle(Contracts.ClassifiedAds.V1.Create command)
        {
            var classifiedAd = new ClassifiedAd
            (
                new ClassifiedAdId(command.Id),
                new UserId(command.OwnerId));

            return _store.save(classifiedAd);
        }        
    }
}