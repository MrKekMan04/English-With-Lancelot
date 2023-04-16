using System;
using Mini_games;
using Mini_games.Words_By_Hints;

public class WbhGame : GameWithKeyboard
{
    protected override void Init()
    {
        GameData = GetData(GameConstants.WbhDataPath);
        KeyboardLength = GameConstants.WbhKeyboardLength;

        NextLevel();
    }

    public override void CheckIsAnswerRight(string userInput)
    {
        if (!CurrentLevel.Answer.Equals(userInput, StringComparison.OrdinalIgnoreCase)) return;
        
        AddScore(1);
        Win();
    }

    private void NextLevel()
    {
        CurrentLevel = GetNextLevel();

        userKeyboard.Init();
        userInputs.Init();
        gameSigns.Init();
    }
    
    private Level GetNextLevel()
    {
        var answer = GetRandomWord(GameData);
        var responses = GameData[answer];
        
        return new Level(answer, responses);
    }

    private void Win()
    {
        userKeyboard.Remove();
        userInputs.Remove();
        gameSigns.Remove();

        NextLevel();
    }
}