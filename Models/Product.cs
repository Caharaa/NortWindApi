using System.ComponentModel.DataAnnotations;
namespace NorthwindAPI.Models{
public class Products{
    [Key]
    public double ProductID { get; set; }
    [Required,StringLength(100)]
    public string? ProductName { get; set; }
    public double CategoryID {get;set;}

    public  double UnitsInStock { get; set; }

    public double UnitsOnOrder {get; set;}
    
}}