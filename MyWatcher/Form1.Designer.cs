namespace MyWatcher
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
            this.subscribe = new System.Windows.Forms.Button();
            this.unsubscribe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // subscribe
            // 
            this.subscribe.Location = new System.Drawing.Point(42, 59);
            this.subscribe.Name = "subscribe";
            this.subscribe.Size = new System.Drawing.Size(75, 23);
            this.subscribe.TabIndex = 0;
            this.subscribe.Text = "Subscribe";
            this.subscribe.UseVisualStyleBackColor = true;
            this.subscribe.Click += new System.EventHandler(this.subscribe_Click);
            // 
            // unsubscribe
            // 
            this.unsubscribe.Location = new System.Drawing.Point(147, 59);
            this.unsubscribe.Name = "unsubscribe";
            this.unsubscribe.Size = new System.Drawing.Size(75, 23);
            this.unsubscribe.TabIndex = 1;
            this.unsubscribe.Text = "Unsubscribe";
            this.unsubscribe.UseVisualStyleBackColor = true;
            this.unsubscribe.Click += new System.EventHandler(this.unsubscribe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.unsubscribe);
            this.Controls.Add(this.subscribe);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button subscribe;
        private System.Windows.Forms.Button unsubscribe;
    }
}

