using System.Linq;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private Char charPrefab;

    private const int KeyboardLength = 16;

    private Char[] _keyboard;

    public void Init()
    {
        var level = game.CurrentLevel;
        var answer = level.Answer;

        _keyboard = new Char[KeyboardLength];

        InitChars(answer.ToCharArray());
    }

    public void Remove()
    {
        if (_keyboard == null) return;

        foreach (var c in _keyboard) 
            Destroy(c.gameObject);
    }

    private void InitChars(char[] chars)
    {
        var trueCharsLeft = chars.Length;
        var unUsedIndexes = Enumerable.Range(0, trueCharsLeft).ToList();

        var random = new System.Random();

        for (var i = 0; i < KeyboardLength; i++)
        {
            var ch = Instantiate(charPrefab, transform);

            if ((random.Next(0, 1 + 1) == 0 || KeyboardLength == i + 1 + trueCharsLeft) && trueCharsLeft > 0)
            {
                var index = unUsedIndexes[random.Next(0, unUsedIndexes.Count)];

                ch.SetText(chars[index].ToString());

                trueCharsLeft--;
                unUsedIndexes.Remove(index);
            }
            else
                ch.SetText(Char.GetRandomChar().ToString());

            ch.Activate();

            _keyboard[i] = ch;
        }
    }
}