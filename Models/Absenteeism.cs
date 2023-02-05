using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPlusDemoProject.Models;

class Absenteeism
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public ICollection<Student> AbsentStudents { get; set; }
}