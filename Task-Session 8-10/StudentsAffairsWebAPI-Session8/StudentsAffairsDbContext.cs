namespace StudentsAffairsWebAPI;

public class StudentsAffairsDbContext : DbContext
{
    public StudentsAffairsDbContext(DbContextOptions<StudentsAffairsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Applicant> Applicants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>().ToTable("Students");
        
        modelBuilder.Entity<Student>().HasKey(e => e.Id);
        modelBuilder.Entity<Student>().HasIndex(e => e.Name).IsUnique();
        
        modelBuilder.Entity<Student>().Property(e => e.Id).IsRequired();
        modelBuilder.Entity<Student>().Property(e => e.Id).HasMaxLength(5);
        modelBuilder.Entity<Student>().Property(e => e.Name).IsRequired();
        modelBuilder.Entity<Student>().Property(e => e.Name).HasMaxLength(50);
        modelBuilder.Entity<Student>().Property(e => e.Mobile).HasMaxLength(20);
        modelBuilder.Entity<Student>().Property(e => e.Age).HasMaxLength(2);
        modelBuilder.Entity<Student>().Property(e => e.Age).HasDefaultValue(18);



        modelBuilder.Entity<Applicant>().ToTable("Applicants");

        modelBuilder.Entity<Applicant>().HasKey(e => e.Id);
        modelBuilder.Entity<Applicant>().HasIndex(e => e.Name).IsUnique();

        modelBuilder.Entity<Applicant>().Property(e => e.Id).IsRequired();
        modelBuilder.Entity<Applicant>().Property(e => e.Id).HasMaxLength(5);
        modelBuilder.Entity<Applicant>().Property(e => e.Name).IsRequired();
        modelBuilder.Entity<Applicant>().Property(e => e.Name).HasMaxLength(50);
        modelBuilder.Entity<Applicant>().Property(e => e.Mobile).HasMaxLength(20);
        modelBuilder.Entity<Applicant>().Property(e => e.Age).HasMaxLength(2);
        modelBuilder.Entity<Applicant>().Property(e => e.Age).HasDefaultValue(18);
    }
}
