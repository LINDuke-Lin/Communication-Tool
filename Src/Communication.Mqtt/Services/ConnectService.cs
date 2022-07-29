using Communication.Mqtt.Models;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Communication.Mqtt.Services
{
    internal static class ConnectService
    {
        private static MqttClient? _mqttClient;
        private static Thread? t_mqtt;
        private static ConnectModel connectModel =new();

        private static void _TryContinueConnect()
        {
            if (_mqttClient.IsConnected) return;

            Thread retryThread = new Thread(new ThreadStart(delegate
            {
                Subscribe();
            }));

            retryThread.Start();
        }
        private static void SetClient()
        {
            _mqttClient = new MqttClient(connectModel.ServerIp, connectModel.ServerPort, false, null, null, MqttSslProtocols.TLSv1_2);
            if (_mqttClient != null)
            {
                _mqttClient.MqttMsgPublishReceived += client_MqttMsgPublishTransferReceived;
                _mqttClient.ConnectionClosed += (sender, e) =>
                {
                    _TryContinueConnect();
                };
            }
        }
        private static void client_MqttMsgPublishTransferReceived(object sender, MqttMsgPublishEventArgs e)
        {

        }
        private static void Subscribe()
        {
            while (_mqttClient == null || _mqttClient.IsConnected == false)
            {
                if (_mqttClient == null)
                    SetClient();
                else
                    _mqttClient.Connect(connectModel.ClientId, connectModel.MqttUser, connectModel.MqttPassword, false, 20);


                if (_mqttClient.IsConnected)
                {
                    _mqttClient.Subscribe(new String[] { connectModel.PRE_TRANSFER + connectModel.Topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                    break;
                }
            }
        }


        public static void ConnectMqtt(ConnectModel _connectModel)
        {
            if(connectModel == null)
                throw new ArgumentNullException(nameof(connectModel));

            connectModel = connectModel;
            t_mqtt = new Thread(Subscribe);
            t_mqtt.Start();
        }
    }
}
