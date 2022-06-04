using System.Text.Json.Serialization;

namespace Assistant.Models
{
    public class UserModel
    {
        [JsonPropertyName("body")]
        public UserBodyModel Body { get; set; }
        public string Message { get; set; }
    }
}