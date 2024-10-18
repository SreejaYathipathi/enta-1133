using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    // GameManager class handles the overall game logic
    internal class GameManager
    {
        public static AsciiArt art = new AsciiArt(); // Instance of AsciiArt for visual elements
        Player Player = new Player(); // Player instance representing the user
        private Room? currentRoom; // The room the player is currently in
        List<Room>? rooms; // List of all rooms in the game

        // Constructor initializes rooms, sets the player's health, and assigns the starting room
        public void Start()
        {
            MapGenerator mapGenerator = new MapGenerator(); // Map generator for room creation
            rooms = mapGenerator.GenerateRooms(); // Generate rooms using the MapGenerator
            currentRoom = InitializeRooms(); // Set the initial room for the player
            Player.PlayerHp(100); // Initialize player with full health (e.g., 100)
        }

        // Play method starts the game loop
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
            Player.PlayerName(); // Ask for player's name
            Player.ChangeName(); // Allow player to change their name
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

        // Main gameplay loop
        public void GamePlay()
        {
            while (true)
            {
                currentRoom.OnEntered(Player); // Trigger OnEntered method for the current room
                string command = (Console.ReadLine() ?? "").ToLower(); // Get player's command

                if (command == "exit") // Exit the game if the player types "exit"
                {
                    Console.WriteLine("Exiting the game. Goodbye!");
                    break;
                }

                ProcessCommand(command); // Process the player's command
            }
        }

        // Process player commands and trigger respective actions
        private void ProcessCommand(string command)
        {
            switch (command)
            {
                case "search":
                    currentRoom.OnSearched(Player); // Search the current room
                    break;
                case "leave":
                    Console.WriteLine("Which direction do you want to go? (n/s/e/w)");
                    string direction = (Console.ReadLine() ?? "").ToLower(); // Get the direction
                    NavigateToRoom(direction); // Navigate to the specified room
                    break;
                case "attack":
                    Console.WriteLine("Which weapon do you want to use?");
                    string weaponName = Console.ReadLine() ?? ""; // Get the weapon name
                    Console.WriteLine("Which attack? (z/x/c)");
                    string attackType = (Console.ReadLine() ?? "").ToLower(); // Get the attack type

                    // Check if the current room is a combat room
                    if (currentRoom is CombatRoom combatRoom)
                    {
                        combatRoom.PlayerAttack(weaponName, attackType); // Player performs an attack
                    }
                    else
                    {
                        Console.WriteLine("You can only attack in a combat room!"); // Error if not in combat room
                    }
                    break;
                case "drink":
                    Console.WriteLine("Which consumable do you want to drink?");
                    string consumableName = Console.ReadLine() ?? ""; // Get consumable name
                    Player.DrinkConsumable(consumableName, Player.GetPlayerInventory()); // Player drinks the consumable
                    break;
                default:
                    Console.WriteLine("Invalid command. Try 'search', 'leave', 'attack', or 'drink'."); // Invalid command handler
                    break;
            }
        }

        // Handles room navigation based on player's direction input
        private void NavigateToRoom(string direction)
        {
            int nextRoomIndex = -1;

            switch (direction)
            {
                case "n": // Move north
                    nextRoomIndex = 1; // Example index for north room
                    break;
                case "s": // Move south
                    nextRoomIndex = 2; // Example index for south room
                    break;
                case "e": // Move east
                    nextRoomIndex = 3; // Example index for east room
                    break;
                case "w": // Move west
                    nextRoomIndex = 4; // Example index for west room
                    break;
                default:
                    Console.WriteLine("Invalid direction. Please choose n (north), s (south), e (east), or w (west).");
                    return; // Invalid direction handler
            }

            // Check if the next room exists within the room list
            if (nextRoomIndex >= 0 && nextRoomIndex < rooms.Count)
            {
                currentRoom = rooms[nextRoomIndex]; // Move to the next room
                currentRoom.OnEntered(Player); // Trigger the OnEntered method for the new room
            }
            else
            {
                Console.WriteLine("There is no room in that direction."); // Handle invalid room transition
            }
        }

        // Initializes rooms and sets the starting room
        private Room InitializeRooms()
        {
            return rooms.First(); // Set the initial room to the first room in the list
        }

        private int currentRoomIndex = 0; // Tracks the index of the current room

        // Gets the next room in the list, wrapping around if needed

        public void NextRoom()
        {
            if (currentRoomIndex < rooms.Count - 1) // Check if there's a next room
            {
                currentRoomIndex++;
                Room currentRoom = rooms[currentRoomIndex]; // Get the current room
                Console.WriteLine($"Entered: {currentRoom.GetType().Name}"); // Display room type
            }
            else
            {
                Console.WriteLine("No more rooms."); // Handle end of rooms
            }
        }
    }
}
