using NTier.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InjectDeps(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations(app.Environment.IsDevelopment());

app.UseHttpsRedirection();
app.MapControllers(); 

app.Run();
