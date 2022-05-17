using System;
using System.Collections.Generic;
using ThinkFast.Resources;

namespace ThinkFast.Models
{
    public abstract partial class Operation
    {
        private class MultiplyOperation : Operation
        {
            public MultiplyOperation(byte id, char symbol)
                : base(id, symbol)
            {
            }

            public override long Calculate(long first, long second)
            {
                return first * second;
            }

            public override Example CreateExample(long first, long second, int step)
            {
                return new Example(first, second, this, step);
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
                if (first * second <= 100)
                {
                    return null;
                }

                if (first == 9)
                {
                    var temp = second * Ten;

                    var solution = $"{first} × {second} = {Ten} × {second} - {second} = {temp} - {second} = ";

                    return new AnswerMessage(AppResources.Multiplication9Message, solution);
                }

                if (second == 9)
                {
                    var temp = first * Ten;

                    var solution = $"{first} × {second} = {first} × {Ten} - {first} = {temp} - {first} = ";

                    return new AnswerMessage(AppResources.Multiplication9Message, solution);
                }

                if (first == 11)
                {
                    var temp = second * Ten;

                    var solution = $"{first} × {second} = {Ten} × {second} + {second} = {temp} + {second} = ";

                    return new AnswerMessage(AppResources.Multiplication11Message, solution);
                }

                if (second == 11)
                {
                    var temp = first * Ten;

                    var solution = $"{first} × {second} = {first} × {Ten} + {first} = {temp} + {first} = ";

                    return new AnswerMessage(AppResources.Multiplication11Message, solution);
                }

                if (first == 2)
                {
                    return Plus.GetSolution(second, second);
                }

                if (second == 2)
                {
                    return Plus.GetSolution(first, first);
                }

                if (first == 5)
                {
                    if (second % 2 == 0)
                    {
                        var solution = $"{first} × {second} = {Ten} × ({second} ÷ {2})  = ";

                        return new AnswerMessage(AppResources.Multiplication5_2Message, solution);
                    }

                    var solution2 = $"{first} × {second} = {Ten} × {second} ÷ {2} = ";

                    return new AnswerMessage(AppResources.Multiplication5Message, solution2); 
                }

                if (second == 5)
                {
                    if (first % 2 == 0)
                    {
                        var solution = $"{first} × {second} = {first} ÷ {2} × {Ten} = ";

                        return new AnswerMessage(AppResources.Multiplication5_2Message, solution);
                    }

                    var solution2 = $"{first} × {second} = {first} × {Ten} ÷ {2} = ";

                    return new AnswerMessage(AppResources.Multiplication5Message, solution2); 
                }

                if (first == 25)
                {
                    if (second % 4 == 0)
                    {
                        var solution = $"{first} × {second} = {100} × ({second} ÷ {4})  = ";

                        return new AnswerMessage(AppResources.Multiplication25_4Message, solution);
                    }

                    var solution2 = $"{first} × {second} = {100} × {second} ÷ {4}  = ";

                    return new AnswerMessage(AppResources.Multiplication25Message, solution2);
                }

                if (second == 25)
                {
                    if (first % 4 == 0)
                    {
                        var solution = $"{first} × {second} = {first} ÷ {4} × {100} = ";

                        return new AnswerMessage(AppResources.Multiplication25_4Message, solution);
                    }

                    var solution2 = $"{first} × {second} = {first} × {100} ÷ {4} = ";

                    return new AnswerMessage(AppResources.Multiplication25_4Message, solution2);
                }

                if (first == 4)
                {
                    var solution = $"{first} × {second} = {2} × {second * 2}  = ";

                    return new AnswerMessage(AppResources.Multiplication4Message, solution);
                }

                if (second == 4)
                {
                    var solution = $"{first} × {second} = {first * 2} × {2} = ";

                    return new AnswerMessage(AppResources.Multiplication4Message, solution);
                }

                if (first == 8)
                {
                    var solution = $"{first} × {second} = {2} × {second * 2}  = {2} × {second * 2 * 2}  = ";

                    return new AnswerMessage(AppResources.Multiplication8Message, solution);
                }

                if (second == 8)
                {
                    var solution = $"{first} × {second} = {first * 2} × {2}= {first * 2 * 2} × {2} = ";

                    return new AnswerMessage(AppResources.Multiplication8Message, solution);
                }

                if (first < 10)
                {
                    var secondArray = NumberToArray(second);

                    var list = new List<string>(secondArray.Count + 1) { $"{first} × {second} = " };

                    for (var i = secondArray.Count - 1; i >= 0; i--)
                    {
                        var b = secondArray.Count - 1 >= i ? secondArray[i] * Math.Pow(10, i) : 0;
                        var s = i != 0 ? $"{first} × {b} + " : $"{first} × {b} = ";
                        list.Add(s);
                    }

                    var solution = string.Concat(list);

                    return new AnswerMessage(AppResources.MultiplicationMultyOneMessage, solution);
                }

                if (second < 10)
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

                if (first > 10 && second > 10)
                {
                    var secondArray = NumberToArray(second);
                    var capacity = secondArray.Count + 1;
                    var list = new List<string>(capacity) { $"{first} × {second} = " };

                    for (var i = secondArray.Count - 1; i >= 0; i--)
                    {
                        var pow = Math.Pow(10, i);
                        var b = secondArray.Count - 1 >= i ? secondArray[i] * pow : 0;
                        var s = i != 0 ? $"{first} × {b / pow} × {pow} + " : $"{first} × {b} = ";
                        list.Add(s);
                    }

                    var solution = string.Concat(list);

                    return new AnswerMessage(AppResources.MultiplicationMultyMessage, solution);
                }

                return null;
            }
        }
    }
}