using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCForge.World;
using MCForge.Core;
using System.IO;
using net.mcforge.API;
using net.mcforge.API.level;
using net.mcforge.world;

namespace MCForge.Gui.Dialogs {
    public partial class MapManagerDialog : Form, Listener {
        public MapManagerDialog() {
            InitializeComponent();
            Program.console.getServer().getEventSystem().registerEvents(this);
        }



        //---Level Event Handlers -------------------------------
        [EventHandler()]
        void OnAllLevelsLoad_Normal(LevelUnloadEvent eventargs) {
            if (lstUnloaded.Items.Contains(eventargs.getLevel().name))
                lstUnloaded.Items.Remove(eventargs.getLevel().name);

            int index = GetRowIndexFromLevel(eventargs.getLevel());
            if ( index == -1 ) {
                dtaLoaded.Rows.Add(GetRowDataFromLevel(eventargs.getLevel()));
            }
        }
        [EventHandler()]
        void OnAllLevelsUnload_Normal(LevelUnloadEvent eventargs) {
            if ( !lstUnloaded.Items.Contains(eventargs.getLevel().name) )
                lstUnloaded.Items.Add(eventargs.getLevel().name);

            int index = GetRowIndexFromLevel(eventargs.getLevel());
            if ( index != -1 ) {
                dtaLoaded.Rows.RemoveAt(index);
            } 
        }

        // --- End Level Event Handlers--------------------------


        private void MapManagerDialog_Load(object sender, EventArgs e) {
            lstUnloaded.Items.Clear();
            lstUnloaded.Items.AddRange(Program.console.getUnloadedLevelList().ToArray());

            dtaLoaded.ColumnCount = 4;
            dtaLoaded.Columns[0].Name = "Name";
            dtaLoaded.Columns[1].Name = "Size";
            dtaLoaded.Columns[2].Name = "Physics";
            dtaLoaded.Columns[3].Name = "Player Count";

            dtaLoaded.Columns.Add(new DataGridViewButtonColumn() {
                HeaderText = "Unload",
                Text = "O",
                UseColumnTextForButtonValue = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dtaLoaded.Columns.Add(new DataGridViewButtonColumn() {
                HeaderText = "Reload",
                Text = "O",
                UseColumnTextForButtonValue = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dtaLoaded.Columns.Add(new DataGridViewButtonColumn() {
                HeaderText = "Delete",
                Text = "O",
                UseColumnTextForButtonValue = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dtaLoaded.Rows.Clear();
            for ( int i = 0; i < Program.console.getServer().getLevelHandler().getLevelList().size(); i++ ) {
                dtaLoaded.Rows.Add(GetRowDataFromLevel((Level)Program.console.getServer().getLevelHandler().getLevelList().get(i)));
            }


        }

        #region Data Grid View Utils

        string[] GetRowDataFromLevel(Level level) {
            return new[] {level.name, string.Format("{0} x {1} x  {2}", level.width, level.height, level.depth), "True", Program.console.getPlayerCount(level).ToString() };
        }

        int GetRowIndexFromLevel(Level level) {
            return GetRowIndexFromLevelName(level.name);
        }

        int GetRowIndexFromLevelName(string name) {
            for ( int i = 0; i < dtaLoaded.Rows.Count; i++ ) {
                if(dtaLoaded.Rows[i].Cells[i].Value.ToString().Equals(name))
                    return i;
            }
            return -1;
        }

        #endregion


        private void dtaLoaded_CellClick(object sender, DataGridViewCellEventArgs e) {
            switch ( e.ColumnIndex ) {
                case 4: //Unload 
                    Program.console.getServer().getLevelHandler().findLevel(dtaLoaded.Rows[e.RowIndex].Cells[0].Value.ToString()).unload(Program.console.getServer(), true);
                break;

                case 5: //Reload
                string name = dtaLoaded.Rows[e.RowIndex].Cells[0].Value.ToString();
                Program.console.getServer().getLevelHandler().findLevel(name).unload(Program.console.getServer(), true);
                Program.console.getServer().getLevelHandler().loadLevel("levels/" + name + ".ggs");
                break;

                case 6: //Delete
                if ( MessageBox.Show("Are you sure you want to delete this level?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes ) {
                    string levelName = dtaLoaded.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Program.console.getServer().getLevelHandler().findLevel(levelName).unload(Program.console.getServer(), true);
                    File.Delete("levels/" + levelName + ".ggs");
                }
                break;

            }
        }

    }
}
