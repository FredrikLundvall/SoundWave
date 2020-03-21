namespace SoundWave
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
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.numFrequency = new System.Windows.Forms.NumericUpDown();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.btnSaveWaveForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.Location = new System.Drawing.Point(12, 369);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(120, 23);
            this.btnPlaySound.TabIndex = 0;
            this.btnPlaySound.Text = "Spela upp ljud";
            this.btnPlaySound.UseVisualStyleBackColor = true;
            this.btnPlaySound.Click += new System.EventHandler(this.btnPlaySound_Click);
            // 
            // numFrequency
            // 
            this.numFrequency.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numFrequency.Location = new System.Drawing.Point(25, 32);
            this.numFrequency.Maximum = new decimal(new int[] {
            30000000,
            0,
            0,
            0});
            this.numFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFrequency.Name = "numFrequency";
            this.numFrequency.Size = new System.Drawing.Size(88, 20);
            this.numFrequency.TabIndex = 1;
            this.numFrequency.ThousandsSeparator = true;
            this.numFrequency.Value = new decimal(new int[] {
            220000,
            0,
            0,
            0});
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(22, 16);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(51, 13);
            this.lblFrequency.TabIndex = 2;
            this.lblFrequency.Text = "Frekvens";
            // 
            // btnSaveWaveForm
            // 
            this.btnSaveWaveForm.Location = new System.Drawing.Point(165, 369);
            this.btnSaveWaveForm.Name = "btnSaveWaveForm";
            this.btnSaveWaveForm.Size = new System.Drawing.Size(120, 23);
            this.btnSaveWaveForm.TabIndex = 3;
            this.btnSaveWaveForm.Text = "Spara en vågform";
            this.btnSaveWaveForm.UseVisualStyleBackColor = true;
            this.btnSaveWaveForm.Click += new System.EventHandler(this.btnSaveWaveForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 458);
            this.Controls.Add(this.btnSaveWaveForm);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.numFrequency);
            this.Controls.Add(this.btnPlaySound);
            this.Name = "Form1";
            this.Text = "Testa SoundWave";
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlaySound;
        private System.Windows.Forms.NumericUpDown numFrequency;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Button btnSaveWaveForm;
    }
}

