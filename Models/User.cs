using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace RobotManagerAPI.Models
{

    public class User
    {
        private int id;
        private string? username;
        private string? password;
        private Dictionary<string, string> tokens = new();

        public int Id { get => id; set => id = value; }
        public string? Username { get => username; set => username = value; }
        public string? Password { get => password; set => password = value; }

        // Store Tokens as a JSON string in the database
        public string TokensJson
        {
            get => JsonSerializer.Serialize(tokens);
            set => tokens = string.IsNullOrEmpty(value) ? new Dictionary<string, string>() : JsonSerializer.Deserialize<Dictionary<string, string>>(value);
        }

        [NotMapped]
        public Dictionary<string, string> Tokens
        {
            get => tokens;
            set => tokens = value;
        }
    }
}
