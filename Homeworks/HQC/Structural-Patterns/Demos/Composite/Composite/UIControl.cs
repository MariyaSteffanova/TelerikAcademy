namespace Composite
{
    using System;

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
}
