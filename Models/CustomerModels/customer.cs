using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models.CustomerModels;

public class customer
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
    public DateTime? create_date { get; set; }
    //public DateTime? last_update { get; set; }
    public address? address { get; set; }
}

//EXEC spCustomer_Insert
//@first_name = 'Billy', @last_name = 'Bob', @email = 'bbilly@bob.com', @active = 1, @create_date = '03/10/2023';