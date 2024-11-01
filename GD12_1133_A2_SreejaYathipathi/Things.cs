using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    public abstract class Things
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected Things(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    // Weapon class inheriting from Item
    public abstract class Weapon : Things
    {
        public int HP { get; protected set; }

        protected Weapon(string name, string description, int durability)
            : base(name, description)
        {
            HP = durability;
        }

        public abstract int Attack(char attackType);

        public void DecreaseHP()
        {
            HP -= 15; // Decrease weapon HP by 15 on attack
        }

        public bool IsBroken()
        {
            return HP <= 0;
        }
    }

    // Specific weapon classes with their own attack methods
    public class LongSword : Weapon
    {
        public LongSword()
            : base("Long Sword", "A powerful sword with a long blade.", 100) { }

        public override int Attack(char attackType)
        {
            int damageDealt = 0;
            if (attackType == 'z')
            {
                damageDealt = new Random().Next(60, 76);
            }
            else if (attackType == 'x')
            {
                damageDealt = new Random().Next(50, 66);
            }
            else if (attackType == 'c')
            {
                damageDealt = new Random().Next(40, 56);
            }
            return damageDealt;
        }
    }

    public class Dagger : Weapon
    {
        public Dagger()
            : base("Dagger", "A small, lightweight weapon.", 100) { }

        public override int Attack(char attackType)
        {
            int damageDealt = 0;
            if (attackType == 'z')
            {
                damageDealt = new Random().Next(40, 61);
            }
            else if (attackType == 'x')
            {
                damageDealt = new Random().Next(30, 46);
            }
            else if (attackType == 'c')
            {
                damageDealt = new Random().Next(20, 31);
            }
            return damageDealt;
        }
    }

    public class Polearm : Weapon
    {
        public Polearm()
            : base("Polearm", "A versatile weapon with a long reach.", 100) { }

        public override int Attack(char attackType)
        {
            int damageDealt = 0;
            if (attackType == 'z')
            {
                damageDealt = new Random().Next(50, 66);
            }
            else if (attackType == 'x')
            {
                damageDealt = new Random().Next(40, 55);
            }
            else if (attackType == 'c')
            {
                damageDealt = new Random().Next(30, 46);
            }
            return damageDealt;
        }
    }

    // Consumable class inheriting from Item
    public abstract class Consumable : Things
    {
        public int Count { get; private set; }
        public int HealAmount { get; protected set; }

        protected Consumable(string name, string description, int healAmount)
            : base(name, description)
        {
            HealAmount = healAmount;
            Count = 1;
        }
        public void IncrementCount()
        {
            Count++;
        }

        public void Use(Player player)
        {
            // Use the consumable to heal the player
            player.Health += HealAmount;
            Console.WriteLine($"{player.GetPlayerName} has been healed by {HealAmount} points!");
            Count--; // Decrease the count when used
            if (Count <= 0)
            {
                // If the count reaches zero, it can be removed from the inventory
                Console.WriteLine($"{Name} has been fully consumed.");
            }
        }
    }

    // Specific consumable classes
    public class SmallHealingPotion : Consumable
    {
        public SmallHealingPotion()
        : base("Small Healing Potion", "Heals for a small amount of health.", 25)
        {
            // Count is initialized to 1 in the Consumable base class
        }
    }

    public class MediumHealingPotion : Consumable
    {
        public MediumHealingPotion()
        : base("Medium Healing Potion", "Heals for a medium amount of health.", 50)
        {
            // Count is initialized to 1 in the Consumable base class
        }
    }

    public class LargeHealingPotion : Consumable
    {
        public LargeHealingPotion()
        : base("Large Healing Potion", "Heals for a large amount of health.", 100)
        {
            // Count is initialized to 1 in the Consumable base class
        }
    }

}
