using GardenIssueTracker.Application.Common.Mapping;
using GardenIssueTracker.Domain.Entities;

namespace GardenIssueTracker.Application.Comments
{
    public class CommentDto : IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GardenItemId { get; set; }
        public bool IsIssue { get; set; }
        public string Description { get; set; }
    }
}
