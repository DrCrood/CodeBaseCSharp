using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase
{
    struct Person
    {
        public int[] Ids;
        public int Age;
        public int Weight;

        public Person (int age, int weight) 
        {
            //Stuct pass by value but the reference of array will be pass by shallow copy  
            Ids = new int[] { 1,2,3 };
            Age = age;
            Weight = weight;
        }

        public void Display()
        {
            Console.WriteLine($"Ids = {Ids[1]}, Age = {Age}, Weight = {Weight}");
        }
    }


}
