namespace BookShop
{
    partial class Notice2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.YesBtn = new System.Windows.Forms.Button();
            this.FalseBtn = new System.Windows.Forms.Button();
            this.RebackBtn = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.YesBtn);
            this.panel1.Controls.Add(this.FalseBtn);
            this.panel1.Controls.Add(this.RebackBtn);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 246);
            this.panel1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(24, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(372, 27);
            this.label2.TabIndex = 24;
            this.label2.Text = "您貌似还有订单未结算，真的要退出嘛？";
            // 
            // YesBtn
            // 
            this.YesBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.YesBtn.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.YesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YesBtn.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.YesBtn.ForeColor = System.Drawing.Color.White;
            this.YesBtn.Location = new System.Drawing.Point(62, 154);
            this.YesBtn.Name = "YesBtn";
            this.YesBtn.Size = new System.Drawing.Size(124, 36);
            this.YesBtn.TabIndex = 23;
            this.YesBtn.Text = "是";
            this.YesBtn.UseVisualStyleBackColor = false;
            this.YesBtn.Click += new System.EventHandler(this.YesBtn_Click);
            // 
            // FalseBtn
            // 
            this.FalseBtn.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.FalseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FalseBtn.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FalseBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.FalseBtn.Location = new System.Drawing.Point(254, 154);
            this.FalseBtn.Name = "FalseBtn";
            this.FalseBtn.Size = new System.Drawing.Size(124, 36);
            this.FalseBtn.TabIndex = 22;
            this.FalseBtn.Text = "否";
            this.FalseBtn.UseVisualStyleBackColor = true;
            this.FalseBtn.Click += new System.EventHandler(this.FalseBtn_Click);
            // 
            // RebackBtn
            // 
            this.RebackBtn.AutoSize = true;
            this.RebackBtn.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RebackBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            this.RebackBtn.Location = new System.Drawing.Point(280, 294);
            this.RebackBtn.Name = "RebackBtn";
            this.RebackBtn.Size = new System.Drawing.Size(46, 24);
            this.RebackBtn.TabIndex = 15;
            this.RebackBtn.Text = "返回";
            // 
            // Notice2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(452, 270);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notice2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notice2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button YesBtn;
        private System.Windows.Forms.Button FalseBtn;
        private System.Windows.Forms.Label RebackBtn;
    }
}