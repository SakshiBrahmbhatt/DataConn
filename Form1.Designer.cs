﻿namespace DataConn
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
            pubBtn = new Button();
            subBtn = new Button();
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
            // pubBtn
            // 
            pubBtn.Location = new Point(31, 60);
            pubBtn.Name = "pubBtn";
            pubBtn.Size = new Size(94, 29);
            pubBtn.TabIndex = 2;
            pubBtn.Text = "Publish";
            pubBtn.UseVisualStyleBackColor = true;
            // 
            // subBtn
            // 
            subBtn.Location = new Point(145, 60);
            subBtn.Name = "subBtn";
            subBtn.Size = new Size(94, 29);
            subBtn.TabIndex = 3;
            subBtn.Text = "Subscribe";
            subBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(subBtn);
            Controls.Add(pubBtn);
            Controls.Add(statLbl);
            Controls.Add(Connbtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Connbtn;
        private Label statLbl;
        private Button pubBtn;
        private Button subBtn;
    }
}
