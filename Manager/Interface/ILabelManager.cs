using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Interface
{
    public interface ILabelManager
    {
        string AddLabel(LabelModel labelModel);

        string DeleteLabel(int userId, string LabelName);

        string EditLabel(int userId, string labelName, string newLabelName);

        List<string> GetLabel(int userId);

    }
}
