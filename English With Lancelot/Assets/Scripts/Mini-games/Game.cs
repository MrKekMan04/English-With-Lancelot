using System.Collections.Generic;
using System.Linq;
using Mini_games.Words_By_Hints;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public abstract class Game : MonoBehaviour
{
    public Level CurrentLevel { get; protected set; }

    [SerializeField] protected TextMeshProUGUI scoreText;

    protected Dictionary<string, List<string>> GameData;
    protected int Score;

    private void Awake() => Init();

    protected abstract void Init();
    
    public abstract void CheckIsAnswerRight(string userInput);

    protected static Dictionary<string, List<string>> GetData(string path)
    {
        var json = Resources.Load<TextAsset>(path).text;

        return JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
    }
    
    protected static string GetRandomWord(Dictionary<string, List<string>> data) =>
        data.Keys.ToArray()[new System.Random().Next(data.Keys.Count)];

    protected void AddScore(int score)
    {
        Score += score;
        
        UpdateScore();
    }

    private void UpdateScore() => scoreText.text = $"Points: {Score}";
}