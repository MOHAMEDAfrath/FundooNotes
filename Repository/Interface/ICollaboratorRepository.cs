// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Repository.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// interface ICollaboratorRepository
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// Adds collaborator
        /// </summary>
        /// <param name="collaborator">CollaboratorModel collaborator</param>
        /// <returns>returns string after adding collaborator</returns>
        string AddCollaborator(CollaboratorModel collaborator);

        /// <summary>
        /// Delete collaborator
        /// </summary>
        /// <param name="colId">integer colId</param>
        /// <returns>returns string after deleting collaborator</returns>
        string RemoveCollaborator(int colId);

        /// <summary>
        /// Get collaborator
        /// </summary>
        /// <param name="noteId">integer noteId</param>
        /// <returns>returns string after get collaborator</returns>
        List<string> GetCollaborator(int noteId);
    }
}
