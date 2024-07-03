using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class RandomLetterGenerator : MonoBehaviour
{
    public TextMeshProUGUI[] LetterDisplays;

    void Start()
    {
        if (LetterDisplays.Length != 9)
        {
            return;
        }

        DoGeneration();
    }

    public char[] GenerateRandomLetters()
    {
        char[] letters = new char[9];
        string vowels = "AEIOU";
        string consonants = "BCDFGHJKLMNPQRSTVWXYZ";
        System.Random rand = new System.Random();

        // vowels
        for (int i = 0; i < 2; i++)
        {
            char vowel;
            do
            {
                vowel = vowels[rand.Next(vowels.Length)];
            } while (letters.Contains(vowel));

            letters[i] = vowel;
        }

        for (int i = 2; i < 9; i++)
        {
            char letter;
            do
            {
                letter = (rand.Next(2) == 0) ? vowels[rand.Next(vowels.Length)] : consonants[rand.Next(consonants.Length)];
            } while (letters.Contains(letter));

            letters[i] = letter;
        }

        return letters;
    }
    void Update()
    {

    }
    public void DoGeneration()
    {
        char[] letters = GenerateRandomLetters();
        for (int i = 0; i < letters.Length; i++)
        {
            LetterDisplays[i].text = letters[i].ToString();
        }
    }
}

