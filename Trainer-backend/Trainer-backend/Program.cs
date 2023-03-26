using Trainer_backend.Persistence;
using Trainer_backend.Services;

const string allowPolicySpecificOrigins = "_allowPolicySpecificOrigins";

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: allowPolicySpecificOrigins, policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        }
    );
});

builder.Services.AddControllers();
DatabaseContext.CreateDatabase(new DatabaseContext());
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<ISetService, SetService>();
builder.Services.AddScoped<IWorkSetService, WorkSetService>();
builder.Services.AddScoped<IRoutineService, RoutineService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseRouting();
app.UseCors(allowPolicySpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
