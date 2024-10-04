using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Next player to the bench!!! Who's ready to take on the challenge?");
        Console.WriteLine(@"The judge is looking at you! Press ""Y"" to take life by the horns, or ""N"" to keep a low profile and let life pass you by...");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Make your choice:");
        Console.ResetColor();

        string choice = Console.ReadLine().ToUpper();

        // Game points initialization
        int Psp = 100;        // Player's starting points
        int Csp = 100;        // Computer's starting points

        int ticker = 0;       // Round ticker
        int playerWins = 0;   // Track player wins
        int computerWins = 0; // Track computer wins

        Random random = new Random();

        if (choice == "Y")
        {
            Console.WriteLine("What's your name, wrestler?");
            Console.Write("Name: ");
            string name = Console.ReadLine().ToUpper();
            Console.WriteLine($"Welcome to the staaaaage, {name}!");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Round 1....Fight:");
            Console.ResetColor();

            // Start the game
            while (playerWins < 2 && computerWins < 2)
            {
                // Player's turn
                int playerUsedPoints = PlayerSp(ref Psp);

                // Computer's turn
                var (remainingCsp, computerUsedPoints) = ComputerSp(Csp, random);
                Csp = remainingCsp;

                Console.WriteLine($"The opponent used {computerUsedPoints} and has {remainingCsp} points left.");

                // Round results
                Rounds(ref playerWins, playerUsedPoints, computerUsedPoints, ref computerWins);
                ticker++;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Round {ticker}....Fight!");
                Console.ResetColor();
            }

            // Game over - declare winner
            if (playerWins == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name}, YOU ARE THE VICTOR WITH {playerWins} WINS!!! CLAIM YOUR PRIZE....");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You lost with {computerWins} wins for the computer... Bow your head in shame!");
                Console.ResetColor();
            }
        }
        else if (choice == "N")
        {
            Console.WriteLine("Life passes you by and you die alone....");
        }
        else
        {
            Console.WriteLine(@"The Judge hits you and says ""Can you not read fool?""");
        }
    }

    // Method for player's points spent in a round
    static int PlayerSp(ref int Psp)
    {
        Console.WriteLine($"Choose your strength! from 0 - {Psp}:");
        int UsedPsp = int.Parse(Console.ReadLine());
        if (UsedPsp >= 0 && UsedPsp <= Psp)
        {
            Psp -= UsedPsp;
            return UsedPsp;
        }
        else
        {
            Console.WriteLine("Invalid input. Try again....");
            return PlayerSp(ref Psp);
        }
    }

    // Method for computer's points spent in a round
    static (int remainingCsp, int UsedCsp) ComputerSp(int Csp, Random random)
    {
        Console.WriteLine("Your opponent is thinking....");
        int UsedCsp = random.Next(0, Csp);
        Csp -= UsedCsp;
        return (Csp, UsedCsp);
    }

    // Method for processing each round and updating wins
    static void Rounds(ref int playerWins, int UsedPsp, int UsedCsp, ref int computerWins)
    {
        if (UsedPsp > UsedCsp)
        {
            playerWins++;
            Console.WriteLine("You won this round!");
        }
        else if (UsedPsp == UsedCsp)
        {
            Console.WriteLine("It's a draw!");
        }
        else
        {
            computerWins++;
            Console.WriteLine("COMPUTER MAXIMUS won this round!");
        }
    }
}
