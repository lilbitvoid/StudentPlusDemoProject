using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StudentPlusDemoProject.Contexts;
using StudentPlusDemoProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var groups = context
                .Groups
                .Select(group => group.Abbreviation)
                .ToList();
            guna2ComboBox1.DataSource = groups;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using var context = new StudentContext();
            var studentsData = context
                .Students
                .Include(obj => obj.StudentPerson)
                .Include(obj => obj.ContactInfo)
                .Include(obj => obj.StudentGroup)
                .Where(x => x.StudentGroup.Abbreviation.Equals(guna2ComboBox1.SelectedItem))
                //.Select(obj => $"{obj.StudentPerson.PersonName} {obj.StudentPerson.Middlename} {obj.StudentPerson.Surename}")
                .Select(x => x)
                .ToArray();
            checkedListBoxAbsStudent.Items.AddRange(studentsData);
        }

        private async void guna2ButtonSendReport_Click(object sender, EventArgs e)
        {
            using var context = new StudentContext();
            var dialogResult = guna2MessageDialog1.Show();
            if (dialogResult.Equals(System.Windows.Forms.DialogResult.Yes))
            {
                var transfereArray = new Student[checkedListBoxAbsStudent.CheckedItems.Count];
                checkedListBoxAbsStudent.CheckedItems.CopyTo(transfereArray, 0);
                var absStudentsList = new List<Student>();
                foreach (var student in transfereArray)
                {
                    var studentFromDb = context.Students.FirstOrDefault(x => x.Equals(student));
                    if (studentFromDb is not null)
                    {
                        absStudentsList.Add(studentFromDb);
                    } 
                }
                    foreach (var student in absStudentsList)
                    {
                    if (student.Absenteeisms is null) student.Absenteeisms = new Collection<Absenteeism>();
                        student.Absenteeisms.Add(
                            new Absenteeism()
                            {
                                Date = DateOnly.FromDateTime(DateTime.Now)
                            });
                } //change that ((( fix multiply adding
                await context.SaveChangesAsync();
            }
        }
    }
}
