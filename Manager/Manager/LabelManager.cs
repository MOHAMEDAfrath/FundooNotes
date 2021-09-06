using Manager.Interface;
using Models;
using Repository.Interface;
using System;

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
    }
}
