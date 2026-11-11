
using GesNotes.Interfaces;

namespace GesNotes.Services;

public class GenerateurMatriculeIsm : IGenerateurMatricule
{
    private int _compteur = 0;

    public string Generer()
    {
        _compteur++;
        return $"ism{_compteur}";
    }
}
