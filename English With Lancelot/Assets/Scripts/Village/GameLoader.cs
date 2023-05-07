using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name;

    public void LoadGame() => SceneManager.LoadScene(name.text);
}
