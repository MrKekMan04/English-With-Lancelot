using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Char : MonoBehaviour
{
    public Char charReference;
    
    protected Button Button;
    protected TextMeshProUGUI ButtonText;
    
    private void Awake() => Init();

    public abstract void OnClick();
    
    protected abstract void Init();
    
    public string GetText() => ButtonText.text;

    public void SetText(string text) => ButtonText.text = text;

    public void Disable() => Button.interactable = false;

    public void Activate() => Button.interactable = true;
}