using System.ComponentModel.DataAnnotations;

namespace WannaBetApi.Dtos;
public class CharacterInputDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Class { get; set; }
    [Required]
    public string? Role { get; set; }
}