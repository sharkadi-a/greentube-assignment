using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.Middleware;
using Greentube.PasswordService.Api.Options;
using Greentube.PasswordService.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFilterAttribute));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IUserService, SimpeUserService>();
builder.Services.AddScoped<IAuthService, SimpleAuthService>();
builder.Services.AddScoped<IEmailFactory, SimpleEmailFactory>();
builder.Services.AddScoped<IEmailService, SimpleEmailService>();
builder.Services.AddScoped<IPasswordService, SimplePasswordService>();
builder.Services.AddScoped<IValidator, SimpleValidator>();
builder.Services.Configure<PasswordOptions>(builder.Configuration.GetSection(nameof(PasswordOptions)));

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