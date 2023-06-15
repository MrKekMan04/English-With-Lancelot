using System.Collections.Generic;

namespace Mini_games
{
    public class Level
    {
        public string Answer { get; private set; }
        public List<string> Responses { get; private set; }

        public Level(string answer, List<string> responses)
        {
            Answer = answer;
            Responses = responses;
        }
    }
}