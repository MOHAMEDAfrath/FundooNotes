﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface INotesRepository
    {
        string AddNotes(NotesModel notesModel);

        string UpdateTitleOrNote(NotesModel notesModel);

        string UpdateColor(NotesModel notesModel);

        string UpdateArchive(NotesModel notesModel);

        string AddPin(NotesModel notesModel);

        string DeleteAddToTrash(NotesModel notesModel);

    }
}