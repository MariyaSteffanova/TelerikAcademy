namespace Composite
{
    using System;

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
}
