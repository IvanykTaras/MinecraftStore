using Microsoft.EntityFrameworkCore;
using MinecraftStore.Models;

namespace MinecraftStore.Data.Service
{
    public class ProductService : IService<Product>
    {

        private readonly AppDbContext _context;


        public ProductService(AppDbContext context)
        {
            _context = context;
        }


        //Delete
        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }

            var find = _context.Products.Find(id);
            
            if (find is not null)
            {
                _context.Products.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }



        //FindAll
        public ICollection<Product> FindAll()
        {
            return _context.Products.ToList();
        }


        //FindBy
        public Product? FindById(int? id)
        {
            return _context.Products.Find(id);
        }

        

        //Save
        public int Save(Product product)
        {
            var entityEntry = _context.Products.Add(product);
            _context.SaveChanges();
            return entityEntry.Entity.Id;
        }

        //Update
        public bool Update(Product product)
        {
            try
            {
                var find = _context.Products.Find(product.Id);
                if (find is not null)
                {
                    find.Name = product.Name;
                    find.Price = product.Price;
                    find.CreatedDate = product.CreatedDate;
                    find.Rarity = product.Rarity;
                    find.Image = product.Image;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

        }
    }
}
