
using GesNotes.Models;

namespace GesNotes.Interfaces;

public interface IEtudiantService
{
    Etudiant AjouterEtudiant(string nom, string prenom);

    IReadOnlyList<Etudiant> ListerEtudiants();

    Etudiant? RechercherParMatricule(string matricule);

    bool AjouterNote(string matricule, double note);
}
