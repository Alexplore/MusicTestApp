using System;
using System.Linq;
using TestMusicApp.Controllers;

namespace TestMusicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupController GroupController = new GroupController(new MusicGroupsDBContext());
            SongController SongController = new SongController(new MusicGroupsDBContext());

            //Блок инициализации с созданием группы Linkin Park и 5 песен этой группы
            using (MusicGroupsDBContext musicGroupsDBContext = new MusicGroupsDBContext())
            {
                musicGroupsDBContext.Database.EnsureDeleted();
                musicGroupsDBContext.Database.EnsureCreated();

                Group Group = new Group("Linkin Park", "Alternative rock");
                GroupController.CreateGroup(Group);

                Song[] Songs = new Song[5];
                Songs[0] = new Song("Castle of glass", 1);
                Songs[1] = new Song("Numb", 1);
                Songs[2] = new Song("What I`ve done", 1);
                Songs[3] = new Song("New devide", 1);
                Songs[4] = new Song("Breaking the habit", 1);

                for (int i = 0; i < Songs.Length; i++ ) {
                    SongController.CreateSong(Songs[i]);
                }

                while (true) {
                    Console.WriteLine("\nMusic Space\n" +
                        "1.  Show groups.\n" +
                        "2.  Show songs.\n" +
                        "3.  Create group\n" +
                        "4.  Delete group\n" +
                        "5.  Update group\n" +
                        "6.  Find group by id\n" +
                        "7.  Create song\n" +
                        "8.  Delete song\n" +
                        "9.  Update song\n" +
                        "9.  Find song by id\n" +
                        "10. Show choisen group songs\n" +
                        "11. Exit\n");
                    int enteredNumber = Convert.ToInt32(Console.ReadLine());
                    switch (enteredNumber) {
                        case 1:
                            var Groups = GroupController.ReadGroups().ToList();
                            Console.WriteLine("\nId   Name    Genre\n");
                            foreach (Group group in Groups) {
                                Console.WriteLine($"{group.GroupId}    {group.GroupName}    {group.GroupGenre}");
                            }
                            break;
                        case 2:
                            var songs = SongController.ReadSongs().ToList();
                            Console.WriteLine("\nId   Name    Group\n");
                            foreach (Song Song in songs)
                            {
                                Group = (from groups in musicGroupsDBContext.Groups
                                                where groups.GroupId == Song.SongGroupFk
                                                select groups).FirstOrDefault();
                                Console.WriteLine($"{Song.SongId}    {Song.SongName}    {Group.GroupName}");
                            }
                                break;
                    case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                    }
                }
            }
        }
    }
}
