using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    public class GameManager
    {
        public static AsciiArt art = new AsciiArt();
        public static Player player = new Player(100);
        public static MapGenerator mapGenerator;
        private List<Room> rooms;
        private int currentRoomIndex;

        public GameManager()
        {
            mapGenerator = new MapGenerator(player);
            rooms = mapGenerator.GetRooms();
            currentRoomIndex = 0; // Start at the first room
        }

        internal void Play()
        {
            Intro(); // Display introduction
            Rules(); // Show the game rules
            PlayerWantToPlay(); // Ask player if they want to continue
            GamePlay(); // Begin the main gameplay loop
        }

        // Displays welcome art, asks for player name, and allows them to change their name
        public void Intro()
        {
            art.Welcome(); // Show welcome ASCII art
            player.PlayerName(); // Ask for player's name
            player.ChangeName(); // Allow player to change their name
        }

        // Provides the game rules based on user input
        void Rules()
        {
            Console.WriteLine("\nDo you want to learn how you are going to die?");
            Console.WriteLine("\nEnter [yes] or [no]\n");
            string ruleChoice = (Console.ReadLine() ?? "").ToLower(); // Get player's choice

            // Validate the input until a valid response is given
            while (ruleChoice != "yes" && ruleChoice != "no")
            {
                Console.WriteLine("\nDon't create your own commands in my game. Enter only the things that are given to you.\n");
                ruleChoice = (Console.ReadLine() ?? "").ToLower();
            }

            if (ruleChoice == "yes")
            {
                art.About(); // Display the rules or 'about' section if yes
            }
            else if (ruleChoice == "no")
            {
                return; // Continue without showing rules if no
            }
        }

        // Ask the player if they want to continue playing
        void PlayerWantToPlay()
        {
            Console.WriteLine("\nDo you want to continue living?");
            Console.WriteLine("\nEnter [yes] or [no]\n");
            string wantToPlay = (Console.ReadLine() ?? "").ToLower(); // Get player's response

            // Validate the input until a valid response is given
            while (wantToPlay != "yes" && wantToPlay != "no")
            {
                Console.WriteLine("\nDon't create your own commands in my game. Enter only the things that are given to you.\n");
                wantToPlay = (Console.ReadLine() ?? "").ToLower();
            }

            if (wantToPlay == "yes")
            {
                GamePlay(); // Start the gameplay if yes
            }
            else if (wantToPlay == "no")
            {
                art.Died(); // Show death art if no
                art.GameOver(); // Display game over message
                Environment.Exit(0); // Exit the game
            }
        }

        public void GamePlay()
        {
            Console.WriteLine("Welcome to the Adventure Game!");

            while (true)
            {
                Room currentRoom = rooms[currentRoomIndex];
                currentRoom.OnEntered(); // Enter the current room

                // Show commands after the OnEntered logic is done.
                bool shouldExit = false; // Flag to control room exit

                while (!shouldExit) // Inner loop for handling commands
                {
                    Console.WriteLine("Type 'exit' to exit room, 'inventory' to check inventory, or a direction (north, south, east, west) to move.");
                    string command = (Console.ReadLine() ?? "").ToLower();

                    if (command == "exit")
                    {
                        currentRoom.OnExited(); // Call OnExited to handle exit logic
                        shouldExit = true; // Set the flag to exit the inner loop
                    }
                    else if (command == "inventory")
                    {
                        player.inventory.ShowInventory(); // Show the inventory
                    }
                    else if (currentRoom.Connections.ContainsKey(command))
                    {
                        currentRoom.OnExited(); // Call OnExited to handle exiting the current room
                        currentRoomIndex = rooms.IndexOf(currentRoom.Connections[command]); // Move to the new room
                        shouldExit = true; // Set the flag to exit the inner loop
                    }
                    else
                    {
                        Console.WriteLine("Unknown command. Please try again.");
                    }
                }
            }
        }
    }
}
