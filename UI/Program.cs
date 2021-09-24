﻿using System;
using StoreBL;
using DL;
using Serilog;

namespace UI
{
    class Program
    {

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Information("Application Starting...");

            MenuFactory.GetMenu("main").Start();

            Log.Information("Application closing...");

            Log.CloseAndFlush();
        }
    }
}
