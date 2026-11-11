
using GesNotes.Interfaces;
using GesNotes.Services;
using GesNotes.UI;

IEtudiantService service = new EtudiantService();

ConsoleMenu menu = new ConsoleMenu(service);

menu.Demarrer();
