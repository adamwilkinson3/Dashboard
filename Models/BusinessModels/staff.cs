using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MovieApp.Models.CustomerModels;

namespace MovieApp.Models.BusinessModels;

public class staff
{
    [DisplayName("Id")]
    public int? id { get; set; }
    [StringLength(45)]
    [DisplayName("First Name")]
    public string first_name { get; set; }
    [StringLength(45)]
    [DisplayName("Last Name")]
    public string last_name { get; set; }
    [StringLength(50)]
    public string? email { get; set; }
    [Range(0, 1, ErrorMessage = "Value must be 0 or 1")]
    public int? active { get; set; }
    [StringLength(16)]
    public string? username { get; set; }
    [StringLength(40)]
    public string? password { get; set; }
    public DateTime? last_update { get; set; }
    public address? address { get; set; }
}
