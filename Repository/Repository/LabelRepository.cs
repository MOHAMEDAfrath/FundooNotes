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
                var exist = this.UserContext.Labels.Where(x => x.LabelName == labelModel.LabelName).SingleOrDefault();
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
    }
}
