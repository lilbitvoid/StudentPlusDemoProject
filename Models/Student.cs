using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPlusDemoProject.Models;

public class Student 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public PersonInfo StudentPerson { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public Group StudentGroup { get; set; }
}