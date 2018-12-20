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
    public partial class ViewExistingSemester : Form
    {
        public ViewExistingSemester()
        {
            InitializeComponent();
        }

        private void ViewExistingSemester_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("SELECT * FROM Semester;");
            temp.Columns.Add("[SemesterID]", typeof(string), "[SemesterID]");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "SemesterID";
            comboBox1.ValueMember = "SemesterID";
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) return;
            //Dept Field
            DbConnection load = new DbConnection();
            string query = "SELECT S.[Name] FROM Semester S WHERE SemesterID = '" + comboBox1.SelectedValue + "';";
            DataTable temp = load.Select(query);
            textBox1.Text = temp.Rows[0][0].ToString();
            //Cr hours
            query = "SELECT S.Year FROM Semester S WHERE SemesterID = '" + comboBox1.SelectedValue + "';";
            temp = load.Select(query);
            textBox2.Text = temp.Rows[0][0].ToString();
        }

        private void comboBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
