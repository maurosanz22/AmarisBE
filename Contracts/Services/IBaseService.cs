namespace Contracts.Services
{
    public interface IBaseService<T> where T : new()
    {
        T GetById(string id);
        //T GetByKey(string key);
    }
}
