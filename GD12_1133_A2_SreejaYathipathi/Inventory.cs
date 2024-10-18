using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    public class Inventory
    {
        public List<Item> items; // List to store items in the player's inventory

        public Inventory()
        {
            items = new List<Item>(); // Initialize the item list when creating an Inventory instance
        }

        // Adds an item to the inventory
        public void AddItem(Item item)
        {
            items.Add(item); // Add the given item to the inventory
            Console.WriteLine("You picked up: " + item.Name); // Inform the player about the added item
        }

        // Removes an item from the inventory
        public void RemoveItem(Item item)
        {
            if (items.Remove(item)) // Try to remove the specified item from the inventory
            {
                Console.WriteLine("You used: " + item.Name); // Confirm the item was successfully removed
            }
            else
            {
                Console.WriteLine("Item not found in inventory."); // Inform the player if the item was not found
            }
        }

        // Clears all items from the inventory
        public void Clear()
        {
            items.Clear(); // Remove all items from the inventory
        }

        // Checks if there are any consumable items in the inventory
        public bool HasConsumables()
        {
            return items.Any(item => item is Consumables); // Return true if there is at least one consumable item
        }

        // Displays all consumables in the inventory
        public void DisplayConsumables()
        {
            foreach (var item in items) // Loop through each item in the inventory
            {
                if (item is Consumables consumable) // Check if the item is a consumable
                {
                    Console.WriteLine(consumable.Name); // Display the name of the consumable
                }
            }
        }

        // Displays all items in the inventory
        public void Display()
        {
            if (items.Count == 0) // Check if the inventory is empty
            {
                Console.WriteLine("Your inventory is empty."); // Inform the player if the inventory has no items
                return;
            }

            Console.WriteLine("Items in your inventory:"); // List all items in the inventory
            foreach (var item in items) // Loop through the inventory items
            {
                Console.WriteLine("- " + item.Name); // Display each item's name
            }
        }

        // Retrieves a consumable item by its name
        public Item? GetConsumable(string itemName)
        {
            // Loop through each item in the list
            foreach (var item in items)
            {
                // Check if the item name matches the provided name, ignoring case
                if (item.Name.ToLower() == itemName.ToLower())
                {
                    return item; // Return the item if a match is found
                }
            }
            return null; // Return null if no match is found
        }

        // Checks if there are any weapons in the inventory
        public bool HasWeapons()
        {
            return items.Any(item => item is Weapon); // Return true if there is at least one weapon in the inventory
        }
    }
}
