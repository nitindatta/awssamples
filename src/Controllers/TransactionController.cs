using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Aws.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        [HttpPost]
        public IActionResult  Create()
        {
            return Ok("Created");            
        }
        [HttpGet]       
        public IActionResult  Get()
        {
            return Ok("Get");            
        }    
    }
}