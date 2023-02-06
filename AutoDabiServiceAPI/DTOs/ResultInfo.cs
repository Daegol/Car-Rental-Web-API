namespace AutoDabiServiceAPI.DTOs
{
    public class ResultInfo
    {
        public StatusType Status { get; set; }
        public object Message { get; set; }

        public ResultInfo(StatusType status, object message)
        {
            Status = status;
            Message = message;
        }
    }

    public enum StatusType
    {
        Success,
        Failed
    }
}