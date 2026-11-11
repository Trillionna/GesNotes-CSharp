
using GesNotes.Interfaces;
using GesNotes.Services;

namespace GesNotes.Tests;

public class GenerateurMatriculeTests
{
    public static TheoryData<IGenerateurMatricule> Generateurs => new()
    {
        new GenerateurMatriculeIsm(),
        new GenerateurMatriculeAnnee()
    };

    [Theory]
    [MemberData(nameof(Generateurs))]
    public void Generer_RetourneUnMatriculeNonVide(
        IGenerateurMatricule generateur)
    {
        string matricule = generateur.Generer();

        Assert.False(string.IsNullOrWhiteSpace(matricule));
    }

    [Theory]
    [MemberData(nameof(Generateurs))]
    public void Generer_RetourneDesMatriculesDifferents(
        IGenerateurMatricule generateur)
    {
        string premier = generateur.Generer();
        string second = generateur.Generer();

        Assert.NotEqual(premier, second);
    }

    [Fact]
    public void GenerateurIsm_RespecteLeFormat()
    {
        var generateur = new GenerateurMatriculeIsm();

        Assert.Equal("ism1", generateur.Generer());
    }

    [Fact]
    public void GenerateurAnnee_RespecteLeFormat()
    {
        var generateur = new GenerateurMatriculeAnnee();

        string attendu = $"ISM-{DateTime.Now.Year}-0001";

        Assert.Equal(attendu, generateur.Generer());
    }
}
