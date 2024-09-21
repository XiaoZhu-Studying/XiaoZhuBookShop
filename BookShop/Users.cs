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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            Populate();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\OneDrive\文档\XiaoZhuBookShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        //新建一个全局的数据库对象，使用该对象操作数据库
        //SqlConnection对象使用了一个String类型参数的构造函数,
        //这个参数叫连接字符串，是获取或设置用于打开数据库的字符串

        private void Populate()
        {
            Con.Open();
            string query = "select * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//创建数据库的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//SqlDataAdapter通常与SqlCommandBuilder配合使用，这样的组合可以用来批量处理数据库数据
            var da = new DataSet();//虚拟数据库，可以把dataset当作内存中的数据库表，然后将数据存储到虚拟表中
            sda.Fill(da);
            UserDGV.DataSource = da.Tables[0];
            Con.Close();
            UserDGV.ClearSelection();
        }
        //通过查询数据库，将特定的信息显示在数据网格中

        private void Reset()
        {
            UnameTb.Text = "";
            PhoneTb.Text = "";
            AddTb.Text = "";
            PassTb.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PhoneTb.Text == "" ||
                AddTb.Text == "" || PassTb.Text == "")//各信息都要填写完整，如果缺失就不能保存
            {
                MessageBox.Show("系统提示:保存失败,信息缺失!!!");
            }
            else
            {
                try
                {
                    key = 0;
                    Con.Open();
                    string query = "insert into UserTbl values('" + UnameTb.Text + "','" + PhoneTb.Text + "','" + AddTb.Text + "','" + PassTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                    cmd.ExecuteNonQuery();//执行目标操作并更新数据库数据
                    MessageBox.Show("系统提示:用户信息保存成功!!!");
                    Con.Close();//打开数据库后及时关闭

                    Populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }//代码运行时，串行运行try块里的所有语句，一旦异常跳出try
                 //进入catch处理程序中执行，如何由catch捕捉一切异常
            }
        }//保存按钮

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            key = 0;
            Reset();
        }

        int key = 0;//删除key
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)//key为0，则当前没有选定任何一条数据，则无法删除
            {
                MessageBox.Show("系统提示:删除失败,信息缺失或错误!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from UserTbl where UId =" + key + "";
                    SqlCommand cmd = new SqlCommand(query, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                    cmd.ExecuteNonQuery();//执行目标操作并更新数据库数据
                    MessageBox.Show("系统提示:用户信息删除成功!!!");
                    Con.Close();//打开数据库后及时关闭

                    key = 0;
                    Populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }//代码运行时，串行运行try块里的所有语句，一旦异常跳出try
                 //进入catch处理程序中执行，如何由catch捕捉一切异常
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            AddTb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            PassTb.Text = UserDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (UnameTb.Text == "")
            {
                key = 0;//如果没有选定,则key继续为0
            }
            else
            {
                key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
                //如果选定了书目数据，就捕获该数据记录第一列的书籍ID，将值赋给key
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PhoneTb.Text == "" ||
                AddTb.Text == "" || PassTb.Text == "")//key为0，则当前没有选定任何一条数据，则无法删除
            {
                MessageBox.Show("系统提示:编辑失败,信息缺失或错误!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update UserTbl set UName ='" + UnameTb.Text + "', UPhone='" + PhoneTb.Text + "', UAdd='" + AddTb.Text + "', UPassword='" + PassTb.Text + "' where UId=" + key + " ";
                    SqlCommand cmd = new SqlCommand(query, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                    cmd.ExecuteNonQuery();//执行目标操作并更新数据库数据
                    MessageBox.Show("系统提示:用户信息更新完成!!!");
                    Con.Close();//打开数据库后及时关闭

                    key = 0;
                    Populate();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }//代码运行时，串行运行try块里的所有语句，一旦异常跳出try
                 //进入catch处理程序中执行，如何由catch捕捉一切异常
            }
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

        private void DashBoardBtn_Click(object sender, EventArgs e)
        {
            DashBoard obj = new DashBoard();
            obj.Show();
            this.Hide();
        }

        private void DashBoardBtn2_Click(object sender, EventArgs e)
        {
            DashBoard obj = new DashBoard();
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

        private void Users_Load(object sender, EventArgs e)
        {
            UserDGV.ClearSelection();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select distinct * from UserTbl where UName = '" + SearchTb.Text + "' or  UAdd ='" + SearchTb.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//创建数据库的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//SqlDataAdapter通常与SqlCommandBuilder配合使用，这样的组合可以用来批量处理数据库数据
            var da = new DataSet();//虚拟数据库，可以把dataset当作内存中的数据库表，然后将数据存储到虚拟表中
            sda.Fill(da);
            UserDGV.DataSource = da.Tables[0];
            Con.Close();
        }

        private void SearchTb_Click(object sender, EventArgs e)
        {
            SearchTb.Clear();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
