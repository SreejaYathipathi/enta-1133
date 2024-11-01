using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    public abstract class Room
    {
        public string Type { get; protected set; } // Type of the room
        public Dictionary<string, Room> Connections { get; private set; } = new Dictionary<string, Room>();
        public int RoomNumber { get; set; } // Assigns each room a number

        protected Room(string type)
        {
            Type = type;
        }


        public abstract void OnEntered();
        public abstract void OnSearched();
        public abstract void OnExited();

        public void ConnectRoom(string direction, Room room)
        {
            if (!Connections.ContainsKey(direction))
            {
                Connections[direction] = room; // Connect to the specified room
                room.Connections[GetOppositeDirection(direction)] = this; // Connect back to the current room
            }
        }

        private string GetOppositeDirection(string direction)
        {
            return direction switch
            {
                "north" => "south",
                "south" => "north",
                "east" => "west",
                "west" => "east",
                _ => direction
            };
        }

        public void DisplayConnections()
        {
            Console.WriteLine($"{Type} room #{RoomNumber} connections:");
            foreach (var connection in Connections)
            {
                Console.WriteLine($"- {connection.Key} leads to {connection.Value.Type} room #{connection.Value.RoomNumber}");
            }
        }
    }
}
