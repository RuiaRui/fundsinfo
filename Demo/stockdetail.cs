using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FjuColorForm
{
    public partial class stockdetail : FrmMain
    {
        string fundID;
        String stockID;
        Thread td;
        WebHandler wh = new WebHandler();

        public stockdetail(string fundid, string stockid)
        {
            InitializeComponent();
            fundID = fundid;
            stockID = stockid;
            ThreadStart ts = new ThreadStart(getDetailed);
            td = new Thread(ts);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        public void getDetailed()
        {
            string url = "http://fund.eastmoney.com/f10/F10DataApi.aspx?type=ggxq&code=" + fundID + "&gpdm=" + stockID + "&rt=0.29900780686763406";
            String html = wh.GetContent(url);
            Regex re = new Regex("(?<=>).*?(?=<)", RegexOptions.None);
            List<string[]> display = new List<string[]>();
            if (!(html == "var apidata = { content:\"\",quarter:\"\"}"))
            {
                html = html.Substring(html.IndexOf("<tbody>"));
                while (html.Contains("<tr>"))
                {
                    html = html.Substring(html.IndexOf("<tr>"));
                    string result = html.Substring(0, html.IndexOf("</tr>"));
                    MatchCollection mc = re.Matches(result);

                    string[] rd = new string[5];
                    int i = 0;
                    int pass = 1;
                    foreach (Match funds in mc)
                    {
                        if (pass % 2 == 1)
                        {
                            pass++;
                            continue;
                        }
                        rd[i] = funds.Value;
                        i++;
                        pass++;
                    }
                    display.Add(rd);
                    html = html.Substring(html.IndexOf("</tr>") + 5);
                }
                for (int i = 0; i < display.Count; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    int x = i;
                    this.Invoke((EventHandler)delegate
                    {
                        dataGridView1.Rows.Add(row);
                        dataGridView1.Rows[x].Cells[0].Value = display[x][0];
                        dataGridView1.Rows[x].Cells[1].Value = display[x][1];
                        dataGridView1.Rows[x].Cells[2].Value = display[x][2];
                        dataGridView1.Rows[x].Cells[3].Value = display[x][3];
                        dataGridView1.Rows[x].Cells[4].Value = display[x][4];
                    });
                }
            }
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Add(row);
                dataGridView1.Rows[0].Cells[0].Value = "对不起无法获取该网页";

            }
        }

        private void stockdetail_Load(object sender, EventArgs e)
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
            //AnimateWindow(this.Handle, 2000,  AW_HOR_NEGATIVE);\
            dataGridView1.ForeColor = System.Drawing.Color.Black;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = color;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
        }
    }
        
   

}
