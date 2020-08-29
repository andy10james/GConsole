using System;

namespace GConsole
{
    public class MessageBox : IConsoleNode
    {

        public string Message { get; set; }

        public void Render()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            for (var y = 4; y < 7; y++)
            {
                Console.SetCursorPosition(19, y);
                Console.Write(new string(' ', 52));
            }

            Console.SetCursorPosition(20, 4);
            Console.Write('╔');
            Console.Write(new string('═', 48));
            Console.Write('╗');
            Console.SetCursorPosition(20, 5);
            Console.Write('║');
            Console.SetCursorPosition(69, 5);
            Console.Write('║');
            Console.SetCursorPosition(20, 6);
            Console.Write('╚');
            Console.Write(new string('═', 48));
            Console.Write('╝');

            Console.SetCursorPosition(22, 5);
            Console.Write(this.Message);
        }
    }
}
