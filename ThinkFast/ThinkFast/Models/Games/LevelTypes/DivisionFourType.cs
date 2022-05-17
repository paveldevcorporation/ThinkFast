using System;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class DivisionFourType : LevelType
        {
            public DivisionFourType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, '÷', leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                var solution = $"{first} {Symbol} {second} = {first / 2} {Symbol} {2} = ";

                return new AnswerMessage(AppResources.Division4Message, solution);
            }

            public override long Calculate(long first, long second)
            {
                return first / second;
            }

            public override GameExample CreateExample()
            {
                var random = new Random(DateTime.Now.Millisecond);

                const int maxValue = 250;
                const int minValue = 12;
                var first = random.Next(minValue, maxValue);
                const int second = 4;

                var answer = first * second;

                return new GameExample(answer, second, this);
            }

            public override string[] Rules => new[] { AppResources.Division4Message };

        }
    }
}