namespace KriyaEmailForm
{
    partial class MessageForm
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
            this.messageSubject = new System.Windows.Forms.TextBox();
            this.messageBody = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.addressListFileType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // messageSubject
            // 
            this.messageSubject.Location = new System.Drawing.Point(167, 33);
            this.messageSubject.Name = "messageSubject";
            this.messageSubject.Size = new System.Drawing.Size(689, 39);
            this.messageSubject.TabIndex = 1;
            // 
            // messageBody
            // 
            this.messageBody.Location = new System.Drawing.Point(167, 95);
            this.messageBody.Name = "messageBody";
            this.messageBody.Size = new System.Drawing.Size(689, 365);
            this.messageBody.TabIndex = 2;
            this.messageBody.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Subject";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Body";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(254, 481);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(225, 63);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(548, 481);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(225, 63);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear All";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 268);
            this.label3.MaximumSize = new System.Drawing.Size(150, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 64);
            this.label3.TabIndex = 7;
            this.label3.Text = "Recipiant\'s File Type";
            // 
            // addressListFileType
            // 
            this.addressListFileType.FormattingEnabled = true;
            this.addressListFileType.Location = new System.Drawing.Point(12, 356);
            this.addressListFileType.Name = "addressListFileType";
            this.addressListFileType.Size = new System.Drawing.Size(149, 40);
            this.addressListFileType.TabIndex = 8;
            this.addressListFileType.SelectedIndexChanged += new System.EventHandler(this.addressListFileType_SelectedIndexChanged);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 571);
            this.Controls.Add(this.addressListFileType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageSubject);
            this.Controls.Add(this.messageBody);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MessageForm";
            this.Text = "EmailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox messageSubject;
        private System.Windows.Forms.RichTextBox messageBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox addressListFileType;
    }
}