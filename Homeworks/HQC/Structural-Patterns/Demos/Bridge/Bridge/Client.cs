namespace Bridge
{
    using Bridge.InfoShopItems;
    using Bridge.Renderers;
    using System;

    public class Client
    {
        static void Main(string[] args)
        {
            var separator = new string('=', 40);

            Console.WriteLine($"{separator}   Books:");

            var htmlRenderer = new HtmlRenderer();
            var book = new Book(htmlRenderer);
            book.Title = "Mutual Aid: A Factor of Evolution";
            book.Author = "Peter Kropotkin";
            book.Pages = 236;
            book.Display();

            Console.WriteLine(separator);

            var consoleRenderer = new ConsoleRenderer();
            var book2 = new Book(consoleRenderer);
            book2.Title = "Crack Capitalism ";
            book2.Author = "John Holloway";
            book2.Pages = 320;
            book2.Display();

            Console.WriteLine($"{separator}    Movies:");

            var movie = new Movie(htmlRenderer);
            movie.Title = "La educación prohibida";
            movie.Director = "German Doin";
            movie.Duration = 121;
            movie.Topic = "Alternative education";
            movie.Display();

            Console.WriteLine(separator);

            var movie2 = new Movie(consoleRenderer);
            movie2.Title = "Cowspiracy: The Sustainability Secret";
            movie2.Director = "Kip Andersen";
            movie2.Duration = 85;
            movie2.Topic = "Animal rights, Ecology, Sustainability";
            movie2.Display();
        }
    }
}
