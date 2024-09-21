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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\OneDrive\文档\XiaoZhuBookShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        //新建一个全局的数据库对象，使用该对象操作数据库
        //SqlConnection对象使用了一个String类型参数的构造函数,
        //这个参数叫连接字符串，是获取或设置用于打开数据库的字符串

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if(UNameTb.Text == "" || UPassTb.Text == "" || UPhoneTb.Text == "" || UPassTb.Text == "")
            {
                MessageBox.Show("系统提示:您输入的信息不完整!!!");
            }
            else 
            {
                Con.Open();
                string query1 = "select Count(*) from UserTbl where UName = '" + UNameTb.Text + "' ";
                SqlCommand cmd1 = new SqlCommand(query1, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                int Named = (int)cmd1.ExecuteScalar();//执行目标操作并更新数据库数据
                if (Named == 0)
                {
                    string query2 = "insert into UserTbl values('" + UNameTb.Text + "','" + UPhoneTb.Text + "','" + UAddTb.Text + "','" + UPassTb.Text + "')";
                    SqlCommand cmd2 = new SqlCommand(query2, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                    cmd2.ExecuteNonQuery();//执行目标操作并更新数据库数据
                    MessageBox.Show("系统提示:注册成功!!!");
                    Login obj = new Login();
                    obj.Show();
                    this.Hide();
                }
                else if (Named == 1)
                {
                    MessageBox.Show("系统提示:这个名字貌似被使用了哦!!!");
                }
                Con.Close();
            }
        }

        private void ExitTb_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
