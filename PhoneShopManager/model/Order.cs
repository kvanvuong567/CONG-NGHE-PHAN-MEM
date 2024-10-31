using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShopManager.model
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }

        public Order(int orderId, string customerName, int productId, int quantity, DateTime orderDate, double totalPrice)
        {
            OrderID = orderId;
            CustomerName = customerName;
            ProductID = productId;
            Quantity = quantity;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
        }

        // Phương thức khởi tạo mặc định
        public Order() { }
    }
}

