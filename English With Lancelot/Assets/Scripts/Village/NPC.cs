using GameUI;
using UnityEngine;

namespace Village
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] private GameObject window;
        [SerializeField] private string gameName;
        [SerializeField] private string gameDescription;

        private MainUI _mainUI;

        public void Start() => _mainUI = window.GetComponent<MainUI>();

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            _mainUI.Open();
            _mainUI.UpdateInfo(gameName, gameDescription);
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            _mainUI.Hide();
        }
    }
}
