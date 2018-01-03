using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FjuColorForm
{
    public partial class about : FjuColorForm.FrmMain
    {
        public about()
        {
            InitializeComponent();
        }

        private void about_Load(object sender, EventArgs e)
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

            SysButtonItems.Clear();
            CanResize = false;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowDrawIcon = false;
            Text = "关于";
        }
    }
}
