using MvcGoogleForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ModuleFPTGoogleForm.Models
{
    public class AnwserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnwserId { get; set; }
        [StringLength(1000)]
        [Required]
        public String Detail { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [NotMapped]
        public virtual Question Question { get; set; }

    }
}