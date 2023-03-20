using System;
using System.Collections.Generic;
using System.Linq;
using Mini_games.Words_By_Hints;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Keyboard userKeyboard;
    [SerializeField] private Inputs userInputs;
    [SerializeField] private Hints hints;

    [SerializeField] private TextMeshProUGUI scoreText;
    
    public Level CurrentLevel { get; private set; }
    
    private const string DataPath = "Mini-games/Words By Hints/data";

    private Dictionary<string, List<string>> _gameData;
    private int _score;

    private void Awake() => Init();

    private void Init()
    {
        _gameData = GetData(DataPath);
        
        NextLevel();
    }

    public void CheckIsAnswerRight(string userInput)
    {
        if (CurrentLevel.Answer.Equals(userInput, StringComparison.OrdinalIgnoreCase)) 
            Win();
    }

    private static Dictionary<string, List<string>> GetData(string path)
    {
        var json = Resources.Load<TextAsset>(path).text;

        return JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
    }

    private void NextLevel()
    {
        CurrentLevel = GetNextLevel();
        
        userInputs.Init();
        userKeyboard.Init();
        hints.Init();
    }
    
    private Level GetNextLevel()
    {
        var answer = GetRandomWord(_gameData);
        var responses = _gameData[answer];
        
        return new Level(answer, responses);
    }

    private static string GetRandomWord(Dictionary<string, List<string>> data) =>
        data.Keys.ToArray()[new System.Random().Next(data.Keys.Count)];

    private void Win()
    {
        userInputs.Remove();
        userKeyboard.Remove();
        hints.Remove();
        
        SetScore(++_score);
        NextLevel();
    }

    private void SetScore(int score) => scoreText.text = $"Points: {score}";
}