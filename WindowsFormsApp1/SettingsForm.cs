using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();
            alwaysOnTopChkBox.Checked = Properties.Settings.Default.alwaysOnTop;
            darkModeChkBox.Checked = Properties.Settings.Default.darkMode;
            confirmDialogChkBox.Checked = Properties.Settings.Default.showConfirmationOnFinish;
        }

        private void defaultBtn_Click(object sender, EventArgs e) {
            Properties.Settings.Default.alwaysOnTop = false;
            Properties.Settings.Default.darkMode = false;
            Properties.Settings.Default.showConfirmationOnFinish = true;
            this.Owner.TopMost = Properties.Settings.Default.alwaysOnTop;
            Properties.Settings.Default.Save();
            alwaysOnTopChkBox.Checked = Properties.Settings.Default.alwaysOnTop;
            darkModeChkBox.Checked = Properties.Settings.Default.darkMode;
            confirmDialogChkBox.Checked = Properties.Settings.Default.showConfirmationOnFinish;
        }

        private void finishBtn_Click(object sender, EventArgs e) {
            Properties.Settings.Default.alwaysOnTop = alwaysOnTopChkBox.Checked;
            Properties.Settings.Default.darkMode = darkModeChkBox.Checked;
            Properties.Settings.Default.showConfirmationOnFinish = confirmDialogChkBox.Checked;
            this.Owner.TopMost = Properties.Settings.Default.alwaysOnTop;
            Properties.Settings.Default.Save();
        }
    }
}