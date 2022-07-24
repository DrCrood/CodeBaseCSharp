using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodeBase
{
    public class OOP1
    {
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 150)
                {
                    Console.WriteLine(value + " is too big");
                }
                else
                {
                    age = value;
                }
            }
        }

        public int Weight { get; set; } = 199;
        public string Name { get; set; }

        public OOP1(int age, int weight, string name)
        {
            this.Age = age;
            this.Weight = weight;
            this.Name = name;
        }

        public virtual void PrintBasicInfo()
        {
            Console.WriteLine("print basic info from OOP1 base class.");
        }
    }

 
}
