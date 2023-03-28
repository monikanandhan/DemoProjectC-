using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;

namespace SerilogExampleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File(new JsonFormatter(), "important.json")
                           
                            .WriteTo.File("all.logs",
                                          restrictedToMinimumLevel: LogEventLevel.Warning,
                                          rollingInterval: RollingInterval.Day).MinimumLevel.Debug().CreateLogger();
            var person1 = new Person("john", "s");
            var person2 = new Person("jacky", "m");
            var car1 = new Car("Tesla", 2022, person1);
            var car2 = new Car("Hyundai", 2021, person2);
            Log.Verbose("Some verbose log");
            Log.Debug("Some Debug Log");
            Log.Information("Person1:{@person}", person1);
            Log.Information("Person2:{@person}", person2);
            Log.Information("car1:{@car}", car1);
            Log.Information("car21:{@car}",car2);
            Log.Warning("Warning occured at {now}", DateTime.Now);
            Log.Error("Error occured at {now}", DateTime.Now);
            Log.Fatal("Problem with car {@car} accrued at {now}", car1, DateTime.Now);
            Log.Fatal("Problem with car {@car} accrued at {now}", car2, DateTime.Now);



        }
    }
}
