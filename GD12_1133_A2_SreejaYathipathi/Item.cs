using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GD12_1133_A2_SreejaYathipathi
{
    // Base class for all items, including weapons and consumables
    public class Item
    {
        public virtual string Name { get; } // Name of the item, overridden in derived classes

        public Item(string name)
        {
            Name = name; // Assign name to the item
        }

        // Random instance to be used for damage calculation in weapons
        public Random itemrnd = new Random();
    }

    // Abstract base class for consumable items like healing potions
    public abstract class Consumables : Item
    {
        public Consumables(string name) : base(name) { }

        // Abstract method to define the healing effect of a consumable item
        public abstract int HealingAmount(Player player);
    }

    // Class for small healing potion, heals 25% of player's max HP
    public class SmallHealingPotion : Consumables
    {
        public SmallHealingPotion() : base("Small Healing Potion") { }

        public override int HealingAmount(Player player)
        {
            int healAmount = (int)(player.MaxHP * 0.25); // Heal 25% of max health
            return healAmount; // Return the amount healed
        }
    }

    // Class for medium healing potion, heals 50% of player's max HP
    public class MediumHealingPotion : Consumables
    {
        public MediumHealingPotion() : base("Medium Healing Potion") { }

        public override int HealingAmount(Player player)
        {
            int healAmount = (int)(player.MaxHP * 0.5); // Heal 50% of max health
            return healAmount; // Return the amount healed
        }
    }

    // Class for large healing potion, heals 100% of player's max HP
    public class LargeHealingPotion : Consumables
    {
        public LargeHealingPotion() : base("Large Healing Potion") { }

        public override int HealingAmount(Player player)
        {
            return player.MaxHP; // Heal 100% of max health
        }
    }

    // Abstract base class for weapons with properties for damage and weapon HP
    public abstract class Weapon : Item
    {
        public Weapon(string name) : base(name) { }

        // Properties to define weapon's current HP and damage range
        public abstract int weaponHp { get; set; }
        public abstract int minDamage { get; set; }
        public abstract int maxDamage { get; set; }
    }

    // Class for LongSword weapon with specific damage and HP
    public class LongSword : Weapon
    {
        public LongSword() : base("Long Sword") { }

        // Define weapon's HP and damage values
        public override int weaponHp { get; set; } = 100;
        public override int minDamage { get; set; } = 50;
        public override int maxDamage { get; set; } = 75;

        // Method to calculate damage based on attack type (high, medium, low)
        public int Damage(string attackType)
        {
            int damage = 0;

            if (attackType == "z") // High damage
            {
                damage = itemrnd.Next(minDamage, maxDamage + 1);
            }
            else if (attackType == "x") // Medium damage
            {
                damage = itemrnd.Next((minDamage / 2), (maxDamage + 1) / 2);
            }
            else if (attackType == "c") // Low damage
            {
                damage = itemrnd.Next((minDamage / 3), (maxDamage + 1) / 3);
            }
            return damage; // Return calculated damage
        }
    }

    // Class for Dagger weapon with specific damage and HP
    public class Dagger : Weapon
    {
        public Dagger() : base("Dagger") { }

        // Define weapon's HP and damage values
        public override int weaponHp { get; set; } = 80;
        public override int minDamage { get; set; } = 30;
        public override int maxDamage { get; set; } = 50;

        // Method to calculate damage based on attack type (high, medium, low)
        public int Damage(string attackType)
        {
            int damage = 0;

            if (attackType == "z") // High damage
            {
                damage = itemrnd.Next(minDamage, maxDamage + 1);
            }
            else if (attackType == "x") // Medium damage
            {
                damage = itemrnd.Next((minDamage / 2), (maxDamage + 1) / 2);
            }
            else if (attackType == "c") // Low damage
            {
                damage = itemrnd.Next((minDamage / 3), (maxDamage + 1) / 3);
            }
            return damage; // Return calculated damage
        }
    }

    // Class for PoleArm weapon with specific damage and HP
    public class PoleArm : Weapon
    {
        public PoleArm() : base("PoleArm") { }

        // Define weapon's HP and damage values
        public override int weaponHp { get; set; } = 90;
        public override int minDamage { get; set; } = 40;
        public override int maxDamage { get; set; } = 60;

        // Method to calculate damage based on attack type (high, medium, low)
        public int Damage(string attackType)
        {
            int damage = 0;

            if (attackType == "z") // High damage
            {
                damage = itemrnd.Next(minDamage, maxDamage + 1);
            }
            else if (attackType == "x") // Medium damage
            {
                damage = itemrnd.Next((minDamage / 2), (maxDamage + 1) / 2);
            }
            else if (attackType == "c") // Low damage
            {
                damage = itemrnd.Next((minDamage / 3), (maxDamage + 1) / 3);
            }
            return damage; // Return calculated damage
        }
    }
}
