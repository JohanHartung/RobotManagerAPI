namespace RobotManagerAPI.Models
{
    public class Nao
    {
        int id;
        private string name = string.Empty;
        private string headID = string.Empty;
        private string bodyID = string.Empty;
        private int warrantyExtension;
        private DateTime purchased;
        private List<int> issues = new();
        private List<int> notes = new();
        private List<int> clinicVisits = new();
        private Status status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string HeadID { get => headID; set => headID = value; }
        public string BodyID { get => bodyID; set => bodyID = value; }
        public int WarrantyExtension { get => warrantyExtension; set => warrantyExtension = value; }
        public DateTime Purchased { get => purchased; set => purchased = value; }

        public List<int> Issues { get => issues; set => issues = value; }
        public List<int> Notes { get => notes; set => notes = value; }
        public List<int> ClinicVisits { get => clinicVisits; set => clinicVisits = value; }
        public Status Status { get => status; set => status = value; }
    }

    public class Issue
    {

        public int Id { get; set; }
        public required int Nao { get; set; }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool Replicated { get; set; }
        public bool Solved { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReplicatedDate { get; set; }
        public DateTime SolvedDate { get; set; }
        public string ?SolvedReport { get; set; }
    }

    public class Note
    {
        public int Id { get; set; }
        public required int Nao { get; set; }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime Date { get; set; }
    }

    public class ClinicVisit
    {
        public int Id { get; set; }
        public required int Nao { get; set; }

        public DateTime Date { get; set; }
        public required List<int> Issues { get; set; }
        public bool IsBack { get; set; }
        public string ?BackReport { get; set; }
    }

    public enum Status
    {
        Free,
        Game,
        Clinic
    }
}
