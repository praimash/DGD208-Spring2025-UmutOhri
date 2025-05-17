using System;
using System.Collections.Generic;

namespace DGD208_Spring2025_UmutOhri
{
    public class Menu
    {
        private string title;
        private List<string> options;

        public Menu(string title, List<string> options)
        {
            this.title = title;
            this.options = options;
        }

        public void Display()
        {
           
            Console.WriteLine($"\n=== {title} ===", ConsoleColor.Cyan);
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            ConsoleHelper.WriteCentered("\nEnter your choice: ", ConsoleColor.Yellow);

        }
       

        public int GetChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > options.Count)
            {
                Console.WriteLine("Invalid input. Please try again.");
                Display();
            }
            return choice;
        }
    }
}
