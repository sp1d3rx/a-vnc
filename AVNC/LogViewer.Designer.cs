namespace AVNC
{
    partial class LogViewer
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.detailsTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTB = new System.Windows.Forms.TextBox();
            this.ipTB = new System.Windows.Forms.TextBox();
            this.timeTB = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(263, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.detailsTB);
            this.groupBox2.Location = new System.Drawing.Point(12, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 249);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // detailsTB
            // 
            this.detailsTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsTB.Location = new System.Drawing.Point(6, 19);
            this.detailsTB.Multiline = true;
            this.detailsTB.Name = "detailsTB";
            this.detailsTB.ReadOnly = true;
            this.detailsTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.detailsTB.Size = new System.Drawing.Size(555, 207);
            this.detailsTB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time:";
            // 
            // titleTB
            // 
            this.titleTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTB.Location = new System.Drawing.Point(49, 6);
            this.titleTB.Name = "titleTB";
            this.titleTB.ReadOnly = true;
            this.titleTB.Size = new System.Drawing.Size(251, 13);
            this.titleTB.TabIndex = 6;
            // 
            // ipTB
            // 
            this.ipTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ipTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipTB.Location = new System.Drawing.Point(49, 22);
            this.ipTB.Name = "ipTB";
            this.ipTB.ReadOnly = true;
            this.ipTB.Size = new System.Drawing.Size(251, 13);
            this.ipTB.TabIndex = 7;
            // 
            // timeTB
            // 
            this.timeTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTB.Location = new System.Drawing.Point(49, 38);
            this.timeTB.Name = "timeTB";
            this.timeTB.ReadOnly = true;
            this.timeTB.Size = new System.Drawing.Size(251, 13);
            this.timeTB.TabIndex = 8;
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(591, 347);
            this.Controls.Add(this.timeTB);
            this.Controls.Add(this.ipTB);
            this.Controls.Add(this.titleTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LogViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log Details";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox detailsTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.TextBox ipTB;
        private System.Windows.Forms.TextBox timeTB;
    }
}