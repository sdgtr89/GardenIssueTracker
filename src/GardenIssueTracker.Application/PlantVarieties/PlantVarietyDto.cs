using GardenIssueTracker.Application.Common.Mapping;
using GardenIssueTracker.Application.PlantGenera;
using GardenIssueTracker.Domain.Entities;

namespace GardenIssueTracker.Application.PlantVarieties
{
    public class PlantVarietyDto : IMapFrom<PlantVariety>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlantGenusDto PlantGenus { get; set; }
        public int PlantGenusId { get; set; }
    }
}
