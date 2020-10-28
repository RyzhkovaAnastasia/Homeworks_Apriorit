using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework.Models
{
    public class Faculty
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FacultyName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(150)]
        public string DeanName { set; get; }

        [Required]
        [MinLength(5)]
        [MaxLength(150)]
        public string FacultyFounder { set; get; }
        public IEnumerable<Group> Groups { set; get; }
    }
}
