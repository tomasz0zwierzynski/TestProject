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
    public class Tests2
    {

        [Test]
        public async Task PositionControllerTest()
        {
            var dbContext = await prepareDb();
            var positionController = new PositionsController(dbContext);

            var positions = await positionController.Index();

            Assert.NotNull(positions);
        }


        private async Task<WorkerContext> prepareDb()
        {
            var options = new DbContextOptionsBuilder<WorkerContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            var workerContext = new WorkerContext(options);
            workerContext.Database.EnsureCreated();
            

            if (await workerContext.Positions.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    workerContext.Positions.Add(new Workers.Models.Position()
                    {
                        Name = "Sprzatacz",
                        PositionID = i,
                        Amount = 2000
                    });
                    await workerContext.SaveChangesAsync();
                }
            }


            return workerContext;

        }
    }
}