using System;
using System.Linq;
using UnityEngine;

public abstract class GameSigns : MonoBehaviour
{
    [SerializeField] protected Sign signPrefab;

    protected Sign[] Signs;

    public abstract void Init();
    
    public abstract void Remove();
    
    public bool Contains(string answer) =>
        Signs.Where(sign => sign != null).Any(sign => sign.GetText().Equals(answer, StringComparison.Ordinal));

    protected int GetNextEmptySign()
    {
        for (var i = 0; i < Signs.Length; i++)
            if (Signs[i].GetText().Equals("", StringComparison.Ordinal))
                return i;

        return -1;
    }
}