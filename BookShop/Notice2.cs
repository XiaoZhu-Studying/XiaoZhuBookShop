using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BookShop.Order;

namespace BookShop
{
    public partial class Notice2 : Form
    {
        public Notice2()
        {
            InitializeComponent();
        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Order.order.AllDeleteBtn_Click(sender, e);
            Order.order.Hide();
            Login obj = new Login();
            obj.Show();
        }

        private void FalseBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
