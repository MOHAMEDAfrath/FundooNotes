using Manager.Interface;
using Repository.Interface;

namespace Manager.Manager
{
    public class LabelManager : ILabelManager
    {
        public readonly ILabelRepository LabelRepository;

        public LabelManager(ILabelRepository labelRepository)
        {
            this.LabelRepository = labelRepository;
        }
    }
}
