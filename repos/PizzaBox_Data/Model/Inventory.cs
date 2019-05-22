using System;
using System.Collections.Generic;

namespace PizzaBox_Data.Model
{
    public partial class Inventory
    {
        public Inventory()
        {

        }
        public Inventory(int storeid, int t1, int t2, int t3, int t4, int t5,int cheese,int dough)
        {
            StoreId = storeid;
            Ham = t1;
            Bacon = t2;
            Mushroom = t3;
            Peperoni = t4;
            Anchovies = t5;
            Cheese = Cheese;
            Dough = dough;


        }
        public int StoreId { get; set; }
        public int? Ham { get; set; }
        public int? Bacon { get; set; }
        public int? Mushroom { get; set; }
        public int? Peperoni { get; set; }
        public int? Anchovies { get; set; }
        public int? Cheese { get; set; }
        public int? Dough { get; set; }
    }
}
