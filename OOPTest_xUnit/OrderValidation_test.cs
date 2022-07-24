using System;
using Xunit;
using CodeBase.OOP;

namespace OOPTest_xUnit
{
    public class OrderValidation_test
    {
        [Theory]
        [InlineData(PaymentMethod.CreditCard, 1, "Customer Name", "address line 1 for test", true)]
        [InlineData(PaymentMethod.CreditCard, 1, "Valid Name", "address", false)]
        [InlineData(PaymentMethod.CreditCard, 1, "", "address line 1 for test", false)]
        [InlineData(PaymentMethod.DebitCard, 1, "Customer Name", "address line 2 for test", true)]
        [InlineData(PaymentMethod.GiftCard, 0, "Customer Name", "address line 3 for test", false)]
        [InlineData(PaymentMethod.Paypal, 1, "Customer Name", "address line 4 for test", false)]
        public void Order_Validation_Test(PaymentMethod method, int amount, string name, string address, bool valid)
        {
            Customer stubCustomer = new Customer(name, address);

            Payment stubPayment = new Payment(method, amount);

            Order mockOrder = new Order(stubCustomer, stubPayment);

            Assert.Equal(mockOrder.Valid, valid);
        }

        [Theory]
        [InlineData("123 Abc Dr.", null, "College Station", "Texas", "USA", true)]
        [InlineData("123 Abc Dr.", null, "College Station", "TX", "USA", true)]
        [InlineData("123 Abc Road", null, "Bryan", "Texas", "USA", true)]
        [InlineData("123", null, "College Station", "Texas", "USA", false)]
        [InlineData("123 Abc", null, "CS", "Texas", "USA", false)]
        [InlineData("123 Abc Dr.", null, "College Station", "", "USA", false)]
        public void Customer_Address_Validattion_test(string line1, string line2, string city, string state, string country, bool valid)
        {
            Address mockAddress = new Address(line1, line2, city, state, country);
            Assert.Equal(mockAddress.Valid, valid);
        }
    }
}
