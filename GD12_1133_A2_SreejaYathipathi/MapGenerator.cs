using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    public class MapGenerator
    {
        // Method to generate rooms for the game
        public List<Room> GenerateRooms()
        {
            List<Room> rooms = new List<Room>(); // List to store generated rooms
            int roomNumber = 1; // Starting room number

            // Add the first Treasure Room to the list
            var treasureRoom = new TreasureRoom { RoomNumber = roomNumber++ }; // Create first treasure room
            rooms.Add(treasureRoom); // Add the treasure room to the list

            // Randomly determine the number of Normal Rooms (either 1 or 2)
            Random roomRnd = new Random();
            int numberOfNormalRooms = roomRnd.Next(1, 3); // Randomly decide the number of normal rooms

            // Add Normal Rooms based on the randomly determined count
            for (int i = 0; i < numberOfNormalRooms; i++)
            {
                var normalRoom = new NormalRoom { RoomNumber = roomNumber++ }; // Create a normal room
                rooms.Add(normalRoom); // Add the normal room to the list
            }

            // Randomly decide how many Treasure Rooms to add (either 3 or 4)
            int numberOfTreasureRooms = roomRnd.Next(3, 5); // Randomly determine the number of treasure rooms
            for (int i = 0; i < numberOfTreasureRooms; i++)
            {
                var treasureRoomIntermediate = new TreasureRoom { RoomNumber = roomNumber++ }; // Create a treasure room
                rooms.Add(treasureRoomIntermediate); // Add the treasure room to the list
            }

            // Randomly decide how many Combat Rooms to add (either 3 or 4)
            int numberOfCombatRooms = roomRnd.Next(3, 5); // Randomly determine the number of combat rooms
            for (int i = 0; i < numberOfCombatRooms; i++)
            {
                var combatRoomIntermediate = new CombatRoom { RoomNumber = roomNumber++ }; // Create a combat room
                rooms.Add(combatRoomIntermediate); // Add the combat room to the list
            }

            // Add a final Combat Room at the end of the list
            var finalCombatRoom = new CombatRoom { RoomNumber = roomNumber++ }; // Create the final combat room
            rooms.Add(finalCombatRoom); // Add the final combat room to the list

            // Shuffle the list of rooms to randomize the order in which they appear
            ShuffleRooms(rooms);

            // Establish connections between rooms for navigation
            for (int i = 0; i < rooms.Count; i++)
            {
                // Connect each room to the next one in the list
                if (i < rooms.Count - 1)
                {
                    rooms[i].AddConnection(rooms[i + 1]); // Connect current room to the next room
                    rooms[i + 1].AddConnection(rooms[i]); // Connect the next room back to the current room
                }
            }

            return rooms; // Return the list of generated rooms
        }

        // Method to shuffle the list of rooms randomly
        private void ShuffleRooms(List<Room> rooms)
        {
            Random rnd = new Random(); // Create a random number generator
            int n = rooms.Count; // Get the count of rooms
            while (n > 1) // Continue shuffling until only one room is left
            {
                int k = rnd.Next(n--); // Get a random index in the remaining range
                var temp = rooms[n]; // Store the current room temporarily
                rooms[n] = rooms[k]; // Swap the current room with the randomly chosen room
                rooms[k] = temp; // Assign the temporary stored room to the random index
            }
        }
    }
}
