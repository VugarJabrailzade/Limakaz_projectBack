using Limakaz.Database.Abstracts;
using Limakaz.Database.DomainModelsı;

namespace Limakaz.Database.DomainModels;

public class Order : IEntity
{
    public string PrUrl { get; set; }
    public string? TrackingCode { get; set; }
    public decimal PriceAzn { get; set; }
    public decimal PriceTry {  get; set; }
    public decimal TotalCostAzn { get; set; }
    public decimal TotalCostTry { get; set; }
    public int PrCount { get; set; }
    public string PrColor { get; set; }
    public string PrSize { get; set; }
    public string? PrComment { get; set; }
    public string PrType { get; set; }
    public bool IsPaid { get; set; } = false;
    public string? Seller { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int OrderStatusId { get; set; }
    public OrderStatus? OrderStatus { get; set; }
}
