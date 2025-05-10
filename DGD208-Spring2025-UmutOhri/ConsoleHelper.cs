using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_Spring2025_UmutOhri

{
    public static class ConsoleHelper
    {
        public static void WriteCentered(string text, ConsoleColor color = ConsoleColor.White, bool drawBox = false)
        {
            int consoleWidth = Console.WindowWidth;
            int spacesBefore = (consoleWidth - text.Length) / 2;

            if (drawBox)
            {
                string horizontalLine = new string('═', text.Length + 4);
                WriteCentered($"╔{horizontalLine}╗", ConsoleColor.DarkGray);
                WriteCentered($"║  {text}  ║", color);
                WriteCentered($"╚{horizontalLine}╝", ConsoleColor.DarkGray);
            }
            else
            {
                Console.ForegroundColor = color;
                Console.WriteLine(text.PadLeft(spacesBefore + text.Length));
                Console.ResetColor();
            }
        }
    }
}
