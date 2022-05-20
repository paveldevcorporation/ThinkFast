using System;
using System.Text;
using ThinkFast.Models.Operations;
using ThinkFast.Services;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class MultiplicationTableType : LevelType
        {
            private static int index;
            private static readonly int[] seconds = GetNumbers(10);

            private readonly int firstNumber;

            public MultiplicationTableType(int id, uint leadTime, int first, float pointCoefficient)
                : base(id, string.Empty, Operation.Multiply, leadTime, pointCoefficient)
            {
                firstNumber = first;
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                return null;
            }

            public override long Calculate(long first, long second)
            {
                return first * second;
            }

            public override GameExample CreateExample()
            {
                if (index >= seconds.Length)
                {
                    index = 0;
                    seconds.Shuffle();
                }

                var second = seconds[index];
                index++;

                return new GameExample(firstNumber, second, this);
            }

            public override string[] Rules => GetRule();

            private string[] GetRule()
            {
                var list = new StringBuilder(200);
                Array.Sort(seconds);

                foreach (var second in seconds)
                {
                    list.Append($"{firstNumber} {Operation.Symbol} {second} = {firstNumber * second}\n");
                }
                seconds.Shuffle();

                return new[] {list.ToString()};
            }
        }
    }
}