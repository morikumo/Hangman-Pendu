# Hangman-Pendu

---

## Jeu du Pendu en C#

Un jeu du pendu simple en C#, à jouer dans le terminal. Devinez le mot caché en entrant une lettre à chaque tour.

### Fonctionnalités

- **Affichage du mot caché** : Les lettres devinées sont affichées en vert et les non devinées restent en `_`.
- **Lettres incorrectes en rouge** : Les lettres déjà tentées et incorrectes s'affichent en rouge pour éviter les doublons.
- **Graphique du pendu dynamique** : Affichage mis à jour selon les erreurs.

### Principales Méthodes

- **`Play()`** : Gère la boucle du jeu, le comptage des erreurs et la condition de fin.
- **`DisplayGuessedLetters()`** : Affiche le mot caché avec les lettres devinées.
- **`DisplayIncorrectLetters()`** : Liste les lettres incorrectes en rouge.
- **`DisplayHangman()`** : Affiche le pendu en fonction des erreurs.

### Instructions

1. **Compiler et exécuter** :
   ```bash
   dotnet build
   dotnet run
   ```

2. **Utilisation** : Entrez une lettre, le jeu vous informe si elle est correcte (vert) ou incorrecte (rouge).

---

