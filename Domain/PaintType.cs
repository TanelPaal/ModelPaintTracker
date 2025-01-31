namespace Domain;

using System.ComponentModel.DataAnnotations;

public class PaintType
{
    public PaintType()
    {
        Paints = new List<Paint>();
    }

    [Key]
    public int PaintTypeID { get; set; }

    [Required, StringLength(50)]
    public string TypeName { get; set; } = string.Empty;

    public string TypeDescription { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Paint> Paints { get; set; }
}
