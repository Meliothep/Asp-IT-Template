using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;


namespace {{cookiecutter.project_name}}.Tests.Integration.Health;

[Collection("Integration collection")]
public sealed class HealthTest
{
    private readonly WebApplicationFactory<Program> _factory;

    public HealthTest(IntegrationFixture fixture)
    {
        _factory = fixture.factory!;
    }

    [Theory]
    [InlineData("/health")]
    public async Task Get_Health_is_Healthy(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.NotNull(response.Content.Headers.ContentType);
        Assert.Equal("application/json", response.Content.Headers.ContentType.ToString());

        var jsonBody = await response.Content.ReadFromJsonAsync<HealthDTO>();
        Assert.NotNull(jsonBody);
        Assert.Equal("Healthy", jsonBody.status);
    }
}
