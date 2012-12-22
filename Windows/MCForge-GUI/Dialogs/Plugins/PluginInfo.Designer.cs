namespace MCForge.Gui.Dialogs.Plugins
{
    partial class PluginInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDev = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRestart = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblCur = new System.Windows.Forms.Label();
            this.lblLatest = new System.Windows.Forms.Label();
            this.lblSupportsUpdates = new System.Windows.Forms.Label();
            this.btnBach = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(389, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblVersion);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblDev);
            this.groupBox1.Location = new System.Drawing.Point(3, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 92);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic information";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(6, 68);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(98, 16);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "Plugin version: ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 16);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Plugin name: ";
            // 
            // lblDev
            // 
            this.lblDev.AutoSize = true;
            this.lblDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDev.Location = new System.Drawing.Point(6, 42);
            this.lblDev.Name = "lblDev";
            this.lblDev.Size = new System.Drawing.Size(116, 16);
            this.lblDev.TabIndex = 6;
            this.lblDev.Text = "Plugin developer: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRestart);
            this.groupBox2.Controls.Add(this.lblNotes);
            this.groupBox2.Controls.Add(this.lblType);
            this.groupBox2.Controls.Add(this.lblCur);
            this.groupBox2.Controls.Add(this.lblLatest);
            this.groupBox2.Controls.Add(this.lblSupportsUpdates);
            this.groupBox2.Location = new System.Drawing.Point(3, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 174);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update information";
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestart.Location = new System.Drawing.Point(6, 146);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(131, 16);
            this.lblRestart.TabIndex = 13;
            this.lblRestart.Text = "Restart after update: ";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(6, 120);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(132, 16);
            this.lblNotes.TabIndex = 12;
            this.lblNotes.Text = "Update notifications: ";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(6, 94);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(88, 16);
            this.lblType.TabIndex = 11;
            this.lblType.Text = "Update type: ";
            // 
            // lblCur
            // 
            this.lblCur.AutoSize = true;
            this.lblCur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCur.Location = new System.Drawing.Point(6, 42);
            this.lblCur.Name = "lblCur";
            this.lblCur.Size = new System.Drawing.Size(103, 16);
            this.lblCur.TabIndex = 10;
            this.lblCur.Text = "Current version: ";
            // 
            // lblLatest
            // 
            this.lblLatest.AutoSize = true;
            this.lblLatest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatest.Location = new System.Drawing.Point(6, 68);
            this.lblLatest.Name = "lblLatest";
            this.lblLatest.Size = new System.Drawing.Size(97, 16);
            this.lblLatest.TabIndex = 9;
            this.lblLatest.Text = "Latest version: ";
            // 
            // lblSupportsUpdates
            // 
            this.lblSupportsUpdates.AutoSize = true;
            this.lblSupportsUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupportsUpdates.Location = new System.Drawing.Point(6, 16);
            this.lblSupportsUpdates.Name = "lblSupportsUpdates";
            this.lblSupportsUpdates.Size = new System.Drawing.Size(212, 16);
            this.lblSupportsUpdates.TabIndex = 8;
            this.lblSupportsUpdates.Text = "Plugin (doesnt) support(s) updates";
            // 
            // btnBach
            // 
            this.btnBach.Location = new System.Drawing.Point(311, 435);
            this.btnBach.Name = "btnBach";
            this.btnBach.Size = new System.Drawing.Size(75, 23);
            this.btnBach.TabIndex = 9;
            this.btnBach.Text = "Back";
            this.btnBach.UseVisualStyleBackColor = true;
            this.btnBach.Click += new System.EventHandler(this.goBach);
            // 
            // PluginInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBach);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Name = "PluginInfo";
            this.Size = new System.Drawing.Size(389, 461);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSupportsUpdates;
        private System.Windows.Forms.Label lblLatest;
        private System.Windows.Forms.Label lblCur;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnBach;
        private System.Windows.Forms.Label lblRestart;
        private System.Windows.Forms.Label lblNotes;
    }
}
