using loa_optimizer_core;
using System.Diagnostics;

namespace loa_optimizer;

public partial class MainWindow : Form {
  const int LOST_ARK_STEAM_ID = 1599340;
  const string LOST_ARK_STEAM_DIRECTORY = "Lost Ark";
  const string ORIGINAL_INTRO_FILE_NAME = "SGINTRO_WARNING_USA";


  public MainWindow() {
    InitializeComponent();

    {
      // TODO: Support KR, RU?
      var lostArkDir = SteamLocator.FindGamePath(LOST_ARK_STEAM_ID, LOST_ARK_STEAM_DIRECTORY);
      lostArkPathTextBox.Text = lostArkDir;
    }
  }

  private void lostArkPathButton_Click(object sender, EventArgs e) {
    var openFolderDialog = new FolderBrowserDialog();

    if(lostArkPathTextBox.Text != "") {
      openFolderDialog.SelectedPath = lostArkPathTextBox.Text;
    }

    var selectedFolder = openFolderDialog.ShowDialog(this);

    if(selectedFolder != DialogResult.OK) {
      return;
    }

    lostArkPathTextBox.Text = openFolderDialog.SelectedPath;
  }

  private void optimizeButton_Click(object sender, EventArgs e) {
    var processes = Process.GetProcessesByName("lostark");

    if(processes.Length > 0) {
      MessageBox.Show("Please exit Lost Ark before applying optimizations.", "Lost Ark is running!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
    }

    var optimizer = new Optimizer(lostArkPathTextBox.Text, loa_optimizer_core.Region.Global);
    optimizer.Optimize(disableIntroVideoCheckBox.Checked);

    MessageBox.Show("Optimizations should be now applied.", "Optimizations done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
  }
}
