using System;
using PizzaBox_Data.Model;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox_Data
{
    public sealed class PizzaBoxIn
    {
        private static Pizzboxdb instance = null;
        private PizzaBoxIn()
        {

        }
        public static Pizzboxdb Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Pizzboxdb();
                    return instance;
                }
                else
                {
                    return instance;
                }
            }
        }
    }
}
