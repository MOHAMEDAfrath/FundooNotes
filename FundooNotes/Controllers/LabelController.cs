using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class LabelController : ControllerBase
    {
        public readonly ILabelManager LabelManager;

        public LabelController(ILabelManager labelManager)
        {
            this.LabelManager = labelManager;
        }
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
