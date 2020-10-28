using EntityFramework.Models;
using EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static FacultyRepository CreateNewFaculty(Faculty faculty)
        {
            var hogwarts = new UniversityDBContext();
            var facultyRep = new FacultyRepository(hogwarts);
            facultyRep.SetFaculty(faculty);
            return facultyRep;
        }
        static void PrintFacultiesInfo(IEnumerable<Faculty> facultyList)
        {
            Console.WriteLine("--- List of faculties ---");
            foreach (var faculty in facultyList)
            {
                Console.WriteLine($"Name: {faculty.FacultyName}");
                Console.WriteLine($"Dean: {faculty.DeanName}");
                Console.WriteLine($"Founder: {faculty.FacultyFounder}");
                if (faculty.Groups != null)
                {
                    Console.WriteLine("-- Group: ");
                    foreach (var group in faculty.Groups)
                    {
                        Console.WriteLine(group.GroupName);
                        if (group.Students != null)
                        {
                            Console.WriteLine("- Student: ");
                            foreach (var student in group.Students)
                            {
                                Console.WriteLine($"Name: {student.Name}");
                                if(student.Address != null) 
                                    Console.WriteLine($"Address: {student.Address}");
                            }
                        }
                    }
                    Console.WriteLine("\n\n");
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {
                //Create a new faculty, groups, students 

                Faculty dumbledoreFaculty = new Faculty
                {
                    FacultyName = "Albus Dumbledore",
                    FacultyFounder = "Albus Dumbledore",
                    DeanName = "Albus Dumbledore",
                    Groups = new Group[]{
                    new Models.Group() { 
                        GroupName = "First year Dumbledore",
                        Students = new Student[]{
                            new Models.Student(){ Name = "Neville Longbottom"},
                            new Models.Student() { Name = "Dean Thomas"}
                            }
                        }
                    }
                };

                //Add new data to DB 
                var facultyList = CreateNewFaculty(dumbledoreFaculty);

                //Print all faculties with theirs groups and students
                PrintFacultiesInfo(facultyList.GetFaculties());
            }
            catch
            {
                Console.WriteLine("Invalid DB connection");
            }
        }
    }
}


