using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCForge.Gui.Components;
using MCForge.Gui.WindowsAPI;

namespace MCForge.Gui.Dialogs {
    public partial class TextOnlyDialog : AeroForm {

        [Browsable(true)]
        [Category("MCForge")]
        [DefaultValue("MCForge TextOnlyDialog")]
        public string ContentText { get; set; }

        public TextOnlyDialog(string Text) {
            InitializeComponent();
            this.ContentText = Text;
        }

        public TextOnlyDialog() :
            this(string.Empty) { }

        private void TextOnlyDialog_Load(object sender, EventArgs e) {

            if (AeroAPI.CanUseAero)
            {

                this.GlassArea = new Rectangle {
                    Location = textBox1.Location,
                    Width = textBox1.Location.X,
                    Height = textBox1.Location.Y + 30
                };
                this.button1.Visible = false;
                Invalidate();
            }
            else {
                textBox1.BackColor = BackColor;
                textBox1.Padding = new Padding();
                this.aeroButton1.Visible = false;
            }

            ContentText = ContentText.Replace("\n", "\r\n");
            textBox1.Text = ContentText;
            textBox1.Multiline = true;
            textBox1.ReadOnly = true;
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (!AeroAPI.CanUseAero) {
                base.OnPaint(e);
                return;
            }
            e.Graphics.Clear(Color.Black);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aeroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
