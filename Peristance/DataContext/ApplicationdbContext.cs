using Domain.Entities.Cities;
using Domain.Entities.Countries;
using Domain.Entities.Dcouments;
using Domain.Entities.Employees;
using Domain.Entities.Profiles;
using Domain.Entities.staffs;
using Domain.Entities.States;
using Domain.Entities.Students;
using Domain.Entities.UserLogins;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Peristance.DataContext;

public class ApplicationdbContext : DbContext
{
    public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) : base(options)
    {

    }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Dcoument> Dcouments { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<UserLogin> UsersLogin { get; set; }
    public DbSet<Profile> Profiles { get; set; } 
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Staff> Stants { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Profile>()
        //     .HasKey(p => p.Id);
        //modelBuilder.Entity<Profile>()
        //.Property(p => p.Name).HasMaxLength(30)
        //.IsRequired();
        //modelBuilder.Entity<Profile>()
        //    .Property(s => s.Description).HasMaxLength(30);
        //modelBuilder.Entity<Profile>()
        //    .Property(x => x.MobileNo);
        //modelBuilder.Entity<Profile>().ToTable("TestingProfile").Property(p => p.MobileNo).HasColumnName("PhoneNo");
       
 
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
    }
}

