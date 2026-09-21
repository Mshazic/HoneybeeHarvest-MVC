using System.ComponentModel.DataAnnotations;

namespace HoneybeeHarvest.Models;

public sealed class OrderInputModel
{
    [Required(ErrorMessage = "Please enter your name.")]
    public string CustomerName { get; set; } = string.Empty;
    [Required (ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please select a product.")]
    public string ProductName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please enter a quantity.")]
    [Range(1, 12, ErrorMessage = "Please enter a quantity between 1 and 12.")]
    public int Quantity { get; set; } = 1;
}