namespace DataCollector
{
    partial class main
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
            this.consolelog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartCollect = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // consolelog
            // 
            this.consolelog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consolelog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.consolelog.Location = new System.Drawing.Point(0, 56);
            this.consolelog.Name = "consolelog";
            this.consolelog.Size = new System.Drawing.Size(673, 389);
            this.consolelog.TabIndex = 0;
            this.consolelog.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStartCollect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 50);
            this.panel1.TabIndex = 2;
            // 
            // btnStartCollect
            // 
            this.btnStartCollect.Location = new System.Drawing.Point(26, 14);
            this.btnStartCollect.Name = "btnStartCollect";
            this.btnStartCollect.Size = new System.Drawing.Size(75, 23);
            this.btnStartCollect.TabIndex = 2;
            this.btnStartCollect.Text = "开始采集";
            this.btnStartCollect.UseVisualStyleBackColor = true;
            this.btnStartCollect.Click += new System.EventHandler(this.btnStartCollect_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 445);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.consolelog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "main";
            this.Text = "画眉鸟数据采集平台";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox consolelog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStartCollect;
    }
}

