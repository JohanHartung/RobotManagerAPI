using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace RobotManagerAPI.Models
{
    public class Nao
    {
        int id;
        private string name = string.Empty;
        private string headID = string.Empty;
        private string bodyID = string.Empty;
        private int warrantyExtension;
        private DateTime? purchased;
        private Status status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string HeadID { get => headID; set => headID = value; }
        public string BodyID { get => bodyID; set => bodyID = value; }
        public int WarrantyExtension { get => warrantyExtension; set => warrantyExtension = value; }
        public DateTime? Purchased { get => purchased; set => purchased = value; }
        public Status Status { get => status; set => status = value; }
    }

    public class Issue
    {
        private int id;
        private int nao;
        private string title = String.Empty;
        private string? description;
        private int author;
        private string? date;
        private Dictionary<int, string> replicated = new(); // (int user, DateTime dateTime)?
        private (int user, string dateTime)? solved = new();
        private string? solvedReport;

        public int Id { get => id; set => id = value; }
        public int Nao { get => nao; set => nao = value; }

        public string Title { get => title; set => title = value; }
        public string? Description { get => description; set => description = value; }
        public int Author { get => author; set => author = value; }
        [NotMapped]
        public Dictionary<int, string> Replicated { get => replicated; set => replicated = value; }

        public string ReplicatedJson
        {
            get => JsonSerializer.Serialize(replicated);
            set => replicated = string.IsNullOrEmpty(value) ? new Dictionary<int, string>() : JsonSerializer.Deserialize<Dictionary<int, string>>(value);
        }
        public (int user, string dateTime)? Solved { get => solved; set => solved = value; }
        public string? Date { get => date; set => date = value; }
        public string? SolvedReport { get => solvedReport; set => solvedReport = value; }
    }

    public class Note
    {
        private int id;
        private int nao;
        private string title = String.Empty;
        private string? description;
        private int author;
        private string? date;

        public int Id { get => id; set => id = value; }
        public int Nao { get => nao; set => nao = value; }

        public string Title { get => title; set => title = value; }
        public string? Description { get => description; set => description = value; }
        public int Author { get => author; set => author = value; }
        public string? Date { get => date; set => date = value; }
    }

    public class ClinicVisit
    {
        private int id;
        private int nao;
        private string? date;
        private string? backDate;
        private List<int>? issues;
        private string? notes;
        private string? backReport;
        private int author;
        private int collector;

        public int Id { get => id; set => id = value; }
        public int Nao { get => nao; set => nao = value; }

        public string? Date { get => date; set => date = value; }
        public string? BackDate { get => backDate; set => backDate = value; }
        public List<int>? Issues { get => issues; set => issues = value; }
        public string? Notes { get => notes; set => notes = value; }
        public string? BackReport { get => backReport; set => backReport = value; }
        public int Author { get => author; set => author = value; }
        public int Collector { get => collector; set => collector = value; }
    }
    public enum Status
    {
        Free,
        Game,
        Clinic
    }
}
