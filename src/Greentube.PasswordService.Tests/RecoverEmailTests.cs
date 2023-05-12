using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Shouldly;

namespace Greentube.PasswordService.Tests;

public class RecoverEmailTests
{
    [Fact]
    public async void RecoverEmail_WhenUserExists_ShouldSucceed()
    {
        // Arrange
        var user = new UserModel("Andrey", "sharkadi.a@gmail.com");

        await using var application = new PasswordServiceApp();

        var userService = application.Services.GetRequiredService<IUserService>();
        await userService.CreateUser(user);
        
        using var client = application.CreateClient();

        // Act
        var response = await client.PostAsync($"/recover/byEmail/{user.Email}", default);
  
        // Assert
        response.IsSuccessStatusCode.ShouldBeTrue();
        application.AuthTokens.Count.ShouldBe(1);
        application.EmailService.Verify(x =>
                x.Send(It.Is<EmailMessageModel>(x => x.To == user)),
            Times.Once);
    }      
    
    [Fact]
    public async void RecoverEmail_WhenMultipleRequestsSent_ShouldSucceed()
    {
        // Arrange
        var user = new UserModel("Andrey", "sharkadi.a@gmail.com");
        
        await using var application = new PasswordServiceApp();
        
        var userService = application.Services.GetRequiredService<IUserService>();
        await userService.CreateUser(user);
        
        using var client = application.CreateClient();
    
        // Act
        await client.PostAsync($"/recover/byEmail/{user.Email}", default);
        var secondResponse = await client.PostAsync($"/recover/byEmail/{user.Email}", default);
    
        // Assert
        secondResponse.IsSuccessStatusCode.ShouldBeTrue();
        application.AuthTokens.Count.ShouldBe(2);
        application.EmailService.Verify(x => 
                x.Send(It.Is<EmailMessageModel>(y => y.To == user)),
            Times.Exactly(2));
    }    
    
    [Fact]
    public async void RecoverEmail_WhenUserDoesntExists_ShouldFail()
    {
        // Arrange
        var user = new UserModel("Andrey", "sharkadi.a@gmail.com");
        const string nonExistingEmail = "test@test.com";
        
        await using var application = new PasswordServiceApp();
        
        var userService = application.Services.GetRequiredService<IUserService>();
        await userService.CreateUser(user);
        
        using var client = application.CreateClient();
    
        // Act
        var response = await client.PostAsync($"/recover/byEmail/{nonExistingEmail}", default);
    
        // Assert
        response.IsSuccessStatusCode.ShouldBeFalse();
        application.AuthTokens.ShouldBeEmpty();
        application.EmailService.VerifyNoOtherCalls();
    }
    
    [Fact]
    public async void RecoverEmail_WhenInvalidEmail_ShouldFail()
    {
        // Arrange
        var user = new UserModel("Andrey", "sharkadi.a\t\t@gmail.com");
        
        await using var application = new PasswordServiceApp();
        
        var userService = application.Services.GetRequiredService<IUserService>();
        await userService.CreateUser(user);
        
        using var client = application.CreateClient();
    
        // Act
        var response = await client.PostAsync($"/recover/byEmail/{user.Email}", default);
    
        // Assert
        response.IsSuccessStatusCode.ShouldBeFalse();
        application.AuthTokens.ShouldBeEmpty();
        application.EmailService.VerifyNoOtherCalls();
    }
}