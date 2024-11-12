namespace RobotManagerAPI.Models
{
    public class Game
    {
        private int id;
        private DateTime date;
        private string against = String.Empty;
        private Field field;
        private bool home;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Against { get => against; set => against = value; }
        public Field Field { get => field; set => field = value; }
        bool Home { get => home; set => home = value; }

    }
    public enum Field
    {
        A,
        B,
        C,
        D
    }
}
