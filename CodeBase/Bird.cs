using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase
{
    public class Bird : Animal, ICanFly
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public static int NumberofBirds = 0;

        public Bird()
        {
            Bird.NumberofBirds++;
        }
        public Bird(int price, string name) : this()
        {
            Price = price;
            Name = name;
        }


        public override void Eat()
        {
            Console.WriteLine("Bird eat");
        }

        public void Fly()
        {
            Console.WriteLine("Bird eat");
        }

        public void DefaultMethod()
        {
            Console.WriteLine("Re-implemented default method");
        }

        public static void ShowCreatedBirds()
        {
            Console.WriteLine($"Number Of Created Birds = {NumberofBirds}");
        }
    }
}
