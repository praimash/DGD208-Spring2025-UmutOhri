using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_Spring2025_UmutOhri


  
    {
        public class Menu
        {
           
        private string _title;
            private List<string> _options;

            public Menu(string title, List<string> options)
            {
                _title = title;
                _options = options;
            }

            public void Display()
            {
                Console.WriteLine($"\n=== {_title} ===");
                for (int i = 0; i < _options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_options[i]}");
                }
                Console.Write("Enter your choice: ");
            Console.Clear();
            ConsoleHelper.WriteCentered($"=== {_title} ===", ConsoleColor.Cyan);

            for (int i = 0; i < _options.Count; i++)
            {
                string menuItem = $"{i + 1}. {_options[i]}";
                ConsoleHelper.WriteCentered(menuItem);
            }

            ConsoleHelper.WriteCentered("\nEnter your choice: ", ConsoleColor.Yellow);
        }

            public int GetChoice()
            {
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > _options.Count)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Display();
                }
                return choice;
            }

        }
    }

