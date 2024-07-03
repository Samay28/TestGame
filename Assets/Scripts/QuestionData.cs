using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "Quiz/Question Data", order = 1)]
public class QuestionData : ScriptableObject
{
    public string question;
    public string correctAnswer;
}
