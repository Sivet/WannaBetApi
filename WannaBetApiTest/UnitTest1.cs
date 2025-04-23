using Xunit;
using WannaBetApi.Models;
using NSubstitute;

namespace WannaBetApiTest;

public class UnitTest1
{
    private ILogger _logger = Substitute.For<ILogger>();
    
    [Fact]
    public void Test1()
    {
        WeatherForecast weather = new WeatherForecast();
        weather.TemperatureC = 15;
        Assert.Equal(15, weather.TemperatureC);
    }
}
