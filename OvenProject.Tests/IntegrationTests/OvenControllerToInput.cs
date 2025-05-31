using System.Reflection;
using OvenProject.InputHandlerModule;
using OvenProject.OvenControllerModule;

namespace OvenProject.Tests.IntegrationTests;

public class OvenControllerToInput
{
    [Theory]
    [InlineData(180, 200)]
    [InlineData(0, 0)]
    [InlineData(45, 50)]
    [InlineData(270, 300)]
    public void GetInput_ShouldReturnTemperatureFromRotaryController(int angle, int expectedTemperature)
    {
        // Arrange
        var oven = new OvenController();

        // Zugriff auf InputHandler
        var inputHandlerField = typeof(OvenController)
            .GetField("_inputHandler", BindingFlags.NonPublic | BindingFlags.Instance);
        var inputHandler = (InputHandler)inputHandlerField!.GetValue(oven)!;

        // Zugriff auf TemperatureRotaryController
        var tempControllerField = typeof(InputHandler)
            .GetField("_tempController", BindingFlags.NonPublic | BindingFlags.Instance);
        var tempController = (BaseRotaryController<int>)tempControllerField!.GetValue(inputHandler)!;

        // Simuliere Drehwinkel
        tempController.Angle = angle;

        // Act
        var input = oven.GetInput();

        // Assert
        Assert.Equal(expectedTemperature, input.Temperature);
    }
}