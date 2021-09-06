using Models;

namespace Repository.Interface
{
    public interface ILabelRepository
    {
        string AddLabel(LabelModel labelModel);

        string DeleteLabel(int userId, string LabelName);
    }
}
