using Xunit;
using WannaBetApi.Models;

namespace WannaBetApiTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        WeatherForecast weather = new WeatherForecast();
        weather.TemperatureC = 15;
        Assert.Equal(15, weather.TemperatureC);
    }
}