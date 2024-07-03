using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerLevel2 : MonoBehaviour
{

    public TextMeshProUGUI[] buttonTexts;
    public Button[] buttons;
    public TextMeshProUGUI displayText;
    public TMP_Text scoreText;
    public TMP_Text InfoText;

    private HashSet<char> uniqueLetters = new HashSet<char>();
    int score = 0;
    private WordList wordDictionary;
    // private RandomLetterGenerator RLG;
    private Timer TimeLeft;
    void Start()
    {
        wordDictionary = FindObjectOfType<WordList>();
        // RLG = FindObjectOfType<RandomLetterGenerator>();
        TimeLeft = FindObjectOfType<Timer>();

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => PrintButtonLetter(index));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeLeft.timer == 0 && score >= 3)
        {
            InfoText.text = "Game Won! Starting New Level!";
            Invoke("NextScene", 5f);
        }
        else if (TimeLeft.timer == 0 && score < 3)
        {
            InfoText.text = "Game Lost! restarting Level!";
            Invoke("ReloadScene", 5f);
        }
    }
    void PrintButtonLetter(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < buttonTexts.Length && !string.IsNullOrEmpty(buttonTexts[buttonIndex].text) && TimeLeft.timer != 0)
        {
            char letter = buttonTexts[buttonIndex].text[0];
            if (uniqueLetters.Add(letter))
            {
                UpdateDisplayText();
            }
        }
        else
        {
            Debug.Log("Invalid button index or empty button text.");
        }
    }
    void UpdateDisplayText()
    {
        displayText.text = string.Join("", uniqueLetters);
    }

    public void EnterText()
    {
        if (TimeLeft.timer > 0)
        {
            CheckWord(displayText.text);
        }
    }
    void CheckWord(string word)
    {
        if (displayText.text.Length < 3)
        {
            InfoText.text = "Enter 3 letters Minimum!";
            ClearDisplayText();
        }
        else if (wordDictionary.IsValidWord(word))
        {
            score++;
            scoreText.text = "Score: " + score;
            ResetLetters();
            FindObjectOfType<RandomLetterGenerator>().GenerateRandomLetters();
            InfoText.text = "Awesome!";
        }
        else
        {
            ClearDisplayText();
            InfoText.text = "Try Again";
        }
    }

    void ClearDisplayText()
    {
        displayText.text = "";
        uniqueLetters.Clear();
    }

    void ResetLetters()
    {
        // RLG.DoGeneration();
        ClearDisplayText();
    }
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    void NextScene()
    {
        SceneManager.LoadScene("Level3");
    }
}
