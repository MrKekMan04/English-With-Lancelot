using TMPro;
using UnityEngine;
public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject window;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private string gameName;
    [SerializeField] private string gameDescription;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            window.SetActive(true);
            UpdateInfo();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player")) 
            window.SetActive(false);
    }

    private void UpdateInfo()
    {
        name.text = gameName;
        description.text = gameDescription;
    }
}
