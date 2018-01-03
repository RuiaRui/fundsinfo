using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FjuColorForm
{
    public partial class stockvary : FrmMain
    {
        Thread td;
        WebHandler wh = new WebHandler();
        public stockvary(int b)
        {
            InitializeComponent();
            td = new Thread(new ParameterizedThreadStart(getStockResult));
            td.Start(b);
        }

        private void Form6_Load(object sender, EventArgs e)
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

        


        List<string> fundsID = new List<string>();
        List<Stock> stocks = new List<Stock>();
        List<Stockk> stockks = new List<Stockk>();

        public void getStockResult(Object a) {

            int c = (int)a;
            string str = wh.Read("result\\stockresult.txt");
            string[] all = str.Split('\n');          
            List<Stockk> display = new List<Stockk>();
            for (int i = 0; i < all.Length; i++)
            {
                if (all[i] == "") { continue; }
                String[] tmp = all[i].Split(',');
                Stockk temp = new Stockk();
                temp.name = tmp[0];
                if (tmp.Length == 2)
                {
                    temp.delta = Convert.ToDouble(tmp[1]);
                }
                else
                {
                    temp.delta = 0.0;
                }
                display.Add(temp);
            }
            if (c==1)
            {
                dataGridView1.Columns[2].HeaderText = "股票减持金额";
                display.Reverse();
                //第一个为空
                //display.Remove(display[0]);
            }


            for (int i = 0; i < 50; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                int x = i;
                this.Invoke((EventHandler)delegate
                    {
                        dataGridView1.Rows.Add(row);
                        dataGridView1.Rows[x].Cells[0].Value = x + 1;
                        dataGridView1.Rows[x].Cells[1].Value = display[x].name;
                        dataGridView1.Rows[x].Cells[2].Value = Math.Round(display[x].delta, 2);
                    });
            }
        }

        public void getStockSort()
        {
            //List<string> names = wh.GetAll();
            //读取储存在本地的id
            string str = wh.Read("result\\IDresult.txt");
            string[] temp = str.Split(',');
            for (int a = 0; a < temp.Length; a++)
            {
                fundsID.Add(temp[a]);
            }
            string content;
            string HTML;
            //string url;
            double deltas;
            double sum1, sum2;
            //每个基金内的股票数据
            foreach (string ID in fundsID)
            {

                //content = wh.Read("..\\..\\stock\\" + ID + ".txt");
                //content = content.Substring(content.IndexOf("持仓截止日期"));
                //content = content.Substring(content.IndexOf("href") + 6);
                //url = content.Substring(0, content.IndexOf("'"));

                //取得每个基金下的股票id
                content = wh.GetContent("http://fund.eastmoney.com/f10/FundArchivesDatas.aspx?type=jjcc&code="+ID+"&topline=10&year=&month=&rt=0.6009964493629969");
                if(!content.Contains("<tbody>"))
                {
                    continue;
                }
                content = content.Substring(content.IndexOf("<tbody>"));
                content = content.Substring(0, content.IndexOf("</table>"));
                while (content.Contains("<tr>"))
                {
                    content = content.Substring(content.IndexOf("<tr>"));
                    //跳过无用数据
                    content = content.Substring(content.IndexOf("<td") + 3);
                    content = content.Substring(content.IndexOf("<td") + 3);
                    //找到id
                    content = content.Substring(content.IndexOf("<"));
                    string tmp1 = content.Substring(0, 2);
                    if (tmp1 == "<a")
                        content = content.Substring(content.IndexOf(">") + 1);
                    string stockkID = content.Substring(0, content.IndexOf("<"));
                    //找到name
                    content = content.Substring(content.IndexOf("<td") + 1);
                    content = content.Substring(content.IndexOf("<"));
                    string tmp2 = content.Substring(0, 2);
                    if (tmp1 == "<a")
                        content = content.Substring(content.IndexOf(">") + 1);
                    string stockkName = content.Substring(0, content.IndexOf("<"));

                    //进入每个股票在每个基金下变动的页面，找到股票增持减持数据
                    HTML = wh.GetContent("http://fund.eastmoney.com/f10/F10DataApi.aspx?type=ggxq&code="+ID+"&gpdm="+stockkID+"&rt=0.29900780686763406");
                    if(!HTML.Contains("2017-09-30"))
                    {
                        continue;
                    }
                    HTML = HTML.Substring(HTML.IndexOf("2017-09-30"));
                    //跳过无用数据
                    HTML = HTML.Substring(HTML.IndexOf("<td") + 3);
                    HTML = HTML.Substring(HTML.IndexOf("<td") + 3);
                    HTML = HTML.Substring(HTML.IndexOf("<td") + 3);
                    HTML = HTML.Substring(HTML.IndexOf(">")+1);
                    String SUM1 = HTML.Substring(0, HTML.IndexOf("<"));
                    sum1 = Convert.ToDouble(SUM1);

                    if (HTML.Contains("2017-06-30"))
                    {

                        HTML = HTML.Substring(HTML.IndexOf("2017-06-30"));
                        //跳过无用数据
                        HTML = HTML.Substring(HTML.IndexOf("<td") + 3);
                        HTML = HTML.Substring(HTML.IndexOf("<td") + 3);
                        HTML = HTML.Substring(HTML.IndexOf("<td") + 3);
                        HTML = HTML.Substring(HTML.IndexOf(">")+1);
                        String SUM2 = HTML.Substring(0, HTML.IndexOf("<"));
                        sum2 = Convert.ToDouble(SUM2);
                    }else
                    {
                        sum2 = 0;
                    }
                    deltas = sum1 - sum2;
                    deltas = Math.Round(deltas, 2);
                    bool matchs = false;
                    //判断是否已经存储，已有便累加数据，没有就add
                    foreach (Stockk sto in stockks)
                    {
                        if (sto.id == stockkID)
                        {
                            sto.delta += deltas;
                            matchs = true;
                            break;
                        }
                    }
                    if (!matchs)
                    {
                        Stockk st = new Stockk();
                        st.name = stockkName;
                        st.id = stockkID;
                        st.delta = deltas;
                        stockks.Add(st);
                    }                   
                }

                //排序
                List<Stockk> tmp = new List<Stockk>();
                bool IN;
                foreach (Stockk st in stockks)
                {
                    IN = false;
                    for (int i = 0; i < tmp.Count; i++)
                    {
                        if (tmp.ElementAt(i).delta < st.delta)
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

                //写入
                string result = "";
                for (int i = 0; i < tmp.Count; i++)
                {
                    result += tmp.ElementAt(i).name + "," + tmp.ElementAt(i).delta + "\n";
                }
                wh.inText(result, "result\\stockresult", "UTF8");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            getStockSort();
        }
    }
    public class Stockk
    {
        public string id { get; set; }
        public string name { get; set; }
        public double delta { get; set; }
    }
}
