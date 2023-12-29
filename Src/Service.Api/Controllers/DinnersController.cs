// <copyright file="DinnersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class DinnersController : ApiController
    {
        [HttpGet]
        [Route("/dinner")]
        [Authorize]
        [ApiExplorerSettings]
        public IActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
