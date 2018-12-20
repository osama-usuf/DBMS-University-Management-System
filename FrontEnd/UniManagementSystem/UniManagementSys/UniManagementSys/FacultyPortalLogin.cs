using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniManagementSys
{
    public partial class FacultyPortalLogin : Form
    {
        MainForm mf = null;
        public FacultyPortalLogin(MainForm mf)
        {
            this.mf = mf;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Variables.fid = textBox1.Text.ToString();
            FacultyPortal fp = new FacultyPortal();
            fp.Show();
            this.Hide();
        }

        private void FacultyPortalLogin_Load(object sender, EventArgs e)
        {

        }

        private void FacultyPortalLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Show();
        }
    }
}
