namespace Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Model
{
    public Model()
    {
        ModelPaints = new List<ModelPaint>();
    }

    [Key]
    public int ModelID { get; set; }

    [Required, StringLength(100)]
    public string ModelName { get; set; } = string.Empty;

    [Required]
    public int UserID { get; set; }
    public User? User { get; set; }

    [Required]
    public int FactionID { get; set; }
    public Faction? Faction { get; set; }

    [Required]
    public int StateID { get; set; }
    public State? State { get; set; }

    [Range(0, int.MaxValue)]
    public int ModelQuantity { get; set; }

    // Navigation Properties
    public ICollection<ModelPaint> ModelPaints { get; set; }
}
