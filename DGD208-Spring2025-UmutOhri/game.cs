using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGD208_Spring2025_UmutOhri;

namespace DGD208_Spring2025_UmutOhri
{
    public class Game
    {
        private List<Pet> pets = new List<Pet>();
        private Menu mainMenu;
        private bool isRunning = true;
        private Thread musicThread; // Yeni eklenen müzik thread'i

        public Game()
        {
            InitializeMenus();
            StartBackgroundMusic(); // Oyun başlar başlamaz müzik çalsın
        }

        private void StartBackgroundMusic()
        {
            musicThread = new Thread(() =>
            {
                while (isRunning)
                {
                    // 8-bit tarzı basit melodi
                    Console.Beep(659, 150); // Mi
                    Console.Beep(659, 150);
                    Console.Beep(659, 150);
                    Console.Beep(523, 100); // Do
                    Console.Beep(659, 150);
                    Console.Beep(784, 150); // Sol

                    if (!isRunning) break;

                    Thread.Sleep(2000); // Melodi arası
                }
            })
            {
                IsBackground = true // Ana thread bitince otomatik sonlansın
            };
            musicThread.Start();
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

        public async Task RunAsync()
        {
            


            ConsoleHelper.WriteCentered("PET SİMÜLATÖR", ConsoleColor.Cyan, true);
                ConsoleHelper.WriteCentered("v1.1", ConsoleColor.DarkCyan);

                while (isRunning)
                {
                    mainMenu.Display();
                    int choice = mainMenu.GetChoice();
                    await ProcessMainMenuChoice(choice);
                }
            



        }

        private async Task ProcessMainMenuChoice(int choice)
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
                    await UseItemOnPetAsync();
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

        private async Task UseItemOnPetAsync()
        {
            Console.Beep(988, 200);
            if (pets.Count == 0)
            {
                Console.WriteLine("\nYou don't have any pets yet!");
                await Task.Delay(1000);
                return;
            }

            Console.WriteLine("\nSelect a pet:");
            for (int i = 0; i < pets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pets[i].Name} ({pets[i].Type})");
            }

            int petIndex;
            while (!int.TryParse(Console.ReadLine(), out petIndex) || petIndex < 1 || petIndex > pets.Count)
            {
                Console.WriteLine("Invalid selection!");
            }
            Pet selectedPet = pets[petIndex - 1];

            var suitableItems = ItemDatabase.Items
                .Where(item => item.SuitablePets.Contains(selectedPet.Type))
                .ToList();

            if (suitableItems.Count == 0)
            {
                Console.WriteLine("No suitable items available for this pet!");
                await Task.Delay(1000);
                return;
            }

            Console.WriteLine("\nSelect an item:");
            for (int i = 0; i < suitableItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {suitableItems[i].Name} (+{suitableItems[i].StatIncrease} stat, {suitableItems[i].UsageTime}s)");
            }

            int itemIndex;
            while (!int.TryParse(Console.ReadLine(), out itemIndex) || itemIndex < 1 || itemIndex > suitableItems.Count)
            {
                Console.WriteLine("Invalid selection!");
            }
            Item selectedItem = suitableItems[itemIndex - 1];

            Console.WriteLine($"\nUsing {selectedItem.Name} on {selectedPet.Name}...");
            await Task.Delay(selectedItem.UsageTime * 1000);

            switch (selectedItem.Type)
            {
                case ItemType.Food:
                    selectedPet.IncreaseStat(PetStat.Hunger, selectedItem.StatIncrease);
                    break;
                case ItemType.Toy:
                    selectedPet.IncreaseStat(PetStat.Fun, selectedItem.StatIncrease);
                    break;
                case ItemType.Bed:
                    selectedPet.IncreaseStat(PetStat.Sleep, selectedItem.StatIncrease);
                    break;
            }

            Console.WriteLine($"\n{selectedPet.Name}'s stats improved!");
            selectedPet.DisplayStats();
            Console.ReadKey();
        }

        private void DisplayCreatorInfo()
        {
            Console.Beep(988, 200);
            Console.WriteLine("\nCreated by: [Umut Ohri], Student ID: [225040048]");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AdoptPet()
        {
            Console.Beep(988, 200);
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
            Console.Beep(988, 200);
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