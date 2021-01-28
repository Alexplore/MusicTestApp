using System;
using System.Collections.Generic;

#nullable disable

namespace TestMusicApp
{
    public partial class Group
    {
        public Group(string GroupName, string GroupGenre)
        {
            Songs = new HashSet<Song>();
            this.GroupName = GroupName;
            this.GroupGenre = GroupGenre;
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupGenre { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
