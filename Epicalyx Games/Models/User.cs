using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EpicalyxGame.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public DateTime DateOfBirth { get; set; }
       

       

        public List<FinalReview> FinalReview { get; set; }
        public List<AspectReview> AspectReview { get; set; }
    }
}