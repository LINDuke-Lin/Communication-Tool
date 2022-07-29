namespace Communication.Mqtt.Models
{
    public class ConnectModel
    {
        private string? _ServerIp;
        private string? _MqttUser;
        private string? _MqttPassword;
        private string? _ClientId;

        /// <summary>
        /// Mqtt ip
        /// </summary>
        public string ServerIp
        {
            get => _ServerIp;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));

                _ServerIp = value;
            }
        }

        /// <summary>
        /// Mqtt port
        /// </summary>
        public int ServerPort { get; set; }

        /// <summary>
        /// Mqtt User
        /// </summary>
        public string MqttUser
        {
            get => _MqttUser;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));

                _MqttUser = value;
            }
        }

        /// <summary>
        /// Mqtt Password
        /// </summary>
        public string MqttPassword
        {
            get => _MqttPassword;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));

                _MqttPassword = value;
            }
        }

        /// <summary>
        /// Mqtt PRE_TRANSFER
        /// </summary>
        public string? PRE_TRANSFER { get; set; }

        /// <summary>
        /// Mqtt 主題
        /// </summary>
        public string? Topic { get; set; }

        /// <summary>
        /// Mqtt ClientId
        /// </summary>
        public string ClientId
        {
            get => _ClientId;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));

                _ClientId = value;
            }
        }
    }
}
