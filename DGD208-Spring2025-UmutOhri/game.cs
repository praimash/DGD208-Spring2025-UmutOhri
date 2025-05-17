using System;
using System.Collections.Generic;

namespace DGD208_Spring2025_UmutOhri
{
    public class Game
    {
        private List<Pet> pets = new List<Pet>();
        private Menu mainMenu;
        private bool isRunning = true;

        public Game()
        {
            InitializeMenus();
        }

        private void InitializeMenus()
        {
            mainMenu = new Menu("Main Menu", new List<string>
            {


                "Adopt a pet",
                "View pet stats",
                "Use item on pet",
                "Display creator info",
                "Exit the game"
            });
        }

        public void Run()
        {
            
            ConsoleHelper.WriteCentered("PET SİMÜLATÖR", ConsoleColor.Cyan, true);
            ConsoleHelper.WriteCentered("v1.0", ConsoleColor.DarkCyan);
            while (isRunning)
            {
                mainMenu.Display();
                int choice = mainMenu.GetChoice();
                ProcessMainMenuChoice(choice);
            }
        }

        private void ProcessMainMenuChoice(int choice)
        {
            switch (choice)
            {
                
                
                case 1:
                    AdoptPet();
                    break;
                case 2:
                    ViewPetStats();
                    break;
                case 3:
                    Console.WriteLine("Item usage feature coming soon!");
                    break;
                case 4:
                    DisplayCreatorInfo();
                    break;
                case 5:
                    isRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        private void DisplayCreatorInfo()
        {
            Console.WriteLine("\nCreated by: [Umut Ohri], Student ID: [225040048]");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AdoptPet()
        {
            Console.Write("\nEnter your pet's name: ");
            string name = Console.ReadLine();

            var petTypeMenu = new Menu("Select Pet Type", Enum.GetNames(typeof(PetType)).ToList());
            petTypeMenu.Display();
            PetType type = (PetType)(petTypeMenu.GetChoice() - 1);

            Pet newPet = new Pet(name, type);
            newPet.OnPetDied += (pet) =>
            {
                Console.WriteLine($"\n{pet.Name} has died!");
                pets.Remove(pet);
            };
            pets.Add(newPet);

            Console.WriteLine($"\n{name} the {type} added to your pets!");
            Console.ReadKey();
        }

        private void ViewPetStats()
        {
            if (pets.Count == 0)
            {
                Console.WriteLine("\nYou don't have any pets yet!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nYour Pets:");
            foreach (var pet in pets)
            {
                pet.DisplayStats();
            }
            Console.ReadKey();
        }
    }
}