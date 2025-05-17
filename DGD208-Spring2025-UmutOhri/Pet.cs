using System;
using System.Threading.Tasks;

namespace DGD208_Spring2025_UmutOhri
{
    public class Pet
    {
        public string Name { get; set; }
        public PetType Type { get; set; }
        public bool IsAlive { get; private set; } = true;
        public int Hunger { get; private set; } = 50;
        public int Sleep { get; private set; } = 50;
        public int Fun { get; private set; } = 50;

        public event Action<Pet> OnPetDied;

        public Pet(string name, PetType type)
        {
            Name = name;
            Type = type;
            StartStatDecrease();
        }

        private async void StartStatDecrease()
        {
            while (IsAlive)
            {
                await Task.Delay(3000); // 3 seconds

                Hunger = Math.Max(0, Hunger - 1);
                Sleep = Math.Max(0, Sleep - 1);
                Fun = Math.Max(0, Fun - 1);

                if (Hunger == 0 || Sleep == 0 || Fun == 0)
                {
                    IsAlive = false;
                    OnPetDied?.Invoke(this);
                }
            }
        }

        public void DisplayStats()
        {
            Console.WriteLine($"\n{Name} the {Type} - Stats:");
            Console.WriteLine($"Hunger: {Hunger}/100");
            Console.WriteLine($"Sleep: {Sleep}/100");
            Console.WriteLine($"Fun: {Fun}/100");
            Console.WriteLine($"Status: {(IsAlive ? "Alive" : "Dead")}");
        }
    }
}