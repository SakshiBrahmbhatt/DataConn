using System;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using MySql.Data.MySqlClient;
using System.Data;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DataConn
{
    public partial class Form1 : Form
    {
        //mqtt connection variables
        bool connect = false;
        private MqttClient mqttClient;
        private List<String> messages;
        private List<String> subscribedTopics = new List<string>();

        // mysql connection
        MySqlConnection con = new MySqlConnection("SERVER = 192.168.1.9 ; DATABASE = sys ; UID = db ; PASSWORD = Saks@2468 ;");


        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mqttClient.Disconnect();
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

                    try
                    {
                        con.Open();

                        LoadSubscribedTopics();

                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot open connection!");
                    }
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from subscribe_topic", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    subscribeTopic.DataSource = ds.Tables[0];

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

        private void LoadSubscribedTopics()
        {
            // Load all topics from the subscribe_topic table
            try
            {
                subscribedTopics.Clear(); // Clear existing topics before loading

                string query = "SELECT Topic FROM subscribe_topic";
                MySqlCommand cmd = new MySqlCommand(query, con);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string topic = reader["Topic"].ToString();
                        subscribedTopics.Add(topic);

                        // Subscribe to the topic
                        mqttClient.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subscribed topics: " + ex.Message);
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

        private void subBtn_Click(object sender, EventArgs e)
        {
            if (connect)
            {
                if (!string.IsNullOrEmpty(topicBox.Text))
                {
                    string topic = topicBox.Text.Trim();

                    if (!string.IsNullOrEmpty(topic) && !subscribedTopics.Contains(topic))
                    {
                        mqttClient.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                        subscribedTopics.Add(topic);
                        try
                        {
                            con.Open();
                            string insertQuery = "INSERT INTO subscribe_topic (topic, status) VALUES (@topic, @status)";
                            MySqlCommand cmd = new MySqlCommand(insertQuery, con);
                            cmd.Parameters.AddWithValue("@Topic", topic);
                            cmd.Parameters.AddWithValue("@Status", 1);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Topic inserted into subscribe_topic table!");

                            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM subscribe_topic", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            subscribeTopic.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting into subscribe_topic table: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter a topic to subscribe");
                }
            }
            else
            {
                MessageBox.Show("First connect to the broker");
            }
        }

    }
}
