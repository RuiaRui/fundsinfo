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
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace FjuColorForm
{
    public partial class fundsdisplay : FrmMain
    {
        Thread td;
        //初始化页数
        int page = 1;
        //初始化开始界面，并把页数转到第一页

        List<string> fundsID = new List<string>();
        List<Stock> stocks = new List<Stock>();
        WebHandler wh = new WebHandler();

        public fundsdisplay()
        {
            InitializeComponent();
            ThreadStart ts = new ThreadStart(GetIntroduction);
            td = new Thread(ts);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }
        int totalpage;

        void GetIntroduction()
        {
           CheckForIllegalCrossThreadCalls = false;
            turnTo(1);
        }


        //转到特定页
        string turnTo(int pi)
        {
            //清空之前内容
            this.dataGridView1.Rows.Clear();
            string url = "http://fund.eastmoney.com/data/rankhandler.aspx?op=ph&dt=kf&ft=all&rs=&gs=0&sc=zzf&st=desc&sd=2015-10-29&ed=2016-10-29&qdii=&tabSubtype=,,,,,&pi="
                + pi + "&pn=50&dx=1&v=0.10850418109563731";

            string data = wh.GetContent(url);

            String PageNumber = data.Substring(data.IndexOf("allPages") + 9);
            totalpage = Convert.ToInt32(PageNumber.Substring(0, PageNumber.IndexOf(",")));
            this.label1.Text = page + "/" + totalpage;

            //正则表达式，提取每两个引号之间内容
            Regex re = new Regex("(?<=\").*?(?=\")", RegexOptions.None);

            //用正则表达式提取内容
            MatchCollection mc = re.Matches(data);

            int index = 0;

            //跳过单数项
            int pass = 0;

            foreach (Match funds in mc)
            {
                if (pass % 2 == 1)
                {
                    pass++;
                    continue;
                }

                string fund = funds.Value;
                //把逗号之间的内容提取出来放进string数组里
                string[] all = Regex.Split(fund, ",", RegexOptions.IgnoreCase);
                //新建一行
                DataGridViewRow row = new DataGridViewRow();


                //之后的代码都是把string数组的内容放进每一行里
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows.Add(row);
                    dataGridView1.Rows[index].Cells[0].Value = all[0];
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[1].Value = all[1].Substring(0, (all[1].Length > 6 ? 6 : all[1].Length));
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[2].Value = all[3].Length == 0 ? "---" : all[3].Substring(5);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[3].Value = all[4].Length == 0 ? "---" : all[4];
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[4].Value = all[5].Length == 0 ? "---" : all[5];
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[5].Value = getPecent(all[6]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[6].Value = getPecent(all[7]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[7].Value = getPecent(all[8]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[8].Value = getPecent(all[9]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[9].Value = getPecent(all[10]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[10].Value = getPecent(all[11]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[11].Value = getPecent(all[12]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[12].Value = getPecent(all[13]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[13].Value = getPecent(all[14]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[14].Value = getPecent(all[15]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[15].Value = all[20];
                });
                //换行
                index++;
                pass++;
            }
            //改变页码
            page = pi;
            

            //清空文字框内容
            textBox1.Text = "";
            return url;
        }



        //获得两位有效数字的字符串百分数
        string getPecent(string temp)
        {
            if (temp.Length == 0)
            {
                return "---";
            }
            double d = Math.Round(Convert.ToDouble(temp), 2);
            temp = d.ToString();
            if (Convert.ToInt32(d) - d == 0)
                temp += ".00%";
            else if (Convert.ToInt32(d * 10) - d * 10 == 0)
                temp += "0%";
            else
                temp += "%";
            return temp;
        }

    


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //下一页
        private void button2_Click(object sender, EventArgs e)
        {
            if (page == totalpage)
                return;
            turnTo(page + 1);
        }
        //上一页
        private void button1_Click(object sender, EventArgs e)
        {
            if (page == 1)
                return;
            turnTo(page - 1);
        }
        //转到特定页
        private void button3_Click(object sender, EventArgs e)
        {
            //使用try catch通过文字框内容转到特定页，并抛出错误输出
            try
            {
                int a = Convert.ToInt32(textBox1.Text);
                if (!(a > 0 && a <= totalpage))
                    throw new Exception();
                turnTo(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入错误，请检查您输入的数字（1-"+totalpage+"）。", "提示");
                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
            }
        }

        //输入基金代码查看某只基金详情
        private void button5_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;

            //通过try catch把输入的基金代码转到网页，若网页不存在，则抛出错误，
            //同时把输入的错误基金代号的格式抛出
            try
            {
                string x =wh.GetContent(@"http://fund.eastmoney.com/" + str + ".html");
                x = x.Substring(x.IndexOf("<title>") + 7);
                x = x.Substring(0, x.IndexOf("</title>"));
                if (!(x.Contains(str)))
                {
                    throw new Exception();
                }
                funddetail f = new funddetail(str);
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入错误，不存编号为" + str + "的基金。", "提示");
                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
            }
        }


        //查看某只基金详情
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            funddetail f = new funddetail(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            f.Show();
        }

        //更新股票数据
        private void button4_Click(object sender, EventArgs e)
        {

            prograssbar form5 = new prograssbar();
            form5.Show();

        }

       
        //查看股票排行
        private void button6_Click(object sender, EventArgs e)
        {
            stocksort form4 = new stocksort(0);
            form4.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        //查看股票增持信息
        private void button7_Click(object sender, EventArgs e)
        {
            stockvary form61 = new stockvary(0);
            form61.Show();
        }
        //查看股票减持信息
        private void button8_Click(object sender, EventArgs e)
        {
            stockvary form62 = new stockvary(1);
            form62.Show();
        }

        private void fundsdisplay_Load(object sender, EventArgs e)
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
            dataGridView1.ForeColor = System.Drawing.Color.Black;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = color;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            //AnimateWindow(this.Handle, 2000,  AW_HOR_NEGATIVE);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Stock
    {
        public string name { get; set; }
        public double sum { get; set; }
    }
}
