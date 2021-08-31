// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserContext.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Repository.Context
{
    using FundooNotes.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// UserContext class responsible for database operations
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContext"/> class
        /// </summary>
        /// <param name="options">DatabaseContextOptions option</param>
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets DatabaseSet for users to manipulate user data
        /// </summary>
        public DbSet<RegisterModel> Users { get; set; }
    }
}
