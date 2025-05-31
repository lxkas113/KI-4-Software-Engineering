using OvenProject.InputHandlerModule;


namespace OvenProject.Tests.InputHandlerTests;

public class TemperatureRotaryControllerTest
{
    // TC-3-1
    // Requirements tested: 2.1.1; 2.1.2; 2.1.3; 
    [Theory]
    [InlineData(0, 0)]
    [InlineData(45, 50)]
    [InlineData(90, 100)]
    [InlineData(135, 150)]
    [InlineData(180, 200)]
    [InlineData(270, 300)]
    [InlineData(288, 300)]
    [InlineData(300, 300)]
    [InlineData(360, 0)]
    [InlineData(450, 100)]
    public void ReadInput_ReturnsExpectedTemperature(int angle, int expectedTemperature)
    {
        var controller = new TemperatureRotaryController();
        controller.Angle = angle;
        int actualTemperature = controller.ReadInput();
        Assert.Equal(expectedTemperature, actualTemperature);
    }
}