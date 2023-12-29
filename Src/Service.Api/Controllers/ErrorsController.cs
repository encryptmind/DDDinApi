// <copyright file="ErrorsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Service.Api.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()!.Error;
            return Problem(title: exception.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}
