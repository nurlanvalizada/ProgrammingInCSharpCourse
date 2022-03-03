using Lesson30_WebApi.Data.DbQueries;
using Lesson30_WebApi.Data.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Lesson30_WebApi.Data
{
    public class StudentDbContext : DbContext
    {
        private static readonly MethodInfo ConfigureGlobalFiltersMethodInfo = 
            typeof(StudentDbContext).GetMethod(nameof(ConfigureGlobalFilters), 
                BindingFlags.Instance | BindingFlags.NonPublic);

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentCourseQuery> StudentCourseQueries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Course>().ToTable("tblCourse");
            modelBuilder.Entity<Course>().Property(x => x.CreationTime).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Gender>().ToTable("tblGender");
            modelBuilder.Entity<StudentCourse>().ToTable("tblStudentCourse");


            #region DbQuery configs

            modelBuilder.Entity<StudentCourseQuery>().HasNoKey();

            #endregion

            modelBuilder.Entity<StudentCourse>().HasKey(x => new { x.StudentTestId, x.CoursexId });

            #region global filters

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                ConfigureGlobalFiltersMethodInfo
                   .MakeGenericMethod(entityType.ClrType)
                   .Invoke(this, new object[] { modelBuilder });
            }

            //ConfigureGlobalFilters<Student>(modelBuilder);
            //ConfigureGlobalFilters<Course>(modelBuilder);
            //ConfigureGlobalFilters<Gender>(modelBuilder);
            //ConfigureGlobalFilters<StudentCourse>(modelBuilder);

            #endregion

        }

        private void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder) where TEntity : class
        {
            if (ShouldFilterEntity<TEntity>())
            {
                var filterExpression = CreateFilterExpression<TEntity>();
                if (filterExpression != null)
                {
                    modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
                }
            }
        }

        protected virtual bool ShouldFilterEntity<TEntity>() where TEntity : class
        {
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                return true;
            }

            return false;
        }

        protected virtual Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>() where TEntity : class
        {
            Expression<Func<TEntity, bool>> softDeleteFilter = e => !((ISoftDelete)e).IsDeleted;

            return softDeleteFilter;
        }
    }
}
