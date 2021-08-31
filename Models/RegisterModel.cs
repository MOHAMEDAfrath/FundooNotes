// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooNotes.Models
{
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// Register Model class
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        [Key]
        public int UserId { get; set; }
        
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets EmailId
        /// </summary>
        [Required]
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
