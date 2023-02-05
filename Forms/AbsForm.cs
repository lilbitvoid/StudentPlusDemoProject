using Microsoft.EntityFrameworkCore;
using StudentPlusDemoProject.Contexts;
using StudentPlusDemoProject.Models;
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
    public partial class AbsForm : Form
    {
        public AbsForm()
        {
            InitializeComponent();
        }

        private void AbsForm_Load(object sender, EventArgs e)
        {
            using var context = new StudentContext();
            var studentsData = context
                .Students
                .Include(obj => obj.StudentPerson)
                .Include(obj => obj.ContactInfo)
                .Include(obj => obj.StudentGroup)
                .Select(x => new {x.Id,
                    x.StudentPerson.Name,
                    x.StudentPerson.Middlename,
                    x.StudentPerson.Surename,
                    x.StudentPerson.PersonGender,
                    x.StudentGroup.YearGroupCreate,
                    x.StudentGroup.Abbreviation,
                    x.ContactInfo.PhoneNumber})
                .ToList();
            guna2DataGridView1.DataSource = studentsData;
            guna2DataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }
    }
}
