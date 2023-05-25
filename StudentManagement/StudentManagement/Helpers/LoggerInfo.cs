namespace StudentManagement.Helpers
{
    internal class LoggerInfo
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public string MethodName { get; set; }
        public string CorrelationId { get; set; }
        public string RequestId { get; set; }
        public DateTime EventTime { get; set; }
        public string SourceSystem { get; set; }
        public string MachineName { get; set; }
        public string ServiceName { get; set; }
        public int ThreadId { get; set; }
        public string UserName { get; set; }
    }
}