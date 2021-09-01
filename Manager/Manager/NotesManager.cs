﻿using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository notesRepository;

        public NotesManager(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }
        public string AddNotes(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.AddNotes(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateTitleOrNote(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.UpdateTitleOrNote(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
       
        }
        public string UpdateColor(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.UpdateColor(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
