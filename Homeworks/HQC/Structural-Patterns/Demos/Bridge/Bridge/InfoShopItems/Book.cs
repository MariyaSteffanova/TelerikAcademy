namespace Bridge.InfoShopItems
{
    using Bridge.Renderers;
    using System;

    public class Book : InfoShopItem
    {
        public Book(IRenderer renderer)
            : base(renderer)
        {
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

        public override void Display()
        {
            Console.WriteLine(this.renderer.Render("Title", this.Title));
            Console.WriteLine(this.renderer.Render("Author", this.Author));
            Console.WriteLine(this.renderer.Render("Pages", this.Pages.ToString()));
        }
    }
}
