using Labb_LinQ.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_LinQ
{
    internal class Info
    {
    
        public void GetElectronics()
        {
            using(var ctx = new EShopContext())
            {
                var Electronics = ctx.Products
                    .Where(p => p.Category.Name == "Electronics")
                    .OrderByDescending(p => p.Price)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price
                    });

                Console.WriteLine("--- Products in Electronics ---");
                foreach(var product in Electronics)
                {
                    Console.WriteLine($"{product.Name} {product.Price} KR");
                }
            }
        }

        public void GetSuppliers()
        {
            using(var ctx = new EShopContext())
            {
                var Suppliers = ctx.Products.Where(p => p.StockQuantity < 10).GroupBy(p => p.Supplier).Select(g => new
                {
                    g.Key.Name,
                    Products = g.Select(i => new
                    {
                        i.Name,
                        i.StockQuantity
                    })
                });

                Console.WriteLine("--- Suppliers with less than 10 stock ---");
                foreach(var supplier in Suppliers)
                {
                    Console.WriteLine($"\nSupplier: {supplier.Name}");
                    foreach(var product in supplier.Products)
                    {
                        Console.WriteLine($"product: {product.Name} | in storage: {product.StockQuantity}");
                    }
                }
            }
        }

        public void MonthlyRev()
        {
            using(var ctx = new EShopContext())
            {
                var totalrevLastmonth = ctx.Orders.Where(o => o.Date >= DateTime.Now.AddMonths(-1)).Sum(o => o.TotalAmount);

                Console.WriteLine($"Total Revenue this month: {totalrevLastmonth} KR");
            }
        }

        public void MostSoldProd()
        {
            using(var ctx = new EShopContext())
            {
                var MostSold = ctx.OrderDetails.GroupBy(o => o.Product.Name).Select(p => new
                {
                    ProductName = p.Key,
                    sold = p.Sum(o => o.Quantity)
                }).OrderByDescending(t => t.sold).Take(3);

                Console.WriteLine("--- 3 Most sold items ---");
                foreach(var m in MostSold)
                {
                    Console.WriteLine($"{m.ProductName} | {m.sold}");
                }
            }
        }

        public void ShowCatagories()
        {
            using(var ctx = new EShopContext())
            {
                var AllCatagories = ctx.Categories.Select(c => new
                {
                    c.Name,
                    Products = c.Products.Count()

                });

                Console.WriteLine("All Catagories and how many products in it");
                foreach( var c in AllCatagories)
                {
                    Console.WriteLine($"{c.Name} || amount of products in Catagory: {c.Products}");
                }
            }
        }

        public void ExpensiveOrders()
        {
            using(var ctx =new EShopContext())
            {
                var orders = ctx.Orders
                    .Where(o => o.TotalAmount >= 1000)
                    .Select(o => new
                {
                    o.customer.Name,
                    o.customer.Adress,
                    o.customer.Phone,
                    o.customer.Email,
                    o.Status,
                    o.Date,
                    o.TotalAmount,
                    prods = o.OrderDetails.Select(od => new
                    {
                        od.Product.Name,
                        od.Quantity,
                        od.UnitPrice
                    })
                });

                foreach(var o in orders)
                {
                    Console.WriteLine($"Customer: {o.Name}");
                    Console.WriteLine($"Address: {o.Adress}");
                    Console.WriteLine($"Email and PhoneNumber: {o.Email} | {o.Phone}");
                    Console.WriteLine($"Total sum: {o.TotalAmount}KR");
                    Console.WriteLine($"orderStatus: {o.Status} | Order Date {o.Date:yyyy:MM:dd}");
                    Console.WriteLine($"Products:");
                    foreach(var prods in o.prods)
                    {
                        Console.WriteLine($"{prods.Quantity} | {prods.Name} | {prods.UnitPrice}KR");
                    }
                    Console.WriteLine("");
                }
            }
        }
    }
}
