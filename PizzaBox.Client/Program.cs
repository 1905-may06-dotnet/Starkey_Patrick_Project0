﻿using System;
using System.Collections.Generic;
using PizzaBox_Data.Model;
using PizzaBox_Domain;
using PizzaBox_Data;
namespace PizzaBox.Client
{
    
    internal class UserLogin
    {
        public static string userName;
        string password;
        internal UserLogin()
        {

            //if user can view inventory

        }
        public string firstUI()
        {
            Console.WriteLine("Are you a new user?y/n");
            string green = Console.ReadLine();
            if (green == "y")
            {
                Console.WriteLine("first Name..");
                string fname = Console.ReadLine();
                Console.WriteLine("Last name");
                string lname = Console.ReadLine();

                Console.WriteLine("street");
                string street = Console.ReadLine();

                Console.WriteLine("City");
                string city = Console.ReadLine();

                Console.WriteLine("State");
                string state = Console.ReadLine();
                Console.WriteLine("zip code");
                string zipcode = Console.ReadLine();
                Console.WriteLine("password");
                string passcode = Console.ReadLine();
                Console.WriteLine("Username");
                string userName = Console.ReadLine();
                //needto create  customer class and address class
                NewUser<string, string, string, string, string, string, string, string> temp = new NewUser<string, string, string, string, string, string, string, string>(userName, fname, lname, street, state, zipcode, passcode, city);
                return userName;


                //
            }
            else
            {
                Console.WriteLine("Username");
                string userName = Console.ReadLine();
                Console.WriteLine("password");
                string passcode = Console.ReadLine();
                Login<string, string> temp2 = new Login<string, string>(userName, passcode);
                return userName;
            }
        }

    }
    public class orderPizza
    {

        public static string crust;
        public static string size;
        List<string> toppings = new List<string>();
        public orderPizza(string name,int storeId)
        {
            string userName = name;
            int storeid = storeId;
        }

        public decimal CreationUI(string userName, int storeId)
        {
            PizzaOrder gettingPizza = new PizzaOrder();
            Crud db = new Crud();
            int toppingLimit = 5;//max limit on toppings
            Boolean contin = false;
            while (contin == true)
            {
                if (size.ToLower() == "small")
                {

                    contin = true;
                }
                else if (size.ToLower() == "medium")
                {
                    contin = true;
                }
                else if (size.ToLower() == "large")
                {
                    contin = true;
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
                Console.WriteLine("What crust do you wish?(Pan,regular,thin)");
                string crust = Console.ReadLine();
                while (contin == true)
                {
                    if (size.ToLower() == "pan")
                    {
                        contin = true;

                        //Pizza
                    }
                    else if (size.ToLower() == "regular")
                    {
                        contin = true;
                    }
                    else if (size.ToLower() == "thin")
                    {
                        contin = true;
                    }
                    else
                    {
                        Console.WriteLine("please try again.");

                    }
                    Console.WriteLine("Would you like ham and pinapple pizza?y/n");
                    string temp = Console.ReadLine();
                    if (temp == "y")
                    {

                        //add ham and pinapple
                        toppings.Add("ham");
                        toppings.Add("pinapple");


                        bool isItdone = gettingPizza.pizzaAdd<string, string, string>(userName, size, crust, toppings, storeId);
                        return gettingPizza.Cost(size, 2);

                    }
                    else
                    {

                        Console.WriteLine("What pizza size do you wish order?");
                        string size = Console.ReadLine();


                        for (int i = 1; i < toppingLimit; i++)
                        {
                            ///got size and crust now toppings
                            Console.WriteLine("Type in the coresponding number...");
                            Console.WriteLine("1.Ham");
                            Console.WriteLine("2.Pinapple");
                            Console.WriteLine("3.Peperoni");
                            Console.WriteLine("4.Bacon");
                            Console.WriteLine("5.Mushroom");
                            Console.WriteLine("6.anchovies");
                            Console.WriteLine("7. to exit toppings");


                            int Toppingcode = Console.Read();
                            string top = gettingPizza.AddTopping(Toppingcode);
                            if (top != "")
                            {
                                toppings.Add(top);
                            }
                            else
                            {
                                i = toppingLimit + 1;
                                break;
                            }
                        }
                        ////printout confirm
                        Console.WriteLine($"You have a {size} pizza {crust} crust with...");
                        foreach (string i in toppings)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine("y/n");
                        decimal price;
                        price = gettingPizza.Cost(size, toppings.Count);
                        gettingPizza.pizzaAdd<string, string, string>(userName, size, crust, toppings, storeId);
                        //return cost
                        return price;


                    }
                }

            }
            return 0;
        }

        public void totalOrder(string userName, int storeId)
        {
            decimal totalCost = 0;
            for (int i=1;i<100;++i) {

                if (totalCost <= 5000 - 20)
                {
                    totalCost = totalCost + CreationUI(userName, storeId);
                    Console.WriteLine($"Total is now ${totalCost}. Would you like to order one more?y/n");
                    string temp = Console.ReadLine();
                    if (temp == "n")
                    {
                        i = 101;
                    }
                }
                else
                {
                    break;
                }
            }
        }

    }

    public class Admin
    {

        public Admin(string user,int storeid)
        {
            string User = user;
        }
        public void AdminUI(string user,int storeid)
        {
            Console.WriteLine($"Welcome admin {user}.");
            Console.WriteLine("1.Look at store inventory");
            int adinv=Console.Read();
            if (adinv==1)
            {
                //open inventory for that store
                var temp = inventory(storeid);
                Console.WriteLine($"{storeid}");
                Console.WriteLine($"Cheese:    {temp.Cheese}lbs");
                Console.WriteLine($"Ham:       {temp.Ham}lbs");
                Console.WriteLine($"Cheese:    {temp.Anchovies}lbs");
                Console.WriteLine($"Dough:     {temp.Dough}lbs");
                Console.WriteLine($"Peperoni:  {temp.Peperoni}lbs");
                Console.WriteLine($"Mushroom:  {temp.Mushroom}lbs");
                Console.WriteLine($"Bacon:     {temp.Bacon}lbs");
                Console.WriteLine($"Anchovies: {temp.Anchovies}lbs");
            }
            else
            {
                Console.WriteLine("Goodbye.");
            }

        }
        
        Inventory inventory(int storeid)
        {
            Pizzastore a = new Pizzastore();
            return a.inven(storeid);
            
        }

    }
    internal class MainMenu
    {
        MainMenu()
        { }
        int chooseStores()
        {
            Console.WriteLine("Choose which store typing coresponding number.");
            Console.WriteLine("1.1901 Center");
            Console.WriteLine("2. 24B  Baker St.");
            Console.WriteLine("3. 100000 Houston Ave");
            int store = Console.Read();

            return store;
        }
        void mainmenu(string userid, int storeId)
        {
            bool leave = false;
            while (leave==false) {
                Console.WriteLine("-Main Menu-");
                Console.WriteLine("1. Order Pizza");
                Console.WriteLine("2. Order History");
                Console.WriteLine("3.Exit");
                Console.WriteLine("4.Admin");
                int c = Console.Read();
                switch (c)
                {
                    case 1:
                        orderPizza Order = new orderPizza(userid, storeId);
                        Order.totalOrder(userid, storeId);
                        break;
                    case 2:
                        History lastPizza = new History();
                        lastPizza.getHistory(userid);
                        break;
                    case 3:
                        Admin usingAdmin = new Admin(userid, storeId);
                        usingAdmin.AdminUI(userid, storeId);
                        break;
                    case 4:
                        leave = true;
                        break;

                    default:
                        Console.WriteLine("Please type one of the numbers.");
                        break;
                }
            }
        }
    }



        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    UserLogin starting = new UserLogin();
                    starting.firstUI();

                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("error");
                    throw;

                }



            }
        }
}
    
