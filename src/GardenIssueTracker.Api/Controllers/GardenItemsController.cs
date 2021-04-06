using GardenIssueTracker.Api.Controllers;
using GardenIssueTracker.Application.GardenItems;
using GardenIssueTracker.Application.GardenItems.Commands.AddGardenItem;
using GardenIssueTracker.Application.GardenItems.Commands.DeleteGardenItem;
using GardenIssueTracker.Application.GardenItems.Commands.UpdateGardenItem;
using GardenIssueTracker.Application.GardenItems.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GardenTrackerServer.Controllers
{

    public class GardenItemsController : DefaultControllerBase
    {
        [HttpGet("{gardenId}")]
        public async Task<ActionResult<GardenItemsVm>> Get(int gardenId)
        {
            return await Mediator.Send(new GetAllGardenItemsQuery() { GardenId = gardenId });
        }

        [HttpPost()]
        public async Task<int> Add(AddGardenItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateGardenItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            await Mediator.Send(new DeleteGardenItemCommand { Id = id });

            return NoContent();
        }
    }
}
