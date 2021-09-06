﻿using Models;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface ILabelRepository
    {
        string AddLabel(LabelModel labelModel);

        string DeleteLabel(int userId, string LabelName);

        string EditLabel(int userId, string labelName, string newLabelName);

        List<string> GetLabel(int userId);
    }
}
