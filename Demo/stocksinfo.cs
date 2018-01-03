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

namespace FjuColorForm
{
    public partial class stocksinfo : FrmMain
    {
        string ID;
        Thread td;
        WebHandler wh = new WebHandler();
        //初始化
        public stocksinfo(string id)
        {
            InitializeComponent();
            ID = id;
            ThreadStart ts = new ThreadStart(GetIntroduction);
            td = new Thread(ts);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        void GetIntroduction()
        {
            string url = @"http://fund.eastmoney.com/f10/FundArchivesDatas.aspx?type=jjcc&code=" + ID + "&topline=10&year=&month=&rt=0.029766627475606988";

            string data =wh.GetContent(url);
            //如果没有表格内容，则返回
            //string的contain方法是判断字符串是否有一段特定的字符
            if (!data.Contains("<tbody>"))
                return;
            if (!data.Contains("市场"))
            {
                data = data.Substring(data.IndexOf("<tbody>") + 7);
                data = data.Substring(0, data.IndexOf("</tbody>"));
                int index = 0;
                string tmp;
                //处理字符串，获取需要的信息
                while (data.Contains("<tr>"))
                {

                    DataGridViewRow row = new DataGridViewRow();

                    data = data.Substring(data.IndexOf("<td>") + 4);
                    tmp = data.Substring(0, data.IndexOf("<"));
                    this.Invoke((EventHandler)delegate
                    {
                        dataGridView1.Rows.Add(row);
                        dataGridView1.Rows[index].Cells[0].Value = tmp;
                    });

                    data = data.Substring(data.IndexOf("<td>") + 4);
                    tmp = data.Substring(data.IndexOf(">") + 1);
                    //tmp = tmp.Substring(0, tmp.IndexOf("</a"));
                    tmp = tmp.Substring(0, tmp.IndexOf("<"));
                    this.Invoke((EventHandler)delegate
                    {
                        dataGridView1.Rows[index].Cells[1].Value = tmp;
                    });

                    data = data.Substring(data.IndexOf("<td"));
                    data = data.Substring(data.IndexOf(">") + 1);
                    tmp = data.Substring(data.IndexOf(">") + 1);
                    tmp = tmp.Substring(0, tmp.IndexOf("<"));
                    this.Invoke((EventHandler)delegate
                    {
                        dataGridView1.Rows[index].Cells[2].Value = tmp;
                    });

                    //跳过无用数据
                    data = data.Substring(data.IndexOf("<td") + 3);
                    data = data.Substring(data.IndexOf("<td") + 3);
                    data = data.Substring(data.IndexOf("<td") + 3);


                    data = data.Substring(data.IndexOf("<td") + 3);
                    tmp = data.Substring(data.IndexOf(">") + 1);
                    tmp = tmp.Substring(0, tmp.IndexOf("<"));
                    this.Invoke((EventHandler)delegate
                    {
                        dataGridView1.Rows[index].Cells[3].Value = tmp;
                    });

                    data = data.Substring(data.IndexOf("<td") + 3);
                    tmp = data.Substring(data.IndexOf(">") + 1);
                    tmp = tmp.Substring(0, tmp.IndexOf("<"));
                    this.Invoke((EventHandler)delegate
                    {
                        dataGridView1.Rows[index].Cells[4].Value = tmp;
                    });

                    data = data.Substring(data.IndexOf("<td"));
                    tmp = data.Substring(data.IndexOf(">") + 1);
                    tmp = tmp.Substring(0, tmp.IndexOf("<"));
                    this.Invoke((EventHandler)delegate
                    {
                        dataGridView1.Rows[index].Cells[5].Value = tmp;
                    });
                    index++;
                }
            }
            else
            {
                data = data.Substring(data.IndexOf("<tbody>") + 7);
                data = data.Substring(0, data.IndexOf("</tbody>"));
                int index = 0;
                while (data.Contains("<tr>"))
                {

                    DataGridViewRow row = new DataGridViewRow();
                    this.Invoke((EventHandler)delegate
                    {
                        dataGridView1.Rows.Add(row);
                    });
                    for (int i = 0; i < 6; i++)
                    {
                        data = data.Substring(data.IndexOf("<td") + 3);
                        data = data.Substring(data.IndexOf(">") + 1);
                        string tmp = data.Substring(0, data.IndexOf("<"));
                        this.Invoke((EventHandler)delegate
                        {
                            dataGridView1.Rows[index].Cells[i].Value = tmp;
                        });
                    }
                    index++;
                }
            }
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            stockdetail form7 = new stockdetail(ID, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            form7.Show();
        }

        private void stocksinfo_Load(object sender, EventArgs e)
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
    }
}
