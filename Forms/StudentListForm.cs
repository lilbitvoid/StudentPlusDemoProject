using Guna.UI2.WinForms;
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
    public partial class StudentListForm : Form
    {
        public StudentListForm()
        {
            InitializeComponent();
        }

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            using var context = new StudentContext();
            var groups = context
                .Groups
                .Select(group => group.Abbreviation)
                .ToList();
            guna2ComboBox1.DataSource = groups;
        }

        private void guna2ButtonSearch_Click(object sender, EventArgs e)
        {
            using var context = new StudentContext();
            var studentsData = context
                .Students
                .Include(obj => obj.StudentPerson)
                .Include(obj => obj.ContactInfo)
                .Include(obj => obj.StudentGroup)
                .Where(x => x.StudentGroup.Abbreviation.Equals(guna2ComboBox1.SelectedItem))
                .Select(x => new {
                    x.Id,
                    x.StudentPerson.PersonName,
                    x.StudentPerson.Middlename,
                    x.StudentPerson.Surename,
                    x.StudentPerson.PersonGender.GenderChar,
                    x.StudentGroup.YearGroupCreate,
                    x.StudentGroup.Abbreviation,
                    x.ContactInfo.PhoneNumber
                })
                .ToList();
            guna2DataGridView1.DataSource = studentsData;
            guna2DataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using var context = new StudentContext();
            var studentsData = context
                .Students
                .Include(obj => obj.StudentPerson)
                .Include(obj => obj.ContactInfo)
                .Include(obj => obj.StudentGroup)
                .Where(x => x.StudentGroup.Abbreviation.Equals(guna2ComboBox1.SelectedItem))
                .Select(x => new {
                    x.Id,
                    x.StudentPerson.PersonName,
                    x.StudentPerson.Middlename,
                    x.StudentPerson.Surename,
                    x.StudentPerson.PersonGender.GenderChar,
                    x.StudentGroup.YearGroupCreate,
                    x.StudentGroup.Abbreviation,
                    x.ContactInfo.PhoneNumber
                })
                .ToList();
            guna2DataGridView1.DataSource = studentsData;
            guna2DataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.None).Visible = false;
        }

        private void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var studentRow = guna2DataGridView1.CurrentRow;
            new PersonalInfoForm(int.Parse(studentRow.Cells[0].Value.ToString()!)).ShowDialog();

        }
    }
}
