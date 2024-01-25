using System;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Exceptions;

namespace DataConn
{
    public partial class Form1 : Form
    {
        bool connect = false;
        private MqttClient mqttClient;

        public Form1()
        {
            InitializeComponent();
        }

        private void Connbtn_Click(object sender, EventArgs e)
        {
            if(connect == false)
            {
                try
                {
                    mqttClient = new MqttClient("www.mqtt-dashboard.com", 1883, false, null, null, MqttSslProtocols.None);
                    mqttClient.Connect(Guid.NewGuid().ToString());
                    MessageBox.Show("Connected to MQTT broker!");
                    Connbtn.Text = "Disconnect";
                    statLbl.Text = "Connected to broker";
                    connect = true;

                }
                catch (MqttConnectionException ex)
                {
                    MessageBox.Show("Error connecting to MQTT broker: " + ex.Message);
                }
            }
            else
            {
                mqttClient.Disconnect();
                Connbtn.Text = "Connect";
                statLbl.Text = "Not Connected to broker";
                connect = false;
            }
        }
    }
}
