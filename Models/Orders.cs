using System.ComponentModel.DataAnnotations;
namespace NorthwindAPI.Models
{
    public class Orders
    {
        [Key]
        public double OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? CustomerID {get;set;}
        public string? ShipAddress {get;set;}
        public string? ShipCity {get;set;}
        public string? ShipName {get;set;}
        public string? ShipRegion {get;set;}
        public string? ShipPostalCode{get;set;}
        public string? ShipCountry{get;set;}
        public ICollection<OrdersDetails>? OrdersDetails { get; set; }
        

    

    }}