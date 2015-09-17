namespace Composite
{
    using System;
    using System.Collections.Generic;

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
            Console.ForegroundColor = this.Color;

            int lineComponentWidth = (this.Width - this.Name.Length) / 2 - depth;
            int lineBottonWidth = lineComponentWidth * 2 + this.Name.Length;

            string topLineComponent = new string('=', lineComponentWidth);
            string bottomLine = new string('=', lineBottonWidth);
            string space = new string(' ', depth);

            Console.WriteLine($"{space}{topLineComponent}{this.Name}{topLineComponent}{Environment.NewLine}");
            Console.WriteLine($"{space}{this.Text}{Environment.NewLine}");

            foreach (var control in this.controls)
            {
                control.Display(depth + 5);
            }

            Console.ForegroundColor = this.Color;
            Console.WriteLine($"{Environment.NewLine}{space}{bottomLine}");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
