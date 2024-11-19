namespace labAcccc
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelPrompt = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.MaskedTextBox();
            this.buttonGreet = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPrompt
            // 
            this.labelPrompt.AutoSize = true;
            this.labelPrompt.Location = new System.Drawing.Point(239, 77);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(99, 16);
            this.labelPrompt.TabIndex = 0;
            this.labelPrompt.Text = "Enter the Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(342, 102);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 22);
            this.textBoxName.TabIndex = 1;
            // 
            // buttonGreet
            // 
            this.buttonGreet.Location = new System.Drawing.Point(263, 148);
            this.buttonGreet.Name = "buttonGreet";
            this.buttonGreet.Size = new System.Drawing.Size(75, 23);
            this.buttonGreet.TabIndex = 2;
            this.buttonGreet.Text = "Greet Me";
            this.buttonGreet.UseVisualStyleBackColor = true;
            this.buttonGreet.Click += new System.EventHandler(this.buttonGreet_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(239, 201);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(39, 16);
            this.labelMessage.TabIndex = 3;
            this.labelMessage.Text = "Hello";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonGreet);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelPrompt);
            this.Name = "Form1";
            this.Text = "Welcome App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPrompt;
        private System.Windows.Forms.MaskedTextBox textBoxName;
        private System.Windows.Forms.Button buttonGreet;
        private System.Windows.Forms.Label labelMessage;
    }
}
