// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// interface ICollaboratorManager
    /// </summary>
    public interface ICollaboratorManager
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
