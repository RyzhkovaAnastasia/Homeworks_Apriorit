using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.Repositories
{
    class StudentRepository
    {
        UniversityDBContext context;

        public StudentRepository(UniversityDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList();
        }
        public void SetStudents(Student student)
        {
            context.Add(student);
            context.SaveChanges();
        }
        public void UpdateStudents(Student student)
        {
            var oldStudent = context.Students.Where(x => x.Id == student.Id).FirstOrDefault();

            oldStudent.Name = student.Name;
            oldStudent.GroupId = student.GroupId;
            oldStudent.Group = student.Group;
            oldStudent.Address = student.Address;
            context.SaveChanges();
        }
        public void DeleteStudents(Student student)
        {
            context.Remove(student.Id);
        }
    }
}
