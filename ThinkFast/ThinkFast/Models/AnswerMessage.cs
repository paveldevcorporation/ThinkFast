
namespace ThinkFast.Models
{
    public class AnswerMessage
    {
        public AnswerMessage(string message, string solution)
        {
            Message = message;
            Solution = solution;
        }

        public string Message { get; set; }
        public string Solution { get; set; }
        
    }
}