using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPlusDemoProject.Models;

public class Gender
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public char GenderChar { get; set; }
}