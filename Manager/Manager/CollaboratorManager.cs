// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Manager.Manager
{
    using System;
    using System.Collections.Generic;
    using global::Manager.Interface;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// class CollaboratorManager
    /// </summary>
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// ICollaboratorRepository CollaboratorRepository
        /// </summary>
        public readonly ICollaboratorRepository CollaboratorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorManager"/> class
        /// </summary>
        /// <param name="collaboratorRepository">ICollaboratorRepository collaboratorRepository</param>
        public CollaboratorManager(ICollaboratorRepository collaboratorRepository)
        {
            this.CollaboratorRepository = collaboratorRepository;
        }

        /// <summary>
        /// Adds collaborator
        /// </summary>
        /// <param name="collaborator">CollaboratorModel collaborator</param>
        /// <returns>returns string after adding collaborator</returns>
        public string AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                return this.CollaboratorRepository.AddCollaborator(collaborator);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete collaborator
        /// </summary>
        /// <param name="colId">integer colId</param>
        /// <returns>returns string after deleting collaborator</returns>
        public string RemoveCollaborator(int colId)
        {
            try
            {
                return this.CollaboratorRepository.RemoveCollaborator(colId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get collaborator
        /// </summary>
        /// <param name="noteId">integer noteId</param>
        /// <returns>returns string after get collaborator</returns>
        public List<string> GetCollaborator(int noteId)
        {
            try
            {
                return this.CollaboratorRepository.GetCollaborator(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
