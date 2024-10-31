using System;
using System.Windows.Forms;
using PhoneShopManager.dao;
using PhoneShopManager.model;

namespace PhoneShopManager.view
{
    public partial class AddProductFrm : Form
    {
        private DAO dao;

        public AddProductFrm()
        {
            InitializeComponent();
            dao = new DAO();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các trường nhập liệu
                string productName = txtName.Text.Trim();
                if (string.IsNullOrWhiteSpace(productName))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtPrice.Text, out double price) || price < 0)
                {
                    MessageBox.Show("Giá sản phẩm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
                {
                    MessageBox.Show("Số lượng sản phẩm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string brand = txtBrand.Text.Trim();
                string description = txtDes.Text.Trim();
                string imageUrl = txtImage.Text.Trim();

                // Tạo một sản phẩm mới
                Product newProduct = new Product
                {
                    ProductName = productName,
                    Price = price,
                    Stock = stock,
                    Brand = brand,
                    Description = description,
                    ImageURL = imageUrl
                };

                // Thêm sản phẩm vào cơ sở dữ liệu
                if (dao.AddProduct(newProduct))
                {
                    MessageBox.Show("Sản phẩm đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
