public class WbhUserInputs : UserInputs
{
    public override void Init()
    {
        var level = game.CurrentLevel;
        var answerLength = level.Answer.Length;

        Inputs = new Char[answerLength];

        InitChars();
    }

    public override void InputChar(Char c)
    {
        var index = NextInputIndex();

        if (index == -1) return;

        Inputs[index].SetText(c.GetText());
        Inputs[index].charReference = c;

        c.Disable();

        game.CheckIsAnswerRight(GetUserAnswer());
    }

    public override void Remove()
    {
        if (Inputs == null) return;

        foreach (var input in Inputs)
            Destroy(input.gameObject);
    }

    protected override int NextInputIndex()
    {
        for (var i = 0; i < Inputs.Length; i++)
            if (string.Equals(Inputs[i].GetText(), ""))
                return i;

        return -1;
    }

    private void InitChars()
    {
        for (var i = 0; i < Inputs.Length; i++)
        {
            var ch = Instantiate(charPrefab, transform);

            ch.Activate();
            ch.SetText("");

            Inputs[i] = ch;
        }
    }
}