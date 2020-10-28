using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.Repositories
{
    public class FacultyRepository
    {
        UniversityDBContext context;

        public FacultyRepository(UniversityDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Faculty> GetFaculties()
        {
            return context.Faculties.ToList();
        }
        public void SetFaculty(Faculty faculty)
        {
            context.Add(faculty);
            context.SaveChanges();
        }
        public void UpdateFaculty(Faculty faculty)
        {
            var oldFaculty = context.Faculties.Where(x => x.Id == faculty.Id).FirstOrDefault();

            oldFaculty.FacultyName = faculty.FacultyName;
            oldFaculty.FacultyFounder = faculty.FacultyFounder;
            oldFaculty.DeanName = faculty.DeanName;
            oldFaculty.Groups = faculty.Groups;
            context.SaveChanges();
        }
        public void DeleteFaculty(Faculty faculty)
        {
            context.Remove(faculty.Id);
        }
    }
}
