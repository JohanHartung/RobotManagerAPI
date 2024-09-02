namespace RobotManagerAPI.Models
{
    public class Game
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public required string Against { get; set; }
        public Field Field { get; set; }

    }
    public enum Field
    {
        A,
        B,
        C,
        D
    }
}
