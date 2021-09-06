using FundooNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LabelModel
    {
        [Key]
        public int LabelId { get; set; }

        public int ? NotesId { get; set; }

        [ForeignKey("NotesId")]
        public NotesModel NotesModel { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public RegisterModel RegisterModel { get; set; }

        [Required]
        public string LabelName { get; set; }
    }
}
