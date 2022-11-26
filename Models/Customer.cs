using System.ComponentModel.DataAnnotations;

namespace JQueryDataTable.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FName { get; set; }
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        [MaxLength(120)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Contact { get; set; }
        
        public DateTime BirthDtae { get; set; }
        
    }
}
