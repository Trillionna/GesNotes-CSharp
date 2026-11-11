
using GesNotes.Models;

namespace GesNotes.Interfaces;

public interface ILectureEtudiantService
{
    IReadOnlyList<Etudiant> ListerEtudiants();

    Etudiant? RechercherParMatricule(string matricule);
}
