using System;
using System.Collections.Generic;
using System.Linq;
using Mini_games;
using Mini_games.Words_By_Hints;
using TMPro;
using UnityEngine;

public class QuizGame : Game
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuizButtons quizButtons;

    protected override void Init()
    {
        GameData = GetData(GameConstants.QuizDataPath);

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
        // TODO: Lose
        NextLevel();
    }
}