using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Insfrastructure.ORM.EntitiesMapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserRegistration.API.Business.Insfrastructure.ORM.EntitiesMapping;
public sealed class ClientMapping : BaseMapping, IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable(nameof(Client), Schema);
        builder.HasKey(c => c.ClientId);

        builder.Property(c => c.ClientId).HasColumnName("id");

        builder.Property(c => c.FullName).HasColumnType("varchar(150)").IsUnicode(true)
               .HasColumnName("full_name").IsRequired(true);

        builder.HasMany(c => c.Telephones)
               .WithOne()
               .HasForeignKey(t => t.ClientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Addresses)
               .WithOne()
               .HasForeignKey(t => t.ClientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Emails)
               .WithOne()
               .HasForeignKey(t => t.ClientId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
