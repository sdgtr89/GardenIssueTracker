using GardenIssueTracker.Application.Comments;
using GardenIssueTracker.Application.Comments.Commands.AddComment;
using GardenIssueTracker.Application.Comments.Commands.DeleteComment;
using GardenIssueTracker.Application.Comments.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GardenIssueTracker.Api.Controllers
{
    public class CommentsController : DefaultControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ComentsDto>> Get(int gardenItemId)
        {
            return await Mediator.Send(new GetAllCommentsByGardenItem()
            {
                GardenItemId = gardenItemId
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetById(int id)
        {
            return await Mediator.Send(new GetCommentByIdQuery()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(AddCommentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCommentCommand { Id = id });

            return NoContent();
        }
    }
}
