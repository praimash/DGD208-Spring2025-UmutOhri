    using DGD208_Spring2025_UmutOhri;
    using System;

 

    namespace PetSimulator
    {
        class Program
        {
        static async Task Main(string[] args) 
        {

            Game game = new Game();
            await game.RunAsync(); 
        }
    }
    }
