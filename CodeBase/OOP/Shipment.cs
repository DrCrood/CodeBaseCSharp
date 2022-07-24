using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase.OOP
{
    public enum ShippingStatus
    {
        NotAvailable,
        Preparing,
        processing,
        Shipping,
        Shipped,
        Tranfering,
        Delivered
    }

    public class Shipment
    {
        public string Address { get; set; }
        public bool Shipped { get; set; }
        public ShippingStatus Status { get; set; }

        public void Ship()
        {
            this.Status = ShippingStatus.Shipped;
            this.Shipped = true;
        }
    }
}
