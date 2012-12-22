namespace MCForge.Gui.Dialogs.Panels
{
    partial class RankEditor
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
            this.lblEditing = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPermission = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsOp = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReturnSave = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnColor = new MCForge.Gui.Components.ColorSelectionButton(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEditing
            // 
            this.lblEditing.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEditing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditing.Location = new System.Drawing.Point(0, 0);
            this.lblEditing.Name = "lblEditing";
            this.lblEditing.Size = new System.Drawing.Size(576, 17);
            this.lblEditing.TabIndex = 0;
            this.lblEditing.Text = "Currently editing loremipsumdolorsitamet";
            this.lblEditing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rank name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.changedItem);
            // 
            // txtPermission
            // 
            this.txtPermission.Location = new System.Drawing.Point(77, 47);
            this.txtPermission.Name = "txtPermission";
            this.txtPermission.Size = new System.Drawing.Size(100, 20);
            this.txtPermission.TabIndex = 4;
            this.txtPermission.TextChanged += new System.EventHandler(this.changedItem);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Permission:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Is operator:";
            // 
            // chkIsOp
            // 
            this.chkIsOp.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIsOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsOp.Location = new System.Drawing.Point(77, 73);
            this.chkIsOp.Name = "chkIsOp";
            this.chkIsOp.Size = new System.Drawing.Size(100, 20);
            this.chkIsOp.TabIndex = 6;
            this.chkIsOp.Text = "TRUE";
            this.chkIsOp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkIsOp.UseVisualStyleBackColor = true;
            this.chkIsOp.CheckedChanged += new System.EventHandler(this.changeCheckState);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Rank color:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnColor);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkIsOp);
            this.groupBox1.Controls.Add(this.txtPermission);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(23, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 133);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rank settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPlayers);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(23, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 85);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manage rank";
            // 
            // btnPlayers
            // 
            this.btnPlayers.Location = new System.Drawing.Point(9, 49);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(168, 22);
            this.btnPlayers.TabIndex = 1;
            this.btnPlayers.Text = "View/Edit ranked players";
            this.btnPlayers.UseVisualStyleBackColor = true;
            this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(9, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(168, 22);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete rank";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.deleteGroup);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(356, 258);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 22);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.saveProps);
            // 
            // btnReturnSave
            // 
            this.btnReturnSave.Location = new System.Drawing.Point(240, 258);
            this.btnReturnSave.Name = "btnReturnSave";
            this.btnReturnSave.Size = new System.Drawing.Size(110, 22);
            this.btnReturnSave.TabIndex = 34;
            this.btnReturnSave.Text = "Save and return";
            this.btnReturnSave.UseVisualStyleBackColor = true;
            this.btnReturnSave.Click += new System.EventHandler(this.saveAndReturn);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(437, 258);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(136, 22);
            this.btnReturn.TabIndex = 35;
            this.btnReturn.Text = "Return without saving";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnColor.Location = new System.Drawing.Point(77, 99);
            this.btnColor.Name = "btnColor";
            this.btnColor.Relation = null;
            this.btnColor.Size = new System.Drawing.Size(100, 20);
            this.btnColor.TabIndex = 30;
            this.btnColor.Text = "Purple";
            this.btnColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.changedItem);
            // 
            // RankEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnReturnSave);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEditing);
            this.Name = "RankEditor";
            this.Size = new System.Drawing.Size(576, 288);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEditing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPermission;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsOp;
        private System.Windows.Forms.Label label5;
        private Components.ColorSelectionButton btnColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPlayers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReturnSave;
        private System.Windows.Forms.Button btnReturn;
    }
}
