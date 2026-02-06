using System.ComponentModel.DataAnnotations;

namespace TournamentAPI.DTOs;

public class TournamentCreateDTO
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
    public required string Title { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? Description { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "MaxPlayers must be greater than 0")]
    public int MaxPlayers { get; set; }

    [DataType(DataType.DateTime)]
    [CustomValidation(typeof(TournamentCreateDTO), nameof(ValidateDate))]
    public DateTime Date { get; set; }

    public static ValidationResult? ValidateDate(DateTime date, ValidationContext context)
    {
        if (date <= DateTime.Now)
        {
            return new ValidationResult("Date cannot be in the past");
        }
        return ValidationResult.Success;
    }
}
