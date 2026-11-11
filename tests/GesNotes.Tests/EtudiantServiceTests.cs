
using GesNotes.Services;

namespace GesNotes.Tests;

public class EtudiantServiceTests
{
    [Fact]
    public void AjouterEtudiant_CreeUnEtudiantAvecMatricule()
    {
        var service = new EtudiantService(
            new GenerateurMatriculeIsm()
        );

        var etudiant = service.AjouterEtudiant("Karbi", "Rozzi");

        Assert.Equal("ism1", etudiant.Matricule);
        Assert.Equal("Karbi", etudiant.Nom);
        Assert.Single(service.ListerEtudiants());
    }

    [Fact]
    public void AjouterEtudiant_GenereDesMatriculesDifferents()
    {
        var service = new EtudiantService(
            new GenerateurMatriculeIsm()
        );

        var premier = service.AjouterEtudiant("Karbi", "Rozzi");
        var second = service.AjouterEtudiant("Leila", "Rozzi");

        Assert.NotEqual(premier.Matricule, second.Matricule);
        Assert.Equal(2, service.ListerEtudiants().Count);
    }

    [Fact]
    public void RechercherParMatricule_RetourneLeBonEtudiant()
    {
        var service = new EtudiantService(
            new GenerateurMatriculeIsm()
        );

        var attendu = service.AjouterEtudiant("Karbi", "Rozzi");

        var resultat = service.RechercherParMatricule(
            attendu.Matricule
        );

        Assert.Same(attendu, resultat);
    }

    [Fact]
    public void RechercherParMatricule_InconnuRetourneNull()
    {
        var service = new EtudiantService(
            new GenerateurMatriculeIsm()
        );

        var resultat = service.RechercherParMatricule("INCONNU");

        Assert.Null(resultat);
    }

    [Fact]
    public void AjouterNote_AjouteUneNoteAuBonEtudiant()
    {
        var service = new EtudiantService(
            new GenerateurMatriculeIsm()
        );

        var etudiant = service.AjouterEtudiant("Karbi", "Rozzi");

        bool resultat = service.AjouterNote(
            etudiant.Matricule, 19
        );

        Assert.True(resultat);
        Assert.Contains(19, etudiant.Notes);
    }

    [Fact]
    public void AjouterNote_MatriculeInconnuRetourneFalse()
    {
        var service = new EtudiantService(
            new GenerateurMatriculeIsm()
        );

        bool resultat = service.AjouterNote("INCONNU", 15);

        Assert.False(resultat);
    }

    [Fact]
    public void AjouterNote_InvalideDeclencheUneException()
    {
        var service = new EtudiantService(
            new GenerateurMatriculeIsm()
        );

        var etudiant = service.AjouterEtudiant("Karbi", "Rozzi");

        Assert.Throws<ArgumentOutOfRangeException>(
            () => service.AjouterNote(etudiant.Matricule, 25)
        );

        Assert.Empty(etudiant.Notes);
    }
}
