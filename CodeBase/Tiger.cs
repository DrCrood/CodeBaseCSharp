using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase
{
    public class Tiger : Animal, ICanJump
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public static int NumberofTigers = 0;

        public Tiger()
        {
            Tiger.NumberofTigers++;
        }


        public Tiger(int price, string name) : this()
        {
            Price = price;
            Name = name;
        }

        public override void Eat()
        {
            Console.WriteLine("Tiger eat in his own way.");
        }

        public void Jump()
        {
            Console.WriteLine("Tiger Just Jumped.");
        }

        public static void ShowCreatedTigers()
        {
            Console.WriteLine($"Number Of Created Tigers = {NumberofTigers}");
        }
    }
}
