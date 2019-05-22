using System;
using System.Collections.Generic;

namespace PizzaBox_Data.Model
{
    public partial class StoreLocation
    {
        public StoreLocation()
        {
            Pizzahistory = new HashSet<Pizzahistory>();
            PizzasToCreate = new HashSet<PizzasToCreate>();
        }

        public int StoreId { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public virtual ICollection<Pizzahistory> Pizzahistory { get; set; }
        public virtual ICollection<PizzasToCreate> PizzasToCreate { get; set; }
    }
}
