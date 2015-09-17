namespace Composite
{
    using System;

    class Client
    {
        static void Main(string[] args)
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
}
