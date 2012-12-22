namespace MCForge.Gui.Dialogs.Ranks
{
    partial class RankManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnViewRanked = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddRank = new System.Windows.Forms.Button();
            this.btnEditProps = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ranksView = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPerms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ranksView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewRanked);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAddRank);
            this.groupBox2.Controls.Add(this.btnEditProps);
            this.groupBox2.Location = new System.Drawing.Point(417, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 134);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rank tools";
            // 
            // btnViewRanked
            // 
            this.btnViewRanked.Location = new System.Drawing.Point(6, 103);
            this.btnViewRanked.Name = "btnViewRanked";
            this.btnViewRanked.Size = new System.Drawing.Size(125, 23);
            this.btnViewRanked.TabIndex = 3;
            this.btnViewRanked.Text = "View ranked players";
            this.btnViewRanked.UseVisualStyleBackColor = true;
            this.btnViewRanked.Click += new System.EventHandler(this.viewRankedPlayers);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(6, 74);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(125, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove rank";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.removeRank);
            // 
            // btnAddRank
            // 
            this.btnAddRank.Location = new System.Drawing.Point(6, 45);
            this.btnAddRank.Name = "btnAddRank";
            this.btnAddRank.Size = new System.Drawing.Size(125, 23);
            this.btnAddRank.TabIndex = 1;
            this.btnAddRank.Text = "Add rank";
            this.btnAddRank.UseVisualStyleBackColor = true;
            this.btnAddRank.Click += new System.EventHandler(this.addRank);
            // 
            // btnEditProps
            // 
            this.btnEditProps.Location = new System.Drawing.Point(6, 16);
            this.btnEditProps.Name = "btnEditProps";
            this.btnEditProps.Size = new System.Drawing.Size(125, 23);
            this.btnEditProps.TabIndex = 0;
            this.btnEditProps.Text = "Edit rank properties";
            this.btnEditProps.UseVisualStyleBackColor = true;
            this.btnEditProps.Click += new System.EventHandler(this.editProperties);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ranksView);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 266);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server ranks";
            // 
            // ranksView
            // 
            this.ranksView.AllowUserToAddRows = false;
            this.ranksView.AllowUserToDeleteRows = false;
            this.ranksView.AllowUserToResizeColumns = false;
            this.ranksView.AllowUserToResizeRows = false;
            this.ranksView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ranksView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPerms,
            this.colIsOp,
            this.colColor});
            this.ranksView.Location = new System.Drawing.Point(6, 16);
            this.ranksView.MultiSelect = false;
            this.ranksView.Name = "ranksView";
            this.ranksView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ranksView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ranksView.Size = new System.Drawing.Size(385, 242);
            this.ranksView.TabIndex = 0;
            // 
            // colName
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colName.DefaultCellStyle = dataGridViewCellStyle4;
            this.colName.FillWeight = 125F;
            this.colName.Frozen = true;
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 125;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 125;
            // 
            // colPerms
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPerms.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPerms.FillWeight = 65F;
            this.colPerms.Frozen = true;
            this.colPerms.HeaderText = "Permission";
            this.colPerms.MinimumWidth = 65;
            this.colPerms.Name = "colPerms";
            this.colPerms.ReadOnly = true;
            this.colPerms.Width = 65;
            // 
            // colIsOp
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIsOp.DefaultCellStyle = dataGridViewCellStyle6;
            this.colIsOp.FillWeight = 60F;
            this.colIsOp.Frozen = true;
            this.colIsOp.HeaderText = "Is Op";
            this.colIsOp.MinimumWidth = 60;
            this.colIsOp.Name = "colIsOp";
            this.colIsOp.ReadOnly = true;
            this.colIsOp.Width = 60;
            // 
            // colColor
            // 
            this.colColor.FillWeight = 75F;
            this.colColor.Frozen = true;
            this.colColor.HeaderText = "Color";
            this.colColor.MinimumWidth = 75;
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            this.colColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colColor.Width = 75;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(423, 246);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(139, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit manager";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.exit);
            // 
            // RankManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RankManager";
            this.Size = new System.Drawing.Size(576, 288);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ranksView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnViewRanked;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddRank;
        private System.Windows.Forms.Button btnEditProps;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView ranksView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPerms;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.Button btnExit;
    }
}
