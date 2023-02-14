using Microsoft.EntityFrameworkCore;

namespace MinecraftStore.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {
                
                if (context.Products.Any())
                {
                    return;   
                }
                context.Products.AddRange(
                    new Models.Product()
                    {
                        Name = "Some",
                        Image = Enum.ImgOfProduct.Hoe,
                        Price = 1,
                        Rarity = Enum.RarityOfProduct.T3
                    },
                    new Models.Product()
                    {
                        Name = "Name1",
                        Image = Enum.ImgOfProduct.Shovel,
                        Price = 13,
                        Rarity = Enum.RarityOfProduct.T5
                    },
                    new Models.Product()
                    {
                        Name = "Lol",
                        Image = Enum.ImgOfProduct.Twohandpickaxe,
                        Price = 43,
                        Rarity = Enum.RarityOfProduct.T4
                    },
                    new Models.Product()
                    {
                        Name = "Xd",
                        Image = Enum.ImgOfProduct.Pickaxe,
                        Price = 13,
                        Rarity = Enum.RarityOfProduct.T3
                    },
                    new Models.Product()
                    {
                        Name = "Haha",
                        Image = Enum.ImgOfProduct.Hoe,
                        Price = 123,
                        Rarity = Enum.RarityOfProduct.T2
                    },
                    new Models.Product()
                    {
                        Name = "Money",
                        Image = Enum.ImgOfProduct.Hammer,
                        Price = 143,
                        Rarity = Enum.RarityOfProduct.T1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
