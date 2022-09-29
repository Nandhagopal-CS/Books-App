using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public interface IOrder
    {
        List<Order> GetAllOrder();
        Order AddOrder(Order order);

        int GetOrderPrice(Order order);

        void StatusOrder(int orderId,string status);
        
    }
}
