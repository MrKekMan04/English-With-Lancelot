using System.Collections.Generic;

namespace Mini_games.Words_By_Hints
{
    public class Level
    {
        public string Answer { get; private set; }

        public List<string> Hints { get; private set; }

        public Level(string answer, List<string> hints)
        {
            Answer = answer;
            Hints = hints;
        }
    }
}