using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase.OOP
{
    public class Order
    {
        public Customer customer { get; set; }
        public Payment payment { get; set; }
        public Shipment shipment { get; set; }
        public bool productAvailable { get; set; } = true;
        public bool Valid { get; set; }

        public Order(Customer customer, Payment payment)
        {
            this.customer = customer;
            this.payment = payment;
            this.Validate();
        }

        private void Validate()
        {
            if (this.payment.Valid && this.customer.Valid)

                this.Valid = true;
        }

        public bool ReadyToBeShipped()
        {
            if (this.Valid && productAvailable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
