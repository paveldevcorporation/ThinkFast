using System;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class Subtraction789Type : LevelType
        {
            public Subtraction789Type(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, '-', leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                switch (second)
                {
                    case 7:
                    {
                        var solution = $"{first} - {second} = {first} - {Ten} + 3 = ";


                        return new AnswerMessage(AppResources.Minus7Message, solution);
                    }
                    case 8:
                    {
                        var solution = $"{first} - {second} = {first} - {Ten} + 2 = ";

                        return new AnswerMessage(AppResources.Minus8Message, solution);
                    }
                    case 9:
                    {
                        var solution = $"{first} - {second} = {first} - {Ten} + 1 = ";

                        return new AnswerMessage(AppResources.Minus9Message, solution);
                    }
                    default: return null;
                }
            }

            public override long Calculate(long first, long second)
            {
                return first - second;
            }

            public override GameExample CreateExample()
            {
                var random = new Random(DateTime.Now.Millisecond);

                const int firstMaxValue = 90;
                const int firstMinValue = 20;

                const int secondMaxValue = 9;
                const int secondMinValue = 7;

                var second = random.Next(secondMinValue, secondMaxValue);
                var first = GetFirst(random, firstMinValue, firstMaxValue, second);

                return new GameExample(first, second, this);
            }

            private static int GetFirst(Random random, int firstMinValue, int firstMaxValue, int second)
            {
                while (true)
                {
                    var first = random.Next(firstMinValue, firstMaxValue);

                    if ((first - second) % 10 == 0)
                    {
                        continue;
                    }

                    return first;
                }
                
            }

            public override string[] Rules => new[] { AppResources.Minus7Message, AppResources.Minus8Message, AppResources.Minus9Message };
        }
    }
}