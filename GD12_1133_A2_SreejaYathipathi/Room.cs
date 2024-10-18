using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    public abstract class Room
    {
        public List<Room> ConnectedRooms { get; private set; } = new List<Room>(); // List of rooms connected to this room
        public int RoomNumber { get; set; } // Room number to identify the room

        protected Item[]? items; // Array to hold items in the room

        // Abstract methods to be implemented by derived classes
        public abstract void OnEntered(Player player); // Called when a player enters the room
        public abstract void OnSearched(Player player); // Called when a player searches the room
        public abstract void OnExited(Player player); // Called when a player exits the room

        // Method to shuffle a list of items randomly
        protected void ShuffleItems(List<Item> items)
        {
            if (items == null || items.Count == 0) return; // Exit if the list is null or empty

            Random shuffleRandom = new Random(); // Create a random number generator
            int n = items.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = shuffleRandom.Next(0, i + 1); // Generate a random index
                // Swap items[i] with items[j]
                Item temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        // Abstract method to get available directions from the room
        public abstract List<string> GetAvailableDirections();

        // Method to add a connection to another room
        public void AddConnection(Room room)
        {
            ConnectedRooms.Add(room); // Add the connected room to the list
        }

        // Method to show available directions to the player
        protected void ShowAvailableDirections()
        {
            if (ConnectedRooms.Count > 0)
            {
                Console.WriteLine($"Available directions from Room {RoomNumber}:");
                foreach (var room in ConnectedRooms)
                {
                    Console.WriteLine($"- {room.GetType().Name} (Room {room.RoomNumber})"); // Display each connected room
                }
            }
            else
            {
                Console.WriteLine("No available directions."); // Notify if no directions are available
            }
        }
    }

    // Normal Room class that inherits from Room
    public class NormalRoom : Room
    {
        private List<Item> allItems; // List of all possible items in the room

        // Constructor to initialize the normal room with items
        public NormalRoom()
        {
            // Define all possible items in the treasure room
            allItems = new List<Item>
            {
                new Dagger(), // Example item
                new SmallHealingPotion() // Example item
            };
        }

        // Method called when a player enters the normal room
        public override void OnEntered(Player player)
        {
            Console.WriteLine("You have entered a Treasure Room. You can search for treasures or exit."); // Notify player of room entry

            Console.WriteLine("Do you want to search the room? (y/n)"); // Ask player if they want to search
            string searchChoice = (Console.ReadLine() ?? "").ToLower(); // Read player input

            if (searchChoice == "y")
            {
                OnSearched(player); // Call the search method
            }
            else
            {
                GetAvailableDirections(); // Show available directions
            }
        }

        // Method called when a player searches the room
        public override void OnSearched(Player player)
        {
            Console.WriteLine("You search the treasure room."); // Notify player that they are searching
            GenerateRandomItems(); // Generate random items found in the room
            if (items != null && items.Length > 0) // Check if there are items to display
            {
                foreach (var item in items) // Loop through each item found
                {
                    Console.WriteLine($"You found a {item.Name}. Do you want to pick it up? (y/n)"); // Ask player if they want to pick up the item
                    string choice = (Console.ReadLine() ?? "").ToLower(); // Read player input
                    if (choice == "y")
                    {
                        player.PlayerInventory.AddItem(item); // Add item to player's inventory directly
                        Console.WriteLine($"{item.Name} picked up."); // Notify player of item pickup
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} not picked up."); // Notify player that the item was not picked up
                    }
                }
            }
            ShowAvailableDirections(); // Show available directions
            player.PlayerInventory.Display(); // Display the player's inventory
            Console.WriteLine("Do you want to go to the next room? (y/n)"); // Ask if player wants to move to the next room
            string goToNextRoom = (Console.ReadLine() ?? "").ToLower(); // Read player input

            if (goToNextRoom == "y")
            {
                // Here you would implement the logic to move to the next connected room
                // This is a simplified example; you might want to manage room transitions better.
                // For example, you can randomly select the next room or allow the player to choose.
                if (ConnectedRooms.Count > 0)
                {
                    Room nextRoom = ConnectedRooms[0]; // Choose the first connected room (for simplicity)
                    nextRoom.OnEntered(player); // Enter the next room
                }
            }
            else if (goToNextRoom == "n") // If the player chooses not to go
            {
                GameManager.art.Died(); // Call the Died method
                GameManager.art.GameOver(); // Call the GameOver method
                Environment.Exit(0); // Exit the game
            }
        }

        // Method to generate random items found in the normal room
        private void GenerateRandomItems()
        {
            Random NormalRnd = new Random(); // Create a random number generator
            List<Item> itemsToShuffle = new List<Item>(allItems); // Copy the list of all items

            // Shuffle the copied list
            ShuffleItems(itemsToShuffle);

            // Randomly choose the number of items to display (3 to 5)
            int numberOfItems = NormalRnd.Next(1, Math.Min(3, itemsToShuffle.Count + 1));
            items = new Item[numberOfItems]; // Initialize the items array

            // Select the first numberOfItems from the shuffled list
            for (int i = 0; i < numberOfItems; i++)
            {
                items[i] = itemsToShuffle[i]; // Assign unique items to the items array
            }
        }

        // Method called when a player exits the Normal Room
        public override void OnExited(Player player)
        {
            Console.WriteLine("You have exited the Normal Room."); // Notify player of room exit
        }

        // Method to get available directions from the Normal Room
        public override List<string> GetAvailableDirections()
        {
            List<string> directions = new List<string>(); // Initialize the list of directions
            foreach (var room in ConnectedRooms)
            {
                directions.Add($"To {room.GetType().Name} (Room {room.RoomNumber})"); // Add direction to the list
            }
            return directions; // Return list of directions
        }
    }

    // Treasure Room class that inherits from Room
    public class TreasureRoom : Room
    {
        private List<Item> allItems; // List of all possible items in the treasure room

        // Constructor to initialize the treasure room with items
        public TreasureRoom()
        {
            // Define all possible items in the treasure room
            allItems = new List<Item>
            {
                new LongSword(), // Example item
                new Dagger(), // Example item
                new PoleArm(), // Example item
                new MediumHealingPotion(), // Example item
                new LargeHealingPotion() // Example item
            };
        }

        // Method called when a player enters the treasure room
        public override void OnEntered(Player player)
        {
            Console.WriteLine("You have entered a Treasure Room. You can search for treasures or exit."); // Notify player of room entry

            Console.WriteLine("Do you want to search the room? (y/n)"); // Ask player if they want to search
            string searchChoice = (Console.ReadLine() ?? "").ToLower(); // Read player input

            if (searchChoice == "y")
            {
                OnSearched(player); // Call the search method
            }
            else
            {
                GetAvailableDirections(); // Show available directions
            }
        }

        // Method called when a player searches the treasure room
        public override void OnSearched(Player player)
        {
            Console.WriteLine("You search the treasure room."); // Notify player that they are searching
            GenerateRandomItems(); // Generate random items found in the room
            if (items != null && items.Length > 0) // Check if there are items to display
            {
                foreach (var item in items) // Loop through each item found
                {
                    Console.WriteLine($"You found a {item.Name}. Do you want to pick it up? (y/n)"); // Ask player if they want to pick up the item
                    string choice = (Console.ReadLine() ?? "").ToLower(); // Read player input
                    if (choice == "y")
                    {
                        player.PlayerInventory.AddItem(item); // Add item to player's inventory directly
                        Console.WriteLine($"{item.Name} picked up."); // Notify player of item pickup
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} not picked up."); // Notify player that the item was not picked up
                    }
                }
            }
            ShowAvailableDirections(); // Show available directions
            player.PlayerInventory.Display(); // Display the player's inventory
            Console.WriteLine("Do you want to go to the next room? (y/n)"); // Ask if player wants to move to the next room
            string goToNextRoom = (Console.ReadLine() ?? "").ToLower(); // Read player input

            if (goToNextRoom == "y")
            {
                // Here you would implement the logic to move to the next connected room
                // This is a simplified example; you might want to manage room transitions better.
                // For example, you can randomly select the next room or allow the player to choose.
                if (ConnectedRooms.Count > 0)
                {
                    Room nextRoom = ConnectedRooms[0]; // Choose the first connected room (for simplicity)
                    nextRoom.OnEntered(player); // Enter the next room
                }
            }
            else if (goToNextRoom == "n") // If the player chooses not to go
            {
                GameManager.art.Died(); // Call the Died method
                GameManager.art.GameOver(); // Call the GameOver method
                Environment.Exit(0); // Exit the game
            }
        }

        // Method to generate random items found in the treasure room
        private void GenerateRandomItems()
        {
            Random treasureRnd = new Random(); // Create a random number generator
            List<Item> itemsToShuffle = new List<Item>(allItems); // Copy the list of all items

            // Shuffle the copied list
            ShuffleItems(itemsToShuffle);

            // Randomly choose the number of items to display (3 to 5)
            int numberOfItems = treasureRnd.Next(3, Math.Min(5, itemsToShuffle.Count + 1));
            items = new Item[numberOfItems]; // Initialize the items array

            // Select the first numberOfItems from the shuffled list
            for (int i = 0; i < numberOfItems; i++)
            {
                items[i] = itemsToShuffle[i]; // Assign unique items to the items array
            }
        }

        // Method called when a player exits the Treasure Room
        public override void OnExited(Player player)
        {
            Console.WriteLine("You have exited the Treasure Room."); // Notify player of room exit
        }

        // Method to get available directions from the Treasure Room
        public override List<string> GetAvailableDirections()
        {
            List<string> directions = new List<string>(); // Initialize the list of directions
            foreach (var room in ConnectedRooms)
            {
                directions.Add($"To {room.GetType().Name} (Room {room.RoomNumber})"); // Add direction to the list
            }
            return directions; // Return list of directions
        }
    }

    public class CombatRoom : Room
    {
        public Player Player { get; private set; }
        public Villain? Villain { get; private set; }

        public void FightinRoom(Player player, Villain villain)
        {
            Player = player;
            Villain = villain;
        }

        public override void OnEntered(Player player)
        {
            Console.WriteLine($"You have entered a Combat Room! Prepare to fight the {Villain?.Name}.");
            DisplayCombatStatus();
        }

        public override void OnSearched(Player player)
        {
            Console.WriteLine("You cannot search for items during combat!");
        }

        public override void OnExited(Player player)
        {
            Console.WriteLine("You cannot exit during combat! Defeat the villain first.");
        }

        public override List<string> GetAvailableDirections()
        {
            List<string> directions = new List<string>();
            foreach (var room in ConnectedRooms)
            {
                directions.Add($"To {room.GetType().Name} (Room {room.RoomNumber})");
            }
            return directions;
        }

        public void PlayerAttack(string weaponName, string attackType)
        {
            // Simple weapon retrieval from inventory
            Weapon? weapon = null;

            foreach (var item in Player.PlayerInventory.items)
            {
                if (item is Weapon && item.Name.Equals(weaponName, StringComparison.OrdinalIgnoreCase))
                {
                    weapon = (Weapon)item; // Found the weapon in inventory
                    break; // Exit the loop
                }
            }

            if (weapon != null)
            {
                // Use the weapon's specific damage method based on its type
                int damage = 0;

                // Check the type of weapon and calculate damage accordingly
                switch (weapon)
                {
                    case LongSword longSword:
                        damage = longSword.Damage(attackType);
                        break;
                    case Dagger dagger:
                        damage = dagger.Damage(attackType);
                        break;
                    case PoleArm poleArm:
                        damage = poleArm.Damage(attackType);
                        break;
                    default:
                        Console.WriteLine("Invalid weapon type!");
                        return;
                }

                Villain.TakeDamage(damage); // Inflict damage on the villain
                weapon.weaponHp -= 15; // Decrease weapon durability by 15
                Console.WriteLine($"You attack the {Villain.Name} with the {weapon.Name} for {damage} damage!");

                // Check if the villain is defeated
                if (Villain.IsDefeated())
                {
                    Console.WriteLine($"You have defeated the {Villain.Name}! You can now exit the room.");
                    RemoveWeaponIfBroken(weapon); // Check if weapon should be removed
                    ShowAvailableDirections();
                    AskForNextRoom();
                }
                else
                {
                    VillainAttack(); // If the villain is still alive, it attacks back
                }

                // Check if the weapon is broken after the attack
                RemoveWeaponIfBroken(weapon);
            }
            else
            {
                Console.WriteLine("Invalid weapon choice! You don't have that weapon.");
            }

        }

        private void AskForNextRoom()
        {
            Console.WriteLine("Do you want to go to the next room? (y/n)");
            string choice = (Console.ReadLine() ?? "").ToLower();

            if (choice == "y")
            {
                // Assuming the player chooses a direction. You can enhance this logic to let them pick.
                Console.WriteLine("Which direction would you like to go? (Enter the direction as shown)");
                foreach (var direction in GetAvailableDirections())
                {
                    Console.WriteLine(direction); // Display the available directions
                }

                // Accept user input for the direction
                string chosenDirection = Console.ReadLine() ?? "";
                // Here you can implement the logic to change to the chosen room
                // Example: ChangeRoom(chosenDirection); (You would need to implement this logic)
            }
            else
            {
                Console.WriteLine("You chose to stay in the room.");
                Environment.Exit(0);
            }
        }

        private void VillainAttack()
        {
            int damage = Villain.Attack(); // The villain attacks the player
            Player.PlayerHealth -= damage; // Reduce player's health based on villain's attack
            Console.WriteLine($"{Villain.Name} attacks you for {damage} damage!");
            DisplayCombatStatus();

            // Check if the player is defeated
            if (Player.PlayerHealth <= 0)
            {
                Console.WriteLine("You have been defeated! Game over.");
                // Here you can add logic for game over or resetting player state
            }
        }

        private void DisplayCombatStatus()
        {
            Console.WriteLine($"Your HP: {Player.PlayerHealth}");
            Console.WriteLine($"{Villain.Name}'s HP: {Villain.Health}");
        }

        private void RemoveWeaponIfBroken(Weapon weapon)
        {
            if (weapon.weaponHp <= 0)
            {
                Player.PlayerInventory.RemoveItem(weapon); // Remove weapon from inventory
                Console.WriteLine($"Your {weapon.Name} has broken and is removed from your inventory.");
            }
        }
    }
}
