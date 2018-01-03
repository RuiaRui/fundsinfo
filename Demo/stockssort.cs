using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace FjuColorForm
{
    public partial class stocksort : FrmMain
    {
        Thread td;
        WebHandler wh = new WebHandler();
        public stocksort(int b)
        {
            InitializeComponent();
            td = new Thread(new ParameterizedThreadStart(GetIntroduction));
            td.Start(b);
        }

        void GetIntroduction(Object a)
        {
            //读取存在本地的排序数据
            string str =  wh.Read("result\\result.txt");
            string[] all = str.Split('\n');
            List<Stock> display = new List<Stock>();
            for(int i = 0; i < all.Length; i++)
            {
                String[] tmp = all[i].Split(',');
                Stock temp = new Stock();
                temp.name = tmp[0];
                if (tmp.Length == 2)
                {
                    temp.sum = Convert.ToDouble(tmp[1]);
                }
                else
                {
                    temp.sum = 0.0;
                }               
                display.Add(temp);
            }

            //判断为升序还是降序，降序时讲list中反转
            int c = (int)a;
            if (c == 1)
            {
                display.Reverse();
            }


        //输出前100个
            for (int i = 0; i < 100; i++)
            {
                
               DataGridViewRow row = new DataGridViewRow();
                int x = i;
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows.Add(row);
                    dataGridView1.Rows[x].Cells[0].Value = x + 1;
                    dataGridView1.Rows[x].Cells[1].Value = display[x].name;
                    dataGridView1.Rows[x].Cells[2].Value = Math.Round(display[x].sum,10);
                });
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Image back;
            Color color;
            Skin.readSkinImgINI(out back, out color);
            BackColor = color;
            if (back != null)
            {
                Bitmap pic = Skin.SetEdgeBlur((Bitmap)back, color, 64, Skin.BLURSTYLE.RIGHT);
                BackgroundImage = Skin.SetEdgeBlur(pic, color, 64, Skin.BLURSTYLE.BOTTOM);
            }
            //AnimateWindow(this.Handle, 2000,  AW_HOR_NEGATIVE);
            dataGridView1.ForeColor = System.Drawing.Color.Black;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = color;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

        }
        //切换为升序
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            stocksort form41 = new stocksort(0);
            form41.Show();
        }
        //切换为降序
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            stocksort form42 = new stocksort(1);
            form42.Show();
        }
    }
}
