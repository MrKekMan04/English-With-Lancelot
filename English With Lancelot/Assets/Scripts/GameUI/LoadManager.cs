using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameUI
{
    public class LoadManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI name;

        public void LoadGame() => SceneManager.LoadScene(name.text);

        public void SavePosition(Rigidbody2D player)
        {
            PlayerPrefs.SetFloat("X", player.position.x);
            PlayerPrefs.SetFloat("Y", player.position.y);
        }
    }
}
