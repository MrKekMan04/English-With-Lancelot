using System.Collections.Generic;
using System.Linq;
using Mini_games;
using Mini_games.Words_By_Hints;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Game : MonoBehaviour
{
    public Level CurrentLevel { get; protected set; }

    [SerializeField] protected TextMeshProUGUI scoreText;
    [SerializeField] protected Image clockSprite;
    [SerializeField] protected float levelTime;

    protected Dictionary<string, List<string>> GameData;
    private int _score;
    private float _timeElapsed;

    private void Awake() => Init();

    private void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed >= levelTime) 
            SceneManager.LoadScene(GameConstants.VillageSceneName);

        clockSprite.fillAmount = (levelTime - _timeElapsed) / levelTime;
    }

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
        _score += score;
        
        UpdateScore();
    }

    private void UpdateScore() => scoreText.text = $"Points: {_score}";
}