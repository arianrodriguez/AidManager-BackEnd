using System;
using System.Net.Mime;
using System.Threading.Tasks;
using AidManager.API.SampleBounded.Domain.Model.Queries;
using AidManager.API.SampleBounded.Domain.Services;
using AidManager.API.SampleBounded.Interfaces.REST.Resources;
using AidManager.API.SampleBounded.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AidManager.API.SampleBounded.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BooksController(IBookCommandService bookCommandService, IBookQueryService bookQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateBook([FromBody] CreateBookResource resource)
    {
        Console.WriteLine("create book called");
        var createBookCommand = CreateBookCommandFromResourceAssembler.ToCommandFromResource(resource);
        Console.WriteLine("command created");
        var result = await bookCommandService.Handle(createBookCommand);

        var bookById = this.GetBookById(result.Id);
        Console.WriteLine("book by id called" + bookById.Result.ToString());
        
        return CreatedAtAction(nameof(GetBookById), new { id = result.Id },
            BookResourceFromEntityAssembler.ToResourceFromEntity(result));

    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetBookById(int id)
    {
        Console.WriteLine("get book by id called");
        var getBookByIdQuery = new GetBookByIdQuery(id);
        Console.WriteLine("query created");
        var result = await bookQueryService.Handle(getBookByIdQuery);
        Console.WriteLine("query handled");
        var resource = BookResourceFromEntityAssembler.ToResourceFromEntity(result);
        Console.WriteLine("resource created");
        return Ok(resource);
    }

}