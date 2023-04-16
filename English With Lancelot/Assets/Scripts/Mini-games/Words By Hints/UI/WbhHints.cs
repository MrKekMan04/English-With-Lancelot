using UnityEngine;

public class WbhHints : GameSigns
{
    [SerializeField] private WbhGame game;

    public override void Init()
    {
        var hints = game.CurrentLevel.Responses;
        
        var hintsCount = hints.Count;
        
        Signs = new Sign[hintsCount];
        
        for (var i = 0; i < hintsCount; i++)
        {
            var hint = Instantiate(signPrefab, transform);

            hint.SetText(hints[i]);

            Signs[i] = hint;
        }
    }

    public override void Remove()
    {
        if (Signs == null) return;

        foreach (var hint in Signs)
            Destroy(hint.gameObject);
    }
}
