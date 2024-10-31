using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhoneShopManager.dao;
using PhoneShopManager.model;
using PhoneShopManager.view;
using PhoneShopManager.view_order;
using PhoneShopManager.view_report;

namespace PhoneShopManager
{
    public partial class ManagerHomeFrm : Form
    {
        private DAO productDAO = new DAO();
        private List<Product> allProducts;
        private static ManagerHomeFrm _instance;
        private List<Product> filteredProducts;

        public ManagerHomeFrm()
        {
            InitializeComponent();
            LoadProducts(); // Tải sản phẩm khi khởi động
            SetupSortingComboBox(); // Thiết lập ComboBox cho việc sắp xếp
        }

        // Tải danh sách sản phẩm từ cơ sở dữ liệu
        private void LoadProducts()
        {
            allProducts = productDAO.GetProducts();
            DisplayProductsInDataGridView(allProducts); 
        }


        // Hiển thị sản phẩm trên panel
        // Hiển thị sản phẩm trên panel
        private void DisplayProducts(List<Product> products)
        {
            pnlProduct.Controls.Clear(); // Xóa các điều khiển cũ trước khi thêm mới

            if (products.Count == 0)
            {
                // Hiển thị thông báo nếu không có sản phẩm
                Label noProductsLabel = new Label
                {
                    Text = "Không có sản phẩm nào để hiển thị.",
                    AutoSize = true,
                    Location = new System.Drawing.Point(10, 10)
                };
                pnlProduct.Controls.Add(noProductsLabel);
                return;
            }

            // Gọi phương thức RefreshProductPanels
            RefreshProductPanels(products);
        }

        // Phương thức mới để làm mới và sắp xếp các panel sản phẩm
        private void RefreshProductPanels(List<Product> products)
        {
            foreach (var product in products)
            {
                Panel pnlItem = CreateProductPanel(product);
                pnlProduct.Controls.Add(pnlItem); // Thêm panel sản phẩm vào pnlProduct
            }

            // Tự động điều chỉnh kích thước panel dựa vào số lượng sản phẩm
            int numberOfRows = (products.Count + 1) / 2; // Mỗi hàng có 2 sản phẩm
            pnlProduct.Height = Math.Max(284 * numberOfRows, 284); // Điều chỉnh chiều cao panel
        }


        // Tạo panel cho từng sản phẩm
        private Panel CreateProductPanel(Product product)
        {
            Panel pnlItem = new Panel
            {
                Size = new System.Drawing.Size(200, 284),
                Margin = new Padding(10)
            };

            PictureBox pbImage = new PictureBox
            {
                ImageLocation = product.ImageURL,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new System.Drawing.Size(167, 137),
                Location = new System.Drawing.Point(15, 27)
            };

            Label lbID = new Label { Text = "ID: " + product.ProductID, Location = new System.Drawing.Point(12, 11) };
            Label lbName = new Label { Text = "Name: " + product.ProductName, Location = new System.Drawing.Point(12, 167) };
            Label lbPrice = new Label { Text = "Price: " + product.Price.ToString("N0"), Location = new System.Drawing.Point(12, 189) };
            Label lbStock = new Label { Text = "Stock: " + product.Stock.ToString(), Location = new System.Drawing.Point(12, 212) };
            Label lbBrand = new Label { Text = "Brand: " + product.Brand, Location = new System.Drawing.Point(12, 236) };
            Label lbDescription = new Label { Text = "Description: " +  product.Description, Location = new System.Drawing.Point(12, 262), AutoSize = true };

            pnlItem.Controls.Add(pbImage);
            pnlItem.Controls.Add(lbID);
            pnlItem.Controls.Add(lbName);
            pnlItem.Controls.Add(lbPrice);
            pnlItem.Controls.Add(lbStock);
            pnlItem.Controls.Add(lbBrand);
            pnlItem.Controls.Add(lbDescription);

            return pnlItem;
        }

        // Tìm kiếm sản phẩm theo từ khóa
        private void SearchProducts(string keyword)
        {
            filteredProducts = allProducts.Where(p =>
            p.ProductName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
            p.Brand.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            Console.WriteLine($"Số sản phẩm tìm thấy: {filteredProducts.Count}"); // Kiểm tra số lượng sản phẩm tìm thấy

            // Hiển thị các sản phẩm tìm được
            DisplayProducts(filteredProducts);
        }

        private void DisplayProductsInDataGridView(List<Product> products)
        {
            dgvProduct.DataSource = null; 
            dgvProduct.DataSource = products;
            dgvProduct.ClearSelection();
        }
        private void SortProducts(string sortBy)
        {
            List<Product> sortedProducts;
            if (sortBy == "Price")
            {
                sortedProducts = allProducts.OrderBy(p => p.Price).ToList();
            }
            else if (sortBy == "Stock")
            {
                sortedProducts = allProducts.OrderBy(p => p.Stock).ToList();
            }
            else
            {
                sortedProducts = allProducts;
            }

            DisplayProductsInDataGridView(sortedProducts); // Hiển thị danh sách đã sắp xếp trong DataGridView
        }


        private void SetupSortingComboBox()
        {
            cmbType.Items.Add("Price");
            cmbType.Items.Add("Stock");
            cmbType.SelectedIndexChanged += (s, e) =>
            {
                SortProducts(cmbType.SelectedItem.ToString());
            };
        }

        private void QLSP_Click(object sender, EventArgs e)
        {
            ManagerProductFrm managerProductFrm = new ManagerProductFrm();
            managerProductFrm.FormClosed += (s, args) => this.Show(); // Khi form mới đóng, hiện lại form này
            this.Hide();
            managerProductFrm.Show();
        }
        public static void ShowForm()
        {
            if (_instance == null || _instance.IsDisposed) 
            {
                _instance = new ManagerHomeFrm();
                _instance.FormClosed += (s, args) => _instance = null; 
                _instance.Show(); 
            }
            else
            {
                _instance.BringToFront();
            }
        }
        private void home_Click(object sender, EventArgs e)
        {
            ShowForm(); 
            this.Hide(); 
        }

        private void Donhang_Click(object sender, EventArgs e)
        {
            OrderManagerFrm orderManagerFrm = new OrderManagerFrm();
            orderManagerFrm.FormClosed += (s, args) => this.Show(); 
            this.Hide();
            orderManagerFrm.Show();
        }

        private void Report_Click(object sender, EventArgs e)
        {
            ReportFrm reportFrm = new ReportFrm();
            reportFrm.FormClosed += (s, args) => this.Show(); 
            this.Hide();
            reportFrm.Show();
        }

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            string keyword = txtkey.Text.Trim();
            Console.WriteLine($"Từ khóa tìm kiếm: {keyword}"); 
            if (!string.IsNullOrEmpty(keyword))
            {
                SearchProducts(keyword); 
            }
            else
            {
                DisplayProducts(allProducts); 
            }
        }
        private void DisplayProductInPanel(Product product)
        {
            pnlItem.Controls.Clear(); 

            Panel pnlDetail = CreateProductPanel(product);
            pnlItem.Controls.Add(pnlDetail);
        }
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Product selectedProduct;

                // Kiểm tra danh sách filteredProducts có hợp lệ không
                if (filteredProducts != null && filteredProducts.Count > 0)
                {
                    
                    if (e.RowIndex < filteredProducts.Count)
                    {
                        selectedProduct = filteredProducts[e.RowIndex]; // Sử dụng danh sách đã tìm kiếm
                    }
                    else
                    {
                        return; // Nếu không hợp lệ, thoát khỏi phương thức
                    }
                }
                else
                {
                    
                    if (e.RowIndex < allProducts.Count)
                    {
                        selectedProduct = allProducts[e.RowIndex]; // Nếu không, sử dụng danh sách gốc
                    }
                    else
                    {
                        return; // Nếu không hợp lệ, thoát khỏi phương thức
                    }
                }

                DisplayProductInPanel(selectedProduct);
            }
        }
    }
}
