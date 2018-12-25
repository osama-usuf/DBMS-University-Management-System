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
    public partial class FacultyPortal : Form
    {
        public FacultyPortal()
        {
            InitializeComponent();
        }

        private void FacultyPortal_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            if (Variables.fid == null) return;
            string query = "SELECT * FROM Faculty WHERE FacultyID = " + Variables.fid;
            DataTable temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            textBox9.Text = temp.Rows[0][2].ToString();
            textBox1.Text = Variables.fid;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FacultyPersonal fp = new FacultyPersonal();
            fp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FacultySemester fs = new FacultySemester();
            fs.Show();
        }
    }
}
