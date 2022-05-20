using System;
using ThinkFast.Models.Operations;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class MultiplicationFourType : LevelType
        {
            public MultiplicationFourType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, Operation.Multiply, leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                var solution = $"{first} {Operation.Symbol} {second} = {first * 2} {Operation.Symbol} {2} = ";

                return new AnswerMessage(AppResources.Multiplication4Message, solution);
            }

            public override long Calculate(long first, long second)
            {
                return first * second;
            }

            public override GameExample CreateExample()
            {
                var random = new Random(DateTime.Now.Millisecond);

                const int maxValue = 99;
                const int minValue = 10;
                var first = random.Next(minValue, maxValue);
                const int second = 4;

                return new GameExample(first, second, this);
            }

            public override string[] Rules => new[] { AppResources.Multiplication4Message };

        }
    }
}