using MCForge.Gui.Components;
using System.Windows.Forms;
namespace MCForge.Gui.Dialogs
{
    partial class UpdateServiceDialog
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
            this.components = new System.ComponentModel.Container();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.imageListBox1 = new MCForge.Gui.Components.ImageListBox();
            this.listbox1 = new MCForge.Gui.Components.ImageListBox();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Check for updates";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(216, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Install updates now";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(216, 137);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Queue update";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(216, 189);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Remove from Queue";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // images
            // 
            this.images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.images.ImageSize = new System.Drawing.Size(16, 16);
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListBox1
            // 
            this.imageListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imageListBox1.FormattingEnabled = true;
            this.imageListBox1.ImageList = this.images;
            this.imageListBox1.Items.AddRange(new object[] {
            "imagelistbox"});
            this.imageListBox1.Location = new System.Drawing.Point(2, 12);
            this.imageListBox1.Name = "imageListBox1";
            this.imageListBox1.Size = new System.Drawing.Size(208, 264);
            this.imageListBox1.TabIndex = 5;
            // 
            // listbox1
            // 
            this.listbox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listbox1.ImageList = null;
            this.listbox1.Location = new System.Drawing.Point(0, 0);
            this.listbox1.Name = "listbox1";
            this.listbox1.Size = new System.Drawing.Size(100, 95);
            this.listbox1.TabIndex = 0;
            // 
            // UpdateService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 286);
            this.Controls.Add(this.imageListBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "UpdateService";
            this.Text = "UpdateService";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateService_FormClosing);
            this.Load += new System.EventHandler(this.UpdateService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private ImageListBox listbox1;
        private System.Windows.Forms.Button button1;
        private ImageListBox imageListBox1;
        private ImageList images;
    }
}