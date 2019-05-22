using System;
using System.Collections;
using PizzaBox_Data.Model;
using PizzaBox_Data;
using System.Collections.Generic;
namespace PizzaBox_Domain
{





    public class PizzaOrder
    {
        //Stack<P> holding= new Stack<P>;
        static string crust;
        static string size;
        List<string> toppings = new List<string>();
        public PizzaOrder()
        {
            //Pizza<string, string> CurrentItem = new Pizza<string, string>();
            //List<string> toppings = new List<string>();
        }

        public string AddTopping(int c)
        {

            switch (c)
            {
                case 1:
                    return "ham";
                case 2:
                    return "Pinapple";

                case 3:
                    return "Peperoni";

                case 4:
                    return "Bacon";

                case 5:
                    return "Mushroom";

                case 6:
                    return "anchovies";

                case 7:
                    return "";

            }
            return "";
        }
        ////int toppingLimit = 5;//max limit on toppings
        ////Console.WriteLine("Would you like ham and pinapple pizza?y/n");
        ////string temp = Console.ReadLine();
        ////if (temp == "y")
        ////{

        ////    //add ham and pinapple
        ////    toppings.Add("ham");
        ////    toppings.Add("pinapple");
        ////}
        ////else
        ////{
        ////    Console.WriteLine("What Toppings would you like?");
        ////    for (int i = 1; i < toppingLimit; ++i)
        ////    {
        ////        Console.WriteLine("Type in the coresponding number...");
        ////        Console.WriteLine("1.Ham");
        ////        Console.WriteLine("2.Pinapple");
        ////        Console.WriteLine("3.Peperoni");
        ////        Console.WriteLine("4.Bacon");
        ////        Console.WriteLine("5.Mushroom");
        ////        Console.WriteLine("6.anchovies");
        ////        Console.WriteLine("7. to exit toppings");
        ////        try
        ////        {
        ////            int c = Console.Read();
        ////            switch (c)
        ////            {
        ////                case 1:
        ////                    toppings.Add("ham");
        ////                    break;
        ////                case 2:
        ////                    toppings.Add("Pinapple");
        ////                    break;
        ////                case 3:
        ////                    toppings.Add("Peperoni");
        ////                    break;
        ////                case 4:
        ////                    toppings.Add("Bacon");
        ////                    break;
        ////                case 5:
        ////                    toppings.Add("Mushroom");
        ////                    break;
        ////                case 6:
        ////                    toppings.Add("anchovies");
        ////                    break;
        ////                case 7:

        ////                    i = toppingLimit + 1;
        ////                    break;



        ////                default:
        ////                    Console.WriteLine("Please enter a number between 1 and 7.");
        ////                    break;


        ////            }
        ////        }
        ////        catch (System.Exception)//need to catch char not numbers
        ////        {
        ////            Console.WriteLine("Not a number.");
        ////        }










        ////    }

        ////}
        //////print list and put int a pizza
        ////Console.WriteLine($"so a {size} {crust} with...");
        ////foreach (string i in toppings)
        ////{
        ////    Console.WriteLine(i + ", ");
        ////}
        ////String yesOrNo = "";
        ////Console.WriteLine("is that correct?y/n");
        ////Console.ReadLine();
        ////if (yesOrNo == "y")
        ////{
        ////    Pizza<String, String> goodPizza = new Pizza<String, List<String>>(size, crust, toppings);
        ////    PizzaStack.Push(goodPizza);
        ////}
        ////else
        ////{
        ////    addTopping();
        ////}


        public Boolean pizzaAdd<S, C, T>(string id, S size, C crust, List<T> top, int storId)
        {
            var newT = top.ToArray();
            Crud db = new Crud();
            Pizzahistory temp = new Pizzahistory(id, size.ToString(), crust.ToString(), toppings, storId);

            db.PizzaAdd(temp);

            return true;
        }


        public decimal Cost(string size, int toppingsTotal)
        {

            int sizeCost = 5;
            if (size == "medium")
            {
                sizeCost = 7;
                return (sizeCost + (toppingsTotal) * .75m);

            }
            else if (size == "large")
            {
                sizeCost = 10;
                return (sizeCost + (toppingsTotal) * 1.75m);

            }
            else
            {

                return (sizeCost + (toppingsTotal) * .25m);
            }

        }
        void Createorder()
        {
            String temp;
            Boolean thenend = false;
            decimal totalPrice = 0;
            int orderlimit = 5000;
            int pizzaTotal = 0;
            do
            {
                pizzaTotal = pizzaTotal + 1;
                //totalPrice = totalPrice + buildPizza();
                if (totalPrice >= orderlimit || pizzaTotal >= 100)
                {
                    Console.WriteLine("your order is too large or too expensive.");
                    break;
                }
                Console.WriteLine("Do wish to add more?y/n");
                temp = Console.ReadLine();
                if (temp == "n")
                {

                    thenend = true;
                }


                else
                {

                }
            } while (thenend == false);




        }


    }
    public class History
    {
        public History()
        {
            
        }
        public List<Pizzahistory> getHistory(string UserId)
        {
            Crud db = new Crud();
            
            return db.FindLastPizzas(UserId);
        }
    }
    public class Pizzastore
    {
        public Inventory inven(int storeid)
        {
            Crud db = new Crud();
            return db.checkInventory(storeid);
        }
        

    }

    public class NewUser<U, F, L, St, C, S, Z, P>
    {


        public NewUser(U userID, F firstName, L lastName, St street, S State, Z Zip, P Passcode, C City)//create new user and address of user.
        {
            Customers temp = new Customers(userID.ToString(), firstName.ToString(), lastName.ToString(), Passcode.ToString());
            Console.WriteLine("Customerin");
            CustomerAddress address = new CustomerAddress(userID.ToString(),street.ToString(),State.ToString(),Zip.ToString(),City.ToString());
            Crud db = new Crud();
            Console.WriteLine("new crud");
            db.AddCustomers(temp);
            Console.WriteLine("Customer");
            db.AddAddress(address);
            Console.WriteLine($"Weclome {userID}.");

        }


    }
     public class Login<U, P>//returning users
    {
        public Login(U id, P code)
        {
            Crud db = new Crud();
            Customers temp = db.GetCustomers(id.ToString());
            if (temp.Password != code.ToString())
            {
                Console.WriteLine("User ID or password was incorrect, please try again");


            }
            else
            {

                ////


            }

        }



    }

    





}


