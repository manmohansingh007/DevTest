using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerNameController : ControllerBase
    {
        private static readonly string[] CustomerNames = { "Devid", "Charles", "Herry" };

        private readonly ILogger<CustomerNameController> _logger;

        public CustomerNameController(ILogger<CustomerNameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return CustomerNames;
        }
    }
}
