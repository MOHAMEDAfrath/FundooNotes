using Models;
using Repository.Context;
using Repository.Interface;
using System;
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
    }
}
