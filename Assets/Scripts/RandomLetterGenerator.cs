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

        char[] letters = GenerateRandomLetters();
        for (int i = 0; i < letters.Length; i++)
        {
            LetterDisplays[i].text = letters[i].ToString();
        }
    }

    char[] GenerateRandomLetters()
    {
        char[] letters = new char[9];
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        System.Random rand = new System.Random();

        for (int i = 0; i < 9; i++)
        {
            int index;
            do
            {
                index = rand.Next(alphabet.Length);
            } while (letters.Contains(alphabet[index]));

            letters[i] = alphabet[index];
        }

        return letters;
    }
    void Update()
    {

    }
}
