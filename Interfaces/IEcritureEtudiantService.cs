
using GesNotes.Models;

namespace GesNotes.Interfaces;

public interface IEcritureEtudiantService
{
    Etudiant AjouterEtudiant(string nom, string prenom);

    bool AjouterNote(string matricule, double note);
}
