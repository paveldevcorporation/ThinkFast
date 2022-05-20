using ThinkFast.Models.Games;
using ThinkFast.Models.Games.LevelTypes;

namespace ThinkFast.Models.Games
{
    public sealed class GameExample
    {


        public GameExample(long first, long second, LevelType levelType)
        {
            First = first;
            Second = second;
            LevelType = levelType;
            AnswerMessage = GetSolution();
            Answer = levelType.Calculate(first, second).ToString();
        }

        private AnswerMessage GetSolution()
        {
            var solution = LevelType.GetSolution(First, Second);

            return solution ?? new AnswerMessage(string.Empty, ToString());
        }

        public long First { get; }

        public long Second { get; }

        public LevelType LevelType { get; }

        public string Question => $"{First} {LevelType.Operation.Symbol} {Second} = ";

        public string Answer { get;  }

        public AnswerMessage AnswerMessage { get; }

        public override string ToString()
        {
            return $"{First} {LevelType.Operation.Symbol} {Second} = {Answer}";
        }
    }
}