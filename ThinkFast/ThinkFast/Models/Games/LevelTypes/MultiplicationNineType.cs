﻿using System;
using ThinkFast.Resources;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private class MultiplicationNineType : LevelType
        {
            public MultiplicationNineType(int id, uint leadTime, float pointCoefficient)
                : base(id, string.Empty, '×', leadTime, pointCoefficient)
            {
            }

            public override AnswerMessage GetSolution(long first, long second)
            {
	            var temp = first * Ten;

	            var solution = $"{first} {Symbol} {second} = {first} {Symbol} {Ten} - {first} = {temp} - {first} = ";

	            return new AnswerMessage(AppResources.Multiplication9Message, solution);
            }

            public override long Calculate(long first, long second)
            {
                return first * second;
            }

            public override GameExample CreateExample()
            {
                var random = new Random(DateTime.Now.Millisecond);

                const int maxValue = 110;
                const int minValue = 10;
                var first = random.Next(minValue, maxValue);
                const int second = 9;

                return new GameExample(first, second, this);
            }

            public override string[] Rules => new[] {AppResources.Multiplication9Message};
        }
    }
}