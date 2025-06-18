using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using TechRacingF1.Application;
using TechRacingF1.Infrastructure;
using TechRacingF1.WebApi.Auth;
Console.WriteLine("Starting Program.cs execution..."); // Debug log
Console.WriteLine("Creating WebApplication builder..."); // Debug log

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
var logsDirectory = Path.Combine(AppContext.BaseDirectory, "Logs");
if (!Directory.Exists(logsDirectory))
{
    Directory.CreateDirectory(logsDirectory);
}

// Configure Serilog from appsettings.json
builder.Host.UseSerilog((context, services, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Register layer services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Configure API

// Add controllers to the services

builder.Services.AddControllers()
    .AddJsonOptions(static options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.MaxDepth = 64;
    });

// Configure Swagger and API Key
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tech Racing F1 API",
        Version = "v1",
        Description = "API with hexagonal architecture and good practices",
        Contact = new OpenApiContact
        {
            Name = "Development team",
            Email = "development@techracingf1.com"
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    // API Key configuration
    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key needed to access the endpoints. Example: 'ApiKey TechRacingF1Api'",
        In = ParameterLocation.Header,
        Name = "X-API-Key",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKey"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                Scheme = "oauth2",
                Name = "ApiKey",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
    // Including XML comments for API documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

// Setup CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tech Racing F1 API v1"));
app.UseDeveloperExceptionPage();

// Configure CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseRouting();

// Add API Key middleware
app.UseMiddleware<ApiKeyMiddleware>();

// Use authorization
app.UseAuthorization();
app.MapControllers();

app.Run();

