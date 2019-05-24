using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox_Data.Model
{
    public partial class Pizzahistory
    {
        public Pizzahistory()
        {

        }
        public Pizzahistory(string id, string size, string crust, string t1, string t2, string t3, string t4, string t5, int storeid)
        {
            UserId = id;
            Size = size;
            Crust = crust;
            Topping1 = t1;
            Topping2 = t2;
            Topping3 = t3;
            Topping4 = t4;
            Topping5 = t5;
            Orderdate = DateTime.Now;
            StoreId = storeid;
            


        }
        //public Pizzahistory(string id,string size,string crust,List<string> toppings,int storeid)
        //{
        //    UserId = id;
        //    Size = size;
        //    Crust = crust;
        //    Topping1 = toppings.ElementAt(1).ToString();//System.ArgumentOutOfRangeException
        //    Topping2 = toppings.ElementAt(2).ToString();
        //    Topping3 = toppings.ElementAt(3).ToString();
        //    Topping4 = toppings.ElementAt(4).ToString();
        //    Topping5 = toppings.ElementAt(5).ToString();
        //    Orderdate = DateTime.Now;
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
        public DateTime? Orderdate { get; set; }
        public int? StoreId { get; set; }
        public int Orderid { get; set; }

        public virtual StoreLocation Store { get; set; }
        public virtual CustomerAddress User { get; set; }
    }
}
