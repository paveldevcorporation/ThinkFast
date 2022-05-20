using System;
using ThinkFast.Resources;
using ThinkFast.Models.Operations;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class Multiplication25Type : LevelType
        {
            public Multiplication25Type(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, Operation.Multiply, leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
	            if (first % 4 == 0)
	            {
		            var solution = $"{first} {Operation.Symbol} {second} = {first} ÷ {4} {Operation.Symbol} {100} = ";

		            return new AnswerMessage(AppResources.Multiplication25_4Message, solution);
	            }

	            var solution2 = $"{first} {Operation.Symbol} {second} = {first} {Operation.Symbol} {100} ÷ {4} = ";

	            return new AnswerMessage(AppResources.Multiplication25Message, solution2);
            }

            public override long Calculate(long first, long second)
            {
                return first * second;
            }

            public override GameExample CreateExample()
            {
                var random = new Random(DateTime.Now.Millisecond);

                const int maxValue = 100;
                const int minValue = 10;
                var first = random.Next(minValue, maxValue);
                const int second = 25;

                return new GameExample(first, second, this);
            }

            public override string[] Rules => new[] { AppResources.Multiplication25Message, AppResources.Multiplication25_4Message };

        }
    }
}