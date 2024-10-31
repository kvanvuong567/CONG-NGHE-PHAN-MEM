using PhoneShopManager.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneShopManager.view_order
{
    public partial class OrderManagerFrm : Form
    {
        public OrderManagerFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addOrderFrm addOrderFrm = new addOrderFrm();
            addOrderFrm.FormClosed += (s, args) => this.Show();
            this.Hide();

            addOrderFrm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            CancelOrderFrm cancelOrderFrm = new CancelOrderFrm();
            cancelOrderFrm.FormClosed += (s, args) => this.Show();
            this.Hide();

            cancelOrderFrm.Show();
        }
    }
}
