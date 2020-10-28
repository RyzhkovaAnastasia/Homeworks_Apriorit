using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework.Models
{
    public class Student
    {
        [Required]
        public int Id { set; get; }

        [Required]
        [MinLength(5)]
        [MaxLength(150)]
        public string Name { set; get; }

        [MaxLength(150)]
        public string Address { set; get; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        public Group Group { get; set; }
    }
}
