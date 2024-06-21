using System;
using AidManager.API.Authentication.Application.Internal.CommandServices;
using AidManager.API.Authentication.Application.Internal.QueryServices;
using AidManager.API.Authentication.Domain.Repositories;
using AidManager.API.Authentication.Domain.Services;
using AidManager.API.Authentication.Infrastructure.Persistence.EFC.Repositories;
using AidManager.API.Authentication.Interfaces.REST.Resources;
using AidManager.API.Collaborate.Application.Internal.CommandServices;
using AidManager.API.Collaborate.Application.Internal.QueryServices;
using AidManager.API.Collaborate.Domain.Repositories;
using AidManager.API.Collaborate.Domain.Services;
using AidManager.API.Collaborate.Infraestructure.Repositories;
using AidManager.API.ManageCosts.Application.Internal.CommandServices;
using AidManager.API.ManageCosts.Application.Internal.QueryServices;
using AidManager.API.ManageCosts.Domain.Repositories;
using AidManager.API.ManageCosts.Domain.Services;
using AidManager.API.ManageCosts.Infraestructure.Repositories;
using AidManager.API.ManageTasks.Application.Internal.CommandServices;
using AidManager.API.ManageTasks.Application.Internal.QueryServices;
using AidManager.API.ManageTasks.Domain.Repositories;
using AidManager.API.ManageTasks.Domain.Services;
using AidManager.API.ManageTasks.Infrastructure.Repositories;
using AidManager.API.Payment.Application.Internal.CommandServices;
using AidManager.API.Payment.Application.Internal.QueryServices;
using AidManager.API.Payment.Domain.Repositories;
using AidManager.API.Payment.Domain.Services;
using AidManager.API.Payment.Infraestructure.Persistence.EFC.Repositories;
using AidManager.API.Shared.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Interfaces.ASP.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// configure kebab case route naming convention
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDBContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();    
    });

// configure lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// configure CORS
builder.Services.AddCors();

// shared bounded context injection configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// news bounded context injection configuration DEPENDENCY INJECTION
// post bounded context injection configuration
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostCommandService, PostCommandService>();
builder.Services.AddScoped<IPostQueryService, PostQueryService>();

// event bounded context injection configuration
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventCommandService, EventCommandService>();
builder.Services.AddScoped<IEventQueryService, EventQueryService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();

builder.Services.AddScoped<IAnalyticRepository, AnalyticRepository>();
builder.Services.AddScoped<IAnalyticQueryService, AnalyticQueryService>();
builder.Services.AddScoped<IAnalyticCommandService, AnalyticCommandService>();

builder.Services.AddScoped<ITaskRepository, TaskItemsRepository>();
builder.Services.AddScoped<ITaskCommandService, TaskCommandService>();
builder.Services.AddScoped<ITaskQueryService, TaskQueryService>();

builder.Services.AddScoped<IPaymentDetailRepository, PaymentDetailRepository>();
builder.Services.AddScoped<IPaymentDetailCommandService, PaymentDetailCommandService>();
builder.Services.AddScoped<IPaymentDetailQueryService, PaymentDetailQueryService>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyCommandService, CompanyCommandService>();
builder.Services.AddScoped<ICompanyQueryService, CompanyQueryService>();

builder.Services.AddScoped<IMessageCommandService, MessageCommandService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();


// Configure the HTTP request pipeline.
var app = builder.Build();

// verify database objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDBContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
