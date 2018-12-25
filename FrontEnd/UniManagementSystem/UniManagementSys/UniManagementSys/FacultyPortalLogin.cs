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
        {/*
            Variables.fid = textBox1.Text.ToString();
            FacultyPersonal fp = new FacultyPersonal();
            fp.Show();
            this.Hide();
        */
            try
            {
                Variables.fid = textBox1.Text.ToString();
                DbConnection load = new DbConnection();
                string query = "SELECT * FROM Faculty, [Address] WHERE Address_AddressID = AddressID AND FacultyID = " + Variables.fid;
                DataTable temp = load.Select(query);
                if (temp.Rows.Count == 0) { MessageBox.Show("INVALID ID"); }
                else
                {
                    FacultyPortal sp = new FacultyPortal();
                    sp.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Correct Login Details."); return;
            }
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
