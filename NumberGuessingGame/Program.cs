/*
    system generates a random num - between 1 to 10.
    user has 5 chances.
        user guess a num
        system prints if its higher or lower.
*/

namespace NumberGuessGame
{
    class Problem
    {
        private static readonly Random _random = new();
        public static void Main()
        {
            int randomNum = _random.Next(1, 11);
            int rounds = 5;

            while (rounds-- > 0)
            {
                Console.Write("Guess a number : ");
                int userGuessedNum = Convert.ToInt16(Console.ReadLine());

                if (userGuessedNum < randomNum) Console.WriteLine("Your guess is too low.");
                else if (userGuessedNum > randomNum) Console.WriteLine("Your guess is to high");
                else
                {
                    Console.WriteLine("Congratulations, You Win!!!");
                    return;
                }
            }

            Console.WriteLine("You are out of chances. You lost !!!");
        }
    }
}