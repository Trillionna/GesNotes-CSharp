# GesNotes-CSharp — Gestion des notes des étudiants

## Présentation

Application console développée en C# avec .NET 10, à partir du projet initial de DianaFerradini.

**Objectif pédagogique :** refactoriser une application de gestion des étudiants et de leurs notes en utilisant deux approches : la programmation orientée objet (POO) et les principes SOLID.

## Organisation Git

| Branche | Description |
|---|---|
| `feat/list` | Code original de référence |
| `poo-simple` | Refactorisation POO dans un seul fichier |
| `poo-solid` | Architecture POO avec séparation des responsabilités et principes SOLID |

## Fonctionnalités

- Ajouter un étudiant avec génération automatique de matricule.
- Consulter la liste des étudiants.
- Ajouter une note comprise entre 0 et 20.
- Rechercher un étudiant par matricule.
- Consulter ses notes.
- Valider les données saisies.

## Architecture SOLID

- **S — Single Responsibility :** séparation entre modèle, logique métier et interface console.
- **O — Open/Closed :** possibilité d'ajouter des générateurs de matricules sans modifier `EtudiantService`.
- **L — Liskov Substitution :** utilisation de deux générateurs implémentant le même contrat, avec tests de comportement.
- **I — Interface Segregation :** interfaces distinctes pour la lecture et l'écriture.
- **D — Dependency Inversion :** dépendances injectées par constructeur via des interfaces.

## Exécution

```powershell
dotnet run
```

## Tests automatisés

La branche `poo-solid` contient un projet de tests xUnit.

```powershell
dotnet test tests/GesNotes.Tests/GesNotes.Tests.csproj
```

**Dernière validation :** 23 tests réussis, aucun échec.

## Technologies

- C#
- .NET 10
- Programmation orientée objet
- Principes SOLID
- LINQ
- xUnit
- Git et GitHub

## Référence

Projet initial : [DianaFerradini/GesNotes-CSharp](https://github.com/DianaFerradini/GesNotes-CSharp).

Ce travail constitue une refactorisation pédagogique du projet original.