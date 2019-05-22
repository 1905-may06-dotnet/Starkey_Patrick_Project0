using PizzaBox_Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox_Data
{
    public interface ICrud
    {
        List<Customers> GetCustomers();
        Customers GetCustomers(string userId);
        void AddCustomers(Customers c);
        List<CustomerAddress> GetAddress();
        void AddAddress(CustomerAddress c);
        void PizzaAdd(PizzasToCreate p);


    }
}
