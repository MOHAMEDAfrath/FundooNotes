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
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}",ErrorMessage ="Invalid First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName
        /// </summary>
        [Required]
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}([\s]{0,1}[A-Za-z]{1,})*$", ErrorMessage = "Invalid Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets EmailId
        /// </summary>
        [Required]
        [RegularExpression(@"(^[a-z]+)(([\. \+ \-]?[a-z A-Z 0-9])*)@(([0-9 a-z]+[\.]+[a-z]{3})+([\.]+[a-z]{2,3})?$)", ErrorMessage = "Invalid Email")]
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=[^.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\]*[.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\][^.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\]*$).{8,}$",ErrorMessage ="Invalid Password")]
        public string Password { get; set; }
    }
}
