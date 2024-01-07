using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANCN1
{
    public partial class frmTrangChu : Form
    {

        private List<Image> bannerImages = new List<Image>();
        private int currentImageIndex = 0;
        public frmTrangChu()
        {
            InitializeComponent();

            bannerImages.Add(Properties.Resources.banner1);
            bannerImages.Add(Properties.Resources.banner2);
            bannerImages.Add(Properties.Resources.banner3);
            bannerImages.Add(Properties.Resources.banner4);
            bannerImages.Add(Properties.Resources.banner5);
            timer1.Interval = 3000;
            timer1.Tick += timer1_Tick;
            timer1.Start();

            // Hiển thị hình ảnh đầu tiên
            pictureBox1.Image = bannerImages[currentImageIndex];
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            currentImageIndex++;
            if (currentImageIndex >= bannerImages.Count)
            {
                currentImageIndex = 0;
            }
            pictureBox1.Image = bannerImages[currentImageIndex];
        }
    }
}
