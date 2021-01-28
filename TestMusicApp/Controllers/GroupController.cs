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
            if (group != null)
            {
                MusicGroupsDBContext.Add(group);
                MusicGroupsDBContext.SaveChanges();
            }
        }

        public void DeleteGroup(Group group)
        {
            if (group != null)
            {
                MusicGroupsDBContext.Remove(group);
                MusicGroupsDBContext.SaveChanges();
            }
        }

        public void UpdateGroup(int id, string name, string genre)
        {
            Group group = FindById(id);
            if (group != null)
            {
                group.GroupName = name;
                group.GroupGenre = genre;
                MusicGroupsDBContext.Groups.Update(group);
                MusicGroupsDBContext.SaveChanges();
            }
        }

    }
}
