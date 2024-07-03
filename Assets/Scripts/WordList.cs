using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList : MonoBehaviour
{
    public TextAsset wordListTextAsset;
    private HashSet<string> validWords;
    void Awake()
    {
        LoadWordList();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadWordList()
    {
        validWords = new HashSet<string>();
        string[] words = wordListTextAsset.text.Split('\n');
        foreach (string word in words)
        {
            validWords.Add(word.Trim().ToUpper());
        }
    }

    public bool IsValidWord(string word)
    {
        return validWords.Contains(word.ToUpper());
    }
}
