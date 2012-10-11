using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using net.mcforge.world;

namespace MCForge.Gui.Components {
    public partial class MapBrowser :  DataGridView {

        public Level SelectedLeve {get; set;}

        public MapBrowser() {
            InitializeComponent();
        }

        public void AddMap( Level level ) {

        }

        public void RemoveLevel( int index ) {

        }
    }
}