using System;
using System.Collections.Generic;
using ThinkFast.Resources;

namespace ThinkFast.Models
{
    public abstract partial class Operation
    {
        private class DivisionOperation : Operation
        {
            public DivisionOperation(byte id, char symbol)
                : base(id, symbol)
            {
            }

            public override long Calculate(long first, long second)
            {
                return first / second;
            }

            public override Example CreateExample(long first, long second, int step)
            {
                return first >= second
                    ? FindDivider(first, second, step)
                    : FindDivider(second, first, step);
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                if (second == 1 || first == 0)
                {
                    return null;
                }

                //if (first < 100 && first / second > 10)
                //{
                //    var list = new List<string>(4) {$"{first} / {second} = "};
                //    var a = Ten * second;
                //    var s = $"{a} / {second} + {first - a} / {second}";

                //    list.Add(s);
                //    list.Add($"= {first / second}");

                //    return string.Concat(list);
                //}

                if (second == 5)
                {
                    var solution = $"{first} / {second} = {first * 2} / {Ten} = {first / second}";

                    return new AnswerMessage(AppResources.Division5Message, solution);
                }

                if (first>100 && second < 10)
                {
                    var solution = GetSolutionM(first, second);

                    return new AnswerMessage(AppResources.DivisionOneMessage, solution); 
                }

                if (first < 100 && second < 10 && first > second * 10)
                {
                    var solution = GetSolutionMSmall(first, second);

                    return new AnswerMessage(AppResources.DivisionOneMessage, solution);
                }

                return null;
            }

            private static string GetSolutionM(long first, long second)
            {
                var list = new List<string>(4) {$"{first} / {second} = "};
                list.Add(DecisionDivision(first, second));
                list.Add($"= {first / second}");
                return string.Concat(list);
            }

            private static string GetSolutionMSmall(long first, long second)
            {
                var list = new List<string>(4) { $"{first} / {second} = " };
                list.Add(DecisionDivisionSmal(first, second));
                list.Add($" = {first / second}");
                return string.Concat(list);
            }

            private static string DecisionDivision(long first, long second)
            {
                var firstArray = NumberToArray(first);
                var capacity = firstArray.Count;

                if (capacity <= 2)
                {
                    return $"{first} / {second}";
                }

                var paw = (int) Math.Pow(10, capacity - 2);
                var easyFirst = first / paw;

                while (easyFirst % second != 0)
                {
                    easyFirst--;
                }

                easyFirst *= paw;

                var nextDividend = first - easyFirst;
                var t = DecisionDivision(nextDividend, second);
                var s = $"{easyFirst} / {second} + {t} ";

                return s;
            }

            private static string DecisionDivisionSmal(long first, long second)
            {
                var firstArray = NumberToArray(first);
                var t = firstArray[1] * 10;

                while (true)
                {
                    if (t % second == 0)
                    {
                        break;
                    }

                    t -= 10;
                }

                return $"{t} / {second} + {first - t} / {second}";
            }

            private Example FindDivider(long first, long second, int step)
            {
                if (first % second == 0)
                {
                    return new Example(first, second, this, step);
                }

                var max = first < 100 ? 100 : 1000;

                for (var i = first; i < max; i++)
                {
                    for (long a = second, b = second; a <= first && b >= 1; a++, b--)
                    {
                        if (i % a == 0 && a < i)
                        {
                            return new Example(i, a, this, step);
                        }

                        if (i % b == 0 && b > 1)
                        {
                            return new Example(i, b, this, step);
                        }
                    }
                }

                return new Example(0, second, this, step);
            }
        }
    }
}