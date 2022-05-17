using ThinkFast.Models.Games;
using ThinkFast.Models.Games.LevelTypes;

namespace ThinkFast.Models.Games
{
    public sealed class GameExample
    {
        private readonly long first;

        private readonly long second;

        private readonly LevelType levelType;

        public GameExample(long first, long second, LevelType levelType)
        {
            this.first = first;
            this.second = second;
            this.levelType = levelType;
            AnswerMessage = GetSolution();
            Answer = levelType.Calculate(first, second).ToString();
        }

        private AnswerMessage GetSolution()
        {
            var solution = levelType.GetSolution(first, second);

            return solution ?? new AnswerMessage(string.Empty, ToString());
        }


        public string Question => $"{first} {levelType.Symbol} {second} = ";

        public string Answer { get;  }

        public AnswerMessage AnswerMessage { get; }

        public override string ToString()
        {
            return $"{first} {levelType.Symbol} {second} = {Answer}";
        }
    }
}