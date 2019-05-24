using System;
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

        //public static string crust;
        //public static string size=;
        List<string> toppings = new List<string>();
        public orderPizza()
        {

        }

        public decimal CreationUI(string userName, int storeId)
        {
            string crust = "";
            string size = "";
            PizzaOrder gettingPizza = new PizzaOrder();
            Crud db = new Crud();
            int toppingLimit = 5;//max limit on toppings
            Boolean contin = false;
            while (contin == false)
            {
                Console.WriteLine("what size do you wish to have?");
                size = Console.ReadLine();
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
            }
                Console.WriteLine("What crust do you wish?(Pan,regular,thin)");
                crust = Console.ReadLine();
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
                    string topping1 = "";
                    string topping2 = "";
                    string topping3 = "";
                    string topping4 = "";
                    string topping5 = "";
                    Console.WriteLine("Would you like ham and pinapple pizza?y/n");
                    string temp = Console.ReadLine();
                    if (temp == "y")
                    {

                        //add ham and pinapple
                        topping1=("ham");
                        topping2=("pinapple");


                        bool isItdone = gettingPizza.pizzaAdd<string,string,string>(userName, size, crust, topping1, topping2, topping3, topping4, topping5, storeId);
                        return gettingPizza.Cost(size, 2);

                    }
                    else
                    {

                        Console.WriteLine("What pizza size do you wish order?");
                        size = Console.ReadLine();


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
                        decimal price=0;
                        price = gettingPizza.Cost(size, toppings.Count);
                        topping1 = toppings[0];
                        topping2 = toppings[1];
                        topping3 = toppings[2];
                        topping4 = toppings[3];
                        topping5 = toppings[4];
                        gettingPizza.pizzaAdd<string, string, string>(userName, size, crust, topping1, topping2, topping3, topping4, topping5, storeId);
                        //return cost
                        return price;


                    }
                }
            return 0;
            
            
        }

        public void totalOrder(string userName, int storeId)
        {
            decimal totalCost = 0;
            for (int i = 1; i < 100; ++i)
            {

                if (totalCost <= 5000 - 20)
                {
                    
                    totalCost = totalCost + CreationUI(userName, storeId);
                    Console.WriteLine($"Total is now ${totalCost}. Would you like to order one more?y/n");
                    string temp = Console.ReadLine();
                    if (temp == "y")
                    {
                        break;
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

        public Admin(string user, int storeid)
        {
            string User = user;
        }
        public void AdminUI(string user, int storeid)
        {
            Console.WriteLine($"Welcome admin {user}.");
            Console.WriteLine("1.Look at store inventory");
            string adinv = "1";
            adinv = Console.ReadLine();
            if (adinv == "1")
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
    public class MainMenu
    {
        
        public MainMenu()
        { }
        public int chooseStores()
        {
            int store = 0;
            Console.WriteLine("Choose which store typing coresponding number.");
            Console.WriteLine("1.1901 Center St.");
            Console.WriteLine("2. 24B  Baker St.");
            Console.WriteLine("3. 100000 Houston Ave");
            store = Convert.ToInt32( Console.ReadLine());

            return store;
        }
        public void mainmenu(string userid, int storeId)
        {
            string c = "";
            bool leave = false;
            while (leave == false)
            {
                Console.WriteLine("-Main Menu-");
                Console.WriteLine("1. Order Pizza");
                Console.WriteLine("2. Order History");
                Console.WriteLine("3.Admin");
                Console.WriteLine("4.Exit");
                c = Console.ReadLine();


                if (c == "1")
                {
                    orderPizza Order = new orderPizza();
                    //Order.CreationUI(userid, storeId);
                    Order.totalOrder(userid, storeId);

                }

                else if (c == "2")
                {
                    History lastPizza = new History();
                    var temp = lastPizza.getHistory(userid);
                    try
                    {

                        foreach (var i in temp.ToArray())
                        {
                            Console.WriteLine($"a{i.Size} {i.Crust} crust Pizza with");
                            Console.WriteLine(i.Topping1);
                            Console.WriteLine(i.Topping2);
                            Console.WriteLine(i.Topping3);
                            Console.WriteLine(i.Topping4);
                            Console.WriteLine(i.Topping5);

                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (c == "3")
                {

                    Admin usingAdmin = new Admin(userid, storeId);
                    usingAdmin.AdminUI(userid, storeId);
                }
                else if (c == "4")
                {
                    leave = true;
                }

                else
                {
                    Console.WriteLine("Please type one of the numbers.");
                }


            }
        }
    }



    class Program
    {
        public static string getUsername()
        {
            UserLogin starting = new UserLogin();
            string userid = starting.firstUI();
            return userid;

        }
        static void Main(string[] args)
        {
            UserLogin starting = new UserLogin();

            try
            {

                string user = getUsername();

                orderPizza temp = new orderPizza();
                MainMenu mainMenu = new MainMenu();
                int store = mainMenu.chooseStores();
                mainMenu.mainmenu(user, store);


            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine("error");
                throw;

            }



        }
    }
}


