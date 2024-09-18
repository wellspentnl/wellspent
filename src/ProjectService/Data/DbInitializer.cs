using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectService.Entities;
using Task = ProjectService.Entities.Task;

namespace ProjectService.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            SeedData(scope.ServiceProvider.GetService<DataContext>());
        }

        private static void SeedData(DataContext context)
        {
            context.Database.Migrate();

            if (context.Projects.Any())
            {
                Console.WriteLine("Already have data - no need to seed");
                return;
            }

            var projects = new List<Project>()
            {
                new Project
                    {
                        Title = "Community Garden",
                        Description = "A project to create a community garden where volunteers will plant and maintain various plants and trees.",
                        StartDate = new DateTime(2024, 1, 15).ToUniversalTime(),
                        EndDate = new DateTime(2024, 6, 30).ToUniversalTime(),
                        Location = "Park Central, Amsterdam",
                        Tasks = new List<Task>()
                        {
                            new Task
                            {
                                Name = "Task2",
                                Description  = "Description1"
                            },
                            new Task
                            {
                                Name = "Task2",
                                Description  = "Description2"
                            }
                        },
                        // CreatedById = 1, // Assuming there's a user with ID 1
                        CreatedAt = DateTime.UtcNow,
                    },
                    new Project
                    {
                        Title = "Beach Cleanup",
                        Description = "A volunteer-driven initiative to clean up the local beach and reduce ocean pollution.",
                        StartDate = new DateTime(2024, 3, 5).ToUniversalTime(),
                        EndDate = new DateTime(2024, 3, 10).ToUniversalTime(),
                        Location = "Zandvoort Beach",
                        Tasks = new List<Task>()
                        {
                            new Task
                            {
                                Name = "Task2",
                                Description  = "Description1"
                            },
                            new Task
                            {
                                Name = "Task2",
                                Description  = "Description2"
                            }
                        },// CreatedById = 2,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Project
                    {
                        Title = "Food Donation Drive",
                        Description = "Organizing a city-wide food donation drive to help local shelters and reduce food waste.",
                        StartDate = new DateTime(2024, 2, 1).ToUniversalTime(),
                        EndDate = new DateTime(2024, 2, 15).ToUniversalTime(),
                        Location = "Various locations across Amsterdam",
                        Tasks = new List<Task>()
                        {
                            new Task
                            {
                                Name = "Task2",
                                Description  = "Description1"
                            },
                            new Task
                            {
                                Name = "Task2",
                                Description  = "Description2"
                            }
                        },
                        // CreatedById = 3,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Project
                    {
                        Title = "Senior Assistance Program",
                        Description = "Volunteers will help senior citizens with daily chores, groceries, and appointments.",
                        StartDate = new DateTime(2024, 4, 1).ToUniversalTime(),
                        EndDate = new DateTime(2024, 7, 31).ToUniversalTime(),
                        Location = "Senior Homes in Amsterdam",
                        Tasks = new List<Task>()
                        {
                            new Task
                            {
                                Name = "Task2",
                                Description  = "Description1"
                            },
                            new Task
                            {
                                Name = "Task2",
                                Description  = "Description2"
                            }
                        },
                        // CreatedById = 4,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Project
                    {
                        Title = "Tree Planting Initiative",
                        Description = "Planting 500 trees in a local park as part of a reforestation effort.",
                        StartDate = new DateTime(2024, 5, 1).ToUniversalTime(),
                        EndDate = new DateTime(2024, 5, 31).ToUniversalTime(),
                        Location = "Vondelpark, Amsterdam",
                        Tasks = new List<Task>()
                        {
                            new Task
                            {
                                Name = "Task2",
                                Description  = "Description1"
                            },
                            new Task
                            {
                                Name = "Task2",
                                Description  = "Description2"
                            }
                        },
                        CreatedAt = DateTime.UtcNow
                    }

            };

            context.AddRange(projects);

            context.SaveChanges();
        }
    }
}