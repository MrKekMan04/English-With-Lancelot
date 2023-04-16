using UnityEngine;

public abstract class GameWithKeyboard : Game
{
    [SerializeField] protected Keyboard userKeyboard;
    [SerializeField] protected UserInputs userInputs;
    [SerializeField] protected GameSigns gameSigns;

    public int KeyboardLength { get; protected set; }
}