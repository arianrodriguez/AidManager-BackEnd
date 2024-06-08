using System.Net.Mime;
using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Domain.Model.Queries;
using AidManager.API.Authentication.Domain.Services;
using AidManager.API.Authentication.Interfaces.REST.Resources;
using AidManager.API.Authentication.Interfaces.REST.Transform;
using AidManager.API.UserProfile.Interfaces.REST.Resources;
using AidManager.API.UserProfile.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AidManager.API.Authentication.Interfaces;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(IUserCommandService userCommandService, IUserQueryService userQueryService) : ControllerBase
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
        var query = new GetUserByEmailQuery(resource.Email);
        var userExists = await userQueryService.FindUserByEmail(query);
        if(userExists != null) // Mail is already in use
        {
            return Ok(new {status_code = 404, message = "Mail is already in use", data = new {}});
        }
        
        var command = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await userCommandService.Handle(command);
        if(user == null) return BadRequest();

        var userResource = CreateGetUserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(new {status_code=202, message="User created", data=userResource});
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Obtains all users",
        Description = "Obtains all users",
        OperationId = "GetAllUsers"
    )]
    [SwaggerResponse(200, "The users were obtained")]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();
        var users = await userQueryService.Handle(query);
        if(users == null) return BadRequest();
        var usersResources = users.Select(CreateResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(usersResources);
    }
    
    // users?email=...
    [HttpGet]
    [Microsoft.AspNetCore.Mvc.Route("auth")]
    [SwaggerResponse(200, "The user was obtained")]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email, string password)
    {
        var query = new GetUserByEmailQuery(email);
        var user = await userQueryService.FindUserByEmail(query);
        if (user == null)
        {
            return Ok(new {status_code=404, message = "User not found", data = new {}});
        }
        
        var resource = CreateUserCredentialsResourceFromEntityAssembler.ToResourceFromEntity(user, password);
        var command = CreateUserCredentialsCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        if(!await userCommandService.AuthenticateUser(command)) return Ok(new {status_code=401, message = "Invalid credentials", data = new {}});
        return Ok(new {status_code=202,message = "Authenticated", data = user});
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromQuery] string email, [FromBody] UpdateUserResource resource)
    {
        var query = new GetUserByEmailQuery(email);
        var user = await userQueryService.FindUserByEmail(query);
        if(user == null) return BadRequest();
        
        var command = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var updatedUser = await userCommandService.Handle(command,  email);
        if(updatedUser == null) return BadRequest();
        
        var userResource = CreateResourceFromEntityAssembler.ToResourceFromEntity(updatedUser);
        return Ok(userResource);
    }
    
    
    
}