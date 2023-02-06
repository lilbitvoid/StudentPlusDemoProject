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
using IronPdf;

namespace StudentPlusDemoProject.Forms
{
    public partial class PersonalInfoForm : Form
    {
        PdfDocument pdfDocument;
        public PersonalInfoForm(int id)
        {
            var renderer = new ChromePdfRenderer();
            InitializeComponent();
            using var context = new StudentContext();
            var student = context
                .Students
                .Include(obj => obj.StudentPerson)
                .Include(obj => obj.StudentPerson.PersonGender)
                .Include(obj => obj.ContactInfo)
                .Include(obj => obj.StudentGroup)
                .Include(obj => obj.Absenteeisms)
                .Single(x => x.Id.Equals(id));
            guna2HtmlLabelName.Text = $"Student Name: {student.StudentPerson.PersonName}";
            guna2CirclePictureBox1.ImageLocation = Path.Combine(@".\resource", student.StudentPerson.PhotoPath);
            guna2HtmlLabelAge.Text = $"Student Age: {DateTime.Today.Year - student.StudentPerson.BirthDate.Year}";
            guna2HtmlLabelMiddlename.Text = $"Student Middlename: {student.StudentPerson.Middlename}";
            guna2HtmlLabelSurename.Text = $"Student Surename: {student.StudentPerson.Surename}";
            guna2HtmlLabelGender.Text = $"Student Gender: {student.StudentPerson.PersonGender.Name}";
            var abs = student
                .Absenteeisms
                .Where(x => x.Date.Month.Equals(DateTime.Now.Month) && x.Date.Year.Equals(DateTime.Now.Year))
                .Select(x => new { x.Date })
                .ToArray();
            guna2DataGridView1.DataSource = abs;
            var absDateForHtml = String.Join("<br>", abs.Select(x => x.Date.ToString()).ToArray());
            #region html
            var htmlTemplate = $@"<!DOCTYPE html>
<page size=""A4""></page>
<html>
  <body style=""width: 29.7cm; height: 21cm"">
    <center><h2>Report on Student {student.StudentPerson.PersonName} {student.StudentPerson.Middlename} {student.StudentPerson.Surename}</h2></center>
    <p style=""font-size: 16px"">Date - {DateOnly.FromDateTime(DateTime.Now)}</p>
    <p style=""font-size: 16px""></p>Absenteeism:</p>
    <p style=""font-size: 16px""></p>{absDateForHtml}</p>
<br>
<br>
<p>Curator signature:</p>
  </body>
</html>
";
            #endregion html
            pdfDocument = renderer.RenderHtmlAsPdf(htmlTemplate);
        }
        private void PersonalInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2ButtonExport_Click(object sender, EventArgs e)
        {
            var HtmlLine = new HtmlToPdf();
            //Get HTML Text from User.
            //Create SaveFileDialog for get Save PDF file path.
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Save PDF",
                CheckPathExists = true,
                DefaultExt = "pdf",
                Filter = "pdf files (*.pdf)|*.pdf",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            //If User press Save.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                pdfDocument.SaveAs(filePath);
                guna2MessageDialog1.Show();
            }
        }
    }
}
