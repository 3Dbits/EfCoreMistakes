using EfCoreMistakes.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EfCoreMistakes.Data
{
    public class EfCoreMistakesContext(DbContextOptions<EfCoreMistakesContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SomeModel>()
               .HasMany(b => b.SubModels)
               .WithOne(p => p.SomeModel)
               .HasForeignKey(p => p.SomeModelId);

            modelBuilder.Entity<SubModel>()
               .HasMany(b => b.SubSubModels)
               .WithOne(p => p.SubModel)
               .HasForeignKey(p => p.SubModelId);

            modelBuilder.Entity<SubSubModel>()
               .HasMany(b => b.SubSubSubModels)
               .WithOne(p => p.SubSubModel)
               .HasForeignKey(p => p.SubSubModelId);

            modelBuilder.Entity<SomeModel>().HasData(GetSeedDataSomeModels());
            modelBuilder.Entity<SubModel>().HasData(GetSeedDataSubModels());
            modelBuilder.Entity<SubSubModel>().HasData(GetSeedDataSubSubModels());
            modelBuilder.Entity<SubSubSubModel>().HasData(GetSeedDataSubSubSubModels());

            modelBuilder.Entity<SubSubModel>().HasQueryFilter(p => p.Id < 5);

            // with IEntityTypeConfiguration
            modelBuilder.ApplyConfiguration(new SomeModelConfiguration());
            // or to automatically apply all configurations in an assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<SomeModel> SomeModel { get; set; } = default!;
        public DbSet<SubModel> SubModel { get; set; } = default!;
        public DbSet<SubSubModel> SubSubModel { get; set; } = default!;
        public DbSet<SubSubSubModel> SubSubSubModel { get; set; } = default!;

        private static IEnumerable<SomeModel> GetSeedDataSomeModels() =>
            [
                new() { Id = 1, Title = "SomeModel 1" },
                new() { Id = 2, Title = "SomeModel 2" }
            ];

        private static IEnumerable<SubModel> GetSeedDataSubModels() =>
            [
                new() { Id = 1, Information = "Submodel 1", SomeModelId = 1 },
                new() { Id = 2, Information = "Submodel 2", SomeModelId = 1 },
                new() { Id = 3, Information = "Submodel 3", SomeModelId = 2 },
                new() { Id = 4, Information = "Submodel 4", SomeModelId = 2 },
                new() { Id = 5, Information = "Submodel 5", SomeModelId = 2 }
            ];

        private static IEnumerable<SubSubModel> GetSeedDataSubSubModels() =>
            [
                new() { Id = 1, SubSubInformation = "SubSubmodel 1", SubModelId = 1 },
                new() { Id = 2, SubSubInformation = "SubSubmodel 2", SubModelId = 2 },
                new() { Id = 3, SubSubInformation = "SubSubmodel 3", SubModelId = 3 },
                new() { Id = 4, SubSubInformation = "SubSubmodel 4", SubModelId = 4 },
                new() { Id = 5, SubSubInformation = "SubSubmodel 5", SubModelId = 5 },
                new() { Id = 6, SubSubInformation = "SubSubmodel 6", SubModelId = 5 },
                new() { Id = 7, SubSubInformation = "SubSubmodel 7", SubModelId = 5 },
                new() { Id = 8, SubSubInformation = "SubSubmodel 8", SubModelId = 5 },
                new() { Id = 9, SubSubInformation = "SubSubmodel 9", SubModelId = 5 },
                new() { Id = 10, SubSubInformation = "SubSubmodel 10", SubModelId = 5 },
            ];

        private static IEnumerable<SubSubSubModel> GetSeedDataSubSubSubModels() =>
            [
                new() { Id = 1, SubSubSubInformation = "SubSubmodel 1", SubSubModelId = 1 },
                new() { Id = 2, SubSubSubInformation = "SubSubmodel 2", SubSubModelId = 2 },
                new() { Id = 3, SubSubSubInformation = "SubSubmodel 3", SubSubModelId = 3 },
                new() { Id = 4, SubSubSubInformation = "SubSubmodel 4", SubSubModelId = 4 },
                new() { Id = 5, SubSubSubInformation = "SubSubmodel 5", SubSubModelId = 5 },
                new() { Id = 6, SubSubSubInformation = "SubSubmodel 6", SubSubModelId = 5 },
                new() { Id = 7, SubSubSubInformation = "SubSubmodel 7", SubSubModelId = 5 },
                new() { Id = 8, SubSubSubInformation = "SubSubmodel 8", SubSubModelId = 6 },
                new() { Id = 9, SubSubSubInformation = "SubSubmodel 9", SubSubModelId = 6 },
                new() { Id = 10, SubSubSubInformation = "SubSubmodel 10", SubSubModelId = 6 },
            ];
    }
}
