using System.ComponentModel.DataAnnotations;


namespace DemoBackend.Database
{
    public class Category
    {
        [Key]
       public int CategoryId { get; set; }
        public string CategoryName { get; set; }
       
    }
}