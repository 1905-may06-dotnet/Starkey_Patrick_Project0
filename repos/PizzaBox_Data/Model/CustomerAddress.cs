using System;
using System.Collections.Generic;

namespace PizzaBox_Data.Model
{
    public partial class CustomerAddress
    {
        public CustomerAddress()
        {
            Pizzahistory = new HashSet<Pizzahistory>();
        }

        public CustomerAddress(string id,string st, string state, string zip, string city)
        {
            
            UserId = id;
            Street = st;
            State = state;
            ZipCode = zip;
            City = city;
        }

        public string UserId { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public virtual ICollection<Pizzahistory> Pizzahistory { get; set; }
    }
}
