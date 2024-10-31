using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PhoneShopManager.model;

namespace PhoneShopManager.dao
{
    public class DAO
    {
        private string connectionString = @"Server=DESKTOP-GVDQ046;Database=PhoneShopDB;User ID=sa;Password=1111;";

        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string query = "SELECT * FROM Product";

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = reader.GetInt32(0), 
                        ProductName = reader.GetString(1), 
                        Price = reader.GetDouble(2),
                        Stock = reader.GetInt32(3), 
                        Brand = reader.GetString(4),
                        Description = reader.GetString(5), 
                        ImageURL = reader.GetString(6) 
                    });
                }
            }
            return products; // Trả về danh sách sản phẩm
        }

        // Lấy danh sách sản phẩm từ cơ sở dữ liệu
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            string query = "SELECT * FROM Product";

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price = reader.GetDouble(2),
                        Stock = reader.GetInt32(3),
                        Brand = reader.GetString(4),
                        Description = reader.GetString(5),
                        ImageURL = reader.GetString(6)
                    });
                }
            }
            return products;
        }

        public bool AddProduct(Product product)
        {
            string query = "INSERT INTO Product (ProductName, Price, Stock, Brand, Description, ImageURL) VALUES (@ProductName, @Price, @Stock, @Brand, @Description, @ImageURL)";

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Stock", product.Stock);
                cmd.Parameters.AddWithValue("@Brand", product.Brand);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@ImageURL", product.ImageURL);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu thêm thành công
            }
        }

        public DataTable SearchProducts(string keyword)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Chỉnh sửa tên bảng ở đây
                string query = "SELECT * FROM Product WHERE ProductName LIKE @keyword OR Description LIKE @keyword OR Brand LIKE @keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }



        public bool DeleteProduct(int productId)
        {
            // Biến để lưu kết quả thực hiện
            bool isDeleted = false;

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Product WHERE ProductID = @productId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productId", productId); // Thêm tham số

                    // Thực thi câu lệnh xóa
                    int rowsAffected = cmd.ExecuteNonQuery(); // Trả về số hàng bị ảnh hưởng

                    // Nếu có hàng bị xóa thì trả về true
                    if (rowsAffected > 0)
                    {
                        isDeleted = true;
                    }
                }
            }

            return isDeleted; // Trả về kết quả
        }

        public bool UpdateProduct(Product product)
        {
            string query = "UPDATE Product SET ProductName = @ProductName, Price = @Price, Stock = @Stock, Brand = @Brand, Description = @Description, ImageURL = @ImageURL WHERE ProductID = @ProductID";

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Stock", product.Stock);
                cmd.Parameters.AddWithValue("@Brand", product.Brand);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@ImageURL", product.ImageURL);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu cập nhật thành công
            }
        }

        public Product GetProductById(int productId)
        {
            Product product = null;
            string query = "SELECT * FROM Product WHERE ProductID = @ProductID";

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = new Product
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price = reader.GetDouble(2),
                        Stock = reader.GetInt32(3),
                        Brand = reader.GetString(4),
                        Description = reader.GetString(5),
                        ImageURL = reader.GetString(6)
                    };
                }
            }
            return product; // Trả về sản phẩm nếu tìm thấy, hoặc null nếu không tìm thấy
        }

        public bool AddOrder(Order order)
        {
            string query = "INSERT INTO [Order] (CustomerName, ProductID, Quantity, OrderDate, TotalPrice) VALUES (@CustomerName, @ProductID, @Quantity, @OrderDate, @TotalPrice)";

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                cmd.Parameters.AddWithValue("@ProductID", order.ProductID);
                cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; 
            }
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            string query = "SELECT * FROM [Order]";

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        OrderID = reader.GetInt32(0),
                        CustomerName = reader.GetString(1),
                        ProductID = reader.GetInt32(2),
                        Quantity = reader.GetInt32(3),
                        OrderDate = reader.GetDateTime(4),
                        TotalPrice = reader.GetDouble(5)
                    });
                }
            }
            return orders; 
        }

        public bool DeleteOrder(int orderId)
        {
            bool isDeleted = false;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM [Order] WHERE OrderID = @orderId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    isDeleted = rowsAffected > 0; 
                }
            }
            return isDeleted; 
        }

        public string GetConnectionString()
        {
            return connectionString;
        }

    }
}
