using System.Net;
using FluentAssertions;

namespace PipelineBehaviorsDemo.Tests.IntegrationTests;

public class WebApiTests
{
    [Theory]
    [InlineData("api/v1/weathers/rome")]
    [InlineData("api/v1/weathers/carthage")]
    public async Task Should_Get_Weather_By_City_Returns_Ok(string route)
    {
        // arrange
        var fixture = new WebApiTestFixture();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData("api/v1/weathers/12")]
    [InlineData("api/v1/weathers/ab")]
    public async Task Should_Get_Weather_By_City_Returns_BadRequest(string route)
    {
        // arrange
        var fixture = new WebApiTestFixture();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData("api/v1/weathers/berlin")]
    [InlineData("api/v1/weathers/london")]
    public async Task Should_Get_Weather_By_City_Returns_NotFound(string route)
    {
        // arrange
        var fixture = new WebApiTestFixture();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}
