using System;
using System.ComponentModel.DataAnnotations;

namespace LifeQuest.BLL.Models
{
    public class ChallengeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Points { get; set; }
        public int Duration { get; set; }
        public bool IsPublic { get; set; }
        public string Difficulty { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class CreateChallengeDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Points are required")]
        [Range(1, 1000, ErrorMessage = "Points must be between 1 and 1000")]
        public int Points { get; set; }

        public int CategoryId { get; set; }
        public bool IsPublic { get; set; } = true;
        public string Difficulty { get; set; } = "Medium";
    }
}
