
using GesNotes.Interfaces;
using GesNotes.Services;
using GesNotes.UI;

IGenerateurMatricule generateur = new GenerateurMatriculeAnnee();

IEtudiantService service = new EtudiantService(generateur);

ConsoleMenu menu = new ConsoleMenu(service);

menu.Demarrer();
