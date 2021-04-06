using GardenIssueTracker.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GardenIssueTracker.Infrastructure.Data
{
    public class GardenDbContextSeed
    {
        public static async Task SeedSampleDataAsync(GardenDbContext context)
        {
            await SeedPlantGenera(context);
            await SeedPlantVarieties(context);
            await SeedGardens(context);
            await SeedGardenItems(context);
        }

        private static async Task SeedPlantGenera(GardenDbContext context)
        {
            if (!context.PlantGenera.Any())
            {
                context.PlantGenera.AddRange(
                    new PlantGenus()
                    {
                        ScientificName = "Solanum lycopersicum",
                        CommonName = "Tomato"
                    },
                    new PlantGenus()
                    {
                        ScientificName = "Capsicum",
                        CommonName = "Pepper"
                    },
                    new PlantGenus()
                    {
                        ScientificName = "Solanum tuberosum",
                        CommonName = "Potato"
                    });

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedPlantVarieties(GardenDbContext context)
        {
            if (!context.PlantVarieties.Any())
            {
                context.PlantVarieties.AddRange(
                    new PlantVariety()
                    {
                        Name = "Sungold",
                        PlantGenusId = context.PlantGenera.SingleOrDefault(pf => pf.CommonName == "Tomato").Id
                    },
                    new PlantVariety()
                    {
                        Name = "Orange Blaze",
                        PlantGenusId = context.PlantGenera.SingleOrDefault(pf => pf.CommonName == "Pepper").Id
                    },
                    new PlantVariety()
                    {
                        Name = "Ranger Russet",
                        PlantGenusId = context.PlantGenera.SingleOrDefault(pf => pf.CommonName == "Potato").Id
                    },
                    new PlantVariety()
                    {
                        Name = "Cayenne",
                        PlantGenusId = context.PlantGenera.SingleOrDefault(pf => pf.CommonName == "Pepper").Id
                    });

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedGardens(GardenDbContext context)
        {
            if (!context.Gardens.Any())
            {
                context.Gardens.AddRange(
                    new Garden()
                    {
                        Name = "Steve Backyard",
                        StartDate = DateTime.Now
                    },
                    new Garden()
                    {
                        Name = "Steve Frontyard",
                        StartDate = DateTime.Now
                    },
                    new Garden()
                    {
                        Name = "Steve Sideyard",
                        StartDate = DateTime.Now
                    });

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedGardenItems(GardenDbContext context)
        {
            if (!context.GardenItems.Any())
            {
                context.GardenItems.AddRange(
                     new GardenItem()
                     {
                         DatePlanted = DateTime.Now,
                         GardenId = context.Gardens.SingleOrDefault(pf => pf.Name == "Steve Backyard").Id,
                         PlantVarietyId = context.PlantVarieties.SingleOrDefault(pv => pv.Name == "Ranger Russet").Id
                     },
                     new GardenItem()
                     {
                         DatePlanted = DateTime.Parse("2021-04-01"),
                         GardenId = context.Gardens.SingleOrDefault(pf => pf.Name == "Steve Backyard").Id,
                         PlantVarietyId = context.PlantVarieties.SingleOrDefault(pv => pv.Name == "Orange Blaze").Id
                     },
                     new GardenItem()
                     {
                         DatePlanted = DateTime.Now,
                         GardenId = context.Gardens.SingleOrDefault(pf => pf.Name == "Steve Frontyard").Id,
                         PlantVarietyId = context.PlantVarieties.SingleOrDefault(pv => pv.Name == "Cayenne").Id
                     },
                     new GardenItem()
                     {
                         DatePlanted = DateTime.Parse("2021-03-28"),
                         GardenId = context.Gardens.SingleOrDefault(pf => pf.Name == "Steve Frontyard").Id,
                         PlantVarietyId = context.PlantVarieties.SingleOrDefault(pv => pv.Name == "Sungold").Id
                     },
                     new GardenItem()
                     {
                         DatePlanted = DateTime.Now,
                         GardenId = context.Gardens.SingleOrDefault(pf => pf.Name == "Steve Sideyard").Id,
                         PlantVarietyId = context.PlantVarieties.SingleOrDefault(pv => pv.Name == "Sungold").Id
                     },
                     new GardenItem()
                     {
                         DatePlanted = DateTime.Parse("2021-03-24"),
                         GardenId = context.Gardens.SingleOrDefault(pf => pf.Name == "Steve Sideyard").Id,
                         PlantVarietyId = context.PlantVarieties.SingleOrDefault(pv => pv.Name == "Ranger Russet").Id
                     });

                await context.SaveChangesAsync();
            }
        }
    }
}
