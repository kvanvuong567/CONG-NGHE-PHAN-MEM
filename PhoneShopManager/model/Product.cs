namespace PhoneShopManager.model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; } // URL của ảnh sản phẩm

        public Product(int productId, string productName, double price, int stock, string brand, string description, string imageUrl)
        {
            ProductID = productId;
            ProductName = productName;
            Price = price;
            Stock = stock;
            Brand = brand;
            Description = description;
            ImageURL = imageUrl;
        }

        // Phương thức khởi tạo mặc định
        public Product() { }

        public override string ToString()
        {
            return ProductName; 
        }
    }
}
