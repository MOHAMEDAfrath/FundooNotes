using Manager.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;

namespace Manager.Manager
{
    public class LabelManager : ILabelManager
    {
        public readonly ILabelRepository LabelRepository;

        public LabelManager(ILabelRepository labelRepository)
        {
            this.LabelRepository = labelRepository;
        }
        public string AddLabel(LabelModel labelModel)
        {
            try
            {
                return this.LabelRepository.AddLabel(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteLabel(int userId, string LabelName)
        {
            try
            {
                return this.LabelRepository.DeleteLabel(userId, LabelName);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditLabel(int userId, string labelName, string newLabelName)
        {
            try
            {
                return this.LabelRepository.EditLabel(userId, labelName, newLabelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetLabel(int userId)
        {
            try
            {
                return this.LabelRepository.GetLabel(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AddNotesLabel(LabelModel labelModel)
        {
            try
            {
                return this.LabelRepository.AddNotesLabel(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteALabelFromNote(LabelModel labelModel)
        {
            try
            {
                return this.LabelRepository.DeleteALabelFromNote(labelModel);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetLabelByNote(int notesId)
        {
            try
            {
                return this.LabelRepository.GetLabelByNote(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<NotesModel> DisplayNotesBasedOnLabel(int userId, string labelName)
        {
            try
            {
                return this.LabelRepository.DisplayNotesBasedOnLabel(userId, labelName);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
