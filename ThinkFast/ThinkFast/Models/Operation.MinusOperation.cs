using System;
using System.Collections.Generic;
using System.Linq;
using ThinkFast.Resources;

namespace ThinkFast.Models
{
    public abstract partial class Operation
    {
        private class MinusOperation : Operation
        {
            public MinusOperation(byte id, char symbol)
                : base(id, symbol)
            {
            }

            public override long Calculate(long first, long second)
            {
                return first - second;
            }

            public override Example CreateExample(long first, long second, int step)
            {
                return first >= second
                    ? new Example(first, second, this, step)
                    : new Example(second, first, this, step);
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                if (Sen.Contains(second))
                {
                    switch (second)
                    {
                        case 7:
                        {
                            var solution = $"{first} - {second} = {first} - {Ten} + 3 = {first - second}";


                            return new AnswerMessage(AppResources.Minus7Message, solution);
                        }
                        case 8:
                        {
                            var solution = $"{first} - {second} = {first} - {Ten} + 2 = {first - second}";

                            return new AnswerMessage(AppResources.Minus8Message, solution);
                            }
                        case 9:
                        {
                            var solution = $"{first} - {second} = {first} - {Ten} + 1 = {first - second}";

                            return new AnswerMessage(AppResources.Minus9Message, solution);
                            }
                        default: return null;
                    }
                }

                if (second > 10)
                {
                    return GetMultiDigitSolution(first, second);
                }

                return null;
            }

            private static AnswerMessage GetMultiDigitSolution(long first, long second)
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

                list.Add($"{first - second}");

                var solution = string.Concat(list);

                return new AnswerMessage(AppResources.MinusMultiMessage, solution);
            }
        }
    }
}