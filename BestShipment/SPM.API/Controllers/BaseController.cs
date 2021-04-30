using Microsoft.AspNetCore.Mvc;
using SPM.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPM.API.Controllers
{
    [Route("api/[controller]/[action]")]

    public class BaseController : Controller
    {
        protected APIResponseViewModel GetRespons(object data = null, string message = "Done")
        {
            var result = new APIResponseViewModel();
            result.Status = true;
            result.Message = message;
            result.Data = data;
            return result;
        }
    }
}
