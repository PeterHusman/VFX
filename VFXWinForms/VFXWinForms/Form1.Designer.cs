namespace VFXWinForms
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
            this.colorDialogMin = new System.Windows.Forms.ColorDialog();
            this.colorDialogMax = new System.Windows.Forms.ColorDialog();
            this.buttonColorMin = new System.Windows.Forms.Button();
            this.buttonMax = new System.Windows.Forms.Button();
            this.strtProcess = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // buttonColorMin
            // 
            this.buttonColorMin.Location = new System.Drawing.Point(13, 26);
            this.buttonColorMin.Name = "buttonColorMin";
            this.buttonColorMin.Size = new System.Drawing.Size(123, 23);
            this.buttonColorMin.TabIndex = 0;
            this.buttonColorMin.Text = "Select Color 1";
            this.buttonColorMin.UseVisualStyleBackColor = true;
            this.buttonColorMin.Click += new System.EventHandler(this.buttonColorMin_Click);
            // 
            // buttonMax
            // 
            this.buttonMax.Location = new System.Drawing.Point(152, 26);
            this.buttonMax.Name = "buttonMax";
            this.buttonMax.Size = new System.Drawing.Size(120, 23);
            this.buttonMax.TabIndex = 1;
            this.buttonMax.Text = "Select Color 2";
            this.buttonMax.UseVisualStyleBackColor = true;
            this.buttonMax.Click += new System.EventHandler(this.buttonMax_Click);
            // 
            // strtProcess
            // 
            this.strtProcess.Location = new System.Drawing.Point(77, 129);
            this.strtProcess.Name = "strtProcess";
            this.strtProcess.Size = new System.Drawing.Size(130, 23);
            this.strtProcess.TabIndex = 2;
            this.strtProcess.Text = "Start Process";
            this.strtProcess.UseVisualStyleBackColor = true;
            this.strtProcess.Click += new System.EventHandler(this.strtProcess_Click);
            // 
            // saveFile
            // 
            this.saveFile.FileName = "Save Location";
            this.saveFile.Filter = "Text files|*.txt";
            this.saveFile.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFile_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.strtProcess);
            this.Controls.Add(this.buttonMax);
            this.Controls.Add(this.buttonColorMin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialogMin;
        private System.Windows.Forms.ColorDialog colorDialogMax;
        private System.Windows.Forms.Button buttonColorMin;
        private System.Windows.Forms.Button buttonMax;
        private System.Windows.Forms.Button strtProcess;
        private System.Windows.Forms.SaveFileDialog saveFile;
    }
}

