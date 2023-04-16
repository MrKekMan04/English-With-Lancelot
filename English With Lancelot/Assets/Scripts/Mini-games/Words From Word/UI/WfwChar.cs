using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WfwChar : Char
{
    private WfwUserInputs _userInputs;
    
    protected override void Init()
    {
        Button = GetComponent<Button>();
        ButtonText = GetComponentInChildren<TextMeshProUGUI>();
        _userInputs = GameObject.Find("Inputs").GetComponent<WfwUserInputs>();
    }
    
    public override void OnClick()
    {
        if (!_userInputs.ContainsChar(this)) 
            _userInputs.InputChar(this);
    }
}