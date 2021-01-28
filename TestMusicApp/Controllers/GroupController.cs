using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestMusicApp.Controllers
{
    class GroupController
    {
        MusicGroupsDBContext musicGroupsDBContext;

        public GroupController(MusicGroupsDBContext musicGroupsDBContext) {
            this.musicGroupsDBContext = musicGroupsDBContext;
        }
        public Group FindById(int id)
        {
            Group group = ((Group)(from groups in musicGroupsDBContext.Groups
                           where groups.GroupId == id
                           select groups));
            return  group;
        }

        public IQueryable<Group> findAll()
        {
            return (from groups in musicGroupsDBContext.Groups
                            select groups);
        }

    }
}
