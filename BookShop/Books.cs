using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
//相当于引用库或是包
//将C#与SQL server进行连接

namespace BookShop
{
    public partial class Books : Form
    {
        public Books()
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
            string query = "select * from BookTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//创建数据库的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//SqlDataAdapter通常与SqlCommandBuilder配合使用，这样的组合可以用来批量处理数据库数据
            var da = new DataSet();//虚拟数据库，可以把dataset当作内存中的数据库表，然后将数据存储到虚拟表中
            sda.Fill(da);
            BookDGV.DataSource = da.Tables[0];
            Con.Close();
            BookDGV.ClearSelection();
        }
        //通过查询数据库，将特定的信息显示在数据网格中

        private void Filter()
        {
            Con.Open();
            string query = "select * from BookTbl where BCat = '" + CatCbSearchCb.SelectedItem.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//创建数据库的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//SqlDataAdapter通常与SqlCommandBuilder配合使用，这样的组合可以用来批量处理数据库数据
            var da = new DataSet();//虚拟数据库，可以把dataset当作内存中的数据库表，然后将数据存储到虚拟表中
            sda.Fill(da);
            BookDGV.DataSource = da.Tables[0];
            Con.Close();
        }
        //过滤器功能
        //通过查询数据库，将特定的信息显示在数据网格中

        private void Reset()
        {
            BTitleTb.Text = "";
            BAutTb.Text = "";
            BCatCb.SelectedIndex = -1;
            QtyTb.Text = "";
            PriceTb.Text = "";
        }//重置将所有文本框清空

        private void ExitBtn0_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitBtn1_Click(object sender, EventArgs e)
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

        private void Books_Load(object sender, EventArgs e)
        {
            BookDGV.ClearSelection();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text == "" || BAutTb.Text == "" ||
                BCatCb.SelectedIndex == -1 || QtyTb.Text == "" ||
                PriceTb.Text == "")//各信息都要填写完整，如果缺失就不能保存
            {
                MessageBox.Show("系统提示:保存失败,信息缺失!!!");
            }
            else
            {
                try
                {
                    key = 0;
                    Con.Open();
                    string query = "insert into BookTbl values('" + BTitleTb.Text + "','" + BAutTb.Text + "','" + BCatCb.SelectedItem.ToString() + "'," + QtyTb.Text + "," + PriceTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                    cmd.ExecuteNonQuery();//执行目标操作并更新数据库数据
                    MessageBox.Show("系统提示:书籍信息保存成功!!!");
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
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text == "" || BAutTb.Text == "" ||
                BCatCb.SelectedIndex == -1 || QtyTb.Text == "" ||
                PriceTb.Text == "")//key为0，则当前没有选定任何一条数据，则无法删除
            {
                MessageBox.Show("系统提示:编辑失败,信息缺失或错误!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update BookTbl set BTitle ='" + BTitleTb.Text + "', BAuthor='" + BAutTb.Text + "', BCat='" + BCatCb.SelectedItem.ToString() + "', BQty=" + QtyTb.Text + ", BPrice=" + PriceTb.Text + " where BId=" + key + " ";
                    SqlCommand cmd = new SqlCommand(query, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                    cmd.ExecuteNonQuery();//执行目标操作并更新数据库数据
                    MessageBox.Show("系统提示:书籍信息更新完成!!!");
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
                    string query = "delete from BookTbl where BId =" + key + "";
                    SqlCommand cmd = new SqlCommand(query, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                    cmd.ExecuteNonQuery();//执行目标操作并更新数据库数据
                    MessageBox.Show("系统提示:书籍信息删除成功!!!");
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

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            key = 0;
            Reset();
        }

        private void CatCbSearchCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();//选定类目时触发
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Populate();
            CatCbSearchCb.SelectedIndex = -1;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select distinct * from BookTbl where BTitle = '" + SearchTb.Text + "' or  BAuthor ='" + SearchTb.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//创建数据库的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//SqlDataAdapter通常与SqlCommandBuilder配合使用，这样的组合可以用来批量处理数据库数据
            var da = new DataSet();//虚拟数据库，可以把dataset当作内存中的数据库表，然后将数据存储到虚拟表中
            sda.Fill(da);
            BookDGV.DataSource = da.Tables[0];
            Con.Close();
        }

        private void SearchTb_Click(object sender, EventArgs e)
        {
            SearchTb.Clear();
        }

        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitleTb.Text = BookDGV.SelectedRows[0].Cells[1].Value.ToString();
            BAutTb.Text = BookDGV.SelectedRows[0].Cells[2].Value.ToString();
            BCatCb.SelectedItem = BookDGV.SelectedRows[0].Cells[3].Value.ToString();
            QtyTb.Text = BookDGV.SelectedRows[0].Cells[4].Value.ToString();
            PriceTb.Text = BookDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (BTitleTb.Text == "")
            {
                key = 0;//如果没有选定,则key继续为0
            }
            else
            {
                key = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());
                //如果选定了书目数据，就捕获该数据记录第一列的书籍ID，将值赋给key
            }
        }
    }
}