namespace Bridge.InfoShopItems
{
    using Bridge.Renderers;
    using System;

    public class Movie : InfoShopItem
    {
        public Movie(IRenderer renderer)
            : base(renderer)
        {
        }

        public string Title { get; set; }
        public string Director { get; set; }
        public string Topic { get; set; }
        public int Duration { get; set; }

        public override void Display()
        {
            Console.WriteLine(this.renderer.Render("Title", this.Title));
            Console.WriteLine(this.renderer.Render("Director", this.Director));
            Console.WriteLine(this.renderer.Render("Topic", this.Topic));
            Console.WriteLine(this.renderer.Render("Duration", $"{this.Duration} min"));
        }
    }
}
