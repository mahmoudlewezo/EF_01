using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_01.Entities
{
    [Table("BookAuthors")]
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Biography { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        // Navigation Property
        public ICollection<Book> Books { get; set; }
            = new List<Book>();

        // NotMapped Property
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
