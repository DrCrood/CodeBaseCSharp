using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase.OOP
{
    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        Paypal,
        GiftCard
    }


    public class Payment
    {
        public int Amount { get; set; }
        public bool Processed { get; set; }
        public bool Valid { get; set; }
        public PaymentMethod paymentMethod { get; set; }

        public Payment(PaymentMethod method, int amount)
        {
            this.paymentMethod = method;
            this.Amount = amount;
            this.Validate();
        }

        private void Validate()
        {
            if (Amount <= 0)
            {
                this.Valid = false;
                return;
            }

            if (paymentMethod == PaymentMethod.Paypal)
            {
                this.Valid = false;
                return;
            }

            this.Valid = true;
        }
    }
}
