using System.Collections.Generic;

namespace Assistant.Models
{
    public class HistoryModel
    {
        public List<HistoryBodyModel> Body { get; set; }
        public string Message { get; set; }
    }
}