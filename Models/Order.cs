using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_LinQ.models
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int TotalAmount { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;

        public Customer customer { get; set; } = null!;
       public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    }
}
