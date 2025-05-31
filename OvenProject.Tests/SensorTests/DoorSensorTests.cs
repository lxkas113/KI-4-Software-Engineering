using OvenProject.SensorModule;

namespace OvenProject.Tests.SensorTests;

public class DoorSensorTests
{
    // TC-7-1
    [Fact]
    public void DefaultState_ShouldBeClosed()
    {
        var sensor = new DoorSensor();

        var result = sensor.GetValue();

        Assert.True(result);
    }
    
    // TC-7-2
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void SetDoorState_UpdatesInternalState(bool expected)
    {
        var sensor = new DoorSensor();
        sensor.SetDoorState(expected);

        var result = sensor.GetValue();

        Assert.Equal(expected, result);
    }
}