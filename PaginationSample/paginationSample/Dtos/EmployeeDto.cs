using System.ComponentModel.DataAnnotations;

namespace paginationSample.Dtos;

public class EmployeeDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public int CompanyId { get; set; }
}