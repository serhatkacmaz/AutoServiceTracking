using AutoServiceTracking.Shared.Responses;
using AutoServiceTracking.Web.Dashboard.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceTracking.Web.Dashboard.Infrastructure.Helpers
{
    public static class ErrorHelper
    {
        public static void ResponseHandler<T>(RequestResponse<T> response, ControllerContext controllerContext) where T : class
        {
            if (response.Errors != null && response.Errors.Count > 0)
            {
                foreach (var item in response.Errors)
                {
                    var splitResult = item.Split(' ', 2);

                    var propertyName = splitResult[0];
                    var errorMesage = splitResult[1];
                    controllerContext.ModelState.AddModelError(propertyName, errorMesage);
                }

                throw new ValidateException("Validate error.");
            }
        }
    }
}
