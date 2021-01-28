using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestMusicApp.Controllers
{
    class SongController
    {

        MusicGroupsDBContext MusicGroupsDBContext;

        public SongController(MusicGroupsDBContext MusicGroupsDBContext)
        {
            this.MusicGroupsDBContext = MusicGroupsDBContext;
        }
        public Song FindById(int id)
        {
            Song song = (from songs in MusicGroupsDBContext.Songs
                                   where songs.SongId == id
                                   select songs).First();
            return song;
        }

        public IQueryable<Song> ReadSongs()
        {
            return (from songs in MusicGroupsDBContext.Songs
                    select songs);
        }

        public void CreateSong(Song song)
        {
            MusicGroupsDBContext.Add(song);
            MusicGroupsDBContext.SaveChanges();
        }

        public void DeleteSong(Song song)
        {
            MusicGroupsDBContext.Remove(song);
            MusicGroupsDBContext.SaveChanges();
        }

        public void UpdateSong(Song song)
        {
            MusicGroupsDBContext.Update(song);
            MusicGroupsDBContext.SaveChanges();
        }

        public IQueryable<Song> SongsByGroupName(string groupName) {
            return (from songs in MusicGroupsDBContext.Songs
                    where songs.SongGroupFkNavigation.GroupName == groupName
                    select songs);
        }

    }
}
