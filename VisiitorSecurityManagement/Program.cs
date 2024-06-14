using VisiitorSecurityManagement.CosmosDB;
using VisiitorSecurityManagement.Interface;
using VisiitorSecurityManagement.Other;
using VisiitorSecurityManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICosmosDBService>(s =>
{
    var configuration = s.GetRequiredService<IConfiguration>();
    var cosmosEndPoint = configuration["CosmosDb:Endpoint"];
    var primaryKey = configuration["CosmosDb:PrimaryKey"];
    return new CosmosDBService(cosmosEndPoint, primaryKey);
});

// Register the other services
builder.Services.AddScoped<IVisitorService, VisitorService>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IOfficeService, OfficeService>();

// Register the email service and configure SMTP settings
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<IEmailService, SmtpEmailService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
