using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase.OOP
{
    public class Address
    {
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public bool Valid { get; set; }

        public Address()
        {

        }

        public Address(string line1, string line2, string city, string state, string country)
        {
            this.FirstLine = line1;
            this.SecondLine = line2;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.Validate();
        }

        public void SetFirstLine(string line)
        {
            this.FirstLine = line;
            this.Validate();
        }

        public void SetSecondLine(string line)
        {
            this.SecondLine = line;
            this.Validate();
        }

        public void SetCity(string city)
        {
            this.City = city;
            this.Validate();
        }


        public void SetState(string state)
        {
            this.State = state;
            this.Validate();
        }


        public void SetCountry(string country)
        {
            this.Country = country;
            this.Validate();
        }

        private void Validate()
        {
            if (this.FirstLine == null || this.FirstLine.Length < 5)
            {
                this.Valid = false;
                return;
            }

            if (this.City == null || this.City.Length < 3)
            {
                this.Valid = false;
                return;
            }


            if (this.State == null || this.State.Length < 2)
            {
                this.Valid = false;
                return;
            }

            this.Valid = true;

        }

    }
}
