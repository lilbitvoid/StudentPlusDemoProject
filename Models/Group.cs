using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPlusDemoProject.Models;

public class Group
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateOnly YearGroupCreate { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }    
}