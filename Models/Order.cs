using System;
using System.ComponentModel.DataAnnotations;

namespace SAOnlineMartMVC.Models
{
    public class Order
    {
        public int Id { get; set; } // Primary key, typically an integer

        [Required(ErrorMessage = "Order ID is required")]
        public string OrderId { get; set; } = Guid.NewGuid().ToString(); // Unique identifier as a string

        [Required(ErrorMessage = "Order date is required")]
        public DateTime OrderDate { get; set; } = DateTime.Now; // Default to current date and time

        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Payment method is required")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than zero")]
        public decimal TotalAmount { get; set; } // Total amount for the order

        // Optional: Include a UserId if tracking users
        public string UserId { get; set; } // User ID (string type if using GUIDs or similar)
    }
}
