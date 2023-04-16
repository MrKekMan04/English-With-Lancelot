using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Sign : MonoBehaviour
{
    private TextMeshProUGUI _text;
    
    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    public string GetText() => _text.text;
    
    public void SetText(string text) => _text.text = text;
}
