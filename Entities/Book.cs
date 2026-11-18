using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_01.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public int NumberOfPages { get; set; }

        public int PublishedYear { get; set; }

        public bool IsInStock { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation Properties
        public Category Category { get; set; } = null!;

        public ICollection<Author> Authors { get; set; }
            = new List<Author>();

        // NotMapped Property
        [NotMapped]
        public bool IsExpensive => Price > 500;
    }
}
