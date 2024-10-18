using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GD12_1133_A2_SreejaYathipathi
{
    // Abstract base class representing a villain
    public abstract class Villain
    {
        // Abstract property to get and set the name of the villain
        public abstract string Name { get; set; }
        public abstract string Element { get; set; } // Element associated with the villain (e.g., fire, water)

        // Randomly generated health points (HP) between 80 and 120
        public int Health { get; private set; }

        // Constructor that initializes the villain's health
        public Villain()
        {
            Random villianRnd = new Random();
            Health = villianRnd.Next(80, 121); // HP set randomly between 80 and 120
        }

        // Method for the villain to attack the player, returns damage inflicted
        public int Attack()
        {
            int attackDamage = GenerateDamage(); // Generate damage when attacking
            Console.WriteLine(Name + " attacks with " + Element + " power! Inflicted damage: " + attackDamage);
            return attackDamage; // Return the damage inflicted
        }

        // Virtual method to generate damage; can be overridden in subclasses
        public virtual int GenerateDamage()
        {
            return 0; // Default implementation returns 0, to be overridden in subclasses
        }

        // Method to receive damage from the player and reduce health
        public void TakeDamage(int damage)
        {
            Health -= damage; // Decrease health by the damage taken
            if (Health < 0)
            {
                Health = 0; // Ensure health doesn't go below 0
            }
        }

        // Method to check if the villain is defeated (health is 0 or less)
        public bool IsDefeated()
        {
            return Health <= 0; // Return true if the villain is defeated
        }
    }

    // Fire Elemental Villain class, inherits from Villain
    public class FireElementalVillain : Villain
    {
        // Override Name property to specify the name of the villain
        public override string Name { get; set; } = "Fire Villain";
        public override string Element { get; set; } = "Fire"; // Specify the element for the villain

        // Override GenerateDamage to specify damage range for fire elemental
        public override int GenerateDamage()
        {
            Random rnd = new Random();
            return rnd.Next(30, 51); // Higher damage range for fire elemental (30-50)
        }
    }

    // Water Elemental Villain class, inherits from Villain
    public class WaterElementalVillain : Villain
    {
        // Override Name property to specify the name of the villain
        public override string Name { get; set; } = "Water Villain";
        public override string Element { get; set; } = "Water"; // Specify the element for the villain

        // Override GenerateDamage to specify damage range for water elemental
        public override int GenerateDamage()
        {
            Random rnd = new Random();
            return rnd.Next(20, 41); // Standard damage range for water elemental (20-40)
        }
    }

    // Earth Elemental Villain class, inherits from Villain
    public class EarthElementalVillain : Villain
    {
        // Override Name property to specify the name of the villain
        public override string Name { get; set; } = "Earth Villain";
        public override string Element { get; set; } = "Earth"; // Specify the element for the villain

        // Override GenerateDamage to specify damage range for earth elemental
        public override int GenerateDamage()
        {
            Random rnd = new Random();
            return rnd.Next(20, 41); // Standard damage range for earth elemental (20-40)
        }
    }

    // Air Elemental Villain class, inherits from Villain
    public class AirElementalVillain : Villain
    {
        // Override Name property to specify the name of the villain
        public override string Name { get; set; } = "Air Villain";
        public override string Element { get; set; } = "Air"; // Specify the element for the villain

        // Override GenerateDamage to specify damage range for air elemental
        public override int GenerateDamage()
        {
            Random rnd = new Random();
            return rnd.Next(20, 41); // Standard damage range for air elemental (20-40)
        }
    }
}
