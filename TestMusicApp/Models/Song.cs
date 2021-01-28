using System;
using System.Collections.Generic;

#nullable disable

namespace TestMusicApp
{
    public partial class Song
    {
        public Song()
        {
        }
        public Song(string SongName, int SongGroupFk)
        {
            this.SongName = SongName;
            this.SongGroupFk = SongGroupFk;
        }
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string SongText { get; set; }
        public int SongGroupFk { get; set; }

        public virtual Group SongGroupFkNavigation { get; set; }
    }
}
