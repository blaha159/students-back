using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace students_back.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public RedirectResult RedirectToSwaggerUi()
        {
            return Redirect("/swagger/");
        }
    }
}
