using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Self.E2E.IntegrateTest.Tests;

[TestFixture]
public class BasicIntegrateTest
{
    private WebApplicationFactory<Program> _factory;

    [OneTimeSetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
    }

    [Test]
    public async Task True_Send_ReturnCorrect()
    {
        var client = _factory.CreateClient();

        var resp = await client.GetAsync("WeatherForecast/True");

        resp.EnsureSuccessStatusCode();
        var result = await resp.Content.ReadAsStringAsync();
        
        resp.Should().BeSuccessful();
        result.Should().BeEquivalentTo("true");
    }
}