namespace FjuColorForm
{
    partial class fundsdisplay
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abbreviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IOPV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ＡＮＶ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rootvole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oneweek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onemonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.threemonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sixmonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oneyear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.twoyears = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.threeyears = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thisyear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handlingcharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new CCWin.SkinControl.SkinButton();
            this.button1 = new CCWin.SkinControl.SkinButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("方正姚体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.abbreviation,
            this.date,
            this.IOPV,
            this.ＡＮＶ,
            this.Rootvole,
            this.oneweek,
            this.onemonth,
            this.threemonths,
            this.sixmonths,
            this.oneyear,
            this.twoyears,
            this.threeyears,
            this.thisyear,
            this.create,
            this.handlingcharge});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.Location = new System.Drawing.Point(6, 38);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1207, 457);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // code
            // 
            this.code.HeaderText = "基金代码";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 120;
            // 
            // abbreviation
            // 
            this.abbreviation.HeaderText = "基金简称";
            this.abbreviation.Name = "abbreviation";
            this.abbreviation.ReadOnly = true;
            this.abbreviation.Width = 120;
            // 
            // date
            // 
            this.date.HeaderText = "日期";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 70;
            // 
            // IOPV
            // 
            this.IOPV.HeaderText = "单位净值";
            this.IOPV.Name = "IOPV";
            this.IOPV.ReadOnly = true;
            // 
            // ＡＮＶ
            // 
            this.ＡＮＶ.HeaderText = "累计净值";
            this.ＡＮＶ.Name = "ＡＮＶ";
            this.ＡＮＶ.ReadOnly = true;
            // 
            // Rootvole
            // 
            this.Rootvole.HeaderText = "日增长率";
            this.Rootvole.Name = "Rootvole";
            this.Rootvole.ReadOnly = true;
            // 
            // oneweek
            // 
            this.oneweek.HeaderText = "近1周";
            this.oneweek.Name = "oneweek";
            this.oneweek.ReadOnly = true;
            // 
            // onemonth
            // 
            this.onemonth.HeaderText = "近1月";
            this.onemonth.Name = "onemonth";
            this.onemonth.ReadOnly = true;
            // 
            // threemonths
            // 
            this.threemonths.HeaderText = "近3月";
            this.threemonths.Name = "threemonths";
            this.threemonths.ReadOnly = true;
            // 
            // sixmonths
            // 
            this.sixmonths.HeaderText = "近6月";
            this.sixmonths.Name = "sixmonths";
            this.sixmonths.ReadOnly = true;
            // 
            // oneyear
            // 
            this.oneyear.HeaderText = "近1年";
            this.oneyear.Name = "oneyear";
            this.oneyear.ReadOnly = true;
            // 
            // twoyears
            // 
            this.twoyears.HeaderText = "近2年";
            this.twoyears.Name = "twoyears";
            this.twoyears.ReadOnly = true;
            // 
            // threeyears
            // 
            this.threeyears.HeaderText = "近3年";
            this.threeyears.Name = "threeyears";
            this.threeyears.ReadOnly = true;
            // 
            // thisyear
            // 
            this.thisyear.HeaderText = "今年来";
            this.thisyear.Name = "thisyear";
            this.thisyear.ReadOnly = true;
            // 
            // create
            // 
            this.create.HeaderText = "成立来";
            this.create.Name = "create";
            this.create.ReadOnly = true;
            // 
            // handlingcharge
            // 
            this.handlingcharge.HeaderText = "手续费";
            this.handlingcharge.Name = "handlingcharge";
            this.handlingcharge.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button2.DownBack = null;
            this.button2.Location = new System.Drawing.Point(305, 521);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.MouseBack = null;
            this.button2.Name = "button2";
            this.button2.NormlBack = null;
            this.button2.Size = new System.Drawing.Size(97, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "下一页";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button1.DownBack = null;
            this.button1.Location = new System.Drawing.Point(16, 521);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.MouseBack = null;
            this.button1.Name = "button1";
            this.button1.NormlBack = null;
            this.button1.Size = new System.Drawing.Size(97, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "上一页";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(170, 525);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(58, 23);
            this.textBox1.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button3.DownBack = null;
            this.button3.Location = new System.Drawing.Point(236, 521);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button3.MouseBack = null;
            this.button3.Name = "button3";
            this.button3.NormlBack = null;
            this.button3.Size = new System.Drawing.Size(57, 33);
            this.button3.TabIndex = 6;
            this.button3.Text = "转到";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 530);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 7;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 528);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "基金编号";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.Location = new System.Drawing.Point(499, 524);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(67, 23);
            this.textBox2.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button5.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button5.DownBack = null;
            this.button5.Location = new System.Drawing.Point(582, 520);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button5.MouseBack = null;
            this.button5.Name = "button5";
            this.button5.NormlBack = null;
            this.button5.Size = new System.Drawing.Size(80, 35);
            this.button5.TabIndex = 11;
            this.button5.Text = "搜索";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // fundsdisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1228, 573);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("方正姚体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "fundsdisplay";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.fundsdisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn abbreviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn IOPV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ＡＮＶ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rootvole;
        private System.Windows.Forms.DataGridViewTextBoxColumn oneweek;
        private System.Windows.Forms.DataGridViewTextBoxColumn onemonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn threemonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn sixmonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn oneyear;
        private System.Windows.Forms.DataGridViewTextBoxColumn twoyears;
        private System.Windows.Forms.DataGridViewTextBoxColumn threeyears;
        private System.Windows.Forms.DataGridViewTextBoxColumn thisyear;
        private System.Windows.Forms.DataGridViewTextBoxColumn create;
        private System.Windows.Forms.DataGridViewTextBoxColumn handlingcharge;
        private CCWin.SkinControl.SkinButton button2;
        private CCWin.SkinControl.SkinButton button1;
        private System.Windows.Forms.TextBox textBox1;
        private CCWin.SkinControl.SkinButton button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private CCWin.SkinControl.SkinButton button5;
    }
}

