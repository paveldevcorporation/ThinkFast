
namespace ThinkFast.Models
{
    public class AnswerMessage
    {
        public AnswerMessage(string message, string solution)
        {
            Message = message;
            Solution = solution;
            HasMessage = !string.IsNullOrEmpty(message);
        }

        public string Message { get; set; }
        public string Solution { get; set; }
        public bool HasMessage { get; }

    }
}