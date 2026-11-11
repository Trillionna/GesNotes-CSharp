
using GesNotes.Interfaces;
using GesNotes.Services;
using GesNotes.UI;

IGenerateurMatricule generateur = new GenerateurMatriculeIsm();

IEtudiantService service = new EtudiantService(generateur);

ConsoleMenu menu = new ConsoleMenu(service);

menu.Demarrer();
