using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI name;

    public void LoadGame()
    {
        SceneManager.LoadScene(name.text);
    }
}
