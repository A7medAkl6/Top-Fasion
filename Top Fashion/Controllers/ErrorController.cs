using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top_Fashion.TopFashion.Main.Errors;

namespace Top_Fashion.Controllers
{
    [Route("errors/{statusCode}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        //[HttpGet("Error")]
        public IActionResult Error(int statusCode)
        {
            return new ObjectResult(new BaseCommonResponse(statusCode));
        }
    }
}
