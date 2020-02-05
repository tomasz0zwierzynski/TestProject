using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workers.Controllers;
using Workers.Data;

namespace Tests
{
    public class Tests
    {

        [Test]
        public async Task WorkersControllerTest()
        {
            var dbContext = await prepareDb();
            var workersController = new WorkersController(dbContext);

            var workers = await workersController.Index();

            Assert.NotNull(workers);
        }

        /*

        [Test]
        public async Task PositionControllerTest()
        {
            var dbContext = await prepareDb();
            var positionController = new PositionsController(dbContext);

            var positions = await positionController.Index();

            Assert.NotNull(positions);
        }
        */

        private async Task<WorkerContext> prepareDb()
        {
            var options = new DbContextOptionsBuilder<WorkerContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            var workerContext = new WorkerContext(options);
            workerContext.Database.EnsureCreated();
            if (await workerContext.Workers.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    workerContext.Workers.Add(new Workers.Models.Worker()
                    {
                        FirstName = "Tomasz",
                        LastName = "Zwierzynski",
                        Birthday = DateTime.Parse("1994-08-16")
                    });
                    await workerContext.SaveChangesAsync();
                }
            }

            /*
            if (await workerContext.Positions.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    workerContext.Positions.Add(new Workers.Models.Position()
                    {
                        Name = "Sprzatacz",
                        PositionID = 1001,
                        Amount = 2000
                    });
                    await workerContext.SaveChangesAsync();
                }
            }
    */        

            return workerContext;
 
        }
    }
}