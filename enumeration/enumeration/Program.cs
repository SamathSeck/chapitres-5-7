using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<(int Nombre, string Hexadécimal)> conversions = new List<(int, string)>();
        bool continuer = true;

        Console.WriteLine("Conversion Hexadécimale");

        while (continuer)
        {
            try
            {
                Console.Write("Saisissez un entier à convertir en hexadécimal : ");
                int nombre = int.Parse(Console.ReadLine());

                string valeurHexa = ConvertirEnHexadécimal(nombre);

                Console.WriteLine($"La valeur hexadécimale de {nombre} est : {valeurHexa}");

                conversions.Add((nombre, valeurHexa));

                Console.Write("Tapez O pour convertir un autre nombre ou appuyez sur n'importe quelle touche pour arrêter : ");
                string reponse = Console.ReadLine().ToUpper();
                if (reponse != "O")
                {
                    continuer = false;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erreur : Veuillez entrer un entier valide.");
            }
        }

        Console.WriteLine("\nRésumé des conversions");
        foreach (var (Nombre, Hexadécimal) in conversions)
        {
            Console.WriteLine($"Nombre : {Nombre} => Hexadécimal : {Hexadécimal}");
        }

        Console.WriteLine("\nAppuyez sur 'Q' pour quitter.");
        while (Console.ReadKey().Key != ConsoleKey.Q)
        {
            // attendant que l'utilisateur appui 'Q' pour quitter
        }

        Console.WriteLine("\nMerci d'avoir utilisé le programme !");
    }

    public static string ConvertirEnHexadécimal(int nombre)
    {
        if (nombre == 0) return "0";

        List<char> caracteresHexa = new List<char>();
        while (nombre > 0)
        {
            int reste = nombre % 16;
            caracteresHexa.Add(reste < 10 ? (char)(reste + '0') : (char)(reste - 10 + 'A'));
            nombre /= 16;
        }

        caracteresHexa.Reverse();
        return new string(caracteresHexa.ToArray());
    }
}
