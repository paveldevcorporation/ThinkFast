using ThinkFast.Models.Operations;
using ThinkFast.Services;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class SubtractionFrom10Type : LevelType
        {
            private static int index;
            private static readonly int[] seconds = GetNumbers(9);
            
            public SubtractionFrom10Type(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, Operation.Minus, leadTime, pointCoefficient)
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
                if (index >= seconds.Length)
                {
                    index = 0;
                    seconds.Shuffle();
                }

                var second = seconds[index];
                index++;

                return new GameExample(Ten, second, this);
            }
        }
    }
}