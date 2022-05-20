using System;
using ThinkFast.Models.Operations;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class DivisionEightType : LevelType
        {
            public DivisionEightType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, Operation.Division, leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                var solution = $"{first} {Operation.Symbol} {second} = {first / 2} {Operation.Symbol} {2} = {first / 2 / 2 } {Operation.Symbol} {2} = ";

                return new AnswerMessage(AppResources.Division8Message, solution);
            }

            public override long Calculate(long first, long second)
            {
                return first / second;
            }

            public override GameExample CreateExample()
            {
                var random = new Random(DateTime.Now.Millisecond);

                const int maxValue = 125;
                const int minValue = 12;
                var first = random.Next(minValue, maxValue);
                const int second = 8;

                var answer = first * second;

                return new GameExample(answer, second, this);
            }

            public override string[] Rules => new[] { AppResources.Division8Message };

        }
    }
}