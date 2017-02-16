namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.messagesList = new System.Windows.Forms.ListBox();
            this.loadMessagesButton = new System.Windows.Forms.Button();
            this.messagesCountLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wordsToSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Click login to get token.";
            // 
            // messagesList
            // 
            this.messagesList.FormattingEnabled = true;
            this.messagesList.Location = new System.Drawing.Point(12, 80);
            this.messagesList.Name = "messagesList";
            this.messagesList.Size = new System.Drawing.Size(660, 472);
            this.messagesList.TabIndex = 3;
            // 
            // loadMessagesButton
            // 
            this.loadMessagesButton.Location = new System.Drawing.Point(570, 25);
            this.loadMessagesButton.Name = "loadMessagesButton";
            this.loadMessagesButton.Size = new System.Drawing.Size(102, 32);
            this.loadMessagesButton.TabIndex = 4;
            this.loadMessagesButton.Text = "Load messages";
            this.loadMessagesButton.UseVisualStyleBackColor = true;
            this.loadMessagesButton.Click += new System.EventHandler(this.loadMessagesButton_Click);
            // 
            // messagesCountLabel
            // 
            this.messagesCountLabel.AutoSize = true;
            this.messagesCountLabel.Location = new System.Drawing.Point(9, 55);
            this.messagesCountLabel.Name = "messagesCountLabel";
            this.messagesCountLabel.Size = new System.Drawing.Size(154, 13);
            this.messagesCountLabel.TabIndex = 5;
            this.messagesCountLabel.Text = "Login before getting messages.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter a word to search:";
            // 
            // wordsToSearch
            // 
            this.wordsToSearch.Location = new System.Drawing.Point(132, 32);
            this.wordsToSearch.Name = "wordsToSearch";
            this.wordsToSearch.Size = new System.Drawing.Size(432, 20);
            this.wordsToSearch.TabIndex = 7;
            this.wordsToSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wordsToSearch_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 564);
            this.Controls.Add(this.wordsToSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.messagesCountLabel);
            this.Controls.Add(this.loadMessagesButton);
            this.Controls.Add(this.messagesList);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox messagesList;
        private System.Windows.Forms.Button loadMessagesButton;
        private System.Windows.Forms.Label messagesCountLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox wordsToSearch;
    }
}

