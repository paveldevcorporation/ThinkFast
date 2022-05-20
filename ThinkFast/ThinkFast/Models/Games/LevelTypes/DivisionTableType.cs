using System;
using System.Text;
using ThinkFast.Models.Operations;
using ThinkFast.Services;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class DivisionTableType : LevelType
        {
            private static int index;
            private static readonly int[] firsts = GetNumbers(10);

            private readonly int secondNumber;

            public DivisionTableType(int id, uint leadTime, int second, float pointCoefficient)
                : base(id, string.Empty, Operation.Division, leadTime, pointCoefficient)
            {
                secondNumber = second;
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                return null;
            }

            public override long Calculate(long first, long second)
            {
                return first / second;
            }

            public override GameExample CreateExample()
            {
                if (index >= firsts.Length)
                {
                    index = 0;
                    firsts.Shuffle();
                }

                var first = firsts[index];

                index++;

                var answer = first * secondNumber;

                return new GameExample(answer, secondNumber, this);
            }

            public override string[] Rules => GetRule();

            private string[] GetRule()
            {
                var list = new StringBuilder(200);
                Array.Sort(firsts);

                foreach (var first in firsts)
                {
                    var answer = first * secondNumber;

                    list.Append($"{answer} {Operation.Symbol} {secondNumber} = {answer / secondNumber}\n");
                }
                firsts.Shuffle();

                return new[] { list.ToString() };

            }
        }
    }
}