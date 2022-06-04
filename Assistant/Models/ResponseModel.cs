namespace Assistant.Models
{
    public class ResponseModel
    {
        public string Query { get; set; }
        public string Text { get; set; }
        public string Action { get; set; }
        public string Intent { get; set; }
        public bool Question { get; set; }
        public DataModel Data { get; set; }
    }
}