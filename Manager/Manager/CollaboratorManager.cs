using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Manager
{
    public class CollaboratorManager: ICollaboratorManager
    {
        public readonly ICollaboratorRepository collaboratorRepository;

        public CollaboratorManager(ICollaboratorRepository collaboratorRepository)
        {
            this.collaboratorRepository = collaboratorRepository;
        }
        public string AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                return this.collaboratorRepository.AddCollaborator(collaborator);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string RemoveCollaborator(int colId)
        {
            try
            {
                return this.collaboratorRepository.RemoveCollaborator(colId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
