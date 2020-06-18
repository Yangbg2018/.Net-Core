using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace firstApp.Controllers
{
    [Route("About")]
    public class AboutController : Controller
    {
        [Route("[action]")]
        public string show()
        {
            return "message from About show()";
        }
        [Route("[action]")]
        public string run()
        {
            return "message from run";
        }
    }
}
