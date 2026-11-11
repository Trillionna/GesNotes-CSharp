
using GesNotes.Interfaces;
using GesNotes.Models;

namespace GesNotes.Services;

public class EtudiantService : IEtudiantService
{
    private readonly List<Etudiant> _etudiants = new();
    private readonly IGenerateurMatricule _generateur;

    // Injection de dépendance
    public EtudiantService(IGenerateurMatricule generateur)
    {
        _generateur = generateur;
    }

    // Ajouter un étudiant
    public Etudiant AjouterEtudiant(string nom, string prenom)
    {
        string matricule = _generateur.Generer();

        Etudiant etudiant = new Etudiant(
            matricule,
            nom,
            prenom
        );

        _etudiants.Add(etudiant);

        return etudiant;
    }

    // Lister les étudiants
    public IReadOnlyList<Etudiant> ListerEtudiants()
    {
        return _etudiants.AsReadOnly();
    }

    // Rechercher un étudiant par matricule
    public Etudiant? RechercherParMatricule(string matricule)
    {
        return _etudiants.FirstOrDefault(
            e => e.Matricule == matricule
        );
    }

    // Ajouter une note à un étudiant
    public bool AjouterNote(string matricule, double note)
    {
        Etudiant? etudiant = RechercherParMatricule(matricule);

        if (etudiant is null)
        {
            return false;
        }

        etudiant.AjouterNote(note);

        return true;
    }
}
