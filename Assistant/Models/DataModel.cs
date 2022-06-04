namespace Assistant.Models
{
    public class DataModel
    {
        public bool Question { get; set; }
        public string Stream { get; set; }
        public int TrackId { get; set; }
        public bool NewSessionStarted { get; set; }
        public string Action { get; set; }
    }
}