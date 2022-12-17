namespace VisualRiders.PointOfSale.Project.Models;

public class ItemSelectionValue
{
    public int Id { get; set; }
    
    public int ItemSelectionId { get; set; }
    public ItemSelection ItemSelection { get; set; }
    
    public string Value { get; set; }
}