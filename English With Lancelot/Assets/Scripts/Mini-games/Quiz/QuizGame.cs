using System;
using System.Collections.Generic;
using System.Linq;
using Mini_games.Quiz;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class QuizGame : MonoBehaviour
{
    public QuizLevel CurrentLevel { get; private set; }
    
    private const string DataPath = "Mini-games/Quiz/data";
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private ButtonsScript buttonsScript;

    private Dictionary<string, string> _quizData;
    private int _score;

    private void Awake() => Init();

    private void Init()
    {
        _quizData = GetData(DataPath);

        NextLevel();
    }

    private static Dictionary<string, string> GetData(string path)
    {
        var json = Resources.Load<TextAsset>(path).text;

        return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
    }

    private void NextLevel()
    {
        CurrentLevel = GetNextLevel();

        buttonsScript.Init();

        questionText.text = CurrentLevel.Question;
    }

    public void CheckIsAnswerRight(string userInput)
    {
        if (CurrentLevel.Answer.Equals(userInput, StringComparison.OrdinalIgnoreCase))
            Win();
        else
            Lose();
        
        NextLevel();
    }

    private QuizLevel GetNextLevel()
    {
        var answer = GetRandomWord(_quizData);
        var question = _quizData[answer];
        var responses = new List<string>(new[] { answer });

        for (var i = 0; i < 3; i++) 
            responses.Add(GetRandomWord(_quizData));

        return new QuizLevel(question, answer, responses);
    }

    private static string GetRandomWord(Dictionary<string, string> data) =>
        data.Keys.ToArray()[new System.Random().Next(data.Keys.Count)];

    private void Win() => SetScore(++_score);

    private void Lose() => SetScore(--_score);

    private void SetScore(int score) => scoreText.text = $"Points: {score}";
}