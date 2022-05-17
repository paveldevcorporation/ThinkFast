using System;
using System.Collections.Generic;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class MultiplicationMultiOneType : LevelType
        {
            public MultiplicationMultiOneType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, '×', leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
	            var firstArray = NumberToArray(first);
	            var list = new List<string>(firstArray.Count + 1) { $"{first} × {second} = " };

	            for (var i = firstArray.Count - 1; i >= 0; i--)
	            {
		            var b = firstArray.Count - 1 >= i ? firstArray[i] * Math.Pow(10, i) : 0;
		            var s = i != 0 ? $"{b} × {second} + " : $"{b} × {second} = ";
		            list.Add(s);
	            }
                
	            var solution = string.Concat(list);

                return new AnswerMessage(AppResources.MultiplicationMultyOneMessage, solution);
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

                const int secondMaxValue = 9;
                const int secondMinValue = 1;
                var second = Random.Next(secondMinValue, secondMaxValue);

                return new GameExample(first, second, this);
            }

            public override string[] Rules => new[] {AppResources.MultiplicationMultyOneMessage };
        }
    }
}