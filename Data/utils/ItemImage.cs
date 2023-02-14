using MinecraftStore.Data.Enum;

namespace MinecraftStore.Data.utils
{
    public static class ItemImage
    {
        private readonly static string[] paths = {
            "/img/hammer.jpg",
            "/img/hoe.png",
            "/img/pickaxe.jpg",
            "/img/shovel.png",
            "/img/twohandpickaxe.jpg"
        };

        public static string GetPath(ImgOfProduct idOfPath) => paths[(int)idOfPath];


    }
}
