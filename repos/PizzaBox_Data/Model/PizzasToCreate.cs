using System;
using System.Collections.Generic;

namespace PizzaBox_Data.Model
{
    public partial class PizzasToCreate
    {

        //public PizzasToCreate(string id, string size, string crust, string t1, string t2, string t3, string t4, string t5, int storeid)
        //{
        //    UserId = id;
        //    Size = size;
        //    Crust = crust;
        //    Topping1 = t1;
        //    Topping2 = t2;
        //    Topping3 = t3;
        //    Topping4 = t4;
        //    Topping5 = t5;
        //    //Orderdate = DateTime.Now;
        //    StoreId = storeid;



        //}



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
