using System;
using System.Collections.Generic;

class Programme
{
    static void Main(string[] args)
    {
        while (true) 
        {
            try
            {
                Console.WriteLine("Jeu : Trouver le Nombre");
                List<int> choixJoueur = new List<int>();
                int borneMinimale = 1, borneMaximale = 10; 
                int nombreAleatoire = new Random().Next(borneMinimale, borneMaximale + 1);
                int tentatives = 0;
                double note = 0;

                Console.WriteLine($"Un nombre entre {borneMinimale} et {borneMaximale} a été généré. Trouvez-le !");

                while (true)
                {
                    int choixUtilisateur = LireNombre($"Choisissez un nombre entre {borneMinimale} et {borneMaximale} : ", borneMinimale, borneMaximale);

                    tentatives++; 
                    choixJoueur.Add(choixUtilisateur); 

                    if (choixUtilisateur == nombreAleatoire)
                    {
                        note = (double)(borneMaximale - borneMinimale + 1) / tentatives;
                        Console.WriteLine($"\nBravo ! Vous avez trouvé le nombre {nombreAleatoire}.");
                        Console.WriteLine($"Nombre de tentatives : {tentatives}");
                        Console.WriteLine($"Vos choix : {string.Join(", ", choixJoueur)}");
                        Console.WriteLine($"Votre note : {note:F2}");
                        Console.WriteLine("Vous avez gagné !");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ce n'est pas le bon nombre. Essayez encore !");
                    }
                }

                Console.WriteLine("\nVoulez-vous rejouer ? (O/N)");
                string choixRejouer = Console.ReadLine()?.Trim().ToUpper();
                if (choixRejouer == "N")
                {
                    Console.WriteLine("Merci d'avoir joué ! À bientôt !");
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur inattendue s'est produite : {ex.Message}");
            }
        }
    }
    static int LireNombre(string message, int borneMinimale, int borneMaximale)
    {
        while (true)
        {
            Console.Write(message);
            string saisie = Console.ReadLine();

            if (int.TryParse(saisie, out int nombre))
            {
                if (nombre >= borneMinimale && nombre <= borneMaximale)
                {
                    return nombre;
                }
                else
                {
                    Console.WriteLine($"Erreur : Le nombre doit être compris entre {borneMinimale} et {borneMaximale}.");
                }
            }
            else
            {
                Console.WriteLine("Erreur : Veuillez saisir un nombre valide.");
            }
        }
    }
}
