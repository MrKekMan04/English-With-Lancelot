using System;
using System.Linq;
using System.Text;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private Char charPrefab;

    private Char[] _inputs;

    public void Init()
    {
        var level = game.CurrentLevel;
        var answerLength = level.Answer.Length;

        _inputs = new Char[answerLength];

        InitChars();
    }

    public void InputChar(Char ch)
    {
        var index = NextInputIndex();

        if (index == -1) return;

        _inputs[index].SetText(ch.GetText());
        _inputs[index].SetCharReference(ch);

        ch.Disable();

        game.CheckIsAnswerRight(GetUserAnswer());
    }

    public bool ContainsChar(Char ch) => _inputs.Any(c => c == ch);

    public void Remove()
    {
        if (_inputs == null) return;
        
        foreach (var input in _inputs) 
            Destroy(input.gameObject);
    }

    private void InitChars()
    {
        for (var i = 0; i < _inputs.Length; i++)
        {
            var ch = Instantiate(charPrefab, transform);

            ch.Activate();
            ch.SetText("");

            _inputs[i] = ch;
        }
    }

    private int NextInputIndex()
    {
        for (var i = 0; i < _inputs.Length; i++)
            if (string.Equals(_inputs[i].GetText(), "", StringComparison.Ordinal))
                return i;

        return -1;
    }

    private string GetUserAnswer()
    {
        var sb = new StringBuilder();
        
        foreach (var input in _inputs) 
            sb.Append(input.GetText() ?? "");
        
        return sb.ToString();
    }
}