// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// class CollaboratorModel
    /// </summary>
    public class CollaboratorModel
    {
        /// <summary>
        /// Gets or sets ColId
        /// </summary>
        [Key]
        public int ColId { get; set; }

        /// <summary>
        ///  Gets or sets NotesId
        /// </summary>
        public int NotesId { get; set; }

        /// <summary>
        ///  Gets or sets notesModel
        /// </summary>
        [ForeignKey("NotesId")]
        public NotesModel notesModel { get; set; }

        /// <summary>
        ///  Gets or sets ColEmail
        /// </summary>
        [Required]
        [RegularExpression(@"(^[a-z]+)(([\. \+ \-]?[a-z A-Z 0-9])*)@(([0-9 a-z]+[\.]+[a-z]{3})+([\.]+[a-z]{2,3})?$)", ErrorMessage = "Invalid Email")]
        public string ColEmail { get; set; }
    }
}
