using System;
using System.Windows.Forms;
using PhoneShopManager.dao;
using PhoneShopManager.model;

namespace PhoneShopManager.view_order
{
    public partial class addOrderFrm : Form
    {
        private DAO dao = new DAO();
        private double productPrice = 0.0;

        public addOrderFrm()
        {
            InitializeComponent();
            LoadProducts();
            nbSoluong.ValueChanged += NbSoluong_ValueChanged;
        }

        // Hàm để nạp dữ liệu sản phẩm vào ComboBox
        private void LoadProducts()
        {
            var products = dao.GetAllProducts();
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "ID";
            cmbProduct.DataSource = products;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ form
                string customerName = txtNameCuster.Text;

                if (cmbProduct.SelectedItem != null)
                {
                    // Lấy đối tượng Product từ SelectedItem
                    Product selectedProduct = (Product)cmbProduct.SelectedItem;
                    int productId = selectedProduct.ProductID; // Lấy ID từ đối tượng Product
                    int quantity = (int)nbSoluong.Value;

                    // Tính tổng giá trị đơn hàng
                    double totalPrice = productPrice * quantity; // Tính tổng đơn hàng

                    // Tạo đơn hàng mới
                    Order order = new Order
                    {
                        CustomerName = customerName,
                        ProductID = productId,
                        Quantity = quantity,
                        OrderDate = dtDate.Value,
                        TotalPrice = totalPrice
                    };

                    // Thêm đơn hàng vào cơ sở dữ liệu
                    if (dao.AddOrder(order))
                    {
                        MessageBox.Show("Đơn hàng đã được tạo thành công!");
                        this.Close();
                    }
                    else
                    {
                        ShowErrorMessage("Có lỗi xảy ra khi tạo đơn hàng.");
                    }
                }
                else
                {
                    ShowErrorMessage("Vui lòng chọn sản phẩm.");
                }
            }
            catch (FormatException)
            {
                ShowErrorMessage("Vui lòng nhập đúng định dạng cho ID sản phẩm và số lượng.");
            }
            catch (InvalidCastException)
            {
                ShowErrorMessage("Đã xảy ra lỗi trong việc chuyển đổi kiểu dữ liệu. Vui lòng kiểm tra dữ liệu.");
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi: {ex.Message}");
            }
        }

        // Hàm để hiển thị thông báo lỗi
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem != null)
            {
                // Lấy đối tượng Product từ SelectedItem
                Product selectedProduct = (Product)cmbProduct.SelectedItem; // Lấy đối tượng sản phẩm
                productPrice = selectedProduct.Price; // Cập nhật giá sản phẩm
                UpdateTotalPrice(); // Cập nhật tổng đơn hàng
            }
        }

        private void NbSoluong_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice(); // Cập nhật tổng đơn hàng khi số lượng thay đổi
        }

        private void UpdateTotalPrice()
        {
            int quantity = (int)nbSoluong.Value;
            double totalPrice = productPrice * quantity; // Tính tổng giá
            txtTotal.Text = $"{totalPrice:C}"; // Hiển thị tổng đơn hàng
        }
    }
}
