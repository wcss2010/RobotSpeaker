namespace RobotSpeaker.Forms
{
    partial class VoiceUI
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
            this.cpChatContent = new RobotSpeaker.Controls.Chat.ContentPanel();
            this.SuspendLayout();
            // 
            // cpChatContent
            // 
            this.cpChatContent.AutoScroll = true;
            this.cpChatContent.BackColor = System.Drawing.Color.Transparent;
            this.cpChatContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cpChatContent.Location = new System.Drawing.Point(0, 64);
            this.cpChatContent.Name = "cpChatContent";
            this.cpChatContent.Size = new System.Drawing.Size(1031, 423);
            this.cpChatContent.TabIndex = 1;
            // 
            // VoiceUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 487);
            this.Controls.Add(this.cpChatContent);
            this.Name = "VoiceUI";
            this.Text = "VoiceUI";
            this.TitleText = "语音对话";
            this.TitleTextColor = System.Drawing.Color.White;
            this.Controls.SetChildIndex(this.cpChatContent, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Chat.ContentPanel cpChatContent;
    }
}