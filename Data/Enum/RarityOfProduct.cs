using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinecraftStore.Data.Enum
{
    public enum RarityOfProduct
    {
       [Display(Name ="Tier 1")] T1 = 1,
       [Display(Name ="Tier 2")] T2 = 2,
       [Display(Name ="Tier 3")] T3 = 3,
       [Display(Name ="Tier 4")] T4 = 4,
       [Display(Name ="Tier 5")] T5 = 5,

    }
}
