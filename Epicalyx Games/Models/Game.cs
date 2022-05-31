using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpicalyxGame.Models
{
    public class Game
    {
        public int GameID { get; set; }
        [Required]
        [Display(Name = "Game Name")]
        public string GameName { get; set; }

        [Display(Name = "Age Rating")]
     
        [StringLength(3)]
        
        public string AgeRating { get; set; }
        

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Display(Name = "Release Year")]
        [Required]
        
        [Range(1958,2300, ErrorMessage = "Release Year must be between 1958 and 2300" )]
        public int ReleaseYear { get; set; }

        public List<FinalReview> FinalReview { get; set; }
        public List<AspectReview> AspectReview { get; set; }

    }
}
