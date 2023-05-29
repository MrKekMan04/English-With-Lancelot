using System;
using System.Collections.Generic;
using System.Linq;
using Mini_games;
using Mini_games.Words_By_Hints;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizGame : Game
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuizButtons quizButtons;
    [SerializeField] private Image[] hearts;
    
    private int _hearts;

    protected override void Init()
    {
        GameData = GetData(GameConstants.QuizDataPath);
        _hearts = 3;

        NextLevel();
    }

    private void NextLevel()
    {
        CurrentLevel = GetNextLevel();

        quizButtons.Init();

        questionText.text = GameData[CurrentLevel.Answer].FirstOrDefault();
    }

    public override void CheckIsAnswerRight(string userInput)
    {
        if (CurrentLevel.Answer.Equals(userInput, StringComparison.OrdinalIgnoreCase))
        {
            AddScore(1);
            Win();
        }
        else
            Lose();
    }

    private Level GetNextLevel()
    {
        var answer = GetRandomWord(GameData);
        var responses = new List<string> { answer };

        for (var i = 0; i < GameConstants.ResponsesCount - 1; i++)
            responses.Add(GetRandomWord(GameData));

        return new Level(answer, responses);
    }

    private void Win() => NextLevel();

    private void Lose()
    {
        RemoveHeart();

        if (_hearts > 0)
            NextLevel();
        else
            SceneManager.LoadScene(GameConstants.VillageSceneName);
    }

    private void RemoveHeart()
    {
        _hearts--;
        
        hearts.First(image => image.gameObject.activeSelf).gameObject.SetActive(false);
    }
}