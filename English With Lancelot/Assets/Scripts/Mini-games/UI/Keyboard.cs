using System.Linq;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private GameWithKeyboard game;
    [SerializeField] private Char charPrefab;

    private Char[] _keyboard;

    public void Init()
    {
        var level = game.CurrentLevel;
        var answer = level.Answer;

        _keyboard = new Char[game.KeyboardLength];

        InitChars(answer.ToCharArray());
    }

    public void Remove()
    {
        if (_keyboard == null) return;

        foreach (var c in _keyboard)
            Destroy(c.gameObject);
    }

    private void InitChars(char[] wordChars)
    {
        var correctCharsLeft = wordChars.Length;
        var unUsedIndexes = Enumerable.Range(0, correctCharsLeft).ToList();

        var random = new System.Random();

        for (var i = 0; i < _keyboard.Length; i++)
        {
            var ch = Instantiate(charPrefab, transform);

            if ((random.Next(0, 1 + 1) == 0 || _keyboard.Length == i + correctCharsLeft) && correctCharsLeft > 0)
            {
                var index = game is WbhGame ? unUsedIndexes[random.Next(0, unUsedIndexes.Count)] : i;

                ch.SetText(wordChars[index].ToString());

                correctCharsLeft--;
                unUsedIndexes.Remove(index);
            }
            else
                ch.SetText(WbhChar.GetRandomChar().ToString());

            ch.Activate();

            _keyboard[i] = ch;
        }
    }
}