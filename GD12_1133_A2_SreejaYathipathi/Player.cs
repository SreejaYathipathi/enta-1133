using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    // The Player class manages player stats, health, inventory, and actions
    public class Player
    {
        public int PlayerHealth { get; set; } // The player's current health
        public int MaxHP { get; set; } // The player's maximum health
        public int DamageTaken { get; set; } // Tracks the total damage the player has taken
        public Inventory? PlayerInventory { get; private set; } // The player's inventory for storing items and consumables

        string userName = ""; // Stores the player's name
        public int Health { get; set; } // Manages the player's health
        public int ExperiencePoints { get; set; } // Stores the player's experience points
        public List<string> inventory; // A list representing the player's inventory

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

        // Initializes the player's health and inventory at the start of the game
        public void PlayerHp(int maxHP)
        {
            MaxHP = maxHP; // Sets max health
            PlayerHealth = MaxHP; // Sets current health to max health
            PlayerInventory = new Inventory(); // Initializes player's inventory
            DamageTaken = 0; // Initializes damage taken to zero
        }

        // Checks if the player's health has reached zero (i.e., if the player is dead)
        public bool IsDead()
        {
            return PlayerHealth <= 0; // Returns true if player health is zero or less
        }

        // Reduces player health when they take damage
        public void TakeDamage(int damage)
        {
            DamageTaken += damage; // Increases damage taken
            PlayerHealth -= damage; // Reduces player health

            if (IsDead()) // If player dies, remove all inventory items
            {
                RemoveInventory();
            }
        }

        // Clears the player's inventory when they die
        private void RemoveInventory()
        {
            PlayerInventory.Clear(); // Clears all items from inventory
        }

        // Prompts the player to drink consumables if their health is low
        public void CheckConsumables()
        {
            if (PlayerHealth < 30) // If health drops below 30, prompt to drink consumables
            {
                if (PlayerInventory.HasConsumables()) // Checks if there are consumables in the inventory
                {
                    Console.WriteLine("Your HP is low! Do you want to drink a consumable?");
                    PlayerInventory.DisplayConsumables(); // Displays available consumables in the inventory

                    string selectedItem = Console.ReadLine() ?? ""; // Gets player's choice of consumable
                    DrinkConsumable(selectedItem, GetPlayerInventory()); // Drinks the selected consumable
                }
                else
                {
                    Console.WriteLine("You don't have any consumables to drink."); // Informs player if no consumables are available
                }
            }
        }

        public Inventory? GetPlayerInventory()
        {
            return PlayerInventory;
        }

        // Heals the player by drinking a selected consumable
        public void DrinkConsumable(string itemName, Inventory? playerInventory)
        {
            Item consumable = playerInventory.GetConsumable(itemName); // Fetches the selected consumable from inventory

            if (consumable is Consumables consumableItem) // Checks if the item is a consumable
            {
                int healingAmount = consumableItem.HealingAmount(this); // Heals the player based on the consumable's effect
                PlayerHealth += healingAmount; // Increases player health
                if (PlayerHealth > MaxHP) PlayerHealth = MaxHP; // Ensures player health does not exceed max health
                PlayerInventory.RemoveItem(consumable); // Removes the consumed item from inventory
                Console.WriteLine($"You drank {consumable.Name} and healed for {healingAmount} HP."); // Displays healing effect
            }
            else
            {
                Console.WriteLine("You can't drink that! It's not in your inventory."); // Informs player if the selected item is invalid
            }
        }

        // Checks if the player has any weapons in their inventory
        public bool HasWeapons()
        {
            return PlayerInventory.HasWeapons(); // Returns true if player has weapons in their inventory
        }
    }
}
