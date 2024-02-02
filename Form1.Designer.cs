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
            viewData = new Button();
            topicBox = new TextBox();
            subscribeTopic = new DataGridView();
            msgBox = new ListView();
            ((System.ComponentModel.ISupportInitialize)serverData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subscribeTopic).BeginInit();
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
            serverData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            serverData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            serverData.Location = new Point(1, 244);
            serverData.Name = "serverData";
            serverData.RowHeadersWidth = 51;
            serverData.Size = new Size(1837, 377);
            serverData.TabIndex = 4;
            serverData.CellContentClick += serverData_CellContentClick;
            // 
            // viewData
            // 
            viewData.Location = new Point(31, 209);
            viewData.Name = "viewData";
            viewData.Size = new Size(94, 29);
            viewData.TabIndex = 5;
            viewData.Text = "View Data";
            viewData.UseVisualStyleBackColor = true;
            viewData.Click += viewData_Click;
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
            subscribeTopic.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            subscribeTopic.Location = new Point(357, 13);
            subscribeTopic.Name = "subscribeTopic";
            subscribeTopic.RowHeadersWidth = 51;
            subscribeTopic.Size = new Size(455, 187);
            subscribeTopic.TabIndex = 7;
            // 
            // msgBox
            // 
            msgBox.Location = new Point(833, 13);
            msgBox.Name = "msgBox";
            msgBox.Size = new Size(308, 187);
            msgBox.TabIndex = 8;
            msgBox.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1838, 622);
            Controls.Add(msgBox);
            Controls.Add(subscribeTopic);
            Controls.Add(topicBox);
            Controls.Add(viewData);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Connbtn;
        private Label statLbl;
        private Button subBtn;
        private DataGridView serverData;
        private Button viewData;
        private TextBox topicBox;
        private DataGridView subscribeTopic;
        private ListView msgBox;
    }
}
