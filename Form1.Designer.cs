namespace DataConn
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Connbtn = new Button();
            statLbl = new Label();
            subBtn = new Button();
            serverData = new DataGridView();
            topicBox = new TextBox();
            subscribeTopic = new DataGridView();
            filterMyData = new CheckBox();
            searchText = new TextBox();
            searchBtn = new Button();
            users = new DataGridView();
            addUser = new Button();
            ((System.ComponentModel.ISupportInitialize)serverData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subscribeTopic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)users).BeginInit();
            SuspendLayout();
            // 
            // Connbtn
            // 
            Connbtn.Location = new Point(31, 13);
            Connbtn.Name = "Connbtn";
            Connbtn.Size = new Size(94, 29);
            Connbtn.TabIndex = 0;
            Connbtn.Text = "Connect";
            Connbtn.UseVisualStyleBackColor = true;
            Connbtn.Click += Connbtn_Click;
            // 
            // statLbl
            // 
            statLbl.AutoSize = true;
            statLbl.Location = new Point(131, 17);
            statLbl.Name = "statLbl";
            statLbl.Size = new Size(172, 20);
            statLbl.TabIndex = 1;
            statLbl.Text = "Not connected to broker";
            // 
            // subBtn
            // 
            subBtn.Location = new Point(31, 58);
            subBtn.Name = "subBtn";
            subBtn.Size = new Size(94, 29);
            subBtn.TabIndex = 3;
            subBtn.Text = "Subscribe";
            subBtn.UseVisualStyleBackColor = true;
            subBtn.Click += subBtn_Click;
            // 
            // serverData
            // 
            serverData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            serverData.BackgroundColor = SystemColors.InactiveCaption;
            serverData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            serverData.Location = new Point(1, 244);
            serverData.Name = "serverData";
            serverData.RowHeadersWidth = 51;
            serverData.Size = new Size(1837, 377);
            serverData.TabIndex = 4;
            // 
            // topicBox
            // 
            topicBox.Location = new Point(131, 58);
            topicBox.Name = "topicBox";
            topicBox.PlaceholderText = "topic/#";
            topicBox.Size = new Size(166, 27);
            topicBox.TabIndex = 6;
            // 
            // subscribeTopic
            // 
            subscribeTopic.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            subscribeTopic.BackgroundColor = SystemColors.InactiveCaption;
            subscribeTopic.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            subscribeTopic.Location = new Point(357, 13);
            subscribeTopic.Name = "subscribeTopic";
            subscribeTopic.RowHeadersWidth = 51;
            subscribeTopic.Size = new Size(455, 187);
            subscribeTopic.TabIndex = 7;
            // 
            // filterMyData
            // 
            filterMyData.AutoSize = true;
            filterMyData.Location = new Point(12, 214);
            filterMyData.Name = "filterMyData";
            filterMyData.Size = new Size(157, 24);
            filterMyData.TabIndex = 9;
            filterMyData.Text = "Only show my data";
            filterMyData.UseVisualStyleBackColor = true;
            filterMyData.CheckedChanged += filterMyData_CheckedChanged;
            // 
            // searchText
            // 
            searchText.Location = new Point(218, 212);
            searchText.Name = "searchText";
            searchText.PlaceholderText = "topic/#";
            searchText.Size = new Size(166, 27);
            searchText.TabIndex = 10;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(390, 210);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(94, 29);
            searchBtn.TabIndex = 11;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // users
            // 
            users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            users.BackgroundColor = SystemColors.InactiveCaption;
            users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            users.Location = new Point(857, 12);
            users.Name = "users";
            users.RowHeadersWidth = 51;
            users.Size = new Size(455, 187);
            users.TabIndex = 12;
            // 
            // addUser
            // 
            addUser.Location = new Point(1174, 209);
            addUser.Name = "addUser";
            addUser.Size = new Size(138, 29);
            addUser.TabIndex = 13;
            addUser.Text = "Add New User";
            addUser.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1838, 622);
            Controls.Add(addUser);
            Controls.Add(users);
            Controls.Add(searchBtn);
            Controls.Add(searchText);
            Controls.Add(filterMyData);
            Controls.Add(subscribeTopic);
            Controls.Add(topicBox);
            Controls.Add(serverData);
            Controls.Add(subBtn);
            Controls.Add(statLbl);
            Controls.Add(Connbtn);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)serverData).EndInit();
            ((System.ComponentModel.ISupportInitialize)subscribeTopic).EndInit();
            ((System.ComponentModel.ISupportInitialize)users).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Connbtn;
        private Label statLbl;
        private Button subBtn;
        private DataGridView serverData;
        private TextBox topicBox;
        private DataGridView subscribeTopic;
        private CheckBox filterMyData;
        private TextBox searchText;
        private Button searchBtn;
        private DataGridView users;
        private Button addUser;
    }
}
