using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.Models;
using Greentube.PasswordService.Api.Options;
using Greentube.PasswordService.Api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Moq;

namespace Greentube.PasswordService.Tests;

internal class PasswordServiceApp : WebApplicationFactory<Program>
{
    private class PasswordServiceWrapper : IPasswordService
    {
        private readonly IPasswordService _passwordServiceImplementation;
        private readonly ISet<string> _tokens;

        public PasswordServiceWrapper(IPasswordService passwordServiceImplementation, ISet<string> tokens)
        {
            _passwordServiceImplementation = passwordServiceImplementation;
            _tokens = tokens;
        }

        public async Task<string> GenerateResetToken(UserModel user)
        {
            var resetToken = await _passwordServiceImplementation.GenerateResetToken(user);
            _tokens.Add(resetToken);

            return resetToken;
        }

        public Task<bool> VerifyTokenOnce(string token, string email)
        {
            return _passwordServiceImplementation.VerifyTokenOnce(token, email);
        }
    }

    public Mock<IEmailService> EmailService { get; }
    
    public ISet<string> AuthTokens { get; } = new HashSet<string>();

    public PasswordServiceApp()
    {
        EmailService = new Mock<IEmailService>();
        EmailService.Setup(x => x.SendTemplateEmail(It.IsAny<EmailMessageModel>()))
            .Returns(Task.CompletedTask);
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(x =>
        {
            x.RemoveAll<IEmailService>();
            x.AddScoped<IEmailService>(x => EmailService.Object);
            x.RemoveAll<IPasswordService>();
            x.AddScoped<IPasswordService>(x => new PasswordServiceWrapper(new SimplePasswordService(
                x.GetRequiredService<IMemoryCache>(),
                x.GetRequiredService<IOptions<PasswordOptions>>()), AuthTokens));
        });
    }
}