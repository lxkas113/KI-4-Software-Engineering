using OvenProject.GlobalModels;
using OvenProject.InputHandlerModule;

namespace OvenProject.Tests.InputHandlerTests;

public class ModeRotaryControllerTest
{
    // TC-3-2
    // Requirements tested: R-1.4; R-1.5;
    [Theory]
    [InlineData(0, CookingMode.Idle)]
    [InlineData(50, CookingMode.TopBottomHeat)]
    [InlineData(100, CookingMode.TopHeat)]
    [InlineData(150, CookingMode.BottomHeat)]
    [InlineData(200, CookingMode.Grill)]
    [InlineData(250, CookingMode.CirculatingAir)]
    [InlineData(300, CookingMode.HotAir)]
    [InlineData(360, CookingMode.Idle)]
    [InlineData(410, CookingMode.TopBottomHeat)]
    public void ReadInput_ReturnsExpectedCookingMode(int angle, CookingMode expected)
    {
        var controller = new ModeRotaryController();
        controller.SetTestAngle(angle);

        var actual = controller.ReadInput();

        Assert.Equal(expected, actual);
    }

}