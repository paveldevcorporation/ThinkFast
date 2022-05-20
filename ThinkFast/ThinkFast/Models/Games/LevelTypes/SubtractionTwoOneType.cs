using System;
using ThinkFast.Models.Operations;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class SubtractionTwoOneType : LevelType
        {
            public SubtractionTwoOneType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, Operation.Minus, leadTime, pointCoefficient)
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

                const int firstMaxValue = 99;
                const int firstMinValue = 11;

                const int secondMaxValue = 9;
                const int secondMinValue = 1;

                var first = random.Next(firstMinValue, firstMaxValue);
                var second = random.Next(secondMinValue, secondMaxValue);

                return new GameExample(first, second, this);
            }
        }
    }
}