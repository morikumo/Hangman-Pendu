using System;
using System.Collections.Generic;

class HangmanGame
{
    private string wordToGuess;
    private char[] guessedLetters;
    private int maxGuesses;
    private int incorrectGuesses;
    private List<char> incorrectLetters = new List<char>();

    public HangmanGame(string word)
    {
        wordToGuess = word.ToUpper();
        guessedLetters = new char[wordToGuess.Length];
        maxGuesses = 6;
        incorrectGuesses = 0;
    }

    public void Play()
    {
        Console.WriteLine("Bienvenue au jeu du Pendu !");
        Console.WriteLine("Devinez le mot, une lettre à la fois. Vous avez 6 essais maximum.");
        Console.WriteLine();

        while (true)
        {
            Console.Clear(); // Nettoie la console pour chaque tour pour une meilleure lisibilité
            DisplayHangman();
            DisplayGuessedLetters();
            DisplayIncorrectLetters(); // Affiche les lettres incorrectes
            Console.WriteLine("\n");

            Console.Write("Entrez une lettre : ");
            char letter = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (char.IsLetter(letter))
            {
                if (!IsLetterGuessed(letter))
                {
                    if (wordToGuess.Contains(letter))
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Affiche en vert pour les bonnes lettres
                        Console.WriteLine("\nBonne lettre !");
                        Console.ResetColor();
                        UpdateGuessedLetters(letter);

                        if (IsWordGuessed())
                        {
                            Console.Clear();
                            Console.WriteLine("Félicitations ! Vous avez deviné le mot : " + wordToGuess);
                            break;
                        }
                    }
                    else
                    {
                        incorrectGuesses++;
                        incorrectLetters.Add(letter); // Ajoute la lettre incorrecte à la liste
                        Console.ForegroundColor = ConsoleColor.Red; // Texte en rouge pour les mauvaises lettres
                        Console.WriteLine("\nLettre incorrecte ! Il vous reste " + (maxGuesses - incorrectGuesses) + " essais.");
                        Console.ResetColor();

                        if (incorrectGuesses == maxGuesses)
                        {
                            Console.Clear();
                            DisplayHangman(); // Affiche la dernière étape du pendu
                            Console.WriteLine("Jeu terminé ! Le mot était : " + wordToGuess);
                            break;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Texte en rouge pour les lettres déjà utilisées
                    Console.WriteLine("Vous avez déjà deviné cette lettre. Réessayez.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Entrée invalide ! Entrez une seule lettre.");
            }
        }

        Console.WriteLine("Merci d'avoir joué au Pendu !");
    }

    private void DisplayGuessedLetters()
    {
        Console.Write("Mot : ");
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (guessedLetters[i] != '\0')
            {
                Console.ForegroundColor = ConsoleColor.Green; // Lettres correctement devinées en vert
                Console.Write(guessedLetters[i] + " ");
                Console.ResetColor();
            }
            else
            {
                Console.Write("_ ");
            }
        }
    }

    private void DisplayIncorrectLetters()
    {
        Console.Write("\nLettres incorrectes : ");
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (char letter in incorrectLetters)
        {
            Console.Write(letter + " ");
        }
        Console.ResetColor();
    }

    private bool IsLetterGuessed(char letter)
    {
        return Array.Exists(guessedLetters, guessed => guessed == letter) || incorrectLetters.Contains(letter);
    }

    private void UpdateGuessedLetters(char letter)
    {
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (wordToGuess[i] == letter)
            {
                guessedLetters[i] = letter;
            }
        }
    }

    private bool IsWordGuessed()
    {
        foreach (char guessedLetter in guessedLetters)
        {
            if (guessedLetter == '\0')
            {
                return false;
            }
        }

        return true;
    }

    private void DisplayHangman()
    {
        string[] hangmanStages = {
            "  +---+\n      |\n      |\n      |\n     ===",
            "  +---+\n  O   |\n      |\n      |\n     ===",
            "  +---+\n  O   |\n  |   |\n      |\n     ===",
            "  +---+\n  O   |\n /|   |\n      |\n     ===",
            "  +---+\n  O   |\n /|\\  |\n      |\n     ===",
            "  +---+\n  O   |\n /|\\  |\n /    |\n     ===",
            "  +---+\n  O   |\n /|\\  |\n / \\  |\n     ==="
        };

        Console.WriteLine(hangmanStages[incorrectGuesses]);
    }
}

class Program
{
    static void Main(string[] args)
    {
        HangmanGame game = new HangmanGame("pendu"); // Mot à deviner
        game.Play();
    }
}
