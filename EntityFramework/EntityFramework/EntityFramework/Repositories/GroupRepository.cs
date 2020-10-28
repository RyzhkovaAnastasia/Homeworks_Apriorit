using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.Repositories
{
    class GroupRepository
    {
        UniversityDBContext context;

        public GroupRepository(UniversityDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Group> GetGroups()
        {
            return context.Groups.ToList();
        }
        public void SetGroup(Group group)
        {
            context.Add(group);
            context.SaveChanges();
        }
        public void UpdateGroup(Group group)
        {
            var oldGroup = context.Groups.Where(x => x.Id == group.Id).FirstOrDefault();

            oldGroup.Students = group.Students;
            oldGroup.Faculty = group.Faculty;
            oldGroup.GroupName = group.GroupName;
            oldGroup.FacultyId = group.FacultyId;
            context.SaveChanges();
        }
        public void DeleteGroup(Group group)
        {
            context.Remove(group.Id);
        }
    }
}
