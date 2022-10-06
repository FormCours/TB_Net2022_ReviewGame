using System.ComponentModel.DataAnnotations;

namespace ReviewGameAzure.API.DTO
{
    /// <summary>
    /// Response model for category
    /// </summary>
    public class CategoryDTO
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }
    }

    /// <summary>
    /// Data model for categorie
    /// </summary>
    public class CategoryDataDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }
    }
}
