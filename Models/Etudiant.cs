
namespace GesNotes.Models;

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
        if (double.IsNaN(note) || double.IsInfinity(note) ||
            note < 0 || note > 20)
        {
            throw new ArgumentOutOfRangeException(
                nameof(note),
                "La note doit être comprise entre 0 et 20."
            );
        }

        _notes.Add(note);
    }
}
