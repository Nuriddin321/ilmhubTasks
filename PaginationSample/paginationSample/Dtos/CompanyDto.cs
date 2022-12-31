using System.ComponentModel.DataAnnotations;

namespace paginationSample.Dtos;

public class CompanyDto
{
    [Required]
    public string? Name { get; set; }
}