using System;
using SQLite;
using ThinkFast.Models.Operations;

namespace ThinkFast.Models
{
    [Table("ExampleRepeat")]
    public class ExampleRepeat : Entity
    {
        public ExampleRepeat()
        {
        }

        public ExampleRepeat(long first, long second, byte operationId)
        {
            First = first;
            Second = second;
            OperationId = operationId;
            AddDate = DateTime.Now;
            Learned = false;
        }

        public void Learn()
        {
            Learned = true;
            LearnedDate = DateTime.Now;
        }

        public long First { get; }
        public long Second { get; }
        public byte OperationId { get; }
        public bool Learned { get; private set; }
        public DateTime AddDate { get; }
        public DateTime? LearnedDate { get; private set; }


        private Operation operation;


        [Ignore]
        public Operation Operation => operation ?? (operation = Operation.Get(OperationId));
    }
}