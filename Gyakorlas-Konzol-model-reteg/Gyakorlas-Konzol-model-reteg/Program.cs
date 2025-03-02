using Gyakorlas_Konzol_model_reteg.Models;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // 1. feladat
            // Érvénytelen kezdőpontszám
            Console.WriteLine("1.feladat");
            try
            {
                Player jatekos1 = new Player("Játékos1", "jatekos1@nyertes.hu", -5);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            // Érvényes kezdőpontszám
            Player jatekos2 = new Player("Jétékos Jani", "jatekos.jani@nyertes.hu", 50);
            Console.WriteLine(jatekos2);
            Console.WriteLine();


            // 2. feladat
            Console.WriteLine("2.feladat");
            jatekos2.Win(20);
            jatekos2.Win(30);
            Console.WriteLine($"Játékos Jani nyert {jatekos2.Won} alkalommal.");

            jatekos2.Lose(40);
            Console.WriteLine($"Játékos Jani aktuális pontszáma: {jatekos2.Score}");
            Console.WriteLine($"Játékos Jani nyerő-e? {jatekos2.Winner()}");
            Console.WriteLine();


            // 3. feladat
            Console.WriteLine("3.feladat");
            Player jatekos3 = new Player("Játékos3", "jatekos3@nyertes.hu", 100);
            jatekos3.Win(50);
            jatekos3.Lose(30);
            jatekos3.Lose(40);
            Console.WriteLine($"Játékos3 nyerő-e? {jatekos3.Winner()}");
            Console.WriteLine();


            // 4. feladat
            Console.WriteLine("4.feladat");
            if (jatekos2.Score > jatekos3.Score)
            {
                Console.WriteLine($"A győztes: {jatekos2.Name} ({jatekos2.Score} pont)");
            }
            else if (jatekos2.Score < jatekos3.Score)
            {
                Console.WriteLine($"A győztes: {jatekos3.Name} ({jatekos3.Score} pont)");
            }
            else
            {
                Console.WriteLine("A két játékos döntetlent játszott.");
            }
            Console.WriteLine();


            // 5. feladat
            Console.WriteLine("5.feladat");
            try
            {
                jatekos2.Lose(100);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                jatekos3.Lose(200);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}