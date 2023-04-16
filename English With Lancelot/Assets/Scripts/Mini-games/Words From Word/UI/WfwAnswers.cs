using Mini_games;

public class WfwAnswers : GameSigns
{
    public int Count { get; private set; }

    public override void Init()
    {
        Signs = new Sign[GameConstants.WfwAnswersLimit];

        for (var i = 0; i < GameConstants.WfwAnswersLimit; i++)
        {
            var answer = Instantiate(signPrefab, transform);

            answer.SetText("");

            Signs[i] = answer;
        }
    }

    public void AddAnswer(string answer)
    {
        var index = GetNextEmptySign();

        if (index == -1) return;

        Count++;

        Signs[index].SetText(answer);
    }

    public override void Remove()
    {
        if (Signs == null) return;

        foreach (var answer in Signs)
            Destroy(answer.gameObject);

        Count = 0;
    }
}