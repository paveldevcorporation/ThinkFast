using System;
using ThinkFast.Models.Operations;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class AdditionTwoOneType : LevelType
        {
            public AdditionTwoOneType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, Operation.Plus, leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                var answer = first + second;
                var withTransition = first / 10 < answer / 10;

                if (answer > 10 && withTransition && answer % 10 != 0)
                {
                    var x = answer / 10 * 10;
                    var secondOne = x - first;
                    var secondTwo = answer - x;
                    var solution = $"{first} + {second} = {first} + {secondOne} + {secondTwo} = ";

                    return new AnswerMessage(AppResources.Addition1To20Rule, solution);
                }

                return null;
            }

            public override long Calculate(long first, long second)
            {
                return first + second;
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

            public override string[] Rules => new[] { AppResources.Addition1To20Rule };
        }
    }
}