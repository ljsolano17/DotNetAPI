namespace Solution.API.DataModels
{
    public class GroupUpdate
    {
        public int GroupUpdateId { get; set; }

        public string? Updatemsg { get; set; }

        public double? Status { get; set; }

        public int GroupGoalId { get; set; }

        public DateTime UpdateDate { get; set; }

       // public virtual ICollection<GroupComment> GroupComments { get; set; } = new List<GroupComment>();

        // public virtual ICollection<GroupUpdateSupport> GroupUpdateSupports { get; set; } = new List<GroupUpdateSupport>();
    }
}
