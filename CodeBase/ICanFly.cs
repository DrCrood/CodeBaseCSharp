using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase
{
    public interface ICanFly
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public void Fly();
        public void DefaultMethod()
        {
            Console.WriteLine("Interface default method");
        }
    }

}
