using System;

namespace DGD208_Spring2025_UmutOhri
{
    public class Item
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int StatIncrease { get; set; }
        public int UsageTime { get; set; }
        public PetType[] SuitablePets { get; set; }

        public Item(string name, ItemType type, int statIncrease, int usageTime, PetType[] suitablePets)
        {
            Name = name;
            Type = type;
            StatIncrease = statIncrease;
            UsageTime = usageTime;
            SuitablePets = suitablePets;
        }
    }
}