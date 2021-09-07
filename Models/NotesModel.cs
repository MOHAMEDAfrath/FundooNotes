// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using FundooNotes.Models;

    /// <summary>
    /// NotesModel class
    /// </summary>
    public class NotesModel
    {
        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets foreign key
        /// </summary>
        [ForeignKey("UserId")]
        public RegisterModel Register { get; set; }

        /// <summary>
        /// Gets or sets the Notes ID.
        /// </summary>
        [Key]
        public int NotesId { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the Remainder.
        /// </summary>
        public string Remainder { get; set; }

        /// <summary>
        /// Gets or sets the Color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the Image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is archive.
        /// </summary>
        [DefaultValue(false)]
        public bool Is_Archive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is trash.
        /// </summary>
        [DefaultValue(false)]
        public bool Is_Trash { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is pin.
        /// </summary>
        [DefaultValue(false)]
        public bool Is_Pin { get; set; }
    }
}
