using System.ComponentModel.DataAnnotations;

namespace EpicalyxGame.Models
{
    public class AspectReview
    {
        public int AspectReviewID { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5 Stars (★)")]
        [Display(Name = "Story Rating")]
        public int StoryRating { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5 Stars (★)")]
        [Display(Name = "Soundtrack Rating")]
        public int SoundtrackRating { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5 Stars (★)")]
        [Display(Name = "Graphics Rating")]
        public int GraphicsRating { get; set; }

        [Display(Name = "Gameplay Rating")]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5 Stars (★)")]
        public int GameplayRating { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5 Stars (★)")]
        [Display(Name = "Multiplayer Rating")]
        public int? MultiplayerRating { get; set; }

        [Display(Name = "Story Completion %")]
        [Range(0, 100, ErrorMessage = "Must be between 0%-100%")]
        public decimal? StoryCompletion { get; set; }

        [Display(Name = "Total Completion %")]
        [Range(0,100, ErrorMessage = "Must be between 0%-100%")]
        public decimal? TotalCompletion { get; set; }

        [Display(Name = "Username")]
        public int UserID { get; set; }

        [Display(Name = "Game Name")]
        public int GameID { get; set; }


        public User User { get; set; }
        public Game Game { get; set; }

    }
}