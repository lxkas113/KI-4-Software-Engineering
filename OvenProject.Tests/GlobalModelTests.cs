using System.Reflection;
using OvenProject.InputHandlerModule;
using OvenProject.OvenControllerModule;

namespace OvenProject.Tests;

/// <summary>
/// Testes die Datenkapslung der GobalModels.
/// </summary>
public class GlobalModelTests
{
    // TC-0-3
    public static void SetTargetTemperature(OvenController oven, int targetTemp)
    {
        int angle = (targetTemp * 270) / 300;

        var inputHandlerProxyField = typeof(OvenController)
            .GetField("_inputHandler", BindingFlags.NonPublic | BindingFlags.Instance);
        var inputHandlerProxy = inputHandlerProxyField?.GetValue(oven)
                                ?? throw new Exception("_inputHandler (proxy) not found");

        var inputHandlerField = inputHandlerProxy.GetType()
            .GetField("_inputHandler", BindingFlags.NonPublic | BindingFlags.Instance);
        var inputHandler = inputHandlerField?.GetValue(inputHandlerProxy)
                           ?? throw new Exception("_inputHandler (real) not found");

        var tempControllerField = inputHandler.GetType()
            .GetField("_tempController", BindingFlags.NonPublic | BindingFlags.Instance);
        var tempController = tempControllerField?.GetValue(inputHandler)
                             ?? throw new Exception("_tempController not found");

        var angleProperty = tempController.GetType().BaseType!
                                .GetProperty("Angle", BindingFlags.Public | BindingFlags.Instance)
                            ?? throw new Exception("Property 'Angle' not found");

        angleProperty.SetValue(tempController, angle);
    }
    
    // TC-0-4
    public static TemperatureRotaryController GetTemperatureController(OvenController oven)
    {
        var inputHandlerProxyField = typeof(OvenController).GetField("_inputHandler", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var inputHandlerProxy = inputHandlerProxyField.GetValue(oven)!;

        var inputHandlerField = inputHandlerProxy.GetType().GetField("_inputHandler", BindingFlags.NonPublic | BindingFlags.Instance)!;
        var inputHandler = inputHandlerField.GetValue(inputHandlerProxy)!;

        var tempControllerField = inputHandler.GetType().GetField("_tempController", BindingFlags.NonPublic | BindingFlags.Instance)!;
        return (TemperatureRotaryController)tempControllerField.GetValue(inputHandler)!;
    }
}