using ModuleFPTGoogleForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGoogleForm.Models
{
    public class Question
    {
        public Question()
        {
            AnwserDetails = new List<AnwserDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        [Required]
        public String QuestionName { get; set; }
        [Required]
        public int Type { get; set; }
        public String Answer { get; set; }
        public int FormId { get; set; }
        public virtual ICollection<AnwserDetail> AnwserDetails { get; set; }
        [NotMapped]
        public virtual Form Form { get; set; }
       
    }
}