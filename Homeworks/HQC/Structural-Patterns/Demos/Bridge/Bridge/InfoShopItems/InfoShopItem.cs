namespace Bridge.InfoShopItems
{
    using Bridge.Renderers;

    public abstract class InfoShopItem
    {
        protected readonly IRenderer renderer;

        public InfoShopItem(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Display();
    }
}
