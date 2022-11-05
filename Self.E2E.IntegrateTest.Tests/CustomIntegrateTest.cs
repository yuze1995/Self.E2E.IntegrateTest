using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Self.E2E.IntegrateTest.Tests;

public class CustomIntegrateTest
{
    private WebApplicationFactory<Program> _factory;

    [OneTimeSetUp]
    public void Setup()
    {
        _factory = new CustomWebApplicationFactory();
    }
    
    [Test]
    public async Task Version_Send_ReturnV2()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("WeatherForecast/Version");

        resp.EnsureSuccessStatusCode();
        var result = await resp.Content.ReadAsStringAsync();
        
        resp.Should().BeSuccessful();
        result.Should().BeEquivalentTo("V2");
    } 
}