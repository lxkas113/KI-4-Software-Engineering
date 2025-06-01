using System.Reflection;
using Moq;
using OvenProject.GlobalModels;
using OvenProject.ModeHandlerModule;
using OvenProject.OvenControllerModule;

namespace OvenProject.Tests.OvenControllerTests;

public class TransitionTests
{
    [Fact]
    public void IdleState_ShouldTransitionToPreHeating_WhenTemperatureAboveZero()
    {
        var controller = new OvenController();
        controller.SetState(new IdleState());

        var input = new InputValues
        {
            Temperature = 120,
            Mode = CookingMode.Heat,
            Timer = TimeSpan.FromMinutes(10)
        };


        controller.GetCurrentState().Run(controller, input);

        Assert.IsType<PreHeatingState>(controller.GetCurrentState());
    }

    [Fact]
    public void PreHeatingState_ShouldTransitionToIdle_WhenTemperatureIsZero()
    {
        var controller = new OvenController();
        controller.SetState(new PreHeatingState());

        var input = new InputValues
        {
            Temperature = 0,
            Mode = CookingMode.Heat,
            Timer = TimeSpan.FromMinutes(10)
        };
        
        controller.GetCurrentState().Run(controller, input);

        Assert.IsType<IdleState>(controller.GetCurrentState());
    }

    [Fact]
    public void ActiveState_TransitionsToIdle_WhenTemperatureZero()
    {
        var controller = new OvenController();
        controller.SetState(new ActiveState());

        var input = new InputValues
        {
            Temperature = 0,
            Mode = CookingMode.Heat,
            Timer = TimeSpan.FromMinutes(10)
        };
        
        controller.GetCurrentState().Run(controller, input);

        Assert.IsType<IdleState>(controller.GetCurrentState());
    }

    [Fact]
    public void PreHeatingState_TransitionsToActive_WhenPreheatingDone()
    {
        var controller = new OvenController();
        controller.SetState(new PreHeatingState());
        
        var input = new InputValues
        {
            Temperature = 200,
            Mode = CookingMode.Heat,
            Timer = TimeSpan.FromMinutes(10)
        };

        ((PreHeatingState)controller.GetCurrentState()).SetStillPreheating(false);
        ((PreHeatingState)controller.GetCurrentState()).SetInput(input);
        controller.GetCurrentState().CheckStateTransition(controller);

        Assert.IsType<ActiveState>(controller.GetCurrentState());
    }
}