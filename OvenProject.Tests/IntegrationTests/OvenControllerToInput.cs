using System.Reflection;
using OvenProject.InputHandlerModule;
using OvenProject.OvenControllerModule;

namespace OvenProject.Tests.IntegrationTests;

/// <summary>
/// Integrationstest: Ofencontroller liest Temperatur korrekt vom Drehregler.
/// </summary>
public class OvenControllerToInput
{
    // TC-0-6
    [Theory]
    [InlineData(180, 200)]
    [InlineData(0, 0)]
    [InlineData(45, 50)]
    [InlineData(270, 300)]
    public void GetInput_ShouldReturnTemperatureFromRotaryController(int angle, int expectedTemperature)
    {
        var oven = new OvenController();
        oven.SetState(new IdleState());

        var inputHandlerProxyField = typeof(OvenController)
            .GetField("_inputHandler", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var inputHandlerProxy = inputHandlerProxyField.GetValue(oven)!;

        var inputHandlerField = inputHandlerProxy.GetType()
            .GetField("_inputHandler", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var inputHandler = inputHandlerField.GetValue(inputHandlerProxy)!;

        var tempControllerField = inputHandler.GetType()
            .GetField("_tempController", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var tempController = (TemperatureRotaryController)tempControllerField.GetValue(inputHandler)!;

        tempController.SetTestAngle(angle);

        var input = oven.GetInput();

        Assert.Equal(expectedTemperature, input.Temperature);
    }
}