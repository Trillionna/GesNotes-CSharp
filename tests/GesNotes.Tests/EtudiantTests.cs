
using GesNotes.Models;

namespace GesNotes.Tests;

public class EtudiantTests
{
    [Fact]
    public void Constructeur_InitialiseLesInformations()
    {
        var etudiant = new Etudiant(
            "ISM-2026-0001",
            "Karbi",
            "Rozzi"
        );

        Assert.Equal("ISM-2026-0001", etudiant.Matricule);
        Assert.Equal("Karbi", etudiant.Nom);
        Assert.Equal("Rozzi", etudiant.Prenom);
        Assert.Empty(etudiant.Notes);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(19)]
    [InlineData(20)]
    public void AjouterNote_AccepteLesNotesValides(double note)
    {
        var etudiant = new Etudiant("ISM1", "Karbi", "Rozzi");

        etudiant.AjouterNote(note);

        Assert.Contains(note, etudiant.Notes);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(21)]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    public void AjouterNote_RefuseLesNotesInvalides(double note)
    {
        var etudiant = new Etudiant("ISM1", "Karbi", "Rozzi");

        Assert.Throws<ArgumentOutOfRangeException>(
            () => etudiant.AjouterNote(note)
        );

        Assert.Empty(etudiant.Notes);
    }
}
