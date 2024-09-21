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
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();//令界面打开时，计时器开始工作
        }

        int startpos = 0;//定义一个增长中间量
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 2;
            Myprogress.Value = startpos;
            PercentageLbl.Text = startpos + "%";//将变量值的变化写到百分数上面
            if(Myprogress.Value == 100)
            {
                Myprogress.Value = 0;
                timer1.Stop();//计时停止
                Login login = new Login();//弹出用户登录界面
                login.Show();
                this.Hide();
            }
        }//计时器
    }
}
