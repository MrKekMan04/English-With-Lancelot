using Mini_games;
using UnityEngine;

public class WfwGame : GameWithKeyboard
{
    [SerializeField] private WfwUserInputs wfwUserInputs;
    [SerializeField] private WfwAnswers wfwAnswers;

    protected override void Init()
    {
        GameData = GetData(GameConstants.WfwDataPath);
        
        NextLevel();
    }
    
    public override void CheckIsAnswerRight(string userInput)
    {
        if (CurrentLevel.Responses.Contains(userInput) && !wfwAnswers.Contains(userInput))
        {
            wfwAnswers.AddAnswer(userInput);
            AddScore(userInput.Length);
        }

        if (wfwAnswers.Count == GameConstants.WfwAnswersLimit) 
            Win();
    }
    
    private void NextLevel()
    {
        CurrentLevel = GetNextLevel();
        KeyboardLength = CurrentLevel.Answer.Length;
        
        userKeyboard.Init();
        wfwAnswers.Init();
        wfwUserInputs.Init();
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
        wfwAnswers.Remove();
        wfwUserInputs.Remove();
        
        NextLevel();
    }
}