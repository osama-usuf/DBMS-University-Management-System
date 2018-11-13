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
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            comboBox1.DataSource = load.Select("SELECT * FROM Department;");
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "DepartmentID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbConnection add = new DbConnection();
            string course = "INSERT INTO Course VALUES('" + textBox1.Text + "'," + comboBox1.SelectedValue + ",'" + textBox3.Text + "','" + richTextBox1.Text + "'," + textBox2.Text + ");";
            add.Inserts(course);
            MessageBox.Show("Course Added!");
            this.Close();
            //Add Prereq
        }
    }
}
