using GardenIssueTracker.Application.PlantVarieties;
using GardenIssueTracker.Application.PlantVarieties.Commands.AddPlantVariety;
using GardenIssueTracker.Application.PlantVarieties.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace GardenIssueTracker.Api.Controllers
{

    public class PlantVarietiesController : DefaultControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PlantVarietiesVm>> GetAll([FromQuery] GetAllPlantVarietiesQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantVarietyDto>> Get(int id)
        {
            return await Mediator.Send(new GetPlantVarietyByIdQuery() { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(AddPlantVarietyCommand command)
        {
            return await Mediator.Send(new AddPlantVarietyCommand()
            {
                Name = command.Name,
                PlantGenusId = command.PlantGenusId
            });
        }
    }
}
