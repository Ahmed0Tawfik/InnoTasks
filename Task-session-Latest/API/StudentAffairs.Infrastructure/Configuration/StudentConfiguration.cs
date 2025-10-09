using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentAffairs.Infrastructure;
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasDefaultValue(true)
            .HasMaxLength(50); 

        builder.Property(p => p.Mobile)
            .HasDefaultValue(true)
            .HasMaxLength(11); 

        builder.Property(p => p.Telephone)
            .IsRequired()
            .HasDefaultValue(true)
            .HasMaxLength(10);

        builder.Property(p => p.Age)
            .IsRequired();
            

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasDefaultValue(true); 

        builder.Property(p => p.Message)
           .IsRequired()
           .HasMaxLength(100)
           .HasDefaultValue(true);

        builder.Property(p => p.RowVersion)
            .IsRowVersion();

        builder.HasIndex(p => p.Name); 
        builder.HasIndex(p => p.Email); 
    }

}
