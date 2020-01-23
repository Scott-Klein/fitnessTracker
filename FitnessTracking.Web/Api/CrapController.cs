using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracking.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrapController : ControllerBase
    {
        public CrapController()
        {
            Console.WriteLine("Constructing API Controller");
        }
        public object Get()
        {
            return new { Moniker = "ATL2018", name = "Atlanta Code" };
        }
        
    }
}
