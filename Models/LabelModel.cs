// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using FundooNotes.Models;

    /// <summary>
    /// class LabelModel
    /// </summary>
    public class LabelModel
    {
        /// <summary>
        /// Gets or sets LabelId
        /// </summary>
        [Key]
        public int LabelId { get; set; }

        /// <summary>
        /// Gets or sets NotesId
        /// </summary>
        public int? NotesId { get; set; }

        /// <summary>
        /// Gets or sets NotesModel
        /// </summary>
        [ForeignKey("NotesId")]
        public NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets RegisterModel
        /// </summary>
        [ForeignKey("UserId")]
        public RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// Gets or sets LabelName
        /// </summary>
        [Required]
        public string LabelName { get; set; }
    }
}
