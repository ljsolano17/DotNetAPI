namespace Solution.API.DataModels
{
    public class Updates
    {
        public int UpdateId { get; set; }

        public string? Updatemsg { get; set; }

        public double? Status { get; set; }

        public int GoalId { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
