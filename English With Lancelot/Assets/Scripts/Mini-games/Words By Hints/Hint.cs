using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Hint : MonoBehaviour
{
    private TextMeshProUGUI _text;
    
    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    public void SetText(string text) => _text.text = text;
}
