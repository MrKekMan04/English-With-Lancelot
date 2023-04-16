using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WbhChar : Char
{
    private WbhUserInputs _wbhUserInputs;

    protected override void Init()
    {
        Button = GetComponent<Button>();
        ButtonText = GetComponentInChildren<TextMeshProUGUI>();
        _wbhUserInputs = GameObject.Find("Inputs").GetComponent<WbhUserInputs>();
    }

    public override void OnClick()
    {
        if (_wbhUserInputs.ContainsChar(this))
        {
            if (charReference == null) return;
            
            SetText("");
            charReference.Activate();
        }
        else
            _wbhUserInputs.InputChar(this);
    }

    public static char GetRandomChar() => Convert.ToChar(new System.Random().Next('A', 'Z'));
}