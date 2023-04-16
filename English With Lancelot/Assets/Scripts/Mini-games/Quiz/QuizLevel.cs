using System.Collections.Generic;

namespace Mini_games.Quiz
{
    public class QuizLevel
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public List<string> Responses { get; private set; }
        
        public QuizLevel(string question, string answer, List<string> responses)
        {
            Question = question;
            Answer = answer;
            Responses = responses;
        }
    }
}
