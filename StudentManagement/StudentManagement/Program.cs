using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentManagement;
using StudentManagement.Helpers;
using StudentManagement.IService;
using StudentManagement.Model;
using StudentManagement.Service;


var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

// Add services to the container.


builder.Services.AddControllers();
    //builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DC")));
    builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DS")));
builder.Services.AddLogging(loggingBuilder => loggingBuilder.ClearProviders().AddProvider(new CorrelationIdLoggerProvider()));
builder.Services.AddTransient<IStudentInterface,StudentService>();
    builder.Services.AddTransient<IMarkInterface,MarkService>();
    builder.Services.AddTransient<ITermInterface,TermService>();



    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();


//Add Logging 
//var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//Log.Logger = new LoggerConfiguration()
//.ReadFrom.Configuration(configuration).WriteTo.Console().WriteTo.File("all.logs",
//restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day)
//.CreateLogger();

builder.Services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(provider =>
provider.GetRequiredService<Microsoft.Extensions.Logging.ILogger>());

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
   

    app.Run();
