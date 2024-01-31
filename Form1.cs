using System;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataConn
{
    public partial class Form1 : Form
    {
        //mqtt connection variables
        bool connect = false;
        private MqttClient mqttClient;

        // mysql connection
        MySqlConnection con = new MySqlConnection("SERVER = 192.168.1.9 ; DATABASE = sys ; UID = db ; PASSWORD = Saks@2468 ;");


        public Form1()
        {
            InitializeComponent();
        }

        private void Connbtn_Click(object sender, EventArgs e)
        {
            if (connect == false)
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void viewDataTable()
        {
            try
            {
                con.Open();
                MessageBox.Show("Connection Open!");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection!");
            }
            MySqlDataAdapter da = new MySqlDataAdapter("select * from bmcmqtt", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            serverData.DataSource = ds.Tables[0];
        }

        private void viewData_Click(object sender, EventArgs e)
        {
            viewDataTable();
        }

        private void serverData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

    }
}
