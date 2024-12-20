using System.ComponentModel.DataAnnotations.Schema;

namespace RobotManagerAPI.Models
{
    public class User
    {
        private int id;
        private string? username;
        private string? password;
        private Dictionary<string, string> tokens = new(); // Dictionary<deviceId, token>

        public int Id { get => id; set => id = value; }
        public string? Username { get => username; set => username = value; }
        public string? Password { get => password; set => password = value; }

        [NotMapped]
        public Dictionary<string, string> Tokens { get => tokens; set => tokens = value; }
    }
}
