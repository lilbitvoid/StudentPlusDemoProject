using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPlusDemoProject.Models;

public class PersonInfo
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string PersonName { get; set; }
    public string Surename { get; set; }
    public string Middlename { get; set; }
    public Gender PersonGender { get; set; }
    public bool IsOrphan { get; set; }
    public string PhotoPath { get; set; }
}