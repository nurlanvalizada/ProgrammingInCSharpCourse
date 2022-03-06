using Lesson30_WebApi.Data.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lesson30_WebApi.Data.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> modelBuilder)
        {
            modelBuilder.HasKey(k => k.Id);
            modelBuilder.ToTable("tblStudent");
            modelBuilder.Property(p => p.Surname).HasMaxLength(50);
            modelBuilder.Property(n => n.Surname).HasMaxLength(25);
            modelBuilder.HasIndex(p => p.Name).IsUnique().HasDatabaseName("UIX_tblStudent_Name");
            modelBuilder.HasOne(x => x.Gender).WithMany(x => x.Students).HasForeignKey(x => x.GendexrId)
                .HasConstraintName("FK_Students_Genders_GenderId");

            modelBuilder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
