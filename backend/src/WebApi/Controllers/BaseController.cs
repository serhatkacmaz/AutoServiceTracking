using Core.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BaseController : ControllerBase
{
    [NonAction]
    protected IActionResult CreateActionResult<T>(RequestResponse<T> response)
    {
        if (response.StatusCode == 204)
            return new ObjectResult(null) { StatusCode = response.StatusCode };

        return new ObjectResult(response) { StatusCode = response.StatusCode };
    }
}
