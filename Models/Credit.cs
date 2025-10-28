using System.ComponentModel.DataAnnotations;

namespace CreditelApp.Models;

public class Credit
{
    public int Id { get; set; }

    [Required]
    public string ClientName { get; set; } = string.Empty;

    [Required]
    public string ClientId { get; set; } = string.Empty;

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public double InterestRate { get; set; }

    [Required]
    public int TermMonths { get; set; }

    [Required]
    public string Commercial { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
