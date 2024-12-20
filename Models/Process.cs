namespace RobotManagerAPI.Models
{
    public class Process
    {
        private int id;
        private int userId;
        private string? secret;

        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public string? Secret { get => secret; set => secret = value; }

    }
}
