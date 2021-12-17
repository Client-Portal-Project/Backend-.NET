using Microsoft.EntityFrameworkCore;
using REST.DataLayer;
using REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class DataLayerTest
    {
        private readonly Microsoft.EntityFrameworkCore.DbContextOptions<BatchesDBContext> options;


        public DataLayerTest()
        {
            options = new DbContextOptionsBuilder<BatchesDBContext>().UseSqlite("Filename=DLTest.db;").Options;
            Seed();

        }

        [Fact]
        public void AddOccupationShouldSucceed()
        {
            using (var context = new BatchesDBContext(options))
            {
                IOccupationRepo repo = new OccupationRepo(context);
                Occupation c = new Occupation();
                c.OccupationName = "Rubby";
                c.Description = "Intro to Rubby";
                repo.AddOccupation(c);
            }

            using (var assertContext = new BatchesDBContext(options))
            {
                var result = assertContext.Occupations.FirstOrDefault(Occupation => Occupation.OccupationName == "Rubby");
                Assert.NotNull(result);
                Assert.Equal("Rubby", result.OccupationName);
            }

        }

/*

        [Fact]
        public void AddClientShouldSucceed()
        {
            using (var context = new BatchesDBContext(options))
            {
                IClientRepo repo = new ClientRepo(context);
                Clients cl = new Clients();
                cl.Name = "Client3";
                cl.Address = "4512 GA";
                cl.StateProvince = "Georgia";
                cl.Country = "CountyGA";
                cl.Phone = "4045662113";
                cl.Email = "cl3@gmail.com";
                repo.AddClient(cl);
            }

            using (var assertContext = new BatchesDBContext(options))
            {
                var result = assertContext.Clients.FirstOrDefault(client => client.Name == "Client3");
                Assert.NotNull(result);
                Assert.Equal("Client3", result.Name);
            }

        }*/

        private void Seed()
        {
            using (var context = new BatchesDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

               /* context.Clients.AddRange(
                    new Clients
                    {
                        Name = "Client1",
                        Address = "4512 CA",
                        StateProvince = "California",
                        Country = "CountyCA",
                        Phone = "7845662113",
                        Email = "cl@gmail.com"
                    },
                     new Clients
                     {
                         Name = "Client2",
                         Address = "4012 TX",
                         StateProvince = "Texas",
                         Country = "CountyTX",
                         Phone = "7805662113",
                         Email = "cl2@gmail.com"
                     }


                    );*/

                context.Occupations.AddRange(
                       new Occupation
                       {

                           OccupationName = "java",
                           Description = "Intro to java"
                       },
                        new Occupation
                        {

                            OccupationName = "Python",
                            Description = "Intro to Ptyhon"
                        }

                     );

                context.SaveChanges();


            }
        }
    }
}
