using System.ComponentModel.DataAnnotations;
namespace NorthwindAPI.Models{
public class OrdersDetails
{
    [Key]
    public double OrderID{ get; set; }
    public double ProductID{ get; set; }
    public double UnitPrice { get; set; }
    public double Quantity { get; set; }
    public double Discount { get; set; }
    public Orders Orders { get; set; }


}
}
