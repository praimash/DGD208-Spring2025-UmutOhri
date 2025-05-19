using System;

using System.Collections.Generic;
using System.Linq;

namespace DGD208_Spring2025_UmutOhri
{
    public static class ItemDatabase
    {
        public static List<Item> Items = new List<Item>
        {
            new Item("Dry Food", ItemType.Food, 20, 2, new PetType[] { PetType.Dog, PetType.Cat }),
            new Item("Fish Flakes", ItemType.Food, 15, 1, new PetType[] { PetType.Fish }),
            new Item("Chew Toy", ItemType.Toy, 15, 3, new PetType[] { PetType.Dog }),
            new Item("Feather Toy", ItemType.Toy, 25, 5, new PetType[] { PetType.Cat, PetType.Bird }),
            new Item("Cozy Bed", ItemType.Bed, 30, 10, new PetType[] { PetType.Dog, PetType.Cat, PetType.Rabbit }),
            new Item("Carrot", ItemType.Food, 20, 2, new PetType[] { PetType.Rabbit }),
            new Item("Sexy Rabbit", ItemType.Toy, 20, 2, new PetType[] { PetType.Rabbit }),
            new Item("Dark Cave", ItemType.Bed, 15, 1, new PetType[] { PetType.Fish }),
            new Item("Nest", ItemType.Bed, 15, 1, new PetType[] { PetType.Bird }),
            new Item("Corn", ItemType.Food, 15, 1, new PetType[] { PetType.Bird }),
             new Item("Fish Dance", ItemType.Toy, 15, 1, new PetType[] { PetType.Fish }),
        };
    }
}
