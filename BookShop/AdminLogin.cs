using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UPassTb.Text == "password")
            {
                Books obj = new Books();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("系统提示:密码错误，请先获得管理员权限!!!");
            }
        }

        private void RebackBtn_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
