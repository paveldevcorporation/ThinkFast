using ThinkFast.Models.Operations;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class Addition789Type : LevelType
        {
            public Addition789Type(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, Operation.Plus, leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                switch (second)
                {
                    case 7:
                    {
                        var solution = $"{first} + {second} = {first} + {Ten} - 3 = ";

                        return new AnswerMessage(AppResources.Plus_7_8_9_Message, solution);
                    }
                    case 8:
                    {
                        var solution = $"{first} + {second} = {first} + {Ten} - 2 = ";

                        return new AnswerMessage(AppResources.Plus_7_8_9_Message, solution);
                    }
                    case 9:
                    {
                        var solution = $"{first} + {second} = {first} + {Ten} - 1 = ";

                        return new AnswerMessage(AppResources.Plus_7_8_9_Message, solution);
                    }
                    default: return null;
                }
            }

            public override long Calculate(long first, long second)
            {
                return first + second;
            }

            public override GameExample CreateExample()
            {
                //var random = new Random(DateTime.Now.Millisecond);

                const int firstMaxValue = 90;
                const int firstMinValue = 1;

                const int secondMaxValue = 9;
                const int secondMinValue = 7;

                var first = Random.Next(firstMinValue, firstMaxValue);
                var second = Random.Next(secondMinValue, secondMaxValue);

                return new GameExample(first, second, this);
            }

            public override string[] Rules =>  new[] {AppResources.Plus_7_8_9_Message};
            
        }
    }
}