using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> kifejezesek = new List<string>();
        StreamReader sr = new StreamReader("kifejezesek.txt");
        while (!sr.EndOfStream)
        {
            kifejezesek.Add(sr.ReadLine());
        }
        sr.Close();

        Console.WriteLine($"2. feladat: Kifejezések száma: {kifejezesek.Count()}");

        Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {kifejezesek.Count(x => x.Contains("mod"))}");

        bool nincsolyan = true;
        int nincsolyanIndex = 0;
        while (nincsolyan && nincsolyanIndex != kifejezesek.Count())
        {
            string[] kifejezes = kifejezesek[nincsolyanIndex].Split(" ");
            if (int.Parse(kifejezes[0]) % 10 == 0 && int.Parse(kifejezes[2]) % 10 == 0)
            {
                nincsolyan = false;
            }
            nincsolyanIndex++;
        }
        if (!nincsolyan)
        {
            Console.WriteLine($"4. feladat: Van ilyen kifejezés");
        }
        else
        {
            Console.WriteLine($"4. feladat: Nincs ilyen kifejezés");
        }

        int osszeadas = 0;
        int kivonas = 0;
        int szorzas = 0;
        int valos_osztas = 0;
        int egesz_osztas = 0;
        int maradekos_osztas = 0;
        foreach (var kif in kifejezesek)
        {
            string[] kifejezes2 = kif.Split(" ");
            if (kifejezes2[1] == "+")
            {
                osszeadas++;
            }
            if (kifejezes2[1] == "-")
            {
                kivonas++;
            }
            if (kifejezes2[1] == "*")
            {
                szorzas++;
            }
            if (kifejezes2[1] == "/")
            {
                valos_osztas++;
            }
            if (kifejezes2[1] == "div")
            {
                egesz_osztas++;
            }
            if (kifejezes2[1] == "mod")
            {
                maradekos_osztas++;
            }
        }

        Console.WriteLine($"5. feladat: Statisztika");
        Console.WriteLine($"\tmod -> {maradekos_osztas}");
        Console.WriteLine($"\t/ -> {valos_osztas}");
        Console.WriteLine($"\tdiv -> {egesz_osztas}");
        Console.WriteLine($"\t- -> {kivonas}");
        Console.WriteLine($"\t* -> {szorzas}");
        Console.WriteLine($"\t+ -> {osszeadas}");
        
        static string kiszamol(string bemenet)
        {
            string[] kifejezes2 = bemenet.Split(" ");
            try
            {
                if (kifejezes2[1] == "+")
                {
                    return (Convert.ToString(int.Parse(kifejezes2[0]) + int.Parse(kifejezes2[2])));
                }
                if (kifejezes2[1] == "-")
                {
                    return (Convert.ToString(int.Parse(kifejezes2[0]) - int.Parse(kifejezes2[2])));
                }
                if (kifejezes2[1] == "*")
                {
                    return (Convert.ToString(int.Parse(kifejezes2[0]) * int.Parse(kifejezes2[2])));
                }
                if (kifejezes2[1] == "/")
                {
                    return (Convert.ToString(double.Parse(kifejezes2[0]) / double.Parse(kifejezes2[2])));
                }
                if (kifejezes2[1] == "div")
                {
                    return (Convert.ToString(int.Parse(kifejezes2[0]) % int.Parse(kifejezes2[2])));
                }
                if (kifejezes2[1] == "mod")
                {
                    return (Convert.ToString(int.Parse(kifejezes2[0]) / int.Parse(kifejezes2[2])));
                }
                else
                {
                    return "Hibás operátor!";
                }
            }
            catch (Exception)
            {
                return "Egyéb hiba!";
            }

        }
        Console.Write("7. feladat: Kérek egy kifejezést: ");
        string bekert = Console.ReadLine();
        while (bekert != "")
        {
            Console.WriteLine($"\t{bekert} = {kiszamol(bekert)}");
            Console.Write("7. feladat: Kérek egy kifejezést: ");
            bekert = Console.ReadLine();
        }

        Console.Write("8. feladat: eredmenyek.txt");
        File.Create("eredmenyek.txt").Close();
        using (StreamWriter sw = new StreamWriter("eredmenyek.txt"))
        {
            foreach (var kifejezes in kifejezesek)
            {
                sw.WriteLine(kiszamol(kifejezes));
            }
        }
    }
}