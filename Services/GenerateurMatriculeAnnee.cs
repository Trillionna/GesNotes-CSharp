
using GesNotes.Interfaces;

namespace GesNotes.Services;

public class GenerateurMatriculeAnnee : IGenerateurMatricule
{
    private int _compteur = 0;

    public string Generer()
    {
        _compteur++;

        return $"ISM-{DateTime.Now.Year}-{_compteur:D4}";
    }
}
