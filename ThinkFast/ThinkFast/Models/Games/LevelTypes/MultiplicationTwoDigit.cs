using System;
using System.Collections.Generic;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class MultiplicationTwoDigitType : LevelType
        {
            public MultiplicationTwoDigitType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, '×', leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                var secondArray = NumberToArray(second);
                var capacity = secondArray.Count + 1;
                var list = new List<string>(capacity) { $"{first} × {second} = " };

                for (var i = secondArray.Count - 1; i >= 0; i--)
                {
                    var pow = Math.Pow(10, i);
                    var b = secondArray.Count - 1 >= i ? secondArray[i] * pow : 0;
                    var s = i != 0 ? $"{first} × {b / pow} × {pow}  + " : $"{first} × {b} = ";
                    list.Add(s);
                }
                
                var solution = string.Concat(list);

                return new AnswerMessage(AppResources.MultiplicationMultyMessage, solution);
            }

            public override long Calculate(long first, long second)
            {
                return first * second;
            }

            public override GameExample CreateExample()
            {
	            const int maxValue = 99;
                const int minValue = 11;
                var first = Random.Next(minValue, maxValue);

                const int secondMaxValue = 99;
                const int secondMinValue = 11;
                var second = Random.Next(secondMinValue, secondMaxValue);

                return new GameExample(first, second, this);
            }

            public override string[] Rules => new[] {AppResources.MultiplicationMultyMessage };
        }
    }
}