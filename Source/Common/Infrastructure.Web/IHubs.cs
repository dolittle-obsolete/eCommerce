namespace Infrastructure.Web
{
    public interface IHubs
    {
        T Get<T>() where T: Hub;
    }
}