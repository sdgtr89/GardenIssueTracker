using System;
using System.Collections.Generic;

namespace GardenIssueTracker.Domain.Entities
{
    public class Garden
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public IEnumerable<GardenItem> GardenItems { get; set; }

        public Garden()
        {
            GardenItems = new HashSet<GardenItem>();
        }
    }
}
