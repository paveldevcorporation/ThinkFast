using System;
using System.Collections.Generic;
using ThinkFast.Models.Operations;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class AddingTwoDigitWithin100Type : LevelType
        {
            public AddingTwoDigitWithin100Type(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, Operation.Plus, leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                var firstArray = NumberToArray(first);
                var secondArray = NumberToArray(second);

                var capacity = firstArray.Count < secondArray.Count
                    ? firstArray.Count + 1
                    : secondArray.Count + 1;

                var list = new List<string>(capacity) { $"{first} + {second} = " };

                if (firstArray.Count > secondArray.Count)
                {
                    SeparateDifference(firstArray, secondArray, list);
                }

                if (secondArray.Count > firstArray.Count)
                {
                    SeparateDifference(secondArray, firstArray, list);
                }

                var length = firstArray.Count > secondArray.Count
                    ? firstArray.Count
                    : secondArray.Count;

                for (var i = length - 1; i >= 0; i--)
                {
                    var a = firstArray.Count - 1 >= i ? firstArray[i] * Math.Pow(10, i) : 0;
                    var b = secondArray.Count - 1 >= i ? secondArray[i] * Math.Pow(10, i) : 0;
                    var s = i != 0 ? $"({a} + {b}) + " : $"({a} + {b}) = ";
                    list.Add(s);
                }
                
                var solution = string.Concat(list);

                return new AnswerMessage(AppResources.PlusMultiMessage, solution);
            }

            public override long Calculate(long first, long second)
            {
                return first + second;
            }

            public override GameExample CreateExample()
            {
	            const int maxValue = 70;
                const int minValue = 10;
                var first = Random.Next(minValue, maxValue);


                const int secondMaxValue = 40;
                const int secondMinValue = 10;
                var second = Random.Next(secondMinValue, secondMaxValue);

                return first + second >= 100 
	                ? CreateExample() 
	                : new GameExample(first, second, this);
            }


            private static void SeparateDifference(List<long> firstArray, List<long> secondArray, List<string> list)
            {
                var l = firstArray.Count - secondArray.Count;
                var requiredLength = firstArray.Count - 1 - l;
                var length = firstArray.Count - 1;
                double n = 0;

                for (var i = length; i > requiredLength; i--)
                {
                    var d = firstArray[i] * Math.Pow(10, i);
                    n += d;

                    firstArray.RemoveAt(i);
                }

                list.Add($"{n} + ");
            }


            public override string[] Rules => new[] { AppResources.PlusMultiMessage };
        }
    }
}