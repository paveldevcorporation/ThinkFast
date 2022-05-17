namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class AdditionRoundTensType : LevelType
        {
            public AdditionRoundTensType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, '+', leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                return null;
            }

            public override long Calculate(long first, long second)
            {
                return first + second;
            }

            public override GameExample CreateExample()
            {
                //var random = new Random(DateTime.Now.Millisecond);

                const int maxValue = 90;
                const int minValue = 10;
                var first = Random.Next(minValue, maxValue);
                var second = Random.Next(minValue, maxValue);

                return new GameExample(first, GetRoundTens(second), this);
            }
        }
    }
}