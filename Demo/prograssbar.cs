using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FjuColorForm
{
    public partial class prograssbar : FrmMain
    {
        List<string> fundsID = new List<string>();
        List<Stock> stocks = new List<Stock>();
        Thread td;
        WebHandler wh = new WebHandler();


        public prograssbar()
        {
            InitializeComponent();

            ThreadStart ts = new ThreadStart(datarenew);
            td = new Thread(ts);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();

        }
        //添加进度条更新事件
        private delegate void SetPos(int ipos);

        //设置进度条
        private void SetProgress(int ipos)

        {
            if (this.InvokeRequired)
            {

                SetPos setpos = new SetPos(SetProgress);

                this.Invoke(setpos, new object[]{ipos});

            }else
            {
                
                this.progressBar1.Value = Convert.ToInt32(ipos);
                //this.skinLabel2.Text = (ipos / (this.progressBar1.Maximum)).ToString("P");
            }
        }
        private void Form5_Load(object sender, EventArgs e)
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //数据更新
        public void datarenew()
        {
            CheckForIllegalCrossThreadCalls = false;
            string IDresult = "";

            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            
            int x = 0;

            textBox1.AppendText("开始获取基金id\n");
            //获取所有基金id
            string PageNumberh = "http://fund.eastmoney.com/data/rankhandler.aspx?op=ph&dt=kf&ft=all&rs=&gs=0&sc=zzf&st=desc&sd=2015-10-29&ed=2016-10-29&qdii=&tabSubtype=,,,,,&pi=%221&pn=50&dx=1&v=0.10850418109563731";
            string PageNumber = wh.GetContent(PageNumberh);

            PageNumber = PageNumber.Substring(PageNumber.IndexOf("allRecords") + 11);
            int allRecord = Convert.ToInt32(PageNumber.Substring(0, PageNumber.IndexOf(",")));
            

            PageNumber =PageNumber.Substring(PageNumber.IndexOf("allPages")+9);
            int page = Convert.ToInt32(PageNumber.Substring(0, PageNumber.IndexOf(",")));

            int max = allRecord * 2 + page + 20;
            progressBar1.Maximum = max;

            for (int i = 1; i < page; i++)
            {
                //    this.Invoke((EventHandler)delegate
                //    {
                //    string url = "http://fund.eastmoney.com/data/rankhandler.aspx?op=ph&dt=kf&ft=all&rs=&gs=0&sc=zzf&st=desc&sd=2015-10-29&ed=2016-10-29&qdii=&tabSubtype=,,,,,&pi="
                //    + i + "&pn=50&dx=1&v=0.10850418109563731";

                //    string data = wh.GetContent(url);
                //    //正则表达式，提取每两个引号之间内容
                //    Regex re = new Regex("(?<=\").*?(?=\")", RegexOptions.None);

                //    //用正则表达式提取内容
                //    MatchCollection mc = re.Matches(data);

                //    foreach (Match funds in mc)
                //    {
                //        string fund = funds.Value;
                //        //把逗号之间的内容提取出来放进string数组里
                //        string[] all = Regex.Split(fund, ",", RegexOptions.IgnoreCase);
                //        if (all[0].Length == 0)
                //        { continue; }
                //        IDresult = IDresult + all[0] + ",";
                //    }
                //});
                x += 1;
                SetProgress(x);
            }
            //inText(IDresult, "result\\IDresult");

            textBox1.AppendText("获取基金id完成\n");
            x = page;
            SetProgress(x);

            //这一步是因为id基本上是不变的，为了节省时间，也为了程序其他部分重复使用时的读取方便，
            //加一步储存到本地的过程
            string str = wh.Read("result\\IDresult.txt");
            string[] temp = str.Split(',');
            for (int a = 0; a < temp.Length; a++)
            {
                fundsID.Add(temp[a]);
            }
            textBox1.AppendText("开始获取基金信息\n");
            //获取每一条基金的html全部信息
            string url2;
            string HTML;
            foreach (string ID in fundsID)
            {
                //url2 = "http://fund.eastmoney.com/" + ID + ".html";

                //HTML = wh.GetContent(url2);

                //inText(HTML, ID);

                textBox1.AppendText("写入"+ID+"基金成功\n");
                x += 1;
                SetProgress(x);
            }
            textBox1.AppendText("写入基金到本地成功\n");

         
            string content;
            string total, pecent;

            double sums;
            //处理每一条基金的内容，获取股票信息并储存
            foreach (string ID in fundsID)
            {
                if (ID == "") { continue; }
                content = wh.Read(ID+".txt");
                //有的id下网页为空，筛选掉空文件
                if (content == "") { continue; }
                content = content.Substring(content.IndexOf("基金规模") + 9);
                total = content.Substring(0, content.IndexOf("亿"));
                if (total == "--")
                    continue;
                sums = Convert.ToDouble(total);


                content = content.Substring(content.IndexOf("股票名称"));
                content = content.Substring(0, content.IndexOf("</table>"));
                while (content.Contains("alignLeft"))
                {
                    content = content.Substring(content.IndexOf("alignLeft"));
                    content = content.Substring(content.IndexOf("<"));
                    string tmp1 = content.Substring(0, 2);
                    if (tmp1 == "<a")
                        content = content.Substring(content.IndexOf(">") + 1);
                    string stockName = content.Substring(0, content.IndexOf("<"));
                    content = content.Substring(content.IndexOf("alignRight"));
                    content = content.Substring(content.IndexOf(">") + 1);
                    pecent = content.Substring(0, content.IndexOf("<") - 1);
                    sums *= Convert.ToDouble(pecent) / 100.0;
                    bool matchs = false;

                    //判断是否已经存储，已有便累加数据，没有就add
                    foreach (Stock sto in stocks)
                    {
                        if (sto.name == stockName)
                        {
                            sto.sum += sums;
                            matchs = true;
                            break;
                        }
                    }
                    if (!matchs)
                    {
                        Stock st = new Stock();
                        st.name = stockName;
                        st.sum = sums;
                        stocks.Add(st);
                    }
                }

                x += 1;
                SetProgress(x);
                textBox1.AppendText("处理"+ID+ "基金数据成功\n");

            }
            textBox1.AppendText("获取基金信息完成\n正在排序\n");

           
            //排序
            List<Stock> tmp = new List<Stock>();
            bool IN;
            foreach (Stock st in stocks)
            {
                IN = false;
                for (int i = 0; i < tmp.Count; i++)
                {
                    if (tmp.ElementAt(i).sum < st.sum)
                    {
                        tmp.Insert(i, st);
                        IN = true;
                        break;
                    }
                }
                if (!IN)
                {
                    tmp.Add(st);
                }
            }
            x += 20;
            SetProgress(x);

            //写入本地
            string result = "";
            for (int i = 0; i < tmp.Count; i++)
            {
                result += tmp.ElementAt(i).name + "," + tmp.ElementAt(i).sum + "\n";
            }
            inText(result, "result\\result", "UTF8");
            SetProgress(max);
            textBox1.AppendText("完成更新\n");

           

        }

        void inText(string data, string name, string str="UTF8" )
        {
            FileStream fs = new FileStream("..\\..\\stock\\" + name + ".txt", FileMode.Create);
            //获得字节数组
            byte[] datas;
            if (str == "UTF8")
            {
                datas = System.Text.Encoding.UTF8.GetBytes(data);
                fs.Write(datas, 0, data.Length);
            }
            else
            {
                datas = System.Text.Encoding.Default.GetBytes(data);
                fs.Write(datas, 0, datas.Length);
            }
           // 开始写入
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void skinLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}

