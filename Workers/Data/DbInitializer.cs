using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workers.Models;

namespace Workers.Data
{
    public class DbInitializer
    {

        public static void Initialize(WorkerContext context)
        {
            context.Database.EnsureCreated();

            if ( context.Workers.Any() )
            {
                return;
            }

            var workers = new Worker[]
            {
                new Worker{FirstName="Tomasz", LastName="Zwierzynski", Birthday=DateTime.Parse("1994-08-16")},
                new Worker{FirstName="Szymon", LastName="Nowak", Birthday=DateTime.Parse("1996-09-14")},
                new Worker{FirstName="Adam", LastName="Kowal", Birthday=DateTime.Parse("1992-10-10")},
                new Worker{FirstName="Marcin", LastName="Rewers", Birthday=DateTime.Parse("2000-12-20")}
            };
            foreach ( Worker w in workers )
            {
                context.Workers.Add(w);
            }
            context.SaveChanges();

            var positions = new Position[]
            {
                new Position{Name="Sprzątacz", PositionID=1001, Amount=2000 },
                new Position{Name="Kierownik", PositionID=2002, Amount=5000 },
                new Position{Name="Programista", PositionID=3003, Amount=4000 }
            };
            foreach( Position p in positions )
            {
                context.Positions.Add(p);
            }
            context.SaveChanges();

            var salaries = new Salary[]
            {
                new Salary{WorkerID=1,PositionID=1001,Bonus=1000},
                new Salary{WorkerID=1,PositionID=2002, Bonus=0},
                new Salary{WorkerID=2,PositionID=3003, Bonus=12000},
                new Salary{WorkerID=3,PositionID=1001, Bonus=200}
            };
            foreach ( Salary s in salaries)
            {
                context.Salaries.Add(s);
            }
            context.SaveChanges();

        }

    }
}
