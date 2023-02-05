using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPlusDemoProject.Models;

public class Absenteeism
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is Absenteeism)
        {
            var abs = obj as Absenteeism;
            return this.Date.Equals(abs!.Date);
        }
        return false;
    }
}