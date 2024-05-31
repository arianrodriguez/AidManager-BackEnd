using System.Net.Mime;
using AidManager.API.Collaborate.Domain.Model.Commands;
using AidManager.API.Collaborate.Domain.Model.Queries;
using AidManager.API.Collaborate.Domain.Services;
using AidManager.API.Collaborate.Interfaces.REST.Resources;
using AidManager.API.Collaborate.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AidManager.API.Collaborate.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PostsController(IPostCommandService postCommandService, IPostQueryService postQueryService) : ControllerBase
{
    // create new post
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new post",
        Description = "Create a new post",
        OperationId = "CreatePost"
    )]
    [SwaggerResponse(201, "Post created", typeof(CreatePostResource))]
    public async Task<IActionResult> CreateNewPost([FromBody] CreatePostResource resource)
    {
        var command = CreatePostCommandFromResourceAssembler.ToCommandFromResource(resource);
        var post = await postCommandService.Handle(command);

        if (post == null) return BadRequest();
        
        var postResource = CreateResourceFromEntityAssembler.ToResourceFromEntity(post);
        return Ok(postResource);
    }
    
    // obtain all posts
    [HttpGet]
    [SwaggerOperation (
        Summary = "Get all posts",
        Description = "Get all posts",
        OperationId = "GetAllPosts"
    )]
    [SwaggerResponse(200, "The posts were found")]
    public async Task<IActionResult> GetAllPosts()
    {
        var query = new GetAllPostsQuery();
        var posts = await postQueryService.Handle(query);

        if (posts == null) return BadRequest();
        
        var postResources = posts.Select(CreateResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(postResources);
    }
    
    // obtain post by id
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get post by id",
        Description = "Get post by id",
        OperationId = "GetPostById"
    )]
    [SwaggerResponse(200, "The post was found", typeof(CreatePostResource))]
    public async Task<IActionResult> GetPostById([FromRoute] int id)
    {
        var query = new GetPostById(id);
        var post = await postQueryService.Handle(query);

        if (post == null) return NotFound();
        
        var postResource = CreateResourceFromEntityAssembler.ToResourceFromEntity(post);
        return Ok(postResource);
    }
    
    // delete post by id
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete post by id",
        Description = "Delete post by id",
        OperationId = "DeletePostById"
    )]
    [SwaggerResponse(200, "The post was deleted", typeof(CreatePostResource))]
    public async Task<IActionResult> DeletePostById([FromRoute] int id)
    {
        var command = new DeletePostCommand(id);
        var post = await postCommandService.Handle(command);

        if (post == null) return NotFound();
        
        var postResource = CreateResourceFromEntityAssembler.ToResourceFromEntity(post);
        return Ok(postResource);
    }
    
}