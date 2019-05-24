using PizzaBox_Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaBox_Data
{
    public class Crud 
    {


        #region customers
        public List<Customers> GetCustomers()
        {
            var customers = PizzaBoxIn.Instance.Customers.ToList();
            return customers;

        }
        public Customers GetCustomers(string userId)
        {

            var customers = PizzaBoxIn.Instance.Customers.Where<Customers>(c => c.UserId == userId).FirstOrDefault();
            return customers;

        }
        public void AddCustomers(Customers c)
        {
            PizzaBoxIn.Instance.Customers.Add(c);
            PizzaBoxIn.Instance.SaveChanges();
            Console.WriteLine("You now have an account with PizzaBox");
        }

        //public Customers findCustomers<L,T>(L LastName,T FirstName)
        //{
        //    var customers = PizzaBoxIn.Instance.Customers.Where<Customers>(c => c.Lastname == LastName.ToString() && c.Firstname==FirstName.ToString()).FirstOrDefault();
        //    return customers;

        //}
        #endregion customers
        #region Addresses
        public List<CustomerAddress> GetAddress()
        {
            var Address = PizzaBoxIn.Instance.CustomerAddress.ToList();
            return Address;
        }
        public void AddAddress(CustomerAddress c)
        {
            PizzaBoxIn.Instance.CustomerAddress.Add(c);
            PizzaBoxIn.Instance.SaveChanges();
            Console.WriteLine("Added your location to your account");
        }

        #endregion Addresses
        #region pizzaordering 

        public List<PizzasToCreate> GetPizza()
        {
            var pizzastocreate = PizzaBoxIn.Instance.PizzasToCreate.ToList();
            return pizzastocreate;

        }
        public void Padd(PizzasToCreate  p)
        {
            PizzaBoxIn.Instance.PizzasToCreate.Add(p);
            PizzaBoxIn.Instance.SaveChanges();

        }

        public void PizzaAdd(Pizzahistory p)
        {

            PizzaBoxIn.Instance.Pizzahistory.Add(p);
            PizzaBoxIn.Instance.SaveChanges();

        }

        public List<Pizzahistory> FindLastPizzas(string userId)
        {
            var history = PizzaBoxIn.Instance.Pizzahistory.Where<Pizzahistory>(c => c.UserId == userId).ToList();
            return history;

        }

        public Boolean compareDates(string userId, int time, int storeid)
        {///need to double check this one
            int cDate;
            var date = PizzaBoxIn.Instance.Pizzahistory.Where<Pizzahistory>(c => c.UserId == userId ).OrderByDescending(c => c.Orderdate).FirstOrDefault();
            cDate = DateTime.Compare((DateTime)date.Orderdate, DateTime.Now.AddHours(-24));

            if (cDate<0)
            {
                date = PizzaBoxIn.Instance.Pizzahistory.Where<Pizzahistory>(c => c.UserId == userId && c.StoreId == storeid).OrderByDescending(c => c.Orderdate).FirstOrDefault();

                cDate = DateTime.Compare((DateTime)date.Orderdate, DateTime.Now.AddHours(-2));
                if (cDate < 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return true;
            }
        }


        #endregion Pizzaordering

        #region storeinventory
        public Inventory checkInventory(int sId)
        {
            var inventoryTotal = PizzaBoxIn.Instance.Inventory.Where<Inventory>(c => c.StoreId == sId).FirstOrDefault();
            return inventoryTotal;
        }

 


        #endregion storyinventory

        StoreLocation getstore(int storeid)
        {
            var store = PizzaBoxIn.Instance.StoreLocation.Where<StoreLocation>(c => c.StoreId == storeid).FirstOrDefault();
            return store;
        }

    }





}

