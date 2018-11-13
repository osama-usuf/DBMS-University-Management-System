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
    public partial class AddFaculty : Form
    {
        public AddFaculty()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbConnection add = new DbConnection();

            //Add Address Entry
            int newAddrID = Convert.ToInt32(add.Select("SELECT AddressID FROM Address ORDER BY AddressID DESC;").Rows[0][0]) + 1;
            string query = "INSERT INTO [Address] VALUES (" + newAddrID + ", '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "');";
            add.Inserts(query);

            //Add Faculty Entry
            query = "INSERT INTO Faculty VALUES(" + textBox1.Text + ", " + newAddrID + ", '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "', '" + dateTimePicker1.Value + "', " + textBox8.Text + ")";
            add.Inserts(query);

            //Add Department Entry
            query = "INSERT INTO Faculty_Department VALUES (" + textBox1.Text + ", " + comboBox3.SelectedValue + ", " + 1 + ");";
            add.Inserts(query);
            if (checkBox1.Checked == true)
            {
                query = "INSERT INTO Faculty_Department VALUES (" + textBox1.Text + ", " + comboBox2.SelectedValue + ", " + 0 + ");";
                add.Inserts(query);
            }

            //Add Designation Info



            MessageBox.Show("Faculty Added!");
            this.Close();
        }

        private void AddFaculty_Load(object sender, EventArgs e)
        {
            DbConnection add = new DbConnection();
            comboBox3.DataSource = add.Select("SELECT * FROM Department;");
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "DepartmentID";
        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            DbConnection add = new DbConnection();
            string updateMinor = "SELECT * FROM Department WHERE DepartmentID != " + comboBox3.SelectedValue + ";";
            comboBox2.DataSource = add.Select(updateMinor);
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "DepartmentID";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = !comboBox2.Enabled;
        }
    }
}
