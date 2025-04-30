using System.ComponentModel.DataAnnotations;
namespace  NorthwindAPI.Models {

    public class Categories {
        [Key]
        public double CategoryID {get;set;}
        
        public string? CategoryName {get;set;}


    }
}