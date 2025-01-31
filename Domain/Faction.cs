namespace Domain;

using System.ComponentModel.DataAnnotations;

public class Faction
{
    public Faction()
    {
        Models = new List<Model>();
    }

    [Key]
    public int FactionID { get; set; }

    [Required, StringLength(100)]
    public string FactionName { get; set; } = string.Empty;

    public string FactionDescription { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Model> Models { get; set; }
}
