namespace TRIMANA.Customer.Domain.Exceptions
{
    public class ExceptionResponse
    {
        public string Type { set; get; }
        public string Title { set; get; }
        public string TraceId { set; get; }
        public int Status { set; get; }
        public Dictionary<string, List<string>> Errors { set; get; }
    }
}
