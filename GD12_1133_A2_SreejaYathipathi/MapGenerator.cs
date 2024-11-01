using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    public class MapGenerator
    {
        private List<Room> rooms;
        private Random random;
        private Player player;
        private int mapSize = 3;
        private int allRoom;
        public Room currentRoom;
        public Room lastRoom;

        public MapGenerator(Player player)
        {
            this.player = player;
            rooms = new List<Room>();
            random = new Random();
            allRoom = mapSize * mapSize;
            GenerateMap();
        }

        private void GenerateMap()
        {
            rooms.Clear();

            var startingRoom = new TreasureRoom();
            rooms.Add(startingRoom);
            currentRoom = startingRoom;

            for (int i = 1; i < allRoom - 1; i++)
            {
                rooms.Add(RandomRoomGenerator());
            }

            var bossRoom = new CombatRoom(player);
            rooms.Add(bossRoom);
            lastRoom = bossRoom;

            for (int i = 0; i < rooms.Count; i++)
            {
                rooms[i].RoomNumber = i;
            }

            ArrangeRoomsInGrid();
        }

        private Room RandomRoomGenerator()
        {
            int chance = random.Next(100);
            if (chance < 15)
            {
                return new NormalRoom();
            }
            else if (chance < 65)
            {
                return new TreasureRoom();
            }
            else
            {
                return new CombatRoom(player);
            }
        }

        private void ArrangeRoomsInGrid()
        {
            int roomIndex = 0;
            for (int z = 0; z < mapSize; z++) // Loop through rows (z)
            {
                for (int x = 0; x < mapSize; x++) // Loop through columns (x)
                {
                    if (roomIndex < rooms.Count)
                    {
                        // Connect rooms based on grid layout
                        if (x > 0) // Connect west
                        {
                            rooms[roomIndex].ConnectRoom("west", rooms[roomIndex - 1]);
                        }
                        if (x < mapSize - 1) // Connect east
                        {
                            rooms[roomIndex].ConnectRoom("east", rooms[roomIndex + 1]);
                        }
                        if (z > 0) // Connect south
                        {
                            int southRoomIndex = roomIndex - mapSize;
                            if (southRoomIndex >= 0)
                            {
                                rooms[roomIndex].ConnectRoom("south", rooms[southRoomIndex]);
                            }
                        }
                        if (z < mapSize - 1) // Connect north
                        {
                            int northRoomIndex = roomIndex + mapSize;
                            if (northRoomIndex < rooms.Count)
                            {
                                rooms[roomIndex].ConnectRoom("north", rooms[northRoomIndex]);
                            }
                        }
                        roomIndex++;
                    }
                }
            }
        }

        public void DisplayMapOverview()
        {
            Console.WriteLine("Map Overview:");
            foreach (var room in rooms)
            {
                room.DisplayConnections();
            }
        }
        public List<Room> GetRooms()
        {
            return rooms;
        }
    }
}
