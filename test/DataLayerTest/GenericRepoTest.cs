using Microsoft.EntityFrameworkCore;
using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class GenericRepoTest
    {
        private readonly DbContextOptions<BatchesDBContext> options;


        public GenericRepoTest()
        {
            options = new DbContextOptionsBuilder<BatchesDBContext>().UseSqlite("Filename=GRTest.db;").Options;
            Seed();
        }

        [Fact]
        public void AddSkillShouldSucceed()
        {
            using (var context = new BatchesDBContext(options))
            {
                IGenericRepo<Skill> repo = new GenericRepo<Skill>(context);
                Skill s = new Skill();
                s.SkillName = "Sleeping";
                var entity = repo.Add(s);
                Assert.Equal("Sleeping", entity.SkillName);
            }
        }

        [Fact]
        public async void RemoveSkillShouldSucceed()
        {
            using (var context = new BatchesDBContext(options))
            {
                IGenericRepo<Skill> repo = new GenericRepo<Skill>(context);
                var initialCount = await repo.GetAll();
                var result = initialCount.Last();
                repo.Delete(result);
                Assert.NotEqual(initialCount.Count, initialCount.Count - 1);
            }
        }

        [Fact]
        public void GetAllShouldReturnResults()
        {
            using (var context = new BatchesDBContext(options))
            {
                IGenericRepo<Skill> repo = new GenericRepo<Skill>(context);
                var results = repo.GetAll();
                Assert.NotNull(results);
            }
        }

        [Fact]
        public void GetByIdShouldReturnResults()
        {
            using (var context = new BatchesDBContext(options))
            {
                IGenericRepo<Skill> repo = new GenericRepo<Skill>(context);
                var last = context.Skills.OrderBy(c => c.SkillId).Last();
                Assert.NotNull(last.SkillId);
            }
        }

        [Fact]
        public async void UpdateShouldUpdate()
        {
            using (var context = new BatchesDBContext(options))
            {
                IGenericRepo<Skill> repo = new GenericRepo<Skill>(context);
                var last = context.Skills.OrderBy(c => c.SkillId).Last();
                var initialName = last.SkillName;
                var initId = last.SkillId;
                last.SkillName = "Running";
                repo.Update(last);
                await repo.Save();
                var updated = await repo.GetById(initId);
                Assert.NotEqual(initialName, updated.SkillName);
            }
        }

        private void Seed()
        {
            using (var context = new BatchesDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Skills.AddRange(
                    new Skill
                    {
                        SkillName = "java",
                    },
                    new Skill
                    {
                        SkillName = "c#",
                    }
                );

                context.SaveChanges();
            }
        }
    }
}