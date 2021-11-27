using Core.Result;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        protected IActionResult ApiResponse(Response response) => StatusCode(response.StatusCode, response);

        [NonAction]
        protected IActionResult ApiResponse<T>(Response<T> response) => StatusCode(response.StatusCode, response);
    }
}