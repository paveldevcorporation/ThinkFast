using System.Collections.Generic;

namespace ThinkFast.Models.Operations
{
    public abstract partial class Operation
    {
        private const byte Ten = 10;
        private static readonly long[] Sen = { 7, 8, 9 };


        public static readonly Operation Plus = new PlusOperation(1, '+');
        public static readonly Operation Minus = new MinusOperation(2, '-');
        public static readonly Operation Multiply = new MultiplyOperation(3, '×');
        public static readonly Operation Division = new DivisionOperation(4, '÷');

        protected Operation(byte id, char symbol)
        {
            Id = id;
            Symbol = symbol;
        }

        public abstract long Calculate(long first, long second);
        public abstract Example CreateExample(long first, long second, int step);
        public abstract AnswerMessage GetSolution(long first, long second);

        public static Operation Get(int id)
        {
            switch (id)
            {
                case 1: return Plus;
                case 2: return Minus;
                case 3: return Multiply;
                case 4: return Division;

                default: return null;
            }
        }

        private static List<long> NumberToArray(long number)
        {
            List<long> l = new List<long>();
            while (number > 0)
            {
                l.Add(number % 10);
                number = number / 10;
            }

            return l;
        }

        public byte Id { get; set; }
        public char Symbol { get; set; }
    }
}