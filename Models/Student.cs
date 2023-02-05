using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPlusDemoProject.Models;

public class Student 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public PersonInfo StudentPerson { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public Group StudentGroup { get; set; }
    public ICollection<Absenteeism> Absenteeisms { get; set; }
    public ICollection<Grade> Grades { get; set; }
    public override string ToString()
    {
        return $"{StudentPerson.PersonName} {StudentPerson.Middlename} {StudentPerson.Surename}";
    }
    public override bool Equals(object? obj)
    {
        if (obj is Student)
        {
            var st = obj as Student;
            return st.Id == Id;
        }
        return base.Equals(obj);
    }
}