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
    public partial class CourseSection : Form
    {
        public CourseSection()
        {
            InitializeComponent();
        }

        private void CourseSection_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("SELECT Semester.[Name] [SemName], Semester.Year [SemYr], Course.[CourseID], Course.[Name] [CoName], CourseOfferingID FROM Course,CourseOffering,Semester WHERE CourseID = Course_CourseID AND SemesterID = Semester_SemesterID;");
            temp.Columns.Add("FullName", typeof(string), "SemName + ' ' + SemYr + ' - ' + CourseID + ': ' + CoName");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "CourseOfferingID";
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedValue.ToString());
        }
    }
}
