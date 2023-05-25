using TMPro;
using UnityEngine;

namespace GameUI
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private TextMeshProUGUI description;

        public void Hide() => animator.SetBool("IsOpen", true);

        public void Open() => animator.SetBool("IsOpen", false);

        public void UpdateInfo(string title, string text)
        {
            name.text = title;
            description.text = text;
        }
    }
}
