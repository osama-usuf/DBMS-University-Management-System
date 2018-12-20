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
    public partial class ViewDepartment : Form
    {
        public ViewDepartment()
        {
            InitializeComponent();
        }

        private void ViewDepartment_Load(object sender, EventArgs e)
        {
                DbConnection load = new DbConnection();
                DataTable temp = load.Select("SELECT * FROM Department;");
                temp.Columns.Add("[Name]", typeof(string), "[Name]");
                comboBox1.DataSource = temp;
                comboBox1.DisplayMember = "[Name]";
                comboBox1.ValueMember = "DepartmentID";
                comboBox1.Text = "Please Select a Department to see Details!";
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            string query = "SELECT D.DepartmentID FROM Department D WHERE DepartmentID = '" + comboBox1.SelectedValue + "';";
            DataTable temp = load.Select(query);
            textBox1.Text = temp.Rows[0][0].ToString();
            //Cr hours
            query = "SELECT D.ContactNo FROM Department D WHERE DepartmentID = '" + comboBox1.SelectedValue + "';";
            temp = load.Select(query);
            textBox2.Text = temp.Rows[0][0].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
