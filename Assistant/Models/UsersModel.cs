using System.Collections.Generic;

namespace Assistant.Models
{
    public class UsersModel
    {
        public List<UserBodyModel> Body { get; set; }
        public string Message { get; set; }
    }
}