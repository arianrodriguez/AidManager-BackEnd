﻿using System.Net.Mime;
using AidManager.API.IAM.Domain.Services;
using AidManager.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using AidManager.API.IAM.Interfaces.REST.Resources;
using AidManager.API.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AidManager.API.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class AuthenticationController(IUserIAMCommandService userCommandService) : ControllerBase
{
    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
    {
        try
        {
            var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
            await userCommandService.Handle(signUpCommand);
            return Ok(new { message = "User created successfully" });
        }
        catch (Exception e)
        {
            return BadRequest("Error: " + e.Message);
        }
        
    }
    
    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
        var authenticatedUser = await userCommandService.Handle(signInCommand);
        var authenticatedUserResource =
            AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.user,
                authenticatedUser.token);
        return Ok(authenticatedUserResource);
    }
}