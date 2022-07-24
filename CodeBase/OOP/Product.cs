using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.OOP
{
    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public DateTime ProductionDate { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public Product()
        {

        }

        public bool Equals(Product? other)
        {
            if (other is null)
            {
                return false;
            }
            return this.Id == other.Id && this.Name == this.Name;
        }

        public bool DateDiff(Product other, out string Message)
        {
            Message = "";
            if (other is null)
            {
                Message = $"Object is null.";
                return true;
            }

            if(this.ProductionDate.ToShortDateString() != other.ProductionDate.ToShortDateString())
            {
                Message = $"Date diff: {this.ProductionDate} - {other.ProductionDate}";
                return true;
            }

            return false;
        }

        public override bool Equals(object? obj) => Equals(obj as Product);
        public override int GetHashCode() => (Id, Name).GetHashCode();
        public override string ToString() => Id.ToString();

    }
}
