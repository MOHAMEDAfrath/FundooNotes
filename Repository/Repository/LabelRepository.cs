using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class LabelRepository : ILabelRepository
    {
        public readonly UserContext UserContext;
        public LabelRepository(UserContext userContext)
        {
            this.UserContext = userContext;
        }

        public string AddLabel(LabelModel labelModel)
        {
            try
            {
                var exist = this.UserContext.Labels.Where(x => x.LabelName == labelModel.LabelName && x.UserId==labelModel.UserId).SingleOrDefault();
                if (exist == null) {
                    this.UserContext.Labels.Add(labelModel);
                    this.UserContext.SaveChanges();
                    return "Added Label";
                }
                return "Label Already Exists";
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteLabel(int userId,string LabelName)
        {
            try
            {
                var exists = this.UserContext.Labels.Where(x => x.LabelName == LabelName && x.UserId == userId).ToList();
                if (exists.Count>0)
                {
                    this.UserContext.Labels.RemoveRange(exists);
                    this.UserContext.SaveChanges();
                    return "Deleted Label";
                }
                return "No Label Present";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditLabel(int userId, string labelName, string newLabelName)
        {
            try
            {
                var exist = this.UserContext.Labels.Where(x => x.LabelName == labelName && x.UserId == userId).ToList();
                var labelExists = this.UserContext.Labels.Where(x => x.LabelName == newLabelName && x.UserId == userId).ToList();
                if (exist.Count > 0)
                {
                    exist.ForEach(x => x.LabelName = newLabelName);
                    this.UserContext.Labels.UpdateRange(exist);
                    this.UserContext.SaveChanges();
                    if(labelExists.Count > 0)
                    {
                        return "Merge the '" + labelName + "' label with the '" 
                            + newLabelName + "' label? All notes labeled with '" + labelName 
                            + "' will be labeled with '" + newLabelName + "', and the '" + labelName +
                            "' label will be deleted.";
                    }

                    return "Updated Label";
                }

                return "Label not present";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetLabel(int userId)
        {
            try
            {
                var exist = this.UserContext.Labels.Where(x => x.UserId == userId).Select(x =>x.LabelName).Distinct().ToList();
                if(exist.Count > 0)
                {
                    return exist;
                }
                return null;
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
                this.UserContext.Labels.Add(labelModel);
                this.UserContext.SaveChanges();
                return "Added Label To Note";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteALabelFromNote(LabelModel labelModel)
        {
            try
            {
                var existsLabel = this.UserContext.Labels.Where(x=>x.LabelName == labelModel.LabelName && x.UserId == labelModel.UserId && x.NotesId == null).ToList();
                if(existsLabel.Count == 1)
                {
                    var exists = this.UserContext.Labels.Where(x => x.LabelId == labelModel.LabelId && x.NotesId == labelModel.NotesId).SingleOrDefault();
                    this.UserContext.Labels.Remove(exists);
                    this.UserContext.SaveChanges();
                    return "Deleted Label From Note";
                }
                else
                {
                    var temp = this.UserContext.Labels.Where(x => x.LabelName == labelModel.LabelName && x.UserId == labelModel.UserId).ToList();
                    if(temp.Count == 1)
                    {
                        var exists = this.UserContext.Labels.Where(x=>x.LabelId == labelModel.LabelId).SingleOrDefault();
                        exists.NotesId = null;
                        this.UserContext.Labels.Update(exists);
                        this.UserContext.SaveChanges();
                        return "Deleted Label From Note";
                    }
                    else
                    {
                        var exists = this.UserContext.Labels.Where(x => x.LabelId == labelModel.LabelId).SingleOrDefault();
                        this.UserContext.Labels.Remove(exists);
                        this.UserContext.SaveChanges();
                        return "Deleted Label From Note";
                    }

                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
