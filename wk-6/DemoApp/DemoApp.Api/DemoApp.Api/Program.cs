using DemoApp.DataLogic;


var builder = WebApplication.CreateBuilder(args);

// Connection String:
// Argument, Hardcoded, File, User Secrets, Environmental Variables
string connectionString = builder.Configuration["connectionString"];

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepository>(sp => new SQLRepository(connectionString, sp.GetRequiredService<ILogger<SQLRepository>>()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
