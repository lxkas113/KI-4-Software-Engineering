using System.Reflection;
using Moq;
using OvenProject.GlobalModels;
using OvenProject.ModeHandlerModule;
using OvenProject.OvenControllerModule;

namespace OvenProject.Tests.OvenControllerTests;

public class TransitionTests
{
    // TC-2-6
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

        var proxy = Assert.IsType<StateProxy>(controller.GetCurrentState());
        var newState = proxy.GetState();
        Assert.IsType<PreHeatingState>(newState);
    }

    // TC-2-7
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

        var proxy = Assert.IsType<StateProxy>(controller.GetCurrentState());
        var newState = proxy.GetState();
        Assert.IsType<IdleState>(newState);
    }
    
    // TC-2-8
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

        var proxy = Assert.IsType<StateProxy>(controller.GetCurrentState());
        var newState = proxy.GetState();
        Assert.IsType<IdleState>(newState);
    }
    
    // TC-2-9
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

        var proxy = Assert.IsType<StateProxy>(controller.GetCurrentState());

        var preHeatState = proxy.GetState() as PreHeatingState;
        Assert.NotNull(preHeatState);

        preHeatState.SetStillPreheating(false);
        preHeatState.SetInput(input);

        preHeatState.CheckStateTransition(controller);

        var newProxy = Assert.IsType<StateProxy>(controller.GetCurrentState());
        var innerState = newProxy.GetState();
        Assert.IsType<ActiveState>(innerState);
    }
}