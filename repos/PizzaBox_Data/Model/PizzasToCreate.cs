using System;
using System.Collections.Generic;

namespace PizzaBox_Data.Model
{
    public partial class PizzasToCreate
    {





        public string UserId { get; set; }
        public string Size { get; set; }
        public string Crust { get; set; }
        public string Topping1 { get; set; }
        public string Topping2 { get; set; }
        public string Topping3 { get; set; }
        public string Topping4 { get; set; }
        public string Topping5 { get; set; }
        public int? StoreId { get; set; }
        public int Orderid { get; set; }

        public virtual StoreLocation Store { get; set; }
    }
}
