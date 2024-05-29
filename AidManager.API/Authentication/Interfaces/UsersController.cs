using System.Net.Mime;
using AidManager.API.Authentication.Domain.Services;
using AidManager.API.Authentication.Interfaces.REST.Resources;
using AidManager.API.Authentication.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AidManager.API.Authentication.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(IUserCommandService userCommandService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new user",
        Description = "Creates a new user with a given body",
        OperationId = "CreateUser"
    )]
    [SwaggerResponse(201, "The user was created", typeof(CreateUserResource))]
    public async Task<IActionResult> CreateNewUser([FromBody] CreateUserResource resource)
    {
        var command = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await userCommandService.Handle(command);
        if(user == null) return BadRequest();

        var userResource = CreateResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }
}