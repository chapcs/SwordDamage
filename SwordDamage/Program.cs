using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();
        SwordDamage sword = new SwordDamage();

        while (true)
        {
            Console.Write("0 for no abilities, 1 for magic, 2 for flaming, 3 for both; press any other key to quit: ");
            char keyChar = Console.ReadKey().KeyChar; // the boolean in this line determines whether to intercept the character, optional to display in console; KeyChar selects the character to be stored in keyChar; ReadKey() defaults to false

            if (keyChar == '0' || keyChar == '1' || keyChar == '2' || keyChar == '3')
            {
                sword.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
                sword.SetMagic(keyChar == '1' || keyChar == '3');
                sword.SetFlaming(keyChar == '2' || keyChar == '3');
                Console.WriteLine($"\nRolled {sword.Roll} for {sword.Damage} HP \n");
            }
            else
            {
                return;
            }
        }
    }
}

class SwordDamage
{
    public const int BASE_DAM = 3;
    public const int FLAME_DAM = 2;

    public int Roll;
    public decimal MagicMult = 1M;
    public int FlamingDam = 0;
    public int Damage;

    public void CalculateDamage()
    {
        Damage = (int)(Roll * MagicMult) + BASE_DAM + FlamingDam;
    }
    public void SetMagic(bool isMagic)
    {
        if (isMagic)
        {
            MagicMult = 1.75M;
        }
        else
        {
            MagicMult = 1M;
        }
        CalculateDamage();
    }
    public void SetFlaming(bool isFlaming)
    {
        CalculateDamage();
        if (isFlaming)
        {
            Damage += FLAME_DAM;
        }
    }
}