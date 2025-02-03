using Domain.Aggregates;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfig;

public class ConcourseTableConfig:IEntityTypeConfiguration<Concourse>
{
    public void Configure(EntityTypeBuilder<Concourse> builder)
    {
        builder.ToTable("Concourses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Date).IsRequired(false);
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.PhoneNumber).IsRequired(false);
        builder.Property(x => x.OpeningTime).IsRequired(false);
        builder.Property(x => x.ClosingTime).IsRequired(false);
        builder.Property(x => x.AdressLine1).IsRequired(false);
        builder.Property(x => x.AdressLine2).IsRequired(false);
        builder.Property(x => x.District).IsRequired(false);
        builder.HasOne(x => x.Organization).WithMany(x=>x.Concourses).HasForeignKey(x => x.OrganizationId);
        builder.HasOne(x => x.TicketOffice).WithOne(x=>x.Concourse);
        builder.HasOne(x => x.RegisterOffice).WithOne(x=>x.Concourse);

    }
}
public class RegisterOfficeTableConfig : IEntityTypeConfiguration<RegisterOffice>
{
    public void Configure(EntityTypeBuilder<RegisterOffice> builder)
    {
        builder.ToTable("RegisterOffices");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Concourse).WithOne(x=>x.RegisterOffice).HasForeignKey<RegisterOffice>(x => x.ConcourseId);
    }
}
public class TicketOfficeTableConfig : IEntityTypeConfiguration<TicketOffice>
{
    public void Configure(EntityTypeBuilder<TicketOffice> builder)
    {
        builder.ToTable("TicketOffices");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Concourse)
               .WithOne(x => x.TicketOffice)
               .HasForeignKey<TicketOffice>(x => x.ConcourseId);
    }
}
public class OrganizationTableConfig : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organizations");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();

    }
}
public class CategoryTableConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
    }
}
public class ModalityTableConfig : IEntityTypeConfiguration<Modality>
{
    public void Configure(EntityTypeBuilder<Modality> builder)
    {
        builder.ToTable("Modalities");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
    }
}
public class ConcourseRuleTableConfig : IEntityTypeConfiguration<ConcourseRule>
{
    public void Configure(EntityTypeBuilder<ConcourseRule> builder)
    {
        builder.ToTable("ConcourseRules");
        builder.HasKey(x => x.Id);
    }
}