using System;
using System.Collections.Generic;

#nullable disable

namespace TestMusicApp
{
    public partial class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string SongText { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public Song(string SongName, int GroupId) {
            this.SongName = SongName;
            this.GroupId = GroupId;
        }
    }
}
