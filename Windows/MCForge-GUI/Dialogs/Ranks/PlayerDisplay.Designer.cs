namespace MCForge.Gui.Dialogs.Panels
{
    partial class PlayerDisplay
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
            this.lblManaging = new System.Windows.Forms.Label();
            this.gboxPlayers = new System.Windows.Forms.GroupBox();
            this.lstPlayers = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDerank = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPromote = new System.Windows.Forms.Button();
            this.btnBach = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gboxPlayers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblManaging
            // 
            this.lblManaging.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblManaging.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManaging.Location = new System.Drawing.Point(0, 0);
            this.lblManaging.Name = "lblManaging";
            this.lblManaging.Size = new System.Drawing.Size(576, 17);
            this.lblManaging.TabIndex = 1;
            this.lblManaging.Text = "Managing players for the loremipsum rank";
            this.lblManaging.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gboxPlayers
            // 
            this.gboxPlayers.Controls.Add(this.lstPlayers);
            this.gboxPlayers.Location = new System.Drawing.Point(3, 25);
            this.gboxPlayers.Name = "gboxPlayers";
            this.gboxPlayers.Size = new System.Drawing.Size(570, 160);
            this.gboxPlayers.TabIndex = 2;
            this.gboxPlayers.TabStop = false;
            this.gboxPlayers.Text = "Players with the loremipsum rank";
            // 
            // lstPlayers
            // 
            this.lstPlayers.HideSelection = false;
            this.lstPlayers.Location = new System.Drawing.Point(6, 19);
            this.lstPlayers.MultiSelect = false;
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(558, 135);
            this.lstPlayers.TabIndex = 0;
            this.lstPlayers.UseCompatibleStateImageBehavior = false;
            this.lstPlayers.View = System.Windows.Forms.View.List;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDerank);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnPromote);
            this.groupBox1.Location = new System.Drawing.Point(3, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 84);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // btnDerank
            // 
            this.btnDerank.Location = new System.Drawing.Point(103, 49);
            this.btnDerank.Name = "btnDerank";
            this.btnDerank.Size = new System.Drawing.Size(89, 23);
            this.btnDerank.TabIndex = 3;
            this.btnDerank.Text = "Derank player";
            this.toolTip.SetToolTip(this.btnDerank, "Sets the specified player\'s rank to the default rank");
            this.btnDerank.UseVisualStyleBackColor = true;
            this.btnDerank.Click += new System.EventHandler(this.derankPlayer);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 49);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Rank players";
            this.toolTip.SetToolTip(this.button4, "Ranks the specified player to this rank");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.rankPlayer);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(101, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Demote";
            this.toolTip.SetToolTip(this.button2, "Demotes the selected player to the lowest rank below");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.demotePlayer);
            // 
            // btnPromote
            // 
            this.btnPromote.Location = new System.Drawing.Point(8, 20);
            this.btnPromote.Name = "btnPromote";
            this.btnPromote.Size = new System.Drawing.Size(87, 23);
            this.btnPromote.TabIndex = 0;
            this.btnPromote.Text = "Promote";
            this.toolTip.SetToolTip(this.btnPromote, "Promotes the selected player to the next rank");
            this.btnPromote.UseVisualStyleBackColor = true;
            this.btnPromote.Click += new System.EventHandler(this.promotePlayer);
            // 
            // btnBach
            // 
            this.btnBach.Location = new System.Drawing.Point(498, 262);
            this.btnBach.Name = "btnBach";
            this.btnBach.Size = new System.Drawing.Size(75, 23);
            this.btnBach.TabIndex = 4;
            this.btnBach.Text = "Back";
            this.btnBach.UseVisualStyleBackColor = true;
            this.btnBach.Click += new System.EventHandler(this.goBach);
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
            // PlayerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBach);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxPlayers);
            this.Controls.Add(this.lblManaging);
            this.Name = "PlayerDisplay";
            this.Size = new System.Drawing.Size(576, 288);
            this.gboxPlayers.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblManaging;
        private System.Windows.Forms.GroupBox gboxPlayers;
        private System.Windows.Forms.ListView lstPlayers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPromote;
        private System.Windows.Forms.Button btnBach;
        private System.Windows.Forms.Button btnDerank;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip;

    }
}
