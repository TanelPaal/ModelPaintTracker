namespace Domain;

using System.ComponentModel.DataAnnotations;

public class State
{
    public State()
    {
        Models = new List<Model>();
    }

    [Key]
    public int StateID { get; set; }

    [Required, StringLength(50)]
    public string StateName { get; set; } = string.Empty;

    public string StateDescription { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Model> Models { get; set; }
}
