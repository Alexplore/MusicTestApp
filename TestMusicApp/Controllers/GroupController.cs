using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestMusicApp.Controllers
{
    class GroupController
    {
        MusicGroupsDBContext MusicGroupsDBContext;

        public GroupController(MusicGroupsDBContext MusicGroupsDBContext) {
            this.MusicGroupsDBContext = MusicGroupsDBContext;
        }
        public Group FindById(int id)
        {
            Group group = (from groups in MusicGroupsDBContext.Groups
                           where groups.GroupId == id
                           select groups).First();
            return group;
        }

        public IQueryable<Group> ReadGroups()
        {
            return (from groups in MusicGroupsDBContext.Groups
                            select groups);
        }

        public void CreateGroup(Group group) {
            MusicGroupsDBContext.Add(group);
            MusicGroupsDBContext.SaveChanges();
        }

        public void DeleteGroup(Group group)
        {
            MusicGroupsDBContext.Remove(group);
            MusicGroupsDBContext.SaveChanges();
        }

        public void UpdateGroup(Group group)
        {
            MusicGroupsDBContext.Update(group);
            MusicGroupsDBContext.SaveChanges();
        }

    }
}
