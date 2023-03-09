using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();
        SwordDamage sword = new SwordDamage();

        while (true)
        {
            Console.WriteLine("0 for no abilities, 1 for magic, 2 for flaming, 3 for both; press any other key to quit: ");
            Console.ReadKey(false);
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