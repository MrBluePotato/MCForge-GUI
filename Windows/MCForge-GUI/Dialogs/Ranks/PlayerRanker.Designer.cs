namespace MCForge.Gui.Dialogs.Panels
{
    partial class PlayerRanker
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnRank = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtPlayers = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDone);
            this.groupBox1.Controls.Add(this.btnRank);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtPlayers);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rank players";
            this.toolTip.SetToolTip(this.groupBox1, "To rank players, enter their names\r\nin the textbox, separating\r\neach name with a " +
        "new line");
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(199, 59);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(68, 23);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.removeControl);
            // 
            // btnRank
            // 
            this.btnRank.Location = new System.Drawing.Point(128, 15);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(139, 23);
            this.btnRank.TabIndex = 2;
            this.btnRank.Text = "Rank specified players";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.rankPlayers);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(128, 59);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(68, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear box";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.clearBox);
            // 
            // txtPlayers
            // 
            this.txtPlayers.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPlayers.Location = new System.Drawing.Point(3, 16);
            this.txtPlayers.Multiline = true;
            this.txtPlayers.Name = "txtPlayers";
            this.txtPlayers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlayers.Size = new System.Drawing.Size(123, 65);
            this.txtPlayers.TabIndex = 0;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 2500;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Information";
            // 
            // PlayerRanker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PlayerRanker";
            this.Size = new System.Drawing.Size(273, 84);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtPlayers;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
