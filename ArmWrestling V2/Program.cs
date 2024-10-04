using System.Runtime.InteropServices;

Console.WriteLine("Next player to the bench!!! whos ready to take on the challenge?");
Console.WriteLine(@"The judge is looking at you! press ""Y"" to take life by the horns ""N"" to keep a low profile and let life pass you by...");

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("Make your choice");
Console.ResetColor();

string choice = Console.ReadLine().ToUpper();

int Psp = 100;        // points left for player
int UsedPsp = 0;      // Used points per round 

int Csp = 100;        // points left for computor
int UsedCsp = 0;      // points used by computor 

int Dead = 0;   // start count for computor generated random number

int ticker = 1;

Random random = new Random(); //random yes

int x = 0;         // returned values of wins
int y = 0;

int PLayerPoint = x;    // win point definition
int Computorpoints = y;

if (choice == "Y")
{
    Console.WriteLine("whats your name wrestler?");
    Console.Write("Name: ");
    string name = Console.ReadLine().ToUpper();
    Console.Write("Welcome to the staaaaage...");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(name);
    Console.ResetColor();

    //här börjar spelet

    do
    {
        //round x
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Round {ticker}.... Kill THEM!:");
        Console.ResetColor();

        // PLayer turn 
        UsedPsp = PlayerSp();

         //Computor turn
        var (Remainingcsp, Usedcsp) = ComputorSp(Dead);
        Console.WriteLine($"The other player used {Usedcsp} and has {Remainingcsp} left");
      
        Rounds(ref x, UsedPsp, Usedcsp, ref y);
        UsedCsp = 0;
        UsedPsp = 0;
        ++ticker;

    }
    while (x < 2 && y < 2);

    if (x == 2)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(name);
        Console.ResetColor();
        Console.WriteLine($" YOU ARE THE VICCKKTORRR WITH {x} WINNSSS!!!");
        Console.WriteLine("CLAIM YOUR PRIZE....");
    }
    else
    {
        Console.WriteLine($"YoU LoST with {y} Bow YoUr hEAD In SHAme ANd RetRN TO yOU PLaCE IN SOCiETy...!");
    }

}
else if (choice == "2")
{
    Console.WriteLine("Life passes you by and you die alone....");
}
else
{
    Console.WriteLine(@"The Judge hits you and says ""Can you not read fool!!!!""");
}



int PlayerSp()
{
    Console.WriteLine($"choose your strength! from 0 - {Psp}:");
    int UsedPsp = int.Parse(Console.ReadLine());
    if (UsedPsp > -1 && UsedPsp <= Psp)
    {
        Psp -= UsedPsp;
        return UsedPsp;
    }
    else
    {
        Console.WriteLine("Try again....");
        return PlayerSp();
    }
}

(int, int) ComputorSp(int dead)
{
    Console.WriteLine("Your apponent is loading....");
    int UsedCsp = random.Next(dead, Csp);
    Csp -= UsedCsp;

    return (Csp, UsedCsp);
}

int Rounds(ref int x, int UsedPsp, int UsedCsp, ref int y)
{
    if (UsedPsp > UsedCsp)
    {
        ++x;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You won SON.");
        Console.ResetColor();
        return x;
    }
    else if (UsedPsp == UsedCsp)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Its a DRAW!");
        Console.ResetColor();
        return 0;
    }
    else
    {
        int Ycount = ++y;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("COMPUTOS MAXIMUS won this round!! ");
        Console.ResetColor();
        return y;
    }
}

