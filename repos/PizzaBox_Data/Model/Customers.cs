using System;
using System.Collections.Generic;

namespace PizzaBox_Data.Model
{
    public partial class Customers
    {
        public Customers()
        {
            }
        public Customers(string u, string Fn, string Ln, string code)
        {
            UserId = u;
            Firstname = Fn;
            Lastname = Ln;
            Accesslvl = 1;
            Password = code;


        }
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? Accesslvl { get; set; }
        public string Password { get; set; }
    }
}
