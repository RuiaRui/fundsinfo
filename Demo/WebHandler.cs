using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FjuColorForm
{
    class WebHandler
    {


       public string GetContent(string url)
        {
            string html = "";
            //发送查询请求
            WebRequest request = WebRequest.Create(url);
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
                //获得流
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                html = sr.ReadToEnd();
                response.Close();
            }
            catch (Exception ex)
            {
                //本机没有联网
                if (ex.GetType().ToString().Equals("System.Net.WebException"))
                {
                    MessageBox.Show("请检查你的计算机是否已连接上互联网。\n" + url, "提示");
                }
            }
            return html;
        }

        public void inText(string data, string name, string str = "UTF8")
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

       public List<string> GetAll()//搜索文件夹中的文件
        {
            //list数组步用指定长度
            List<string> b = new List<string>();

            //读取路径下的信息
            DirectoryInfo folder = new DirectoryInfo("..\\..\\stock\\");

            for (int i = 0; i < folder.GetFiles("*.txt").Count(); i++)
            {
                b.Add(folder.GetFiles("*.txt")[i].Name);
            }

            return b;
        }

        public string Read(string name)
        {
            StreamReader sr = new StreamReader("..\\..\\stock\\" + name, Encoding.UTF8);
            String data = sr.ReadToEnd();
            return data;
        }

    }
}
