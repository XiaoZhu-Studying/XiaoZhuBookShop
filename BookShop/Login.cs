using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\OneDrive\文档\XiaoZhuBookShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        //新建一个全局的数据库对象，使用该对象操作数据库
        //SqlConnection对象使用了一个String类型参数的构造函数,
        //这个参数叫连接字符串，是获取或设置用于打开数据库的字符串

        private void ExitTb_Click(object sender, EventArgs e)
        {
            Application.Exit();//窗口的关闭功能
        }

        public static string UserName = "";//全局可用的字符串变量

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UName='" + UNameTb.Text + "' and UPassword='" + UPassTb.Text + "'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")//输入的用户名和密码是系统用户
            {
                UserName = UNameTb.Text;
                Order obj = new Order();
                obj.Show();
                this.Hide();
                Con.Close();
            }
            else
            {
                MessageBox.Show("系统提示:用户名或密码错误!!!");
            }
            Con.Close();
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }

        private void RegisterLbl_Click(object sender, EventArgs e)
        {
            Register obj = new Register();
            obj.Show();
            this.Hide();
        }

        private void ForgetLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请添加客服微信:XiaoZhuShuDian，并发送'111'哦!");
        }
    }
}
