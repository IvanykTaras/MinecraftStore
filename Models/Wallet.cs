using MessagePack;
using Microsoft.EntityFrameworkCore;

namespace MinecraftStore.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public string User_Id { get; set; }

        public int Deposit { get; set; } = 10000;
    }
}
