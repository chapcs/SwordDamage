using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static Random random = new Random();

    private static void Main(string[] args)
    {
        SwordDamage sword = new SwordDamage(RollDice());

        while (true)
        {
            Console.Write("0 for no abilities, 1 for magic, 2 for flaming, 3 for both; press any other key to quit: ");
            char keyChar = Console.ReadKey().KeyChar; // the boolean in this line determines whether to intercept the character, optional to display in console; KeyChar selects the character to be stored in keyChar; ReadKey() defaults to false

            if (keyChar == '0' || keyChar == '1' || keyChar == '2' || keyChar == '3')
            {
                sword.Roll = RollDice();
                sword.Magic = (keyChar == '1' || keyChar == '3');
                sword.Flaming = (keyChar == '2' || keyChar == '3');
                Console.WriteLine($"\nRolled {sword.Roll} for {sword.Damage} HP \n");
            }
            else
            {
                return;
            }
        }
    }
    static int RollDice()
    {
        return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
    }
}

/// <summary>
/// Main method that calculates the the sword damage based off different params
/// </summary>
class SwordDamage
{
    public const int BASE_DAM = 3;
    public const int FLAME_DAM = 2;

    public int roll;
    public bool flaming;
    public bool magic;

    public int Damage { get; private set; }

    public SwordDamage(int startingRoll)
    {
        roll = startingRoll;
        CalculateDamage();
    }

    public int Roll
    {
        get { return roll; }
        set
        {
            roll = value;
            CalculateDamage();
        }
    }

    private void CalculateDamage()
    {
        decimal MagicMult = 1M;
        if (Magic) MagicMult = 1.75M;

        Damage = (int)(Roll * MagicMult) + BASE_DAM;
        if (Flaming) Damage += FLAME_DAM;
        Debug.WriteLine($"CalculateDamage finished: {Damage} (roll: {Roll})");
    }
    public bool Magic
    {
        get { return magic; }
        set
        {
            magic = value;
            CalculateDamage();
        }
    }
    public bool Flaming
    {
        get { return flaming; }
        set
        {
            flaming = value;
            CalculateDamage();
        }
    }
}