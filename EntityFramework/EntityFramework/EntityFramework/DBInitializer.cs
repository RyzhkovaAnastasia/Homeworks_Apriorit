using EntityFramework.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework
{
    class DBInitializer
    {
        public static void Initialize(UniversityDBContext context)
        {
            var Faculties = new Models.Faculty[] {
                new Models.Faculty() { FacultyName = "Rawenclaw", DeanName = "Filius Flitwick", FacultyFounder = "Rowena Ravenclaw" },
                new Models.Faculty() { FacultyName = "Gryffindor", DeanName = "Minerva McGonagall", FacultyFounder = "Godric Gryffindor" },
                new Models.Faculty() { FacultyName = "Slytherin", DeanName = "Severus Snape", FacultyFounder = "Salazar Slytherin" },
                new Models.Faculty() { FacultyName = "Hufflepuff", DeanName = "Pomona Sprout", FacultyFounder = "Helga Hufflepuff" }
                };

            if (!context.Faculties.Any())
            {
                context.Faculties.AddRange(Faculties);
            }
            context.SaveChanges();

            var Groups = new Models.Group[] {
                new Models.Group() { GroupName = "First year Gryffindor", Faculty = Faculties[1] },
                new Models.Group() { GroupName = "First year Slytherin", Faculty = Faculties[2] },
                new Models.Group() { GroupName = "First year Rawenclaw", Faculty = Faculties[0] },
                new Models.Group() { GroupName = "First year Hufflepuff", Faculty = Faculties[3] },
                new Models.Group() { GroupName = "Fourth year Gryffindor", Faculty = Faculties[1] }
                };

            if (!context.Groups.Any())
            {
                context.Groups.AddRange(Groups);
            }
            context.SaveChanges();

            var Students = new Models.Student[] {
                new Models.Student() {
                    Name = "Harry Potter",
                    Address = "4 Privet Drive, Little Whinging, Surrey England, Great Britain",
                    Group = Groups[0] },
                new Models.Student() { Name = "Hermione Granger", Group = Groups[0] },
                new Models.Student() { Name = "Percy Weasley", Group = Groups[4]},
                new Models.Student() { Name = "Draco Lucius Malfoy", Group = Groups[1] },
                new Models.Student() { Name = "Luna Lovegood", Group = Groups[2] },
                new Models.Student() { Name = "Cedric Diggory", Group = Groups[3] },
                new Models.Student() { Name = "Cho Chang", Group = Groups[2]}
                };

            if (!context.Students.Any())
            {
                context.Students.AddRange(Students);
            }
            context.SaveChanges();
        }
    }
}
