# GesNotes-CSharp — Version POO simple

## Présentation

Refactorisation en programmation orientée objet d'une application console C# de gestion des étudiants et de leurs notes.

Projet réalisé à partir du code original de DianaFerradini.

## Objectif

Remplacer les tuples du programme initial par une classe `Etudiant` et appliquer les fondamentaux de la programmation orientée objet.

## Fonctionnalités

- Ajouter un étudiant avec génération automatique de matricule.
- Afficher la liste des étudiants.
- Rechercher un étudiant par matricule.
- Ajouter des notes comprises entre 0 et 20.
- Consulter les notes d'un étudiant.

## Architecture

Toutes les classes sont regroupées dans `Program.cs`, conformément à la consigne pédagogique.

**Classe `Etudiant` :** propriétés, constructeur, encapsulation et gestion des notes.

**Classe `Program` :** menu console, saisies, recherche et gestion de la collection d'étudiants.

Cette version n'applique pas volontairement une séparation architecturale SOLID complète.

## Exécution

Prérequis : SDK .NET 10.

```powershell
dotnet run
```

## Comparaison

La branche `poo-solid` propose une seconde refactorisation du même programme, avec interfaces, services, injection de dépendances et tests automatisés.

## Référence

Code initial : [DianaFerradini/GesNotes-CSharp](https://github.com/DianaFerradini/GesNotes-CSharp).

Travail réalisé dans un cadre pédagogique.