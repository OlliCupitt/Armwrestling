Console.WriteLine("Next player to the bench!!! whos ready to take on the challenge?");
Console.WriteLine(@"The judge is looking at you! press ""Y"" to take life by the horns ""N"" to keep a low profile and let life pass you by...");

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("Make your choice");
Console.ResetColor();

string choice = Console.ReadLine().ToUpper();

int Psp = 100;
int UsedPsp = 0;

int Csp = 100;
int UsedCsp = 0;

int Dead = 0;

Random random = new Random(); //random yes

int x = 0;
int y = 0;

if (choice == "Y")
{
    Console.WriteLine("whats your name wrestler?");
    Console.Write("Name: ");
    string name = Console.ReadLine().ToUpper();
    Console.Write("Welcome to the staaaaage...");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(name);
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Round 1....Fight:");
    Console.ResetColor();
    //här börjar spelet



    //rd 1
    UsedPsp = PlayerSp();
    var (Remainingcsp, Usedcsp) = ComputorSp(Dead);
    Console.WriteLine($"The other player used {Usedcsp} and has {Remainingcsp} left");

    Rounds(ref x, UsedPsp, Usedcsp, ref y);



    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Next round.... Kill THEM!:");
    Console.ResetColor();

    UsedCsp = 0;
    UsedPsp = 0;

    //Rd 2
    PlayerSp();
    (Remainingcsp, Usedcsp) = ComputorSp(Dead);
    Console.WriteLine($"The other player used {Usedcsp} and has {Remainingcsp} left");

    Rounds(ref x, UsedPsp, Usedcsp, ref y);

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Final Round.... TO THE DEATH!:");
    Console.ResetColor();


    UsedCsp = 0;
    UsedPsp = 0;


    //Rd 3 
    PlayerSp();
    (Remainingcsp, Usedcsp) = ComputorSp(Dead);
    Console.WriteLine($"The other player used {Usedcsp} and has {Remainingcsp} left");

    Rounds(ref x, UsedPsp, Usedcsp, ref y);

    UsedCsp = 0;
    UsedPsp = 0;



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
    if (UsedPsp > 0 && UsedPsp <= Psp)
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
        Console.WriteLine("You won son.");
        return x;
    }
    else if (UsedPsp == UsedCsp)
    {
        Console.WriteLine("Its a DRAW!");
        return 0;
    }
    else
    {
        int Ycount = ++y;
        Console.WriteLine("COMPUTOS MAXIMUS won this round!! ");
        return y;
    }
}