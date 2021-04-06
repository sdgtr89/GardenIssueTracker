using GardenIssueTracker.Application.Common.Mapping;
using GardenIssueTracker.Domain.Entities;

namespace GardenIssueTracker.Application.PlantGenera
{
    public class PlantGenusDto : IMapFrom<PlantGenus>
    {
        public int Id { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
    }
}
