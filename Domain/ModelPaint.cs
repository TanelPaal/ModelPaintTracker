namespace Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ModelPaint
{
    [Key]
    public int ModelPaintID { get; set; }

    [Required(ErrorMessage = "Model is required")]
    public int ModelID { get; set; }
    public Model? Model { get; set; }

    [Required(ErrorMessage = "Paint is required")]
    public int PaintID { get; set; }
    public Paint? Paint { get; set; }

    [Required(ErrorMessage = "Usage type is required")]
    public string UsageType { get; set; } = default!;
}
