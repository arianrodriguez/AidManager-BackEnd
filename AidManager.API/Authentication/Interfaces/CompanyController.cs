using System.Net.Mime;
using AidManager.API.Authentication.Domain.Model.Queries;
using AidManager.API.Authentication.Domain.Services;
using AidManager.API.Authentication.Interfaces.REST.Resources;
using AidManager.API.Authentication.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AidManager.API.Authentication.Interfaces;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CompanyController(ICompanyCommandService companyCommandService, ICompanyQueryService companyQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNewCompany([FromBody] CreateCompanyResource resource)
    {
        var command = CreateCompanyCommandFromResourceAssembler.ToCommandFromResource(resource);
        var company = await companyCommandService.handle(command);
        if (company == null) return Ok(new { status_code = 500, message = "Internal pointer" });
        return Ok(new { status_code = 200, message = "Company created" });
    }
    
    [HttpGet("{UID}")]
    public async Task<IActionResult> GetCompanyByUID(string UID)
    {
        var query = new GetCompanyByUIDQuery(UID);
        var company = await companyQueryService.handle(query);
        if (company == null) return Ok(new { status_code = 404, message = "Company not found" });
        return Ok(new { status_code = 200, message = "Company found", company = CreateCompanyResourceFromEntityAssembler.ToResourceFromEntity(company) });
    }
}