﻿using OvenProject.ThermalControllerModule;

namespace OvenProject.ModeHandlerModule;

public interface IModeStrategy
{
    void Run(int targetTemperature);
}