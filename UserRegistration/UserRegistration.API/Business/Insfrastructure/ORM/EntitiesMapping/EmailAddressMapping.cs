using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Insfrastructure.ORM.EntitiesMapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserRegistration.API.Business.Insfrastructure.ORM.EntitiesMapping;
public sealed class EmailAddressMapping : BaseMapping, IEntityTypeConfiguration<EmailAddress>
{
    public void Configure(EntityTypeBuilder<EmailAddress> builder)
    {
        builder.ToTable(nameof(EmailAddress), Schema);
        builder.HasKey(e => e.EmailAddressId);

        builder.Property(e => e.EmailAddressId).HasColumnName("id");

        builder.Property(e => e.ClientId).HasColumnName("client_id");

        builder.Property(e => e.EmailType).HasColumnType("tinyint")
               .HasColumnName("email_type").IsRequired(true);

        builder.Property(e => e.Email).HasColumnType("varchar(150)").IsUnicode(true)
               .HasColumnName("email").IsRequired(true);

    }
}
