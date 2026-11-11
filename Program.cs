
using System;
using System.Collections.Generic;
using System.Linq;

// Classe représentant un étudiant
public class Etudiant
{
    public string Matricule { get; private set; }
    public string Nom { get; private set; }
    public string Prenom { get; private set; }

    private readonly List<double> _notes = new();

    public IReadOnlyList<double> Notes => _notes.AsReadOnly();

    public Etudiant(string matricule, string nom, string prenom)
    {
        Matricule = matricule;
        Nom = nom;
        Prenom = prenom;
    }

    public void AjouterNote(double note)
    {
        if (!double.IsFinite(note) || note < 0 || note > 20)
        {
            throw new ArgumentOutOfRangeException(
                nameof(note),
                "La note doit être comprise entre 0 et 20."
            );
        }

        _notes.Add(note);
    }
}

// Programme principal : gestion et affichage réunis
public class Program
{
    private static readonly List<Etudiant> Etudiants = new();
    private static int _compteur = 0;

    public static void Main(string[] args)
    {
        int choix;

        do
        {
            choix = AfficherMenu();

            switch (choix)
            {
                case 1:
                    AjouterEtudiant();
                    break;
                case 2:
                    AfficherEtudiants();
                    break;
                case 3:
                    AjouterNote();
                    break;
                case 4:
                    AfficherNotes();
                    break;
                case 0:
                    Console.WriteLine("Au revoir !");
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }
        while (choix != 0);
    }

    private static int AfficherMenu()
    {
        Console.WriteLine("\n--- GESTION DES NOTES ---");
        Console.WriteLine("1. Ajouter un étudiant");
        Console.WriteLine("2. Afficher les étudiants");
        Console.WriteLine("3. Ajouter une note");
        Console.WriteLine("4. Afficher les notes d'un étudiant");
        Console.WriteLine("0. Quitter");
        Console.Write("Votre choix : ");

        return int.TryParse(Console.ReadLine(), out int choix)
            ? choix
            : -1;
    }

    private static void AjouterEtudiant()
    {
        string nom = LireChaine("Nom : ");
        string prenom = LireChaine("Prénom : ");

        _compteur++;

        string matricule = $"ism{_compteur}";

        Etudiant etudiant = new Etudiant(
            matricule,
            nom,
            prenom
        );

        Etudiants.Add(etudiant);

        Console.WriteLine(
            $"Étudiant ajouté. Matricule : {etudiant.Matricule}"
        );
    }

    private static void AfficherEtudiants()
    {
        if (Etudiants.Count == 0)
        {
            Console.WriteLine("Aucun étudiant enregistré.");
            return;
        }

        foreach (Etudiant etudiant in Etudiants)
        {
            Console.WriteLine(
                $"{etudiant.Matricule} - {etudiant.Nom} {etudiant.Prenom}"
            );
        }
    }

    private static Etudiant? RechercherEtudiant(string matricule)
    {
        return Etudiants.FirstOrDefault(
            e => e.Matricule == matricule
        );
    }

    private static void AjouterNote()
    {
        string matricule = LireChaine("Matricule : ");

        Etudiant? etudiant = RechercherEtudiant(matricule);

        if (etudiant is null)
        {
            Console.WriteLine("Étudiant introuvable.");
            return;
        }

        double note;

        while (true)
        {
            Console.Write("Note (0 à 20) : ");

            if (double.TryParse(Console.ReadLine(), out note)
                && double.IsFinite(note)
                && note >= 0 && note <= 20)
            {
                break;
            }

            Console.WriteLine("Note invalide.");
        }

        etudiant.AjouterNote(note);

        Console.WriteLine("Note ajoutée avec succès.");
    }

    private static void AfficherNotes()
    {
        string matricule = LireChaine("Matricule : ");

        Etudiant? etudiant = RechercherEtudiant(matricule);

        if (etudiant is null)
        {
            Console.WriteLine("Étudiant introuvable.");
            return;
        }

        if (etudiant.Notes.Count == 0)
        {
            Console.WriteLine("Aucune note enregistrée.");
            return;
        }

        foreach (double note in etudiant.Notes)
        {
            Console.WriteLine($"Note : {note}");
        }
    }

    private static string LireChaine(string message)
    {
        while (true)
        {
            Console.Write(message);

            string? valeur = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(valeur))
            {
                return valeur;
            }

            Console.WriteLine("Ce champ est obligatoire.");
        }
    }
}
