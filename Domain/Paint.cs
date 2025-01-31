namespace Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Paint
{
    public Paint()
    {
        ModelPaints = new List<ModelPaint>();
    }

    [Key]
    public int PaintID { get; set; }

    [Required, StringLength(100)]
    public string PaintName { get; set; } = default!;

    [Required]
    public string HexCode { get; set; } = default!;

    [Required]
    public int BrandID { get; set; }
    public Brand? Brand { get; set; }

    [Required]
    public int UserID { get; set; }
    public User? User { get; set; }

    [Required]
    public int PaintTypeID { get; set; }
    public PaintType? PaintType { get; set; }

    [Range(0, int.MaxValue)]
    public int PaintQuantity { get; set; }

    // Navigation Properties
    public ICollection<ModelPaint> ModelPaints { get; set; }
}
