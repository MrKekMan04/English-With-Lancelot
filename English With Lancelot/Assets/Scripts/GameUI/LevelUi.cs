using Mini_games;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUi : MonoBehaviour
{
    [SerializeField] private Slider levelBar;
    [SerializeField] private TextMeshProUGUI levelText;
    
    private void Awake()
    {
        var playerStats = LevelingSystem.GetPlayerStats();

        var currentExp = playerStats[GameConstants.PlayerExpKey];
        var currentLevel = playerStats[GameConstants.PlayerLevelKey];
        
        SetBarValue((float)currentExp / (currentLevel * GameConstants.LevelExpIncrease));
        SetCurrentLevel(currentLevel);
    }

    private void SetBarValue(float value) => levelBar.value = value;

    private void SetCurrentLevel(int level) => levelText.text = $"Level: {level}";
}
