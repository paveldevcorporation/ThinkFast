using System;

namespace ThinkFast.Models
{
    public static class ExampleCreator
    {
        public static Example CreateExample(int step)
        {
            var random = new Random(DateTime.Now.Millisecond);


            if (step < 10)
            {
                return PlusMinusExample(step, random);
            }
            var operation = random.Next(1, 100) % 2 == 0
                ? GetPlusMinusOperation(random)
                : GetMultiplyDivisionSymbols(random);

            var maxCof = operation == Operation.Multiply
            ? 2
            : 5;
            var maxValue = maxCof * step;
            var minCof = operation == Operation.Multiply
                ? 1
                : 2;
            var minValue = minCof * step;
            var first = random.Next(minValue, maxValue);
            var second = random.Next(minValue, maxValue);

            return operation.CreateExample(first, second, step);
        }

        public static Example CreateExample(int rungFirst, int rungSecond, Operation operation)
        {
            var random = new Random(DateTime.Now.Millisecond);

            var f = (int)Math.Pow(10, rungFirst);
            var s = (int)Math.Pow(10, rungSecond);

            var fMin = f / 10;
            var fMax = f - 1;

            var sMin = s / 10;
            var sMax = s - 1;

            var first = random.Next(fMin, fMax);
            var second = random.Next(sMin, sMax);

            return operation.CreateExample(first, second, 1);
        }

        private static Operation GetMultiplyDivisionSymbols(Random random)
        {
            return random.Next(1, 100) % 2 == 0
                ? Operation.Multiply
                : Operation.Division;
        }

        private static Operation GetPlusMinusOperation(Random random)
        {
            return random.Next(1, 100) % 2 == 0
                ? Operation.Plus
                : Operation.Minus;
        }

        private static Example PlusMinusExample(int step, Random random)
        {
            var maxValue = 5 * step;
            var minValue = step > 6 ? 2 * step : 1;
            var first = random.Next(minValue, maxValue);
            var second = random.Next(minValue, maxValue);
            var operation = random.Next(1, 100) % 2 == 0
                ? Operation.Plus
                : Operation.Minus;

            return operation.CreateExample(first, second, step);
        }
    }
}