using System.Collections.Generic;
using ThinkFast.Services;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class Subtraction10To20Type : LevelType
        {
            private static int index;
            private static readonly (int, int)[] Examples = GetExamples();

            private static (int, int)[] GetExamples()
            {
                var a = GetNumbers(10, 10);
                var b = GetNumbers(10);

                var list = new List<(int, int)>(55);

                foreach (var i in a)
                {
                    foreach (var j in b)
                    {
                        if (i + j <= 20)
                        {
                            list.Add((i, j));
                        }
                    }
                }

                var examples = list.ToArray();

                examples.Shuffle();

                return examples;
            }

            public Subtraction10To20Type(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, '-', leadTime, pointCoefficient)
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
        }
    }
}