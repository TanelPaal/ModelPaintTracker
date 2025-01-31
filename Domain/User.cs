namespace Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public User()
    {
        Paints = new List<Paint>();
        Models = new List<Model>();
    }

    [Key]
    public int UserID { get; set; }

    [Required, StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Paint> Paints { get; set; }
    public ICollection<Model> Models { get; set; }
}
