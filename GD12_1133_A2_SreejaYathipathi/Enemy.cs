using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    public abstract class Enemy
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int AttackPower { get; protected set; }

        protected Enemy(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public abstract void Attack();
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage and has {Health} health left.");
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been defeated!");
            }
        }
    }

    public class WaterEnemy : Enemy
    {
        public WaterEnemy() : base("Water Elemental", 50, 10) { }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks with a splash!");
        }
    }

    public class AirEnemy : Enemy
    {
        public AirEnemy() : base("Air Elemental", 40, 12) { }

        public override void Attack()
        {
            Console.WriteLine($"{Name} strikes with a gust of wind!");
        }
    }

    public class FireEnemy : Enemy
    {
        public FireEnemy() : base("Fire Elemental", 60, 15) { }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks with a burst of flames!");
        }
    }

    public class EarthEnemy : Enemy
    {
        public EarthEnemy() : base("Earth Elemental", 70, 8) { }

        public override void Attack()
        {
            Console.WriteLine($"{Name} attacks with a rock throw!");
        }
    }
}
