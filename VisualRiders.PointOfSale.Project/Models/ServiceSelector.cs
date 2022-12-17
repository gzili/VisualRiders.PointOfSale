namespace VisualRiders.PointOfSale.Project.Models;

public class ServiceSelector
{
    public int Id { get; set; }
    
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    
    public int ItemSelectionId { get; set; }
    public ItemSelection ItemSelection { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Type { get; set; }
}