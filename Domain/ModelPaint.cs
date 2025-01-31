namespace Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ModelPaint
{
    [Key]
    public int ModelPaintID { get; set; }

    [Required]
    public int ModelID { get; set; }
    public Model? Model { get; set; }

    [Required]
    public int PaintID { get; set; }
    public Paint? Paint { get; set; }

    [Required]
    public string UsageType { get; set; } = string.Empty;
}
