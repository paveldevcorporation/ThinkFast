using System.Collections.Generic;
using ThinkFast.Models.Operations;
using ThinkFast.Resources;
using ThinkFast.Services;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class Subtraction1To20Type : LevelType
        {
            private static int index;
            private static readonly (int, int)[] Examples = GetExamples();

            private static (int, int)[] GetExamples()
            {
	            var a = GetNumbers(10);
	            var b = GetNumbers(10);

	            var list = new List<(int, int)>(36);

	            foreach (var i in a)
	            {
		            foreach (var j in b)
		            {
			            var answer = i + j;
			            var correct = j != Ten
			                          && i != Ten
			                          && answer > 10
			                          && answer <= 20;

			            if (correct)
			            {
				            list.Add((i, j));
			            }
		            }
	            }

	            var examples = list.ToArray();

	            examples.Shuffle();

	            return examples;
            }

            public Subtraction1To20Type(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, Operation.Minus, leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                var answer = first - second;

                if (answer < Ten && first > Ten && second != Ten)
                {
                    var secondOne = first - Ten;
                    var secondTwo = Ten - answer;
                    var solution = $"{first} - {second} = {first} - {secondOne} - {secondTwo} = ";

                    return new AnswerMessage(AppResources.Subtraction1To20Rule, solution);
                }

                return null;
            }

            public override long Calculate(long first, long second)
            {
                return first - second;
            }

            public override GameExample CreateExample()
            {
	            if (index >= Examples.Length)
	            {
		            index = 0;
		            Examples.Shuffle();
	            }

	            var (first, second) = Examples[index];
	            index++;

	            var sum = first + second;

	            return new GameExample(sum, second, this);
            }

            public override string[] Rules => new[] { AppResources.Subtraction1To20Rule };
        }
    }
}