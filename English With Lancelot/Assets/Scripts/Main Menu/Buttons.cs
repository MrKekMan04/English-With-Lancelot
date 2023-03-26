using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene("Game");
    
    public void QuitGame() => Application.Quit();
}
