namespace GardenIssueTracker.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GardenItem GardenItem { get; set; }
        public int GardenItemId { get; set; }
        public bool IsIssue { get; set; }
        public string Description { get; set; }
    }
}