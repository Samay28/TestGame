using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonTextGetter : MonoBehaviour
{
    
    public TextMeshProUGUI[] buttonTexts;
    public Button[] buttons;
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => PrintButtonLetter(index));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void PrintButtonLetter(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < buttonTexts.Length && !string.IsNullOrEmpty(buttonTexts[buttonIndex].text))
        {
            char letter = buttonTexts[buttonIndex].text[0];
            Debug.Log("The letter on button " + buttonIndex + " is: " + letter);
        }
        else
        {
            Debug.Log("Invalid button index or empty button text.");
        }
    }
}
