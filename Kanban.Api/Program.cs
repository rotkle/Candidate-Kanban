using Kanban.Api.Helpers;
using Kanban.Api.Repositories;
using Kanban.Api.Repositories.Interfaces;
using Kanban.Api.Services;
using Kanban.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var env = builder.Environment;

services.AddDbContext<DataContext>();
services.AddCors();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddTransient<ICandidateRepository, CandidateRepository>();
services.AddTransient<IStatusRepository, StatusRepository>();
services.AddTransient<IJobRepository, JobRepository>();
services.AddTransient<IUnitOfWork, UnitOfWork>();

services.AddScoped<ICandidateService, CandidateService>();
services.AddScoped<IStatusService, StatusService>();
services.AddScoped<IJobService, JobService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run("http://localhost:4000");
