using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    public class Player
    {
        public int Health { get; set; } // Current health of the player
        public int MaxHealth { get; private set; } // Maximum health the player can have
        public Inventory inventory = new Inventory(); // Player's inventory
        string userName = "";

        public Player(int maxHealth)
        {
            MaxHealth = maxHealth; // Set the maximum health
            Health = maxHealth; // Start with full health
        }

        // Prompts the player to enter their name and stores it
        internal void PlayerName()
        {
            Console.WriteLine("\nCan I have your name to write it on my DEATH NOTE?\r\n");
            userName = Console.ReadLine() ?? ""; // Stores user input for the player name
            Console.WriteLine("\nWhat a nice name " + userName + ", Sadly you won't live past if you don't WIN this game.");
        }

        // Provides the player with an option to change their name
        internal void ChangeName()
        {
            Console.WriteLine("\nDo you want me to write a different name in my DEATH NOTE or you want to continue with " + userName);
            Console.WriteLine("\nEnter (Yes) or (No)\r\n");
            string change = (Console.ReadLine() ?? "").ToLower(); // Gets the player's decision on changing the name
            Console.WriteLine("");

            while (change != "yes" && change != "no")
            {
                Console.WriteLine("\nDon't create your own commands in my game. Enter only the things that given to you");
                change = (Console.ReadLine() ?? "").ToLower(); // Forces valid input (yes or no)
            }

            if (change == "yes")
            {
                PlayerName(); // Re-ask for the player's name if they choose to change it
            }
        }

        // Returns the player's current name
        public string GetPlayerName()
        {
            return userName; // Returns the stored player name
        }

        // Constructor to initialize the player's health
        

        // Method for the player to take damage
        public void TakeDamage(int damage)
        {
            Health -= damage; // Decrease health by damage amount
            Health = Math.Max(Health, 0); // Ensure health does not go below 0
            Console.WriteLine($"Player took {damage} damage! Current HP: {Health}");
        }

        // Method to consume a healing potion
        public void ConsumePotion(Consumable potion)
        {
            if (inventory.RemoveItem(potion)) // Check if the potion is in the inventory
            {
                int healing = MaxHealth * potion.HealAmount / 100; // Calculate healing amount based on potion
                Health = Math.Min(Health + healing, MaxHealth); // Ensure health does not exceed max
                Console.WriteLine($"You consumed a {potion.Name} and healed {healing} health points. Current health: {Health}/{MaxHealth}.");
            }
            else
            {
                Console.WriteLine($"You do not have a {potion.Name} in your inventory.");
            }
        }
    }
}
