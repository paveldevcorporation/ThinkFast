using System;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class MultiplicationFiveType : LevelType
        {
            public MultiplicationFiveType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, '×', leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                if (first % 2 == 0)
                {
                    var solution = $"{first} {Symbol} {second} = {first} ÷ {2} {Symbol} {Ten} = ";

                    return new AnswerMessage(AppResources.Multiplication5_2Message, solution);
                }

                var solution2 = $"{first} {Symbol} {second} = {first} {Symbol} {Ten} ÷ {2} = ";

                return new AnswerMessage(AppResources.Multiplication5Message, solution2);
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
                const int second = 5;

                return new GameExample(first, second, this);
            }

            public override string[] Rules => new[] { AppResources.Multiplication5Message, AppResources.Multiplication5_2Message };

        }
    }
}