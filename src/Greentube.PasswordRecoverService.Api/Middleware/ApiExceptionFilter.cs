using Greentube.PasswordService.Api.DTOs;
using Greentube.PasswordService.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Greentube.PasswordService.Api.Middleware;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override Task OnExceptionAsync(ExceptionContext context)
    {
        if (context.ExceptionHandled) return Task.CompletedTask;

        if (context.Exception is ServiceException serviceException)
        {
            context.Result = new ObjectResult(new ApiResponse()
            {
                Error = serviceException.Message
            })
            {
                StatusCode = serviceException.HttpResponse
            };
        }
        else
        {
            context.Result = new ObjectResult(new ApiResponse
            {
                Error = "Internal Server Error"
            })
            {
                StatusCode = 500
            };
        }
        
        context.ExceptionHandled = true;
        return Task.CompletedTask;
    }
}