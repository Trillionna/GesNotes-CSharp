
using GesNotes.Interfaces;
using GesNotes.Models;

namespace GesNotes.UI;

public class ConsoleMenu
{
    private readonly IEtudiantService _service;

    public ConsoleMenu(IEtudiantService service)
    {
        _service = service;
    }

    public void Demarrer()
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

    private void AjouterEtudiant()
    {
        string nom = LireChaine("Nom : ");
        string prenom = LireChaine("Prénom : ");

        Etudiant etudiant = _service.AjouterEtudiant(nom, prenom);

        Console.WriteLine(
            $"Étudiant ajouté. Matricule : {etudiant.Matricule}"
        );
    }

    private void AfficherEtudiants()
    {
        var etudiants = _service.ListerEtudiants();

        if (etudiants.Count == 0)
        {
            Console.WriteLine("Aucun étudiant enregistré.");
            return;
        }

        foreach (Etudiant etudiant in etudiants)
        {
            Console.WriteLine(
                $"{etudiant.Matricule} - {etudiant.Nom} {etudiant.Prenom}"
            );
        }
    }

    private void AjouterNote()
    {
        string matricule = LireChaine("Matricule : ");

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

        bool resultat = _service.AjouterNote(matricule, note);

        Console.WriteLine(
            resultat
                ? "Note ajoutée avec succès."
                : "Étudiant introuvable."
        );
    }

    private void AfficherNotes()
    {
        string matricule = LireChaine("Matricule : ");

        Etudiant? etudiant =
            _service.RechercherParMatricule(matricule);

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
