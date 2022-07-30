using Communication.Mqtt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.Lib.Services
{

    public interface IMqttLib
    {
        void Connect();

        void Send(string msg);
    }

    public class MqttLib : IMqttLib
    {

        private readonly SendService sendService;

        public MqttLib()
        {
            sendService = new SendService();
        }

        public void Connect()
        {
            ConnectService.ConnectMqtt(new Mqtt.Models.ConnectModel()
            {
                ServerIp = "127.0.0.1",
                ServerPort = 1883,
                MqttUser = "admin",
                MqttPassword = "admin",
                PRE_TRANSFER = "",
                Topic = "first_test",
                ClientId = "test1"
            });
        }

        public void Send(string msg)
        {
            sendService.Send("first_test", msg);
        }
    }
}
