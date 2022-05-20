using System.Collections.Generic;
using ThinkFast.Models.Operations;
using ThinkFast.Services;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class Addition1To10Type : LevelType
        {
            private static int index;
            private static readonly (int, int)[] Examples = GetExamples();

            private static (int, int)[] GetExamples()
            {
	            var a = GetNumbers(10);
	            var b = GetNumbers(10);

	            var list = new List<(int, int)>(45);

	            foreach (var i in a)
	            {
		            foreach (var j in b)
		            {
			            if (i + j <= 10)
			            {
				            list.Add((i, j));
			            }
		            }
	            }

	            var examples = list.ToArray();

                examples.Shuffle();

	            return examples;
            }

            public Addition1To10Type(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, Operation.Plus, leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                return null;
            }

            public override long Calculate(long first, long second)
            {
                return first + second;
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

                return new GameExample(first, second, this);
            }
        }
    }
}