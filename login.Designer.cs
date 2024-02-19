namespace DataConn
{
    partial class login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            userValue = new TextBox();
            passwordValue = new TextBox();
            Loginbutton = new Button();
            topics_assign = new Label();
            topicsToSelect = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 133);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 180);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // userValue
            // 
            userValue.Location = new Point(233, 129);
            userValue.Name = "userValue";
            userValue.Size = new Size(125, 27);
            userValue.TabIndex = 2;
            // 
            // passwordValue
            // 
            passwordValue.Location = new Point(233, 177);
            passwordValue.Name = "passwordValue";
            passwordValue.Size = new Size(125, 27);
            passwordValue.TabIndex = 3;
            passwordValue.UseSystemPasswordChar = true;
            // 
            // Loginbutton
            // 
            Loginbutton.Location = new Point(206, 285);
            Loginbutton.Name = "Loginbutton";
            Loginbutton.Size = new Size(94, 29);
            Loginbutton.TabIndex = 4;
            Loginbutton.Text = "Add User";
            Loginbutton.UseVisualStyleBackColor = true;
            Loginbutton.Click += Loginbutton_Click;
            // 
            // topics_assign
            // 
            topics_assign.AutoSize = true;
            topics_assign.Location = new Point(92, 230);
            topics_assign.Name = "topics_assign";
            topics_assign.Size = new Size(129, 20);
            topics_assign.TabIndex = 5;
            topics_assign.Text = "Topic to subscribe";
            // 
            // topicsToSelect
            // 
            topicsToSelect.FormattingEnabled = true;
            topicsToSelect.Location = new Point(227, 230);
            topicsToSelect.Name = "topicsToSelect";
            topicsToSelect.Size = new Size(151, 28);
            topicsToSelect.TabIndex = 6;
            topicsToSelect.Text = "select";
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 409);
            Controls.Add(topicsToSelect);
            Controls.Add(topics_assign);
            Controls.Add(Loginbutton);
            Controls.Add(passwordValue);
            Controls.Add(userValue);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "login";
            Text = "login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox userValue;
        private TextBox passwordValue;
        private Button Loginbutton;
        private Label topics_assign;
        private ComboBox topicsToSelect;
    }
}