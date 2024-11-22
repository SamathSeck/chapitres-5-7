﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList lstEtudiants = new SortedList();

            while (true)
            {
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("1. Ajouter un étudiant");
                Console.WriteLine("2. Afficher un étudiant par son nom");
                Console.WriteLine("3. Afficher tous les étudiants");
                Console.WriteLine("4. Quitter");
                Console.Write("Choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterEtudiant(lstEtudiants);
                        break;

                    case "2":
                        AfficherEtudiant(lstEtudiants);
                        break;

                    case "3":
                        AfficherTousLesEtudiants(lstEtudiants);
                        break;

                    case "4":
                        Console.WriteLine("Fin du programme.");
                        return;

                    default:
                        Console.WriteLine("Choix invalide, veuillez réessayer.");
                        break;
                }
            }
        }

        static void AjouterEtudiant(SortedList lstEtudiants)
        {
            Console.Write("Nom de l'étudiant : ");
            string nom = Console.ReadLine();

            Console.Write("Âge de l'étudiant : ");
            int age = LireEntier("Veuillez entrer un âge valide : ");

            Console.Write("Note de contrôle continu (sur 20) : ");
            double noteCC = LireNote();

            Console.Write("Note de devoir (sur 20) : ");
            double noteDevoir = LireNote();

            Etudiant etudiant = new Etudiant
            {
                Nom = nom,
                Age = age,
                NoteCC = noteCC,
                NoteDevoir = noteDevoir
            };

            if (!lstEtudiants.ContainsKey(nom))
            {
                lstEtudiants.Add(nom, etudiant);
                Console.WriteLine("Étudiant ajouté avec succès !");
            }
            else
            {
                Console.WriteLine("Erreur : Un étudiant avec ce nom existe déjà.");
            }
        }

        static void AfficherEtudiant(SortedList lstEtudiants)
        {
            Console.Write("Nom de l'étudiant à rechercher : ");
            string nom = Console.ReadLine();

            if (lstEtudiants.ContainsKey(nom))
            {
                Etudiant etudiant = (Etudiant)lstEtudiants[nom];
                Console.WriteLine($"Nom : {etudiant.Nom}, Âge : {etudiant.Age}, Note CC : {etudiant.NoteCC}, Note Devoir : {etudiant.NoteDevoir}, Moyenne : {etudiant.CalculerMoyenne():F2}");
            }
            else
            {
                Console.WriteLine("Étudiant introuvable !");
            }
        }

        static void AfficherTousLesEtudiants(SortedList lstEtudiants)
        {
            if (lstEtudiants.Count == 0)
            {
                Console.WriteLine("Aucun étudiant enregistré.");
                return;
            }

            Console.WriteLine("\n=== Liste des étudiants ===");
            foreach (DictionaryEntry entree in lstEtudiants)
            {
                Etudiant etudiant = (Etudiant)entree.Value;
                Console.WriteLine($"Nom : {etudiant.Nom}, Âge : {etudiant.Age}, Note CC : {etudiant.NoteCC}, Note Devoir : {etudiant.NoteDevoir}, Moyenne : {etudiant.CalculerMoyenne():F2}");
            }
        }

        static double LireNote()
        {
            while (true)
            {
                Console.Write("Entrez une note : ");
                if (double.TryParse(Console.ReadLine(), out double note) && note >= 0 && note <= 20)
                {
                    return note;
                }
                Console.WriteLine("Veuillez saisir une note valide (entre 0 et 20) : ");
            }
        }

        static int LireEntier(string messageErreur)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int entier) && entier > 0)
                {
                    return entier;
                }
                Console.WriteLine(messageErreur);
            }
        }
    }
}
