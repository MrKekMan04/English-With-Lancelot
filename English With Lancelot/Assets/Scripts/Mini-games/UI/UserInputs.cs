using System.Linq;
using System.Text;
using UnityEngine;

public abstract class UserInputs : MonoBehaviour
{
    [SerializeField] protected GameWithKeyboard game;
    [SerializeField] protected Char charPrefab;
    
    protected Char[] Inputs;

    public abstract void Init();

    public abstract void InputChar(Char c);

    public abstract void Remove();

    public string GetUserAnswer()
    {
        var sb = new StringBuilder();
        
        foreach (var input in Inputs.Where(c => c != null))
            sb.Append(input.GetText() ?? "");
        
        return sb.ToString();
    }

    public bool ContainsChar(Char c) => Inputs.Any(input => input == c);

    protected abstract int NextInputIndex();
}