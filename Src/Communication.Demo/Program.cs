// See https://aka.ms/new-console-template for more information
using Communication.Lib.Services;

Console.WriteLine("Hello, World!");

IMqttLib mqttLib = new MqttLib();

mqttLib.Connect();

string msg;
do
{
    msg = Console.ReadLine();
    mqttLib.Send(msg);

} while (msg != "Esc");


Console.ReadKey();