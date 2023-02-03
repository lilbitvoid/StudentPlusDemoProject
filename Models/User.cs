using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentPlusDemoProject.Models
{
    internal class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        public int Password { get; set; }
    }
}
