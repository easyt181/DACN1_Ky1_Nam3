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
    public partial class frmGiaoDienQL : Form
    {
     
        public Button currentButton;
        public void ActivateButton(object btnSender)
        {

            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = ColorTranslator.FromHtml("#FFFFFF"); ;
                    currentButton.ForeColor = ColorTranslator.FromHtml("#000000");
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }

        public void DisableButton()
        {
            foreach (Control previousBtn in panel_Left.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = ColorTranslator.FromHtml("#C0C0C0");
                    previousBtn.ForeColor = ColorTranslator.FromHtml("#000000");
                    previousBtn.Font = new System.Drawing.Font("Roboto Slab", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        public Form currentFormChild;

        public void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public frmGiaoDienQL()
        {
            InitializeComponent();
            
        }

        private void frmGiaoDienQL_Load(object sender, EventArgs e)
        {
            lbGetTen.Text = frmDangNhap.Ten +"!";
            OpenChildForm(new frmTrangChu());
            panel_Top.BackColor = ColorTranslator.FromHtml("#DDDDDD");
            panel_Left.BackColor = ColorTranslator.FromHtml("#DDDDDD");
            button1.BackColor = ColorTranslator.FromHtml("#C0C0C0");
            button2.BackColor = ColorTranslator.FromHtml("#C0C0C0");
            button3.BackColor = ColorTranslator.FromHtml("#C0C0C0");
            
            button5.BackColor = ColorTranslator.FromHtml("#C0C0C0");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ActivateButton(sender);
            OpenChildForm(new frmQLKhoHang());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmQLDonHang());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmQLUuDai());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmQLKhachHang());

        }

        private void llbDangXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            frmDangNhap GoBack = new frmDangNhap();
            GoBack.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTrangChu());

        }

        private void llbDoiMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDoiMatKhau frmDoiMatKhau = new frmDoiMatKhau();
            frmDoiMatKhau.Show();   
        }
    }
}

