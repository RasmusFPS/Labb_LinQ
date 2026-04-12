using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_LinQ
{
    internal class Menu
    {
        public void StartMenu()
        {
            Info info = new Info();
            bool running = true;
            Console.WriteLine("-- Welcome --");
            while (running)
            {
                Console.WriteLine("1. Get all Electronics and sort after price");
                Console.WriteLine("2. Show all Suppliers with less than 10 units");
                Console.WriteLine("3. Total monthly revenue from orders");
                Console.WriteLine("4. Show the top 3 most sold items");
                Console.WriteLine("5. Show all Catagories and Products");
                Console.WriteLine("6. Get all orders with Customer Data where the total is above 1000kr");
                Console.WriteLine("7. EXIT");

                string answer = Console.ReadLine();
                Console.Clear();

                switch(answer)
                {
                    case "1":
                        info.GetElectronics();
                        waitAndClear();
                        break;
                    case "2":
                        info.GetSuppliers();
                        waitAndClear();
                        break;
                    case "3":
                        info.MonthlyRev();
                        waitAndClear();
                        break;
                    case "4":
                        info.MostSoldProd();
                        waitAndClear();
                        break;
                    case "5":
                        info.ShowCatagories();
                        waitAndClear();
                        break;
                    case "6":
                        info.ExpensiveOrders();
                        waitAndClear();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("INCORRECT INPUT");
                        break;
                }
            }
        }

        private void waitAndClear()
        {
            Console.WriteLine("\nPress AnyKey to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
