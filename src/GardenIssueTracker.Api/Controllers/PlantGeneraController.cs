using GardenIssueTracker.Application.PlantGenera;
using GardenIssueTracker.Application.PlantGenera.Commands.AddPlantGenus;
using GardenIssueTracker.Application.PlantGenera.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GardenIssueTracker.Api.Controllers
{
    public class PlantGeneraController : DefaultControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PlantGeneraVm>> GetAll([FromQuery] GetAllPlantGeneraQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantGenusDto>> Get(int id)
        {
            return await Mediator.Send(new GetPlantGenusByIdQuery() { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(AddPlantGenusCommand command)
        {
            return await Mediator.Send(command);
        }
       
    }
}
