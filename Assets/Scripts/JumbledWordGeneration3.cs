using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class JumbledWordGeneration3 : MonoBehaviour
{
    public TextMeshProUGUI[] LetterDisplays;
    public QuestionData[] questions;
    public string currentAnswer;
    public TMP_Text questionText;

    void Start()
    {
        DoGeneration();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public char[] LoadRandomQuestion()
    {
        QuestionData randomQuestion = questions[Random.Range(0, questions.Length)];

        questionText.text = randomQuestion.question;
        currentAnswer = randomQuestion.correctAnswer;

        string answer = currentAnswer;
        char[] letters = new char[9]; // Array for 9 letters
        System.Random rand = new System.Random();

        for (int i = 0; i < answer.Length; i++)
        {
            int index;
            do
            {
                index = rand.Next(9);
            } while (letters[index] != '\0');

            letters[index] = answer[i];
        }


        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = 0; i < 9; i++)
        {
            if (letters[i] == '\0')
            {
                char randomLetter;
                do
                {
                    randomLetter = alphabet[rand.Next(alphabet.Length)];
                } while (letters.Contains(randomLetter) || answer.Contains(randomLetter));

                letters[i] = randomLetter;
            }
        }

        letters = letters.OrderBy(x => rand.Next()).ToArray();
        for (int i = 0; i < 9; i++)
        {
            LetterDisplays[i].text = letters[i].ToString();
        }

        return letters;
    }
    public void DoGeneration()
    {
        char[] letters = LoadRandomQuestion();
        for (int i = 0; i < letters.Length; i++)
        {
            LetterDisplays[i].text = letters[i].ToString();
        }
    }
}
