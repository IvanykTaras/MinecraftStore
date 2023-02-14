using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinecraftStore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string User_Id { get; set; }
        public int Product_Id { get; set; }
        public Product Product { get; set; }
        
    }
}
