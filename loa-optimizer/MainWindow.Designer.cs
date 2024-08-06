namespace loa_optimizer; 
partial class MainWindow {
  /// <summary>
  ///  Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  ///  Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing) {
    if(disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  ///  Required method for Designer support - do not modify
  ///  the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
    lostArkPathTextBox = new TextBox();
    label1 = new Label();
    lostArkPathButton = new Button();
    optimizationsGroupBox = new GroupBox();
    disableIntroVideoCheckBox = new CheckBox();
    optimizeButton = new Button();
    optimizationsGroupBox.SuspendLayout();
    SuspendLayout();
    // 
    // lostArkPathTextBox
    // 
    lostArkPathTextBox.Location = new Point(12, 27);
    lostArkPathTextBox.Name = "lostArkPathTextBox";
    lostArkPathTextBox.Size = new Size(312, 23);
    lostArkPathTextBox.TabIndex = 1;
    // 
    // label1
    // 
    label1.AutoSize = true;
    label1.Location = new Point(12, 9);
    label1.Name = "label1";
    label1.Size = new Size(103, 15);
    label1.TabIndex = 2;
    label1.Text = "Lost Ark directory:";
    // 
    // lostArkPathButton
    // 
    lostArkPathButton.Location = new Point(330, 27);
    lostArkPathButton.Name = "lostArkPathButton";
    lostArkPathButton.Size = new Size(32, 23);
    lostArkPathButton.TabIndex = 3;
    lostArkPathButton.Text = "...";
    lostArkPathButton.UseVisualStyleBackColor = true;
    lostArkPathButton.Click += lostArkPathButton_Click;
    // 
    // optimizationsGroupBox
    // 
    optimizationsGroupBox.Controls.Add(disableIntroVideoCheckBox);
    optimizationsGroupBox.Location = new Point(12, 56);
    optimizationsGroupBox.Name = "optimizationsGroupBox";
    optimizationsGroupBox.Size = new Size(350, 52);
    optimizationsGroupBox.TabIndex = 4;
    optimizationsGroupBox.TabStop = false;
    optimizationsGroupBox.Text = "  Optimizations  ";
    // 
    // disableIntroVideoCheckBox
    // 
    disableIntroVideoCheckBox.AutoSize = true;
    disableIntroVideoCheckBox.Location = new Point(10, 22);
    disableIntroVideoCheckBox.Name = "disableIntroVideoCheckBox";
    disableIntroVideoCheckBox.Size = new Size(125, 19);
    disableIntroVideoCheckBox.TabIndex = 0;
    disableIntroVideoCheckBox.Text = "Disable Intro Video";
    disableIntroVideoCheckBox.UseVisualStyleBackColor = true;
    // 
    // optimizeButton
    // 
    optimizeButton.Location = new Point(12, 114);
    optimizeButton.Name = "optimizeButton";
    optimizeButton.Size = new Size(350, 66);
    optimizeButton.TabIndex = 5;
    optimizeButton.Text = "Optimize";
    optimizeButton.UseVisualStyleBackColor = true;
    optimizeButton.Click += optimizeButton_Click;
    // 
    // MainWindow
    // 
    AutoScaleDimensions = new SizeF(7F, 15F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(370, 187);
    Controls.Add(optimizeButton);
    Controls.Add(optimizationsGroupBox);
    Controls.Add(lostArkPathButton);
    Controls.Add(label1);
    Controls.Add(lostArkPathTextBox);
    FormBorderStyle = FormBorderStyle.FixedSingle;
    MaximizeBox = false;
    Name = "MainWindow";
    StartPosition = FormStartPosition.CenterScreen;
    Text = "LOA Optimizer";
    optimizationsGroupBox.ResumeLayout(false);
    optimizationsGroupBox.PerformLayout();
    ResumeLayout(false);
    PerformLayout();
  }

  #endregion
  private TextBox lostArkPathTextBox;
  private Label label1;
  private Button lostArkPathButton;
  private GroupBox optimizationsGroupBox;
  private CheckBox disableIntroVideoCheckBox;
  private Button optimizeButton;
}
