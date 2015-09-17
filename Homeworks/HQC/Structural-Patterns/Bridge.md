## Bridge



### Същност
___
>* Отделя *абстракцията* от нейната *имплементация*, така че двете могат да бъдат променяни независимо.
>* Създава "Has-A" връзка между абстракцията и имплементацията.
>	* Предоставя възможност за елиминиране на наследяването и заменянето му с композиция (спазвайки принципа "Favor composition over inheritance").

### Необходимост от употреба
___
* При експоненциално нарастване на наследяване. 
* Когато даден клас и дейностите, които той извършва се променят често.

 
### UML диаграма
___
![alt text](Diagrams/BridgeUML.png)

* Implementor: Интерфейс, който предоставя предварителни операции, които всички плъгини трябва да имплементират
* ConcreteImplementor: Класовете, които ще бъдат използвани избирателно като плъгини
* Abstraction: Абстрактен клас, чиито наследници използват и имат референция към имплементация на Implementor

### Имплементация
___

###### IRenderer (Implementor)

```c#
public interface IRenderer
    {
        string Render(string key, string value);
    }
```

###### HtmlRenderer (ConcreteImplementor)

```c#
public class HtmlRenderer : IRenderer
    {
        public string Render(string key, string value)
        {
            return string.Format($"<div id=\"{key.ToLower()}\">\n\t{value}\n</div>");
        }
    }
```

###### ConsoleRenderer (ConcreteImplementor)

```c#
 public class ConsoleRenderer : IRenderer
    {
        public string Render(string key, string value)
        {
            return $"{key,10} : {value}";
        }
    }
```

###### InfoShopItem (Abstraction)

```c#
 public abstract class InfoShopItem
    {
        protected readonly IRenderer renderer;

        public InfoShopItem(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Display();

    }
```

###### Book (RefinedAbstraction)
```c#
 public class Book : InfoShopItem
    {
        public Book(IRenderer renderer)
            :base(renderer)
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
```

###### Movie (RefinedAbstraction)
```c#
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
```
###### Usage
```c#
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
```	



