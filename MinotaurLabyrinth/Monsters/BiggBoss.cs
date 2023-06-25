using System;

namespace MinotaurLabyrinth
{
    public class BigBoss : Monster
    {
        public int HealthPoints { get; set; }
        public int AttackStrength { get; set; }
        public int Speed { get; set; }

        public BigBoss()
        {
            HealthPoints = 100;
            AttackStrength = 20;
            Speed = 2;
        }

        public override void Activate(Hero hero, Map map)
        {
            Console.WriteLine("BigBoss is activated! Brace yourself for a fearsome encounter.");
            Console.WriteLine("BigBoss unleashes a devastating fire breath attack!");
            hero.Health -= AttackStrength;
        }

        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (heroDistance <= 3)
            {
                Console.WriteLine("You feel an intense heat nearby. BigBoss, the fire-breathing monster, is lurking!");
                return true;
            }

            return false;
        }

        public override DisplayDetails Display()
        {
            return new DisplayDetails("[BB]", ConsoleColor.DarkRed);
        }

        // New code begins here
        public void TakeDamage(int damage)
        {
            HealthPoints -= damage;
        }
    }
}
