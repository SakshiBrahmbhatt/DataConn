using System;
using System.Collections.Generic;
using System.Linq;
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
        // MQTT connection variables
        bool connect = false;
        private MqttClient mqttClient;
        private List<string> subscribedTopics = new List<string>();
        private List<MessageData> messages = new List<MessageData>();

        // MySQL connection
        MySqlConnection con = new MySqlConnection("SERVER = 192.168.1.9; DATABASE = sys; UID = db; PASSWORD = Saks@2468;");

        // DeviceId field
        private string deviceId;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            deviceId = Properties.Settings.Default.DeviceId;
            if (string.IsNullOrEmpty(deviceId))
            {
                deviceId = GenerateRandomString(5);
                Properties.Settings.Default.DeviceId = deviceId;
                Properties.Settings.Default.Save();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connect)
            {
                mqttClient.Disconnect();
                Connbtn.Text = "Connect";
                statLbl.Text = "Not Connected to broker";
                connect = false;
                MessageBox.Show("Disconnected from MQTT broker!");
            }
        }

        private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if (connect)
            {
                string messageText = System.Text.Encoding.UTF8.GetString(e.Message);
                MessageData newMessage = new MessageData(messageText);
                messages.Add(newMessage);
                UpdateListBox();
            }
        }

        private void UpdateListBox()
        {
            if (msgBox.InvokeRequired)
            {
                msgBox.Invoke(new Action(UpdateListBox));
            }
            else
            {
                msgBox.Items.Clear();
                foreach (var message in messages)
                {
                    msgBox.Items.Add($"{message.Message}");
                    List<string> parts = new List<string>(message.Message.Split(','));
                    try
                    {
                        con.Open();
                        string insertQuery = "INSERT INTO bmcmqtt (DeviceId,BMCODE,Temperature,Pressure,Volume,Level,Generator,Grid,Aggregate,Compressor1,compressor2,VoltageU,VoltageV,VoltageW,CurrentU,CurrentV,CurrentW,Frequency,PwrF,TPwr,Time,Date) VALUES (@DeviceId,@BMCODE,@Temp,@Press,@Vol,@Lvl,@Gen,@Grid,@Agr,@Comp1,@Comp2,@VoltU,@VoltV,@VoltW,@CurrU,@CurrV,@CurrW,@Freq,@PwrF,@TPwr,@Time,@Date)";
                        MySqlCommand cmd = new MySqlCommand(insertQuery, con);
                        cmd.Parameters.AddWithValue("@DeviceId", deviceId);
                        cmd.Parameters.AddWithValue("@BMCODE", parts[0]);
                        cmd.Parameters.AddWithValue("@Temp", parts[1]);
                        cmd.Parameters.AddWithValue("@Press", parts[2]);
                        cmd.Parameters.AddWithValue("@Vol", parts[3]);
                        cmd.Parameters.AddWithValue("@Lvl", parts[4]);
                        cmd.Parameters.AddWithValue("@Gen", parts[5]);
                        cmd.Parameters.AddWithValue("@Grid", parts[6]);
                        cmd.Parameters.AddWithValue("@Agr", parts[7]);
                        cmd.Parameters.AddWithValue("@Comp1", parts[8]);
                        cmd.Parameters.AddWithValue("@Comp2", parts[9]);
                        cmd.Parameters.AddWithValue("@VoltU", parts[10]);
                        cmd.Parameters.AddWithValue("@VoltV", parts[11]);
                        cmd.Parameters.AddWithValue("@VoltW", parts[12]);
                        cmd.Parameters.AddWithValue("@CurrU", parts[13]);
                        cmd.Parameters.AddWithValue("@CurrV", parts[14]);
                        cmd.Parameters.AddWithValue("@CurrW", parts[15]);
                        cmd.Parameters.AddWithValue("@Freq", parts[16]);
                        cmd.Parameters.AddWithValue("@Pwrf", parts[17]);
                        cmd.Parameters.AddWithValue("@TPwr", parts[18]);
                        cmd.Parameters.AddWithValue("@Time", parts[19]);
                        cmd.Parameters.AddWithValue("@Date", parts[20].Substring(0, 12));
                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("Topic inserted into bmcmqtt table!");

                        MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bmcmqtt", con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        serverData.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inserting into bmcmqtt table: {ex.Message}");
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }




        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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
                    mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                    viewDataTable();

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
            try
            {
                subscribedTopics.Clear();

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
            // Additional initialization code if needed
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

        private void serverData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
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
                            string insertQuery = "INSERT INTO subscribe_topic (Topic, Status) VALUES (@topic, @status)";
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

        private void filterMyData_CheckedChanged(object sender, EventArgs e)
        {
            if (filterMyData.Checked)
            {
                try
                {
                    con.Open();

                    // Use parameterized query to avoid SQL injection
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM bmcmqtt WHERE DeviceId = @deviceId", con);
                    cmd.Parameters.AddWithValue("@deviceId", deviceId);  // Assuming deviceId is a field in your class

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    serverData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting from bmcmqtt table: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                try
                {

                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bmcmqtt", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    serverData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting from bmcmqtt table: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }


        public class MessageData
    {
        public string Message { get; set; }

        public MessageData(string message)
        {
            Message = message;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherMessage = (MessageData)obj;
            return Message == otherMessage.Message;
        }

        public override int GetHashCode()
        {
            return Message.GetHashCode();
        }
    }
}
