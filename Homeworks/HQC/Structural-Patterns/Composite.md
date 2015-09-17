## Composite

### Същност
___
>* Позволява да се обединяват различни типове обекти в дървовидни структури.
>* Дава възможност да се третират еднакво отделни обекти или групи от обекти.
>* Улеснява добавянето на нови видове компоненти.

### Необходимост от употреба
___
* При работата с различни обекти, когато има нужда разликите между тях да бъдат игнорирани и да бъдат третирани еднакво.
* При представяне на йерархия от съставни обекти.
 
### UML диаграма
___
![alt text](Diagrams/CompositeUML.png)

### Имплементация
___

###### UIControl (Component)

```c#
public abstract class UIControl
    {
        public UIControl()
        { 
            
        }
        public string Name { get; set; }
        public int Width { get; set; }
        public ConsoleColor Color { get; set; }

        public abstract void Display(int depth);
    }
```

###### TextArea (Composite)

```c#
 public class TextArea : UIControl
    {
        private readonly ICollection<UIControl> controls;

        public TextArea()
            : base()
        {
            this.controls = new List<UIControl>();
            this.Name = " Text Area ";
            this.Width = 40;
        }

        public TextArea(string text, ConsoleColor color)
            : this()
        {
            this.Text = text;
            this.Color = color;
        }

        public string Text { get; set; }

        public void Add(UIControl control)
        {
            this.controls.Add(control);
        }


        public override void Display(int depth)
        {
           // Do something. (Probably ugly if you want to draw over the console.. like in the demo provided)
        }
    }
```

###### Button (Leaf)

```c#
  public class Button : UIControl
    {
        public Button()
        {
            this.Name = " Click me! ";
        }

        public Button(ConsoleColor color)
            : this()
        {
            this.Color = color;
        }

        public override void Display(int depth)
        {
            var space = new string(' ', depth);
            var line = new string('-', this.Name.Length + 2);

            Console.ForegroundColor = this.Color;
            Console.WriteLine($"{space}{line}");
            Console.WriteLine($"{space}{"|"}{this.Name}{"|"}");
            Console.WriteLine($"{space}{line}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
```
###### Usage
```c#
class Client
    {
        static void Main()
        {
            var mainContent = new TextArea("Hello world!", ConsoleColor.Cyan);
            var innerContent = new TextArea("I'm inner!", ConsoleColor.Green);
            var button = new Button(ConsoleColor.Blue);           

            innerContent.Add(button);
            mainContent.Add(innerContent);
            mainContent.Add(button);

            mainContent.Display(1);       
        }
    }
```