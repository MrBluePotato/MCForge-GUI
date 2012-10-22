using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MCForge.Gui.Dialogs;
using MCForge.Gui.WindowsAPI.Utils;

namespace MCForge.Gui.Components {
    public partial class ColorSelectionButton : Button {

        private ColorRelation _relation;
        public delegate void RelationChanged();
        public event RelationChanged OnColorRelationChanged;

        [Browsable( false )]
        public ColorRelation Relation {
            get { return _relation; }
            set {
                _relation = value;

                if ( value != null ) {
                    Text = value.Text;
                    ForeColor = value.TextColor;
                    BackColor = value.BackColor;
                }
            }
        }



        public ColorSelectionButton() {
            InitializeComponent();
        }

        public ColorSelectionButton( IContainer container ) {
            container.Add( this );
            InitializeComponent();
        }

        private void ColorSelection_Click( object sender, System.EventArgs e ) {
            using ( var colorDialog = new ColorSelectionDialog( Relation ) ) {
                colorDialog.FormClosing += new FormClosingEventHandler( colorDialog_FormClosing );
                colorDialog.ShowDialog();
            }
        }

        void colorDialog_FormClosing( object sender, FormClosingEventArgs e ) {
            ColorSelectionDialog dialog = sender as ColorSelectionDialog;
            if ( dialog == null )
                return;

            if ( dialog.DialogResult == System.Windows.Forms.DialogResult.Cancel )
                return;

            Relation = dialog.Relation;
            if (OnColorRelationChanged != null)
                OnColorRelationChanged();
        }

    }
}
