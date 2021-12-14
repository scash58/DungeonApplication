using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Dungeon
    {

        //props
        //public int NbrofRooms { get; set; }
        //public List<string> Rooms { get; set; }
        //public List<Monster> RoomMonsters { get; set; }

        ////ctor
        //public Dungeon() { }

        //public Dungeon(Monster[] baseMonsters, Monster[] bossMonsters, int roomNbr)
        //{
        //    //Dungeon returnedDungeon = new Dungeon();
        //    int randomIndexBase = new Random().Next(baseMonsters.Length);
        //    int randomIndexBoss = new Random().Next(bossMonsters.Length);

        //    for (int i = 1; i <= roomNbr; i++)
        //    {
        //        if (i == roomNbr)
        //        {
        //            Rooms.Add(GetRoom());
        //            RoomMonsters.Add(bossMonsters[randomIndexBoss]);
        //        }
        //        else
        //        {
        //            Rooms.Add(GetRoom());
        //            RoomMonsters.Add(baseMonsters[randomIndexBase]);
        //        }

        //    }

        //}

        //methods
        //This Method will return a Dungeon with a set number or rooms and monster 
        //with a bose fight in the final room
        //public static Dungeon setUpDungeon(Monster[] baseMonsters, Monster[] bossMonsters, int roomNbr)
        //{
        //    Dungeon returnedDungeon = new Dungeon();
        //    int randomIndexBase = new Random().Next(baseMonsters.Length);
        //    int randomIndexBoss = new Random().Next(bossMonsters.Length);

        //    for (int i = 1; i <= roomNbr; i++)
        //    {
        //        if (i == roomNbr)
        //        {
        //            returnedDungeon.Rooms.Add(GetRoom());
        //            returnedDungeon.RoomMonsters.Add(bossMonsters[randomIndexBoss]);
        //        }
        //        else
        //        {
        //            returnedDungeon.Rooms.Add(GetRoom());
        //            returnedDungeon.RoomMonsters.Add(baseMonsters[randomIndexBase]);
        //        }

        //    }

        //    return returnedDungeon;
        //}

        public static string printDungeon(Monster monster)
        {
            string printRoom = GetRoom() + "\nStanding in this room is " + monster.Name;
            return printRoom;
        }

        private static string GetRoom()
        {
            string[] rooms =
            {
                "The room is dark and musty with the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on you.",
                "This chamber appears to be completely empty. The walls are made of natural stone chiselled flat and straight.",
                "A huge iron cage lies on its side in this room, and its gate rests open on the floor. ",
                "You feel a sense of foreboding upon peering into this cavernous chamber. At its center lies a low heap of refuse.",
                "This small bare chamber holds nothing but a large ironbound chest, which is big enough for a man to fit in and bears a heavy iron lock",
            };

            return rooms[new Random().Next(rooms.Length)];
        }


    }
}
