using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace GConsole
{
    public class Canvas : IConsoleNode
    {

        public string Title { get; set; }

        public ConsoleColor Background { get; set; }

        public ConsoleColor Foreground { get; set; }

        public IList<IConsoleNode> Children { get; set; }

        private ManualResetEventSlim _resetEvent;

        public Canvas()
        {
            this._resetEvent = new ManualResetEventSlim(true);
            this.Children = new List<IConsoleNode>();
        }

        public void Render()
        {
            this._resetEvent.Reset();
            Console.Clear();
            if (this.Title != null)
                Console.Title = this.Title;
            Console.BackgroundColor = this.Background;
            Console.ForegroundColor = this.Foreground;
            Console.BufferHeight = Console.WindowHeight;
            var characters = Console.WindowHeight * Console.WindowWidth;
            for (var i = 0; i < characters; i++)
                Console.Write(' ');

            Console.SetCursorPosition(0, 0);
            foreach (var child in this.Children)
                child.Render();
        }

        public void Clear()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            this._resetEvent.Set();
        }

        public void WaitForClear()
        {
            this._resetEvent.Wait();
        }

    }
}
