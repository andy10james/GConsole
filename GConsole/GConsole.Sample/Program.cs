using System;

namespace GConsole.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var canvas = new Canvas();
            canvas.Background = ConsoleColor.Blue;
            canvas.Children.Add(new MessageBox() { Message = "Hello World!" });
            canvas.Render();

            canvas.WaitForClear();
            
        }
    }
}
