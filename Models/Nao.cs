namespace RobotManagerAPI.Models
{
    public class Nao
    {
        int id;
        private string name;
        private string headID;
        private string bodyID;
        private int warantyExtension;
        private DateTime purchased;
        private List<Issue> issues = new();
        private List<Note> notes = new();
        private List<ClinicVisit> clinicVisits = new();
        private Status status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string HeadID { get => headID; set => headID = value; }
        public string BodyID { get => bodyID; set => bodyID = value; }
        public int WarantyExtension { get => warantyExtension; set => warantyExtension = value; }
        public DateTime Purchased { get => purchased; set => purchased = value; }

        public List<Issue> Issues { get => issues; set => issues = value; }
        public List<Note> Notes { get => notes; set => notes = value; }
        public List<ClinicVisit> ClinicVisits { get => clinicVisits; set => clinicVisits = value; }
        public Status Status { get => status; set => status = value; }
    }

    public class Issue
    {
        int id;
        Nao nao;

        private string title;
        private string description;
        private bool replicated;
        private bool solved;
        private DateTime date;
        private DateTime replicatedDate;
        private DateTime solvedDate;
        private string solvedReport;

        public int Id { get => id; set => id = value; }
        public Nao Nao { get => nao; set => nao = value; }

        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public bool Replicated { get => replicated; set => replicated = value; }
        public bool Solved { get => solved; set => solved = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime ReplicatedDate { get => replicatedDate; set => replicatedDate = value; }
        public DateTime SolvedDate { get => solvedDate; set => solvedDate = value; }
        public string SolvedReport { get => solvedReport; set => solvedReport = value; }
    }

    public class Note
    {
        int id;
        Nao nao;

        private string title;
        private string description;
        private DateTime date;

        public int Id { get => id; set => id = value; }
        public Nao Nao { get => nao; set => nao = value; }

        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public DateTime Date { get => date; set => date = value; }
    }

    public class ClinicVisit
    {
        int id;
        Nao nao;

        private DateTime date;
        private List<Issue> issues;
        private bool isBack;
        private string backReport;

        public int Id { get => id; set => id = value; }
        public Nao Nao { get => nao; set => nao = value; }

        public DateTime Date { get => date; set => date = value; }
        public List<Issue> Issues { get => issues; set => issues = value; }
        public bool IsBack { get => isBack; set => isBack = value; }
        public string BackReport { get => backReport; set => backReport = value; }
    }

    public enum Status
    {
        Free,
        Game,
        Clinic
    }
}
