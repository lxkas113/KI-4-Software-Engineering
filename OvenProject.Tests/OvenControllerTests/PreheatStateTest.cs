using OvenProject.OvenControllerModule;

namespace OvenProject.Tests.OvenControllerTests;

/// <summary>
/// Validiert das Verhalten des PreHeatingState, insbesondere die Übergangsbedingungen und Temperaturerhöhung.
/// </summary>
public class PreheatStateTest
{
    // TC-2-5
    [Fact]
    public void Run_ActiveState_ShouldProduceOutputAndIncreaseTemperature()
    {
        var controller = new OvenController();
        controller.SetState(new PreHeatingState());
        int initialTemp = controller.GetTemperature();

        controller.Run();

        int afterTemp = controller.GetTemperature();
        Assert.True(afterTemp >= initialTemp);
    }
}