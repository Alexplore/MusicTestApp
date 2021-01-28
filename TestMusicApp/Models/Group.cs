using System;
using System.Collections.Generic;

#nullable disable

namespace TestMusicApp
{
    public partial class Group
    {
        public Group()
        {
            Songs = new HashSet<Song>();
        }
        public Group(string GroupName, string GroupGenre)
        {
            this.GroupName = GroupName;
            this.GroupGenre = GroupGenre;
        }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupGenre { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
