namespace ThinkFast.Models
{
    public sealed class Example
    {
        private readonly long first;

        private readonly long second;

        private readonly Operation operation;

        public Example(long first, long second, Operation operation, int step)
        {
            this.first = first;
            this.second = second;
            this.operation = operation;
            Step = step;
        }

        //public UnresolvedExample GetUnresolved()
        //{
        //    return new UnresolvedExample(first, second, operation.Id);
        //}

        public AnswerMessage GetSolution()
        {
            var solution = operation.GetSolution(first, second);

            return solution ?? new AnswerMessage(string.Empty, ToString());
        }


        public string Question => $"{first} {operation.Symbol} {second} = ";

        public string Answer => operation.Calculate(first, second).ToString();

        public int Step { get; }


        public override string ToString()
        {
            return $"{first} {operation.Symbol} {second} = {Answer}";
        }
    }
}