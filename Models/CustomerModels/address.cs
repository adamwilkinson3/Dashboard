using NuGet.Packaging.Signing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models.CustomerModels;

public class address
{
    [DisplayName("Id")]
    public int? id { get; set; }
    [StringLength(255)]
    public string address1 { get; set; }
    [StringLength(150)]
    public string? address2 { get; set; }
    [Range(1, 50)]
    public int? state_id { get; set; }
    [StringLength(189)]
    public string city { get; set; }
    [StringLength(10)]
    public string? postal_code { get; set; }
    [StringLength(20)]
    public string phone { get; set; }
    public State? state { get; set; }
}
