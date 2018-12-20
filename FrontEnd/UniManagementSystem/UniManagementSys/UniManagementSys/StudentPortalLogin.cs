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
    public partial class StudentPortalLogin : Form
    {
        MainForm mf = null;
        public StudentPortalLogin(MainForm mf)
        {
            this.mf = mf;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Variables.sid = textBox1.Text.ToString();
                DbConnection load = new DbConnection();
                string query = "SELECT * FROM Student, [Address] WHERE Address_AddressID = AddressID AND StudentID = " + Variables.sid;
                DataTable temp = load.Select(query);
                if (temp.Rows.Count == 0) { MessageBox.Show("INVALID ID"); }
                else
                {
                    StudentPortal sp = new StudentPortal();
                    sp.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Correct Login Details."); return;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentPortalLogin_Load(object sender, EventArgs e)
        {

        }

        private void StudentPortalLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Show();
        }
    }
}
