using Microsoft.Extensions.DependencyInjection;
using WeekendDraw;
using WeekendDraw.Components.CsvReader;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();

services.AddSingleton<ICsvReader, CsvReader>();

var servicesProvider = services.BuildServiceProvider();
var app = servicesProvider.GetService<IApp>();
app.Run();