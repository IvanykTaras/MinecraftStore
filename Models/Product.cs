using Microsoft.AspNetCore.Mvc;
using MinecraftStore.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace MinecraftStore.Models
{

    //
    //id,
    //name,
    //createddate,
    //price
    //Rarity

    public class Product
    {
        public Product()
        {
            CreatedDate = DateTime.Now;
        }

        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać imię!")]
        [MaxLength(100,ErrorMessage = "Zakres nazwy pomiędzy 1 a 100 zanków")]
        public string Name { get; set; }

        [HiddenInput]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Proszę podać cene!")]
        
        public int Price { get; set; }

        public RarityOfProduct Rarity { get; set; }
        
        public ImgOfProduct Image { get; set; }


    }
}


