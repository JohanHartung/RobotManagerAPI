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
        private int id;
        private int nao;
        private string title = String.Empty;
        private string? description;
        private bool replicated;
        private bool solved;
        private DateTime date;
        private DateTime replicatedDate;
        private DateTime solvedDate;
        private string? solvedReport;

        public int Id { get => id; set => id = value; }
        public int Nao { get => nao; set => nao = value; }

        public string Title { get => title; set => title = value; }
        public string? Description { get => description; set => description = value; }
        public bool Replicated { get => replicated; set => replicated = value; }
        public bool Solved { get => solved; set => solved = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime ReplicatedDate { get => replicatedDate; set => replicatedDate = value; }
        public DateTime SolvedDate { get => solvedDate; set => solvedDate = value; }
        public string? SolvedReport { get => solvedReport; set => solvedReport = value; }
    }

    public class Note
    {
        private int id;
        private int nao;
        private string title = String.Empty;
        private string? description;
        private DateTime date;

        public int Id { get => id; set => id = value; }
        public int Nao { get => nao; set => nao = value; }

        public string Title { get => title; set => title = value; }
        public string? Description { get => description; set => description = value; }
        public DateTime Date { get => date; set => date = value; }
    }

    public class ClinicVisit
    {
        private int id;
        private int nao;
        private DateTime date;
        private DateTime backDate;
        private List<int>? issues;
        private bool isBack;
        private string? notes;
        private string? backReport;

        public int Id { get => id; set => id = value; }
        public int Nao { get => nao; set => nao = value; }

        public DateTime Date { get => date; set => date = value; }
        public DateTime BackDate { get => backDate; set => backDate = value; }
        public List<int>? Issues { get => issues; set => issues = value; }
        public bool IsBack { get => isBack; set => isBack = value; }
        public string? Notes { get => notes; set => notes = value; }
        public string? BackReport { get => backReport; set => backReport = value; }
    }

    public enum Status
    {
        Free,
        Game,
        Clinic
    }
}
