using GardenIssueTracker.Application.Gardens;
using GardenIssueTracker.Application.Gardens.Commands.AddGarden;
using GardenIssueTracker.Application.Gardens.Commands.DeleteGarden;
using GardenIssueTracker.Application.Gardens.Commands.UpdateGarden;
using GardenIssueTracker.Application.Gardens.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GardenIssueTracker.Api.Controllers
{

    public class GardensController : DefaultControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GardensVm>> GetAll([FromQuery] GetAllGardensQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(AddGardenCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateGardenCommand command)
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
            await Mediator.Send(new DeleteGardenCommand { Id = id });

            return NoContent();
        }
    }
}
