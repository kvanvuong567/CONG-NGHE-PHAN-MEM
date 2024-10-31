using System;
using System.Windows.Forms;
using PhoneShopManager.dao;
using PhoneShopManager.model;

namespace PhoneShopManager.view
{
    public partial class CancelOrderFrm : Form
    {
        private DAO dao;

        public CancelOrderFrm()
        {
            InitializeComponent();
            dao = new DAO();
            LoadOrders();
        }

        private void LoadOrders()
        {
            dgvOrders.DataSource = dao.GetAllOrders();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells[0].Value);
                if (dao.DeleteOrder(orderId)) // Giả sử bạn đã có phương thức DeleteOrder trong lớp DAO
                {
                    MessageBox.Show("Đơn hàng đã được hủy thành công.");
                    LoadOrders(); // Cập nhật lại danh sách đơn hàng
                }
                else
                {
                    MessageBox.Show("Hủy đơn hàng không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để hủy.");
            }
        }

      

        private void btnCLose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
