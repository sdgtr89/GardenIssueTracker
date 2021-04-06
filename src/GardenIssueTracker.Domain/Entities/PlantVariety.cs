using System.Collections.Generic;

namespace GardenIssueTracker.Domain.Entities
{
    public class PlantVariety
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlantGenus PlantGenus { get; set; }
        public int PlantGenusId { get; set; }
        public IEnumerable<GardenItem> GardenItems { get; set; }        

        public PlantVariety()
        {
            GardenItems = new HashSet<GardenItem>();
        }
    }
}
