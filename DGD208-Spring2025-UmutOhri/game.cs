using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_Spring2025_UmutOhri


    {
        public class Game
        {
            private Menu _mainMenu;
            private bool _isRunning;

            public Game()
            {
                InitializeMenus();
                _isRunning = true;
            }

            private void InitializeMenus()
            {
                _mainMenu = new Menu("Pet Simulator Main Menu", new List<string>
            {
                "Adopt a pet",
                "View pet stats",
                "Display creator info",
                "Exit the game",
            });
            }

            public void Run()
        {
            ConsoleHelper.WriteCentered("PET SİMÜLATÖR", ConsoleColor.Cyan, true);
            ConsoleHelper.WriteCentered("v1.0", ConsoleColor.DarkCyan);

            Console.WriteLine("Welcome to Pet Simulator!");

                while (_isRunning)
                {
                    _mainMenu.Display();
                    int choice = _mainMenu.GetChoice();
                    ProcessMainMenuChoice(choice);
                }
            }

            private void ProcessMainMenuChoice(int choice)
            {
                switch (choice)
                {
                   
                    
                    case 1:
                        Console.WriteLine("Pet adoption feature coming soon!");
                        break;
                    case 2:
                        Console.WriteLine("Pet stats feature coming soon!");
                        break;
                    case 3:
                        DisplayCreatorInfo();
                        break;
                    case 4:
                            _isRunning = false;
                            Console.WriteLine("Goodbye!");
                            break;

                    default:
                            Console.WriteLine("Invalid choice!");
                            break;
                }

                if (_isRunning)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }

            private void DisplayCreatorInfo()
            {
                Console.WriteLine("\nCreated by: [Umut Ohri], Student ID: [225040048]");
            }
        }
    }

