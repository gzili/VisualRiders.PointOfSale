namespace VisualRiders.PointOfSale.Project.Models;

public class ItemSelection
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal AdditionalPrice { get; set; }

    public List<ProductSelector> ProductSelectors { get; set; }
    
    public List<ServiceSelector> ServiceSelectors { get; set; }
    
    public List<ItemSelectionValue> ItemSelectionValues { get; set; }
}