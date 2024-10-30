using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EfCoreMistakes.Models;

namespace EfCoreMistakes.Data;

public class SomeModelConfiguration : IEntityTypeConfiguration<SomeModel>
{
    public void Configure(EntityTypeBuilder<SomeModel> builder)
    {
        builder
            .HasMany(b => b.SubModels)
            .WithOne(p => p.SomeModel)
            .HasForeignKey(p => p.SomeModelId);
    }
}

