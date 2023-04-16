public class WfwUserInputs : UserInputs
{
    public override void Init()
    {
        var level = game.CurrentLevel;
        var answerLength = level.Answer.Length;

        Inputs = new Char[answerLength];
    }

    public override void InputChar(Char c)
    {
        var index = NextInputIndex();

        if (index == -1) return;

        var newChar = Instantiate(charPrefab, transform);
        newChar.SetText(c.GetText());
        
        Inputs[index] = newChar;
        Inputs[index].charReference = c;
        
        c.Disable();
    }

    public override void Remove()
    {
        if (Inputs == null) return;

        foreach (var input in Inputs)
        {
            if (input == null) continue;
            
            input.charReference.Activate();
            Destroy(input.gameObject);
        }
    }

    protected override int NextInputIndex()
    {
        for (var i = 0; i < Inputs.Length; i++)
            if (Inputs[i] == null)
                return i;

        return -1;
    }
}