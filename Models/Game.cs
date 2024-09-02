namespace RobotManagerAPI.Models
{
    public class Game
    {
        int id;
        private DateTime date;
        private string against;
        private Field field;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Against { get => against; set => against = value; }
        public Field Field { get => field; set => field = value; }

    }
    public enum Field
    {
        A,
        B,
        C,
        D
    }
}
