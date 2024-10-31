using System;
using System.Data;
using System.Windows.Forms;
using PhoneShopManager.model; // Nhập không gian tên cho lớp Products
using PhoneShopManager.dao;   // Nhập không gian tên cho lớp DAO

namespace PhoneShopManager.view
{
    public partial class DelProductFrm : Form
    {
        private DAO dao;

        public DelProductFrm()
        {
            InitializeComponent();
            dao = new DAO(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string keyword = txtkey.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                DataTable dtProducts = dao.SearchProducts(keyword);
                dgvProduct.DataSource = dtProducts;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells["ProductID"].Value);
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    // Thực hiện xóa sản phẩm
                    bool isDeleted = dao.DeleteProduct(productId); 
                    if (isDeleted)
                    {
                        MessageBox.Show("Sản phẩm đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSearch.PerformClick(); // Cập nhật danh sách sản phẩm sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra trong quá trình xóa sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
