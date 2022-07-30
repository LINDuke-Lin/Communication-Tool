using System.Text;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Communication.Mqtt.Services
{
    public class SendService
    {
        public void Send(string topic, string msg)
        {
            if (ConnectService._mqttClient == null || ConnectService._mqttClient.IsConnected == false)
                throw new Exception("尚未連線");

            ConnectService._mqttClient.Publish(topic, Encoding.UTF8.GetBytes(msg), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
        }
    }
}
