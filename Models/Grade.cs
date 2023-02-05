using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPlusDemoProject.Models;

public class Grade
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public ICollection<Lesson> LessonGrade { get; set; }
}