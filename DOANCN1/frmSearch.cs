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
    public partial class frmSearch : Form
    {
        public string TuKhoa
        {
            get { return txtTuKhoa.Text; }
        }
        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
