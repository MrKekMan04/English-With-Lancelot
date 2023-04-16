using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizButtons : MonoBehaviour
{
    [SerializeField] private QuizGame quizGame;
    
    private Button[] _buttons;

    public void Init()
    {
        _buttons = GetComponentsInChildren<Button>();
        SetButtonsText();
    }
    
    public void CheckAnswer(TextMeshProUGUI text) => quizGame.CheckIsAnswerRight(text.text);

    private void SetButtonsText()
    {
        var responses = ShuffleResponses(quizGame.CurrentLevel.Responses);
        
        for (var i = 0; i < _buttons.Length; i++)
            _buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = responses[i];
    }

    private static List<string> ShuffleResponses(List<string> list)
    {
        var random = new System.Random();
        var tempList = new List<string>(list);

        for (var i = list.Count - 1; i > 0; i--)
        {
            var j = random.Next(i + 1);
            (tempList[i], tempList[j]) = (tempList[j], tempList[i]);
        }

        return tempList;
    }
}