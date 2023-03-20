using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private Hint hintPrefab;

    private Hint[] _hints;

    public void Init() => InitHints(game.CurrentLevel.Hints);

    public void Remove()
    {
        if (_hints == null) return;

        foreach (var hint in _hints)
            Destroy(hint.gameObject);
    }

    private void InitHints(IReadOnlyList<string> hints)
    {
        var hintsCount = hints.Count;
        
        _hints = new Hint[hintsCount];
        
        for (var i = 0; i < hintsCount; i++)
        {
            var hint = Instantiate(hintPrefab, transform);

            hint.SetText(hints[i]);

            _hints[i] = hint;
        }
    }
}
