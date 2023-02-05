using Microsoft.EntityFrameworkCore;
using StudentPlusDemoProject.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPlusDemoProject.Forms
{
    public partial class PersonalInfoForm : Form
    {
        public PersonalInfoForm(int id)
        {
            InitializeComponent();
            using var context = new StudentContext();
            var student = context
                .Students
                .Include(obj => obj.StudentPerson)
                .Include(obj => obj.ContactInfo)
                .Include(obj => obj.StudentGroup)
                .Single(x => x.Id.Equals(id));
            guna2HtmlLabelName.Text = $"Student name: {student.StudentPerson.PersonName}";
            guna2CirclePictureBox1.ImageLocation = Path.Combine(@".\resource", student.StudentPerson.PhotoPath);
        }

        private void PersonalInfoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
