using GateWayService.Hubs;
using GateWayService.Services;
using GateWayService.Services.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Serilog setup
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

// HttpClients for downstream microservices
builder.Services.AddHttpClient<ITutorialCommunicationService, TutorialCommunicationService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:CourseServive"]);
});

builder.Services.AddHttpClient<ILeadershipCommunicationService, LeadershipCommunicationService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:LeadershipService"]);
});

// CORS: Allow all for demo purposes
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .SetIsOriginAllowed(_ => true);
    });
});

var app = builder.Build();


// Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gateway API V1");
    c.RoutePrefix = "swagger"; // Swagger UI available at http://localhost:8082/swagger
});


app.UseCors();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<NotificationHub>("/hub/notifications"); 
});

// Optional: simple health check endpoint
app.MapGet("/", () => "Gateway is running");

app.Run();
