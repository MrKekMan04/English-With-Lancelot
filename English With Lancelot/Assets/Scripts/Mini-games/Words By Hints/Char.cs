using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(TextMeshProUGUI))]
public class Char : MonoBehaviour
{
    private Inputs _inputs;
    
    private Button _button;
    private TextMeshProUGUI _buttonText;

    private Char _keyboardsCharReference;

    private void Awake() => Init();

    private void Init()
    {
        _button = GetComponent<Button>();
        _buttonText = GetComponentInChildren<TextMeshProUGUI>();
        _inputs = GameObject.Find("Inputs").GetComponent<Inputs>();
    }

    public string GetText() => _buttonText.text;
    
    public void SetText(string text) => _buttonText.text = text;

    public void Disable() => _button.interactable = false;

    public void Activate() => _button.interactable = true;

    public void SetCharReference(Char ch) => _keyboardsCharReference = ch;

    public void OnClick()
    {
        if (_inputs.ContainsChar(this))
        {
            SetText("");
            _keyboardsCharReference.Activate();
        }
        else
            _inputs.InputChar(this);
    }

    public static char GetRandomChar()
    {
        const int asciiA = 65;
        const int asciiZ = 90;

        return Convert.ToChar(new System.Random().Next(asciiA, asciiZ));
    }
}