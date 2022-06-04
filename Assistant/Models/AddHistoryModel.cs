namespace Assistant.Models
{
    public class AddHistoryModel
    {
        public string Query { get; set; }
        public string Response { get; set; }
        public int UserID { get; set; }
        public string Date { get; set; }
    }
}