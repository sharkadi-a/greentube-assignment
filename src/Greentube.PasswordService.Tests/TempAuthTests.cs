using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.Models;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Greentube.PasswordService.Tests;

public class TempAuthTests
{
    [Fact]
    public async void TempAuth_WhenUserAuthorizeAfterRecover_ShouldSucceed()
    {
        // Arrange
        var user = new UserModel("Andrey", "sharkadi.a@gmail.com");

        await using var application = new PasswordServiceApp();

        var userService = application.Services.GetRequiredService<IUserService>();
        await userService.CreateUser(user);
        
        using var client = application.CreateClient();

        // Act
        await client.PostAsync($"/recover/byEmail/{user.Email}", default);
        var response = await client.PostAsync($"/login/temp/{user.Email}/{application.AuthTokens.Single()}", default);
        
        // Assert
        response.IsSuccessStatusCode.ShouldBeTrue();
    }      
    
    [Fact]
    public async void TempAuth_WhenUserUsesOutdatedUrl_ShouldFail()
    {
        // Arrange
        var user = new UserModel("Andrey", "sharkadi.a@gmail.com");

        await using var application = new PasswordServiceApp();

        var userService = application.Services.GetRequiredService<IUserService>();
        await userService.CreateUser(user);
        
        using var client = application.CreateClient();

        // Act
        await client.PostAsync($"/recover/byEmail/{user.Email}", default);
        var outdatedToken = application.AuthTokens.Single();
        
        await client.PostAsync($"/recover/byEmail/{user.Email}", default);
        var response = await client.PostAsync($"/login/temp/{user.Email}/{outdatedToken}", default);
        
        // Assert
        response.IsSuccessStatusCode.ShouldBeFalse();
    }      
    
    [Fact]
    public async void TempAuth_WhenUserAuthorizeWithoutRequest_ShouldSucceed()
    {
        // Arrange
        var user = new UserModel("Andrey", "sharkadi.a@gmail.com");

        await using var application = new PasswordServiceApp();

        var userService = application.Services.GetRequiredService<IUserService>();
        await userService.CreateUser(user);
        
        using var client = application.CreateClient();

        // Act
        var response = await client.PostAsync($"/login/temp/{user.Email}/NONEXISTINGTOKEN", default);
        
        // Assert
        response.IsSuccessStatusCode.ShouldBeFalse();
    }  
}