using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneShopManager.view
{
    public partial class ManagerProductFrm : Form
    {
        public ManagerProductFrm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProductFrm addProductFrm = new AddProductFrm();
            addProductFrm.FormClosed += (s, args) => this.Show();
            this.Hide();

            addProductFrm.Show();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditProductFrm editProductFrm = new EditProductFrm();
            editProductFrm.FormClosed += (s, args) => this.Show();
            this.Hide();

            editProductFrm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DelProductFrm delProductFrm = new DelProductFrm();
            delProductFrm.FormClosed += (s, args) => this.Show();
            this.Hide(); delProductFrm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
