namespace Domain;

using System.ComponentModel.DataAnnotations;

public class Brand
{
    public Brand()
    {
        Paints = new List<Paint>();
    }

    [Key]
    public int BrandID { get; set; }

    [Required, StringLength(100)]
    public string BrandName { get; set; } = string.Empty;

    [Required]
    public string Country { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Paint> Paints { get; set; }
}
