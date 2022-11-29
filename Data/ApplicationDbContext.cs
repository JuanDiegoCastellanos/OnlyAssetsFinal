using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlyAssetsFinal.Models;

namespace OnlyAssetsFinal.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Relations One to Many
        builder.Entity<Purchase>().HasKey(assetPurchase => new
        {
            assetPurchase.AssetId,
            assetPurchase.AccountId
        });

        builder.Entity<Purchase>()
        .HasOne(assetPurchase => assetPurchase.Asset)
        .WithMany(asset => asset.Purchases)
        .HasPrincipalKey(asset => asset.Id)
        .HasForeignKey(assetPurchase => assetPurchase.AssetId);

        builder.Entity<Purchase>()
        .HasOne(purchase => purchase.Account)
        .WithMany(account=> account.Purchases)
        .HasPrincipalKey(purchase => purchase.Id)
        .HasForeignKey(account => account.AccountId);

        builder.Entity<Account>().HasKey(ac => new 
        {
            ac.Id,
            ac.PersonId,
            ac.RoleId
        });
        
        builder.Entity<Account>()
        .HasOne(c => c.Person)
        .WithMany(ac => ac.Accounts)
        .HasForeignKey(c => c.PersonId);

        builder.Entity<Account>()
        .HasOne(r => r.Role)
        .WithMany(ac => ac.Accounts)
        .HasForeignKey(r => r.RoleId);


        builder.Entity<Asset>().HasKey(a => new{
            a.Id,
            a.CreatorId
        });

        builder.Entity<Asset>()
        .HasOne(a => a.Creator)
        .WithMany(c => c.Assets)
        .HasPrincipalKey(c => c.Id)
        .HasForeignKey(a => a.CreatorId);

        base.OnModelCreating(builder);        
    }

    public DbSet<Account> Account {get; set;}
    public DbSet<Asset> Asset {get; set;}
    public DbSet<Person> Person {get; set;}
    public DbSet<Creator> Creator {get; set;}
    public DbSet<Purchase> Purchase {get; set;}
    public DbSet<Role> Role {get; set;}

}
