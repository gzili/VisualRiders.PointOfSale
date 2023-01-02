using Microsoft.EntityFrameworkCore;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project;

public class PointOfSaleContext : DbContext
{
    public PointOfSaleContext(DbContextOptions<PointOfSaleContext> options) : base(options) {}
    
    public DbSet<BusinessEntity> BusinessEntities { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Client> Clients { get; set; }
    
    public DbSet<ClientLoyalty> ClientLoyalties { get; set; }
    
    public DbSet<Discount> Discounts { get; set; }
    
    public DbSet<DiscountItem> DiscountItems { get; set; }
    
    public DbSet<Inventory> Inventory { get; set; }

    public DbSet<ItemSelection> ItemSelections { get; set; }
    
    public DbSet<ItemSelectionValue> ItemSelectionValues { get; set; }
    
    public DbSet<Loyalty> Loyalties { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderItem> OrderItems { get; set; }
    
    public DbSet<Payment> Payments { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductSelector> ProductSelectors { get; set; }
    
    public DbSet<Reservation> Reservations { get; set; }
    
    public DbSet<ReturnedItem> ReturnedItems { get; set; }
    
    public DbSet<Service> Services { get; set; }
    
    public DbSet<ServiceSelector> ServiceSelectors { get; set; }
    
    public DbSet<Shift> Shifts { get; set; }
    
    public DbSet<StaffMember> StaffMembers { get; set; }
    
    public DbSet<Tax> Taxes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var businessEntity = new BusinessEntity
        {
            Id = 1,
            Name = "Default Business",
            Description = "This is the default business that cannot be deleted.",
            Address = "Test street 1, Test town, Test country",
            Code = "00000"
        };
        
        modelBuilder.Entity<BusinessEntity>()
            .HasData(businessEntity);
        
        modelBuilder.Entity<ReturnedItem>()
            .HasKey(e => new { e.OrderItemId, e.PaymentId });
    }
}