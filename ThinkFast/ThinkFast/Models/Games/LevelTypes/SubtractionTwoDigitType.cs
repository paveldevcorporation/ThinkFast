using System;
using System.Collections.Generic;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class SubtractionTwoDigitType : LevelType
        {
            public SubtractionTwoDigitType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, '-', leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                var secondArray = NumberToArray(second);
                var temp = first;
                var length = secondArray.Count;
                var list = new List<string>(length + 1) { $"{first} - (" };

                for (int i = length - 1; i >= 0; i--)
                {
                    var b = secondArray.Count - 1 >= i ? secondArray[i] * Math.Pow(10, i) : 0;
                    var s = i != 0 ? $"{b} +  " : $"{b}) = ";

                    list.Add(s);
                }

                list.Add($"{first} - ");

                for (int i = length - 1; i >= 0; i--)
                {
                    var b = secondArray.Count - 1 >= i ? secondArray[i] * Math.Pow(10, i) : 0;
                    var s = i != 0 ? $"{b} =  {temp - b} - " : $"{b} = ";

                    list.Add(s);

                    temp = (long)(temp - b);
                }
                
                var solution = string.Concat(list);

                return new AnswerMessage(AppResources.MinusMultiMessage, solution);
            }

            public override long Calculate(long first, long second)
            {
                return first - second;
            }

            public override GameExample CreateExample()
            {
                var random = new Random(DateTime.Now.Millisecond);

                const int maxValue = 99;
                const int minValue = 10;
                var first = random.Next(minValue, maxValue);
                var second = random.Next(minValue, maxValue);

                return first >= second
                    ? new GameExample(first, second, this)
                    : new GameExample(second, first, this);
            }

            public override string[] Rules => new[] { AppResources.MinusMultiMessage };
        }
    }
}