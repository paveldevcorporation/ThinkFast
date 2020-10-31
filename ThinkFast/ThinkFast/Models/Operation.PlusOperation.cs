﻿using System;
using System.Collections.Generic;
using System.Linq;
using ThinkFast.Resources;

namespace ThinkFast.Models
{
    public abstract partial class Operation
    {
        private class PlusOperation : Operation
        {
            public PlusOperation(byte id, char symbol)
                : base(id, symbol)
            {
            }

            public override long Calculate(long first, long second)
            {
                return first + second;
            }

            public override Example CreateExample(long first, long second, int step)
            {
                return new Example(first, second, this, step);
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                if (first + second <= Ten )
                {
                    return null;
                }

                if (Sen.Contains(first))
                {
                    switch (first)
                    {
                        case 7:
                        {
                            var solution = $"{first} + {second} = {Ten} + {second} - 3 = {first + second}";

                            return new AnswerMessage(AppResources.Plus_7_8_9_Message, solution);
                        }
                        case 8:
                        {
                            var solution = $"{first} + {second} = {Ten} + {second} - 2 = {first + second}";

                            return new AnswerMessage(AppResources.Plus_7_8_9_Message, solution);
                            }
                        case 9:
                        {
                            var solution = $"{first} + {second} = {Ten} + {second} - 1 = {first + second}";

                            return new AnswerMessage(AppResources.Plus_7_8_9_Message, solution);
                        }
                        default: return null;
                    }
                }

                if (Sen.Contains(second))
                {
                    switch (second)
                    {
                        case 7:
                        {
                            var solution = $"{first} + {second} = {first} + {Ten} - 3 = {first + second}";

                            return new AnswerMessage(AppResources.Plus_7_8_9_Message, solution);
                            }
                        case 8:
                        {
                            var solution = $"{first} + {second} = {first} + {Ten} - 2 = {first + second}";

                            return new AnswerMessage(AppResources.Plus_7_8_9_Message, solution);
                            }
                        case 9:
                        {
                            var solution = $"{first} + {second} = {first} + {Ten} - 1 = {first + second}";

                            return new AnswerMessage(AppResources.Plus_7_8_9_Message, solution);
                            }
                        default: return null;
                    }
                }

                if (first > 10 && second > 10)
                {
                    return GetMultiDigitSolution(first, second);
                }

                return null;
            }

            private static AnswerMessage GetMultiDigitSolution(long first, long second)
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

                list.Add($"{first + second}");

                var solution = string.Concat(list);

                return new AnswerMessage(AppResources.PlusMultiMessage, solution);
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
        }
    }
}