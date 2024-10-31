using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PhoneShopManager.model;
using PhoneShopManager.dao;

namespace PhoneShopManager.view
{
    public partial class EditProductFrm : Form
    {
        private DAO dao;

        public EditProductFrm()
        {
            InitializeComponent();
            dao = new DAO();
            // Không gọi LoadData ở đây, để không hiển thị toàn bộ sản phẩm
        }

       

        private void ClearTextBoxes()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtImage.Clear();
            txtDes.Clear();
            txtBrand.Clear();
            txtStock.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                txtName.Text = row.Cells["ProductName"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtImage.Text = row.Cells["ImageURL"].Value.ToString();
                txtDes.Text = row.Cells["Description"].Value.ToString();
                txtBrand.Text = row.Cells["Brand"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string keyword = txtkey.Text.Trim(); 
            DataTable searchResults = dao.SearchProducts(keyword);

            if (searchResults.Rows.Count > 0)
            {
                dgvProduct.DataSource = searchResults;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào.");
                dgvProduct.DataSource = null; 
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Cập nhật sản phẩm vào cơ sở dữ liệu
            if (dgvProduct.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells["ProductID"].Value); // Lấy ID sản phẩm từ hàng đã chọn
                string productName = txtName.Text.Trim();

                // Kiểm tra giá trị số và xử lý lỗi
                if (!double.TryParse(txtPrice.Text.Trim(), out double price))
                {
                    MessageBox.Show("Giá không hợp lệ. Vui lòng nhập lại.");
                    return;
                }

                if (!int.TryParse(txtStock.Text.Trim(), out int stock))
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập lại.");
                    return;
                }

                string brand = txtBrand.Text.Trim();
                string description = txtDes.Text.Trim();
                string imageUrl = txtImage.Text.Trim();

                Product product = new Product
                {
                    ProductID = productId,
                    ProductName = productName,
                    Price = price,
                    Stock = stock,
                    Brand = brand,
                    Description = description,
                    ImageURL = imageUrl
                };

                // Cập nhật sản phẩm
                bool success = dao.UpdateProduct(product); // Cần thêm phương thức UpdateProduct vào DAO
                if (success)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                    ClearTextBoxes(); // Dọn dẹp các ô nhập liệu
                    btnSearch_Click_1(sender, e); // Thực hiện tìm kiếm lại để cập nhật danh sách
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để cập nhật.");
            }
        }
    }
}
