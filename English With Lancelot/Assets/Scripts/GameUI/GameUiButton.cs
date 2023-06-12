using Mini_games;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUiButton : MonoBehaviour
{
    public void GoToVillage() => SceneManager.LoadScene(GameConstants.VillageSceneName);
    
    public void QuitGame() => Application.Quit();
}
