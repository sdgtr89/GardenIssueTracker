using System.Collections.Generic;

namespace GardenIssueTracker.Application.Comments
{
    public class ComentsDto
    {
        public IEnumerable<CommentDto> Comments { get; set; }
    }
}
