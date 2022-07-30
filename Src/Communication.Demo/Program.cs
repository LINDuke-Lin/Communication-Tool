// See https://aka.ms/new-console-template for more information
using Communication.Lib.Services;
using Microsoft.Extensions.DependencyInjection;



var diProvider = new ServiceCollection().AddSingleton<IRedisService, RedisService>()
    .AddSingleton<IMqttLib, MqttLib>()
    .BuildServiceProvider();

Console.WriteLine("Hello, World!");



var mqttLib = diProvider.GetService<IMqttLib>();
mqttLib.Connect();

string msg;
do
{
    msg = Console.ReadLine();
    mqttLib.Send(msg);

} while (msg != "Esc");


Console.ReadKey();