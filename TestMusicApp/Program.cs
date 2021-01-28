using System;
using System.Linq;
using TestMusicApp.Controllers;

namespace TestMusicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupController groupController = new GroupController(new MusicGroupsDBContext());
            SongController songController = new SongController(new MusicGroupsDBContext());

            using (MusicGroupsDBContext musicGroupsDBContext = new MusicGroupsDBContext())
            { 
                //Main menu
                while (true) {
                    Console.WriteLine("\nMusic Space\n" +
                        "1.  Show groups.\n" +
                        "2.  Show songs.\n" +
                        "3.  Create group.\n" +
                        "4.  Delete group.\n" +
                        "5.  Update group.\n" +
                        "6.  Create song.\n" +
                        "7.  Delete song.\n" +
                        "8.  Update song.\n" +
                        "9.  Show songs of choosen group.\n" +
                        "10. Exit.\n");
                    int enteredNumber = Convert.ToInt32(Console.ReadLine());
                    switch (enteredNumber) {
                        case 1://Output of all groups
                            var Groups = groupController.ReadGroups().ToList();
                            Console.WriteLine("\nId   Name    Genre\n");
                            foreach (Group group in Groups) {
                                Console.WriteLine($"{group.GroupId}    {group.GroupName}    {group.GroupGenre}");
                            }
                            break;
                        case 2://Output of all songs
                            var songs = songController.ReadSongs().ToList();
                            Console.WriteLine("\nId   Name    Group\n");
                            foreach (Song Song in songs)
                            {
                                Group group = (from groups in musicGroupsDBContext.Groups
                                                where groups.GroupId == Song.SongGroupFk
                                                select groups).FirstOrDefault();
                                Console.WriteLine($"{Song.SongId}    {Song.SongName}    {group.GroupName}");
                            }
                                break;
                        case 3://Creating new a group
                            Console.WriteLine("Enter data of new group\n" +
                                "Name of group:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Genre:");
                            string genre = Console.ReadLine();
                            Group newGroup = new Group(name, genre);
                            groupController.CreateGroup(newGroup);
                            break;
                        case 4://Removeing a group
                            Console.WriteLine("Enter id of the group to delete\n" +
                                "Id of group:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            groupController.DeleteGroup(groupController.FindById(id));
                            break;
                        case 5://Updating a group
                            Console.WriteLine("Enter id of the group to update\n" +
                                "Id of group:");
                            id = Convert.ToInt32(Console.ReadLine());
                            Group Group = groupController.FindById(id);
                            Console.WriteLine($"Name - {Group.GroupName}, Genre - {Group.GroupGenre}\n" +
                                $"Enter new Name:");
                            name = Console.ReadLine();
                            Console.WriteLine("Genre:");
                            genre = Console.ReadLine();
                            groupController.UpdateGroup(id, name, genre);
                            break;
                        case 6://Creating a new song
                            Console.WriteLine("Enter data of new song\n" +
                                "Name of song:");
                            name = Console.ReadLine();
                            Console.WriteLine("Id of a group:");
                            int groupId = Convert.ToInt32(Console.ReadLine());
                            Song newSong = new Song(name, groupId);
                            songController.CreateSong(newSong);
                            break;
                        case 7://Removing a song
                            Console.WriteLine("Enter id of the song to delete\n" +
                                "Id of song:");
                            id = Convert.ToInt32(Console.ReadLine());
                            songController.DeleteSong(songController.FindById(id));
                            break;
                        case 8://Upadting a song
                            Console.WriteLine("Enter id of the song to update\n" +
                                "Id of song:");
                            id = Convert.ToInt32(Console.ReadLine());
                            Song song = songController.FindById(id);
                            Group = (from groups in musicGroupsDBContext.Groups
                             where groups.GroupId == song.SongGroupFk
                             select groups).FirstOrDefault();
                            Console.WriteLine($"Name - {song.SongName}, group - {Group.GroupName}\n" +
                                $"Enter new Name:");
                            name = Console.ReadLine();
                            Console.WriteLine("Id of a group:");
                            groupId = Convert.ToInt32(Console.ReadLine());
                            songController.UpdateSong(id, name, groupId);
                            break;
                        case 9:
                            Console.WriteLine("Enter name of group:");
                            songs = songController.SongsByGroupName(Console.ReadLine()).ToList();
                            Console.WriteLine("\nId   Name\n");
                            foreach (Song Song in songs)
                            { 
                                Console.WriteLine($"{Song.SongId}    {Song.SongName}");
                            }
                            break;
                        case 10:
                            System.Environment.Exit(1);
                            break;
                    }
                }
            }
        }
    }
}
