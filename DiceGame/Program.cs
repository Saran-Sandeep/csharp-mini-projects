/*

10 rounds 
    dice roll (random num from 1 to 6)
    dice rolls randomly - store the value
    dice rolls randomly - store the value
    compare and give 1 point to higher value

check points for users - print winner.


*/
using System.Reflection.Metadata;

namespace DiceGame
{
    class Program
    {

        //creating random instance
        private static readonly Random _random = new();
        static int RollDice()
        {
            return _random.Next(1, 7);
        }

        public static void Main()
        {
            Console.Write("Enter Y to start the game : ");
            string? ip = Console.ReadLine();

            if (!string.Equals(ip.Trim().ToLower(), "y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Thank you for visiting Dice Game.");
                return;
            }

            int rounds = 10;
            int userScore = 0;
            int enemyScore = 0;

            while (rounds-- > 0)
            {

                // user play
                Console.WriteLine(" --- Your chance --- ");
                Console.Write("Enter X to roll the dice : ");
                string? rollInput = Console.ReadLine();

                if (!String.Equals(rollInput.Trim(), "x", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid input. Skipping round.");
                    continue;
                }

                int userRoll = RollDice();
                int enemyRoll = RollDice();

                Console.WriteLine($"You rolled: {userRoll}");
                Console.WriteLine($"Enemy rolled: {enemyRoll}");

                Console.WriteLine();

                //comapre dice values
                if (userRoll > enemyRoll)
                {
                    Console.WriteLine("You won this round.");
                    userScore++;
                }
                else if (enemyRoll > userRoll)
                {
                    Console.WriteLine("You lost this round.");
                    enemyScore++;
                }
                else
                {
                    Console.WriteLine("Round tied.");
                }

                // display current scores.
                Console.WriteLine($"Score — You: {userScore}, Enemy: {enemyScore}");

                Console.WriteLine();
            }

            //final check
            if (userScore > enemyScore) Console.WriteLine("Congratulations, You won the game.");
            else if (userScore < enemyScore) Console.WriteLine("You lost, Enemy won the game.");
            else Console.WriteLine("The game ended as a tie.");

        }
    }
}