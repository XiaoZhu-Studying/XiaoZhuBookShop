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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\OneDrive\文档\XiaoZhuBookShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        //新建一个全局的数据库对象，使用该对象操作数据库
        //SqlConnection对象使用了一个String类型参数的构造函数,
        //这个参数叫连接字符串，是获取或设置用于打开数据库的字符串

        String currentTime = DateTime.Now.ToString("D");

        private void DashBoard_Load(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(BQty) from BookTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BookStockLbl.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(Amount) from OrderTbl", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            SumAmountLbl.Text = dt1.Rows[0][0].ToString();
            Con.Close();

            SqlDataAdapter sda2 = new SqlDataAdapter("select Count(*) from UserTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UserTotalLbl.Text = dt2.Rows[0][0].ToString();
            Con.Close();

            SqlDataAdapter sda3 = new SqlDataAdapter("select sum(Amount) from OrderTbl where Time = '"+ currentTime + "' ", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            DayAmountLbl.Text = dt3.Rows[0][0].ToString();
            Con.Close();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void ExitBtn2_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void UsersBtn_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
            this.Hide();
        }

        private void UsersBtn2_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
            this.Hide();
        }

        private void BooksBtn_Click(object sender, EventArgs e)
        {
            Books obj = new Books();
            obj.Show();
            this.Hide();
        }

        private void BooksBtn2_Click(object sender, EventArgs e)
        {
            Books obj = new Books();
            obj.Show();
            this.Hide();
        }

        private void ExitBtn0_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
