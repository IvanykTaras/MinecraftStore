namespace MinecraftStore.Data.Service
{
    public interface IProductService<T>
    {
        public int Save(T item);
        public bool Delete(int? id);
        public bool Update(T item);
        public T? FindById(int? id);
        public ICollection<T> FindAll();
        
        //public ICollection<T> FindByAuthor(U relationItem);
        
    }
}
