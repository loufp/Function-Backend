using ISpotify.Models;

namespace ISpotify.DataBase;
using Microsoft.EntityFrameworkCore;
public class DBContext: DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    
    // // // // //
    public DbSet<LoginRequest> LoginUsers { get; set; }
    public DbSet<SignupRequest> SignupUsers { get; set; }

    public DbSet<JemendoAPI> Jemendo { get; set; }
    
    public DbSet<Photo> Photos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SignupRequest>(en =>
        {
            en.HasKey(e => e.Id);
            en.Property(e => e.Email).IsRequired();
            en.Property(e => e.Password).IsRequired();
            en.Ignore(e => e.ConfirmPassword);
            en.Property(e => e.Username).IsRequired();
        });
        
        modelBuilder.Entity<LoginRequest>(en =>
        {
            en.HasKey(e => e.Id);
            en.Property(e => e.Email).IsRequired();
            en.Ignore(e => e.Password);
        });
        
        modelBuilder.Entity<JemendoAPI>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.ArtistName).IsRequired();
            entity.Ignore(e => e.Audio);
            entity.Ignore(e => e.AudioDownload);
        });


        modelBuilder.Entity<Photo>(e =>
        {
            e.HasKey(en => en.Id);
            e.Property(en => en.DowlandPhoto).IsRequired();
            e.Property(en => en.PathPhoto).IsRequired();
            e.Property(en => en.TimeDowland).IsRequired();
            
            e.HasOne(p=> p.User)
                .WithMany(b=> b.Photos)
                .HasForeignKey(p=> p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
    
}