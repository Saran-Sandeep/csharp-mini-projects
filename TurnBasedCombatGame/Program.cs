/*
    player and enemy 
        - both has initial 50hp
        - take turns to either attack or heal
        - generate a random number and sub from hp for attack
        - generate a random number and add to hp for heal
        - constantly check if hp is <= 0.
        - declare winner.
*/
using System;

namespace TurnBasedCombat
{
    class Player
    {
        public string Name { get; }
        public int Hp { get; private set; }
        public bool IsAlive => Hp > 0;

        public Player(string name, int hp)
        {
            this.Name = name;
            this.Hp = hp;
        }

        public void TakeDamage(int damage)
        {
            Hp = Math.Max(0, Hp - damage);
        }

        public void Heal(int amount, int maxHp)
        {
            Hp = Math.Min(maxHp, Hp + amount);
        }
    }

    class Program
    {
        static void Main()
        {
            Game _game = new();
            _game.Start();
        }
    }

    class Game
    {

        private readonly Player _user;
        private readonly Player _enemy;
        private readonly Random _random = new();

        private const int MaxHp = 50;
        private const int MaxAttackDamage = 25;
        private const int MaxHealAmount = 20;

        public Game()
        {
            _user = new Player("You", MaxHp);
            _enemy = new Player("Enemy", MaxHp);
        }

        public void Start()
        {
            Console.WriteLine("=== Turn Based Combat Game ===");
            PrintStatus();

            while (_user.IsAlive && _enemy.IsAlive)
            {
                HandleUserTurn();
                if (!_enemy.IsAlive) break;

                HandleEnemyTurn();
                PrintStatus();
            }

            PrintResult();
        }

        private void Attack(Player attacker, Player target)
        {
            int damage = _random.Next(1, MaxAttackDamage + 1);
            target.TakeDamage(damage);
            Console.WriteLine($"{attacker.Name} dealt {damage} damage.");
        }

        private void Heal(Player player)
        {
            int healAmount = _random.Next(1, MaxHealAmount + 1);
            player.Heal(healAmount, MaxHp);
            Console.WriteLine($"{player.Name} healed {healAmount} HP.");
        }

        private void PrintStatus()
        {
            Console.WriteLine($"HP Status — {_user.Name}: {_user.Hp}, {_enemy.Name}: {_enemy.Hp}");
            Console.WriteLine();
        }

        private void PrintResult()
        {
            if (_user.IsAlive)
                Console.WriteLine("Congratulations! You won the battle.");
            else
                Console.WriteLine("You lost. Enemy won the battle.");
        }

        private void HandleUserTurn()
        {
            Console.Write("Enter a to attack or h to heal : ");
            string? userChoice = Console.ReadLine()?.Trim();
            if (string.Equals(userChoice, "a", StringComparison.OrdinalIgnoreCase)) Attack(_user, _enemy);
            else if (string.Equals(userChoice, "h", StringComparison.OrdinalIgnoreCase)) Heal(_user);
            else Console.WriteLine("Invalid choice. Turn skipped.");
        }

        private void HandleEnemyTurn()
        {
            int enemyChoice = _random.Next(1, 3);
            if (enemyChoice == 1)
            {
                Console.WriteLine("Enemy attacks");
                Attack(_enemy, _user);
            }
            else
            {
                Console.WriteLine("Enemy heals.");
                Heal(_enemy);
            }
        }
    }
}