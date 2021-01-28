using System;
using System.Linq;

namespace TestMusicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MusicGroupsDBContext musicGroupsDBContext = new MusicGroupsDBContext())
            {
                musicGroupsDBContext.Database.EnsureDeleted();
                musicGroupsDBContext.Database.EnsureCreated();

                Group group = new Group("Linkin Park", "Alternative rock");
                
                Song[] songs = new Song[5];
                songs[0] = new Song("Castle of glass", 1);
                //songs[0].Group = (Group)musicGroupsDBContext.Groups.Where(p => p.GroupId == songs[0].GroupId);
                songs[1] = new Song("Numb", 1);
                //songs[1].Group = (Group)musicGroupsDBContext.Groups.Where(p => p.GroupId == songs[1].GroupId);
                songs[2] = new Song("What I`ve done", 1);
                //songs[2].Group = (Group)musicGroupsDBContext.Groups.Where(p => p.GroupId == songs[2].GroupId);
                songs[3] = new Song("New devide", 1);
                //songs[3].Group = (Group)musicGroupsDBContext.Groups.Where(p => p.GroupId == songs[3].GroupId);
                songs[4] = new Song("Breaking the habit", 1);
                //songs[4].Group = (Group)musicGroupsDBContext.Groups.Where(p => p.GroupId == songs[4].GroupId);
                musicGroupsDBContext.Groups.Add(group);
                musicGroupsDBContext.Songs.AddRange(songs);
                musicGroupsDBContext.SaveChanges();
            }

            using (MusicGroupsDBContext musicGroupsDBContext = new MusicGroupsDBContext())
            {
                Group group = musicGroupsDBContext.Groups.FirstOrDefault();
                var songs = musicGroupsDBContext.Songs.Where(p=>p.GroupId == group.GroupId);
                foreach (Song s in songs)
                {
                    Console.WriteLine($"{s.Group.GroupName} - {s.SongName}.");
                }
            }
        }
    }
}
