using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework.Models
{
    public class Group
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string GroupName { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public IEnumerable<Student> Students {get; set;}
    }
}
