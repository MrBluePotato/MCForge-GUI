using System.Drawing;
using System.Windows.Forms;

namespace MCForge.Gui.Dialogs {
    /// <summary>
    /// Class used to make an input box to get input from the user
    /// Use the showDialog method to show the input box and collect input
    /// </summary>
    public partial class InputDialog : Form {
        public InputDialog() {
            InitializeComponent();
            this.ControlBox = false;
        }
        /// <summary>
        /// Shows an input dialog and returns the string the user typed
        /// </summary>
        /// <param name="title">The title of the input box</param>
        /// <param name="message">The message to show</param>
        /// <param name="buttonText">The text of the submit button</param>
        /// <returns></returns>
        public static string showDialog(string title, string message, string buttonText) {
            InputDialog i = new InputDialog();
            i.Text = title;
            i.messageLabel.Text = message;
            i.buttonSubmit.Text = buttonText;
            i.txtInput.MinimumSize = new Size(i.buttonSubmit.Location.X, 0);
            string result = null;
            i.buttonSubmit.Click += delegate {
                result = i.txtInput.Text;
                i.Close();
            };
            i.ShowDialog();
            return result;
        }
    }
}