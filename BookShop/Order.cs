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
    public partial class Order : Form
    {
        public static Order order;//单例对象

        public Order()
        {
            InitializeComponent();
            Populate();

            order = this;//单例引用
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

        private void Reset()
        {
            BTitleTb.Text = "";
            QtyTb.Text = "";
            PriceTb.Text = "";
        }

        int FirstnewQty;
        private void UpdateBook()
        {
            FirstnewQty = stock - Convert.ToInt32(QtyTb.Text);
            stock = FirstnewQty;
            try
            {
                Con.Open();
                string query = "update BookTbl set BQty=" + FirstnewQty + " where BId=" + key + " ";
                SqlCommand cmd = new SqlCommand(query, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                cmd.ExecuteNonQuery();//执行目标操作并更新数据库数据
                MessageBox.Show("系统提示：选购成功!!!");
                Con.Close();//打开数据库后及时关闭

                //key = 0;
                Populate();
                //Reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }//代码运行时，串行运行try块里的所有语句，一旦异常跳出try
             //进入catch处理程序中执行，如何由catch捕捉一切异常
        }
        private void UpdateBook2(int QtyChange)
        {
            int SecondnewQty = FirstnewQty + QtyChange;
            FirstnewQty = SecondnewQty;
            try
            {
                Con.Open();
                string query = "update BookTbl set BQty=" + SecondnewQty + " where BId=" + key + " ";
                SqlCommand cmd = new SqlCommand(query, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                cmd.ExecuteNonQuery();//执行目标操作并更新数据库数据
                MessageBox.Show("系统提示：删除订单项成功!!!");
                Con.Close();//打开数据库后及时关闭

                //key = 0;
                Populate();
                //Reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }//代码运行时，串行运行try块里的所有语句，一旦异常跳出try
             //进入catch处理程序中执行，如何由catch捕捉一切异常
        }
        private void UpdateBook3(int QtyChange, int key)
        {
            try
            {
                Con.Open();
                string query1 = "select BQty from BookTbl where BId = " + key + " ";
                SqlCommand cmd1 = new SqlCommand(query1, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                int ThirdnewQty = (int)cmd1.ExecuteScalar();//执行目标操作并更新数据库数据

                ThirdnewQty = ThirdnewQty + QtyChange;

                string query2 = "update BookTbl set BQty=" + ThirdnewQty + " where BId=" + key + " ";
                SqlCommand cmd2 = new SqlCommand(query2, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                cmd2.ExecuteNonQuery();//执行目标操作并更新数据库数据
                Con.Close();//打开数据库后及时关闭


                //key = 0;
                //Reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }//代码运行时，串行运行try块里的所有语句，一旦异常跳出try
             //进入catch处理程序中执行，如何由catch捕捉一切异常
        }

        int key = 0;//删除key
        int stock = 0;//库存量

        private void ExitBtn0_Click(object sender, EventArgs e)
        {
            if (OrderDGV.Rows.Count == 0)
            {
                Application.Exit();
            }
            else
            {
                Notice1 obj = new Notice1();
                obj.Show();
            }
        }

        private void ExitBtn1_Click(object sender, EventArgs e)
        {
            if(OrderDGV.Rows.Count == 0)
            {
                Login obj = new Login();
                obj.Show();
                this.Hide();
            }
            else
            {
                Notice2 obj1 = new Notice2();
                obj1.Show();
            }
        }

        private void ExitBtn2_Click(object sender, EventArgs e)
        {
            if(OrderDGV.Rows.Count == 0)
            {
                Login obj = new Login();
                obj.Show();
                this.Hide();
            }
            else
            {
                Notice2 obj1 = new Notice2();
                obj1.Show();
            }
        }

        int prodid, prodqty, prodprice, total, pos = 72; string prodname;

        private void Order_Load(object sender, EventArgs e)
        {
            UserNameLbl.Text = Login.UserName;
            
            Con.Open();
            string query = "select distinct BCat from BookTbl where BQty != 0 ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//创建数据库的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//SqlDataAdapter通常与SqlCommandBuilder配合使用，这样的组合可以用来批量处理数据库数据
            var da = new DataSet();//虚拟数据库，可以把dataset当作内存中的数据库表，然后将数据存储到虚拟表中
            sda.Fill(da);
            DayBookCatDGV.DataSource = da.Tables[0];
            Con.Close();

            OrderDGV.ClearSelection();
            BookDGV.ClearSelection();

        }

        private void SearchTb_Click(object sender, EventArgs e)
        {
            SearchTb.Clear();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select distinct * from BookTbl where BTitle = '" + SearchTb.Text + "' or  BAuthor ='" + SearchTb.Text + "' or BCat ='" + SearchTb.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//创建数据库的批量抓取
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//SqlDataAdapter通常与SqlCommandBuilder配合使用，这样的组合可以用来批量处理数据库数据
            var da = new DataSet();//虚拟数据库，可以把dataset当作内存中的数据库表，然后将数据存储到虚拟表中
            sda.Fill(da);
            BookDGV.DataSource = da.Tables[0];
            Con.Close();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Populate();
        }

        int n = 1;//行序
        int GrdTotal = 0;//总金额

        private void AddtoOrderBtn_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text == "")
            {
                MessageBox.Show("系统提示:您并未选择任何书籍!!!");
            }
            else
            {
                if (QtyTb.Text == "")
                {
                    MessageBox.Show("系统提示:请输入您需要购买的数量！！！");
                }
                else
                {
                    if (Convert.ToInt32(QtyTb.Text) > stock)
                    {
                        MessageBox.Show("系统提示:您选购的商品库存不足！！！");
                    }
                    else
                    {
                        int total = Convert.ToInt32(QtyTb.Text) * Convert.ToInt32(PriceTb.Text);

                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells(OrderDGV);
                        newRow.Cells[0].Value = n;
                        newRow.Cells[1].Value = BTitleTb.Text;
                        newRow.Cells[2].Value = PriceTb.Text;
                        newRow.Cells[3].Value = QtyTb.Text;
                        newRow.Cells[4].Value = total;
                        newRow.Cells[5].Value = key;
                        OrderDGV.Rows.Add(newRow);
                        OrderDGV.ClearSelection();
                        n++;
                        UpdateBook();
                        GrdTotal += total;
                        TotalLbl.Text = GrdTotal + "元";
                    }
                }
            }
        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        int at;//要删除的那行行头
        int QtyChange;//变化的数量
        int tag;//是否选中

        public void AllDeleteBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < OrderDGV.Rows.Count; i++)
            {
                QtyChange = Convert.ToInt32(OrderDGV.Rows[i].Cells[3].Value.ToString());
                key = Convert.ToInt32(OrderDGV.Rows[i].Cells[5].Value.ToString());
                UpdateBook3(QtyChange, key);
            }//每次刷新表之后重新给表排序
            OrderDGV.Rows.Clear();
            if (OrderDGV.Rows.Count == 0)
            {
                n = 1;//重置行序
            }
            OrderDGV.ClearSelection();

            Populate();
            MessageBox.Show("系统提示：订单已清空!!!");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (tag == 1)
            {
                UpdateBook2(QtyChange);
                OrderDGV.Rows.RemoveAt(at - 1);

                for (int i = 0; i < OrderDGV.Rows.Count; i++)
                {
                    OrderDGV.Rows[i].Cells[0].Value = i + 1;
                }//每次刷新表之后重新给表排序

                if (OrderDGV.Rows.Count == 0)
                {
                    n = 1;//重置行序
                }
                OrderDGV.ClearSelection();
                tag = 0;
            }
            else
            {
                MessageBox.Show("系统提示:您貌似没有选择任何订单项哦!!!");
            }
        }

        private void OrderDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            at = Convert.ToInt32(OrderDGV.SelectedRows[0].Cells[0].Value.ToString());

            QtyChange = Convert.ToInt32(OrderDGV.SelectedRows[0].Cells[3].Value.ToString());

            key = Convert.ToInt32(OrderDGV.SelectedRows[0].Cells[5].Value.ToString());

            tag = 1;
        }

        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitleTb.Text = BookDGV.SelectedRows[0].Cells[1].Value.ToString();
            //QtyTb.Text = BookDGV.SelectedRows[0].Cells[4].Value.ToString();
            PriceTb.Text = BookDGV.SelectedRows[0].Cells[5].Value.ToString();
            QtyTb.Text = "";
            if (BTitleTb.Text == "")
            {
                key = 0;//如果没有选定,则key继续为0
                stock = 0;
            }
            else
            {
                key = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());
                //如果选定了书目数据，就捕获该数据记录第一列的书籍ID，将值赋给key
                stock = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[4].Value.ToString());
            }
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("小朱书店", new Font("幼圆", 12, FontStyle.Bold), Brushes.Red, new Point(116, 20));
            e.Graphics.DrawString("编号    书名           价格      数量      总计", new Font("微软雅黑", 10, FontStyle.Bold), Brushes.Red, new Point(20, 50));
            foreach(DataGridViewRow row in OrderDGV.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column7"].Value);
                prodname = "" + row.Cells["Column8"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column9"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column10"].Value);
                total = Convert.ToInt32(row.Cells["Column11"].Value);

                e.Graphics.DrawString("" + prodid, new Font("微软雅黑", 8, FontStyle.Bold), Brushes.Blue, new Point(32, pos));
                e.Graphics.DrawString("" + prodname, new Font("微软雅黑", 8, FontStyle.Bold), Brushes.Blue, new Point(62, pos));
                e.Graphics.DrawString("" + prodprice, new Font("微软雅黑", 8, FontStyle.Bold), Brushes.Blue, new Point(146, pos));
                e.Graphics.DrawString("" + prodqty, new Font("微软雅黑", 8, FontStyle.Bold), Brushes.Blue, new Point(202, pos));
                e.Graphics.DrawString("" + total, new Font("微软雅黑", 8, FontStyle.Bold), Brushes.Blue, new Point(253, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("订单总额:" + GrdTotal + "元", new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Crimson, new Point(18, pos+50));
            e.Graphics.DrawString(currentTime, new Font("微软雅黑", 11, FontStyle.Bold), Brushes.Crimson, new Point(160, pos + 52));
            e.Graphics.DrawString("**********小朱书店**********", new Font("微软雅黑", 10, FontStyle.Bold), Brushes.Crimson, new Point(55, pos + 85));

            OrderDGV.Rows.Clear();
            OrderDGV.Refresh();
            pos = 72;
            GrdTotal = 0;
            //小票打印出来后，清空购物车中的内容
        }//最终的打印显示

        String currentTime = DateTime.Now.ToString("D");      
        private void PrintBtn_Click(object sender, EventArgs e)
        {
            n = 1;
            if (OrderDGV.Rows.Count == 0)//如果表格里没有数据
            {
                MessageBox.Show("系统提示:你还没有选择宝贝哦:)");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into OrderTbl values('" + UserNameLbl.Text + "'," + GrdTotal + ",'"+currentTime+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);//数据命令对象，主要向数据库发送增删改查的sql语句
                    cmd.ExecuteNonQuery();//执行目标操作并更新数据库数据
                    MessageBox.Show("系统提示:订单信息保存成功!!!");
                    Con.Close();//打开数据库后及时关闭
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }//代码运行时，串行运行try块里的所有语句，一旦异常跳出try
                 //进入catch处理程序中执行，如何由catch捕捉一切异常

                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 300, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }
    }
}
