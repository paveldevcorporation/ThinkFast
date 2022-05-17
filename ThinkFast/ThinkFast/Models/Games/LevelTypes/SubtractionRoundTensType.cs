using System;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class SubtractionRoundTensType : LevelType
        {
            public SubtractionRoundTensType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, '-', leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                return null;
            }

            public override long Calculate(long first, long second)
            {
                return first - second;
            }

            public override GameExample CreateExample()
            {
                var random = new Random(DateTime.Now.Millisecond);

                const int maxValue = 99;
                const int minValue = 20;
                var first = random.Next(minValue, maxValue);
                var second = random.Next(minValue, maxValue);

                return first >= second
                    ? new GameExample(first, GetRoundTens(second), this)
                    : new GameExample(second, GetRoundTens(first), this);
            }
        }
    }
}