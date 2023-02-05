using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPlusDemoProject.Models;

public class Teacher
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public PersonInfo TeacherPerson { get; set; }
    public ICollection<Lesson> TeacherLessons { get; set; }
    public ContactInfo TeacherContact { get; set; }
}