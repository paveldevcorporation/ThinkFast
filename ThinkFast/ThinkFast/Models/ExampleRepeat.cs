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

        public ExampleRepeat(long first, long second, byte operationId, uint leadTime)
        {
            First = first;
            Second = second;
            OperationId = operationId;
            LeadTime = leadTime;
            AddDate = DateTime.Now;
            Learned = false;
        }

        public void Learn()
        {
            Learned = true;
            LearnedDate = DateTime.Now;
        }

        public long First { get; set; }
        public long Second { get; set; }
        public byte OperationId { get; set; }
        public bool Learned { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? LearnedDate { get; set; }
        public uint LeadTime { get; set; }


        private Operation operation;


        [Ignore]
        public Operation Operation => operation ?? (operation = Operation.Get(OperationId));
    }
}