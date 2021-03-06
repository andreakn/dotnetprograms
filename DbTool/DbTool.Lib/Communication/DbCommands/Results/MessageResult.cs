namespace DbTool.Lib.Communication.DbCommands.Results
{
    public class MessageResult : DbCommandResultBase
    {
        public string Message { get; private set; }

        public MessageResult(string message)
        {
            Message = message;
        }

        protected override string ConvertToString()
        {
            return Message;
        }
    }
}