using Labb_LinQ.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    }
}
