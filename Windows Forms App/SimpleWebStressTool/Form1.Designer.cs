namespace SimpleWebStressTool
{
    partial class SimpleWebStressTool
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartStressTestButton = new System.Windows.Forms.Button();
            this.EndStressTestButton = new System.Windows.Forms.Button();
            this.RequestsPerSecondLabel = new System.Windows.Forms.Label();
            this.TotalRequestsLabel = new System.Windows.Forms.Label();
            this.TotalTimeLabel = new System.Windows.Forms.Label();
            this.RequestsDroppedLabel = new System.Windows.Forms.Label();
            this.TotalDataLabel = new System.Windows.Forms.Label();
            this.AverageSpeedLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.URLInputBox = new System.Windows.Forms.RichTextBox();
            this.ThreadsToUseUpDown = new System.Windows.Forms.NumericUpDown();
            this.AverageRequestsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadsToUseUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(173, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label2.Location = new System.Drawing.Point(42, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. of threads to use: ";
            // 
            // StartStressTestButton
            // 
            this.StartStressTestButton.AutoSize = true;
            this.StartStressTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.StartStressTestButton.Location = new System.Drawing.Point(102, 388);
            this.StartStressTestButton.Name = "StartStressTestButton";
            this.StartStressTestButton.Size = new System.Drawing.Size(132, 39);
            this.StartStressTestButton.TabIndex = 4;
            this.StartStressTestButton.Text = "Start Test";
            this.StartStressTestButton.UseVisualStyleBackColor = true;
            this.StartStressTestButton.Click += new System.EventHandler(this.StartStressTestButton_ClickAsync);
            // 
            // EndStressTestButton
            // 
            this.EndStressTestButton.AutoSize = true;
            this.EndStressTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.EndStressTestButton.Location = new System.Drawing.Point(575, 388);
            this.EndStressTestButton.Name = "EndStressTestButton";
            this.EndStressTestButton.Size = new System.Drawing.Size(132, 39);
            this.EndStressTestButton.TabIndex = 5;
            this.EndStressTestButton.Text = "End Test";
            this.EndStressTestButton.UseVisualStyleBackColor = true;
            this.EndStressTestButton.Click += new System.EventHandler(this.EndStressTestButton_Click);
            // 
            // RequestsPerSecondLabel
            // 
            this.RequestsPerSecondLabel.AutoSize = true;
            this.RequestsPerSecondLabel.Location = new System.Drawing.Point(292, 203);
            this.RequestsPerSecondLabel.Name = "RequestsPerSecondLabel";
            this.RequestsPerSecondLabel.Size = new System.Drawing.Size(220, 13);
            this.RequestsPerSecondLabel.TabIndex = 6;
            this.RequestsPerSecondLabel.Text = "Sending at the rate of  0 requests per second";
            // 
            // TotalRequestsLabel
            // 
            this.TotalRequestsLabel.AutoSize = true;
            this.TotalRequestsLabel.Location = new System.Drawing.Point(292, 231);
            this.TotalRequestsLabel.Name = "TotalRequestsLabel";
            this.TotalRequestsLabel.Size = new System.Drawing.Size(116, 13);
            this.TotalRequestsLabel.TabIndex = 7;
            this.TotalRequestsLabel.Text = "Total Requests Sent: 0";
            // 
            // TotalTimeLabel
            // 
            this.TotalTimeLabel.AutoSize = true;
            this.TotalTimeLabel.Location = new System.Drawing.Point(305, 253);
            this.TotalTimeLabel.Name = "TotalTimeLabel";
            this.TotalTimeLabel.Size = new System.Drawing.Size(103, 13);
            this.TotalTimeLabel.TabIndex = 8;
            this.TotalTimeLabel.Text = "Total Time Taken: 0";
            // 
            // RequestsDroppedLabel
            // 
            this.RequestsDroppedLabel.AutoSize = true;
            this.RequestsDroppedLabel.Location = new System.Drawing.Point(229, 277);
            this.RequestsDroppedLabel.Name = "RequestsDroppedLabel";
            this.RequestsDroppedLabel.Size = new System.Drawing.Size(179, 13);
            this.RequestsDroppedLabel.TabIndex = 9;
            this.RequestsDroppedLabel.Text = "Total Requests dropped by server: 0";
            // 
            // TotalDataLabel
            // 
            this.TotalDataLabel.AutoSize = true;
            this.TotalDataLabel.Location = new System.Drawing.Point(290, 299);
            this.TotalDataLabel.Name = "TotalDataLabel";
            this.TotalDataLabel.Size = new System.Drawing.Size(118, 13);
            this.TotalDataLabel.TabIndex = 10;
            this.TotalDataLabel.Text = "Total Data Recieved: 0";
            // 
            // AverageSpeedLabel
            // 
            this.AverageSpeedLabel.AutoSize = true;
            this.AverageSpeedLabel.Location = new System.Drawing.Point(239, 321);
            this.AverageSpeedLabel.Name = "AverageSpeedLabel";
            this.AverageSpeedLabel.Size = new System.Drawing.Size(169, 13);
            this.AverageSpeedLabel.TabIndex = 11;
            this.AverageSpeedLabel.Text = "Average Speed of Transmission: 0";
            // 
            // ResetButton
            // 
            this.ResetButton.AutoSize = true;
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.ResetButton.Location = new System.Drawing.Point(340, 388);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(132, 39);
            this.ResetButton.TabIndex = 12;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // URLInputBox
            // 
            this.URLInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.URLInputBox.Location = new System.Drawing.Point(299, 66);
            this.URLInputBox.Multiline = false;
            this.URLInputBox.Name = "URLInputBox";
            this.URLInputBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.URLInputBox.Size = new System.Drawing.Size(473, 35);
            this.URLInputBox.TabIndex = 13;
            this.URLInputBox.Text = "http://localhost";
            // 
            // ThreadsToUseUpDown
            // 
            this.ThreadsToUseUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.ThreadsToUseUpDown.Location = new System.Drawing.Point(299, 130);
            this.ThreadsToUseUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.ThreadsToUseUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThreadsToUseUpDown.Name = "ThreadsToUseUpDown";
            this.ThreadsToUseUpDown.Size = new System.Drawing.Size(255, 35);
            this.ThreadsToUseUpDown.TabIndex = 14;
            this.ThreadsToUseUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AverageRequestsLabel
            // 
            this.AverageRequestsLabel.AutoSize = true;
            this.AverageRequestsLabel.Location = new System.Drawing.Point(245, 343);
            this.AverageRequestsLabel.Name = "AverageRequestsLabel";
            this.AverageRequestsLabel.Size = new System.Drawing.Size(163, 13);
            this.AverageRequestsLabel.TabIndex = 15;
            this.AverageRequestsLabel.Text = "Average Requests per second: 0";
            this.AverageRequestsLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // SimpleWebStressTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.AverageRequestsLabel);
            this.Controls.Add(this.ThreadsToUseUpDown);
            this.Controls.Add(this.URLInputBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.AverageSpeedLabel);
            this.Controls.Add(this.TotalDataLabel);
            this.Controls.Add(this.RequestsDroppedLabel);
            this.Controls.Add(this.TotalTimeLabel);
            this.Controls.Add(this.TotalRequestsLabel);
            this.Controls.Add(this.RequestsPerSecondLabel);
            this.Controls.Add(this.EndStressTestButton);
            this.Controls.Add(this.StartStressTestButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "SimpleWebStressTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Web Stress Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ThreadsToUseUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartStressTestButton;
        private System.Windows.Forms.Button EndStressTestButton;
        private System.Windows.Forms.Label RequestsPerSecondLabel;
        private System.Windows.Forms.Label TotalRequestsLabel;
        private System.Windows.Forms.Label TotalTimeLabel;
        private System.Windows.Forms.Label RequestsDroppedLabel;
        private System.Windows.Forms.Label TotalDataLabel;
        private System.Windows.Forms.Label AverageSpeedLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.RichTextBox URLInputBox;
        private System.Windows.Forms.NumericUpDown ThreadsToUseUpDown;
        private System.Windows.Forms.Label AverageRequestsLabel;
    }
}

