using ThinkFast.Models.Operations;

namespace ThinkFast.Models
{
    public sealed class Example
    {
        public Example(long first, long second, Operation operation, int step)
        {
            First = first;
            Second = second;
            Operation = operation;
            Step = step;
            AnswerMessage = GetSolution();
            Answer = operation.Calculate(first, second).ToString();
        }

        //public UnresolvedExample GetUnresolved()
        //{
        //    return new UnresolvedExample(first, second, operation.Id);
        //}

        public AnswerMessage GetSolution()
        {
            var solution = Operation.GetSolution(First, Second);

            return solution ?? new AnswerMessage(string.Empty, ToString());
        }

        public long First { get; }

        public long Second { get; }

        public Operation Operation { get; }

        public string Question => $"{First} {Operation.Symbol} {Second} = ";

        public string Answer { get; }

        public int Step { get; }

        public AnswerMessage AnswerMessage { get; }


        public override string ToString()
        {
            return $"{First} {Operation.Symbol} {Second} = {Answer}";
        }
    }
}