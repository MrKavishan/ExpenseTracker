using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Expence
    {
        public int Id { get; set; }
        [Required] public string Description { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount Need To Be Higher")]
        public int Amount { get; set; }
        [Required] public string Category { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
