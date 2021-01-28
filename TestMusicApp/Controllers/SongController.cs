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
        public Song FindById(int Id)
        {
            Song Song = ((Song)(from songs in MusicGroupsDBContext.Songs
                                   where songs.SongId == Id
                                   select songs));
            return Song;
        }

        public IQueryable<Song> ReadSongs()
        {
            return (from songs in MusicGroupsDBContext.Songs
                    select songs);
        }

        public void CreateSong(Song Song)
        {
            MusicGroupsDBContext.Add(Song);
            MusicGroupsDBContext.SaveChanges();
        }

        public void DeleteSong(Song Song)
        {
            MusicGroupsDBContext.Remove(Song);
            MusicGroupsDBContext.SaveChanges();
        }

        public void UpdateSong(Song Song)
        {
            MusicGroupsDBContext.Update(Song);
            MusicGroupsDBContext.SaveChanges();
        }

        public IQueryable<Song> SongsByGroupName(string GroupName) {
            return (from songs in MusicGroupsDBContext.Songs
                    where songs.SongGroupFkNavigation.GroupName == GroupName
                    select songs);
        }

    }
}
