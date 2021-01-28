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
        public Group FindById(int Id)
        {
            Group Group = ((Group)(from groups in MusicGroupsDBContext.Groups
                           where groups.GroupId == Id
                           select groups));
            return  Group;
        }

        public IQueryable<Group> ReadGroups()
        {
            return (from groups in MusicGroupsDBContext.Groups
                            select groups);
        }

        public void CreateGroup(Group Group) {
            MusicGroupsDBContext.Add(Group);
            MusicGroupsDBContext.SaveChanges();
        }

        public void DeleteGroup(Group Group)
        {
            MusicGroupsDBContext.Remove(Group);
            MusicGroupsDBContext.SaveChanges();
        }

        public void UpdateGroup(Group Group)
        {
            MusicGroupsDBContext.Update(Group);
            MusicGroupsDBContext.SaveChanges();
        }

    }
}
