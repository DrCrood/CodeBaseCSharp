using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase
{
    public abstract class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Weight { get; set; }
        public static int NumberofAnimals = 0;

        public abstract void Eat();

        public virtual void PrintBasicInfo()
        {
            Console.WriteLine("Print animal basic info");
        }

        public Animal()
        {
            Animal.NumberofAnimals++;
        }

        public static void ShowAnimalNumbers()
        {
            Console.WriteLine($"Number of created animals = {Animal.NumberofAnimals}");
        }

    }
}
