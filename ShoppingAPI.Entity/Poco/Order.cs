using ShoppingAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.Poco
{
    public class Order : AuditableEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int UserId { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
        public virtual User User { get; set; }
    }
}
