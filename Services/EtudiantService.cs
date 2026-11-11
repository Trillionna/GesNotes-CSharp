
using GesNotes.Interfaces;
using GesNotes.Models;

namespace GesNotes.Services;

public class EtudiantService : IEtudiantService
{
    private readonly List<Etudiant> _etudiants = new();
    private int _compteur = 0;

    public Etudiant AjouterEtudiant(string nom, string prenom)
    {
        _compteur++;

        string matricule = $"ism{_compteur}";

        Etudiant etudiant = new Etudiant(
            matricule,
            nom,
            prenom
        );

        _etudiants.Add(etudiant);

        return etudiant;
    }

    public IReadOnlyList<Etudiant> ListerEtudiants()
    {
        return _etudiants.AsReadOnly();
    }

    public Etudiant? RechercherParMatricule(string matricule)
    {
        return _etudiants.FirstOrDefault(
            e => e.Matricule == matricule
        );
    }

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
