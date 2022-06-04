namespace Assistant.Models
{
    public class HistoryBodyModel
    {
        public int HistoryID { get; set; }
        public string Query { get; set; }
        public string Response { get; set; }
        public int UserID { get; set; }
        public string Date { get; set; }
    }
}