namespace Amaris.ViewsModels
{
    public abstract class BaseVm<T> where T : new()
    {
        public string Id { get; set; }

        public abstract void MapperFromModel(T entity);
    }
}