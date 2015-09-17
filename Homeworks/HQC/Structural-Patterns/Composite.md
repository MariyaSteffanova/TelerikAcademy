## Composite

### �������
___
>* ��������� �� �� ���������� �������� ������ ������ � ���������� ���������.
>* ���� ���������� �� �� �������� ������� ������� ������ ��� ����� �� ������.
>* �������� ���������� �� ���� ������ ����������.

### ������������ �� ��������
___
* ��� �������� � �������� ������, ������ ��� ����� ��������� ����� ��� �� ����� ���������� � �� ����� ��������� �������.
* ��� ����������� �� �������� �� �������� ������.
 
### UML ��������
___
![alt text](Diagrams/CompositeUML.png)

### �������������
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
