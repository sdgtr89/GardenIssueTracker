using System.Collections.Generic;

namespace GardenIssueTracker.Domain.Entities
{
    public class PlantGenus
    {
        public int Id { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public IEnumerable<PlantVariety> PlantVarieties { get; set; }

        public PlantGenus()
        {
            PlantVarieties = new HashSet<PlantVariety>();
        }
    }
}
