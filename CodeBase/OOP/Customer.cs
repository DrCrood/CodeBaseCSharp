using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase.OOP
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Order> orders { get; set; }
        public bool Valid { get; set; }

        public Customer(string name, string address)
        {
            this.Name = name;
            this.Address = address;
            this.Validate();
        }

        private void Validate()
        {
            if (Name.Length > 4 && Address.Length > 10)
            {
                this.Valid = true;
            }
            else
            {
                this.Valid = false;
            }
        }
    }
}
