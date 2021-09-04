﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Interface
{
    public interface ICollaboratorManager
    {
        string AddCollaborator(CollaboratorModel collaborator);

        string RemoveCollaborator(int colId);

        List<string> GetCollaborator(int noteId);
    }
}
