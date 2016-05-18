namespace SearchTextApp
{
    partial class MainFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.addButton = new System.Windows.Forms.Button();
            this.RootDirectoriesListBox = new System.Windows.Forms.ListBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.filenameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.searchStringTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nestedSearchCheckBox = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.fileListGridView = new SearchTextApp.Controls.ListDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fileCountLabel = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFileWithTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.messageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.progressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileListGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(16, 24);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 25);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "추가";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // RootDirectoriesListBox
            // 
            this.RootDirectoriesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RootDirectoriesListBox.FormattingEnabled = true;
            this.RootDirectoriesListBox.ItemHeight = 17;
            this.RootDirectoriesListBox.Location = new System.Drawing.Point(16, 55);
            this.RootDirectoriesListBox.Name = "RootDirectoriesListBox";
            this.RootDirectoriesListBox.Size = new System.Drawing.Size(248, 123);
            this.RootDirectoriesListBox.TabIndex = 2;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(97, 24);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 25);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "제거";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RemoveButton);
            this.groupBox1.Controls.Add(this.RootDirectoriesListBox);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.groupBox1.Size = new System.Drawing.Size(280, 204);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색할 디렉터리";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.filenameTextBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.groupBox2.Size = new System.Drawing.Size(280, 60);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "파일 이름";
            // 
            // filenameTextBox
            // 
            this.filenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameTextBox.Location = new System.Drawing.Point(16, 24);
            this.filenameTextBox.Name = "filenameTextBox";
            this.filenameTextBox.Size = new System.Drawing.Size(248, 25);
            this.filenameTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.searchStringTextBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.groupBox3.Size = new System.Drawing.Size(280, 60);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "검색할 문자열";
            // 
            // searchStringTextBox
            // 
            this.searchStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchStringTextBox.Location = new System.Drawing.Point(16, 24);
            this.searchStringTextBox.Name = "searchStringTextBox";
            this.searchStringTextBox.Size = new System.Drawing.Size(248, 25);
            this.searchStringTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(189, 31);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 25);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "검색";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1MinSize = 280;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(612, 383);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nestedSearchCheckBox);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 324);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.panel1.Size = new System.Drawing.Size(280, 59);
            this.panel1.TabIndex = 6;
            // 
            // nestedSearchCheckBox
            // 
            this.nestedSearchCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nestedSearchCheckBox.AutoSize = true;
            this.nestedSearchCheckBox.Checked = true;
            this.nestedSearchCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nestedSearchCheckBox.Location = new System.Drawing.Point(109, 6);
            this.nestedSearchCheckBox.Name = "nestedSearchCheckBox";
            this.nestedSearchCheckBox.Size = new System.Drawing.Size(155, 21);
            this.nestedSearchCheckBox.TabIndex = 1;
            this.nestedSearchCheckBox.Text = "하위 디렉터리 검색여부";
            this.nestedSearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.fileListGridView);
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            this.splitContainer2.Panel1MinSize = 250;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.logTextBox);
            this.splitContainer2.Size = new System.Drawing.Size(327, 383);
            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 2;
            // 
            // fileListGridView
            // 
            this.fileListGridView.AllowUserToAddRows = false;
            this.fileListGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.fileListGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.fileListGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fileListGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.fileListGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft NeoGothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fileListGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.fileListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileListGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListGridView.EnableHeadersVisualStyles = false;
            this.fileListGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fileListGridView.Location = new System.Drawing.Point(0, 29);
            this.fileListGridView.MultiSelect = false;
            this.fileListGridView.Name = "fileListGridView";
            this.fileListGridView.ReadOnly = true;
            this.fileListGridView.RowHeadersVisible = false;
            this.fileListGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fileListGridView.Size = new System.Drawing.Size(327, 221);
            this.fileListGridView.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.fileCountLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 29);
            this.panel3.TabIndex = 1;
            // 
            // fileCountLabel
            // 
            this.fileCountLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.fileCountLabel.Location = new System.Drawing.Point(0, 0);
            this.fileCountLabel.Name = "fileCountLabel";
            this.fileCountLabel.Size = new System.Drawing.Size(110, 29);
            this.fileCountLabel.TabIndex = 0;
            this.fileCountLabel.Text = "검색된 파일: 0";
            this.fileCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logTextBox
            // 
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.Location = new System.Drawing.Point(0, 0);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(327, 129);
            this.logTextBox.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csvToolStripMenuItem,
            this.textFileWithTabToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // csvToolStripMenuItem
            // 
            this.csvToolStripMenuItem.Name = "csvToolStripMenuItem";
            this.csvToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.csvToolStripMenuItem.Text = "Csv";
            // 
            // textFileWithTabToolStripMenuItem
            // 
            this.textFileWithTabToolStripMenuItem.Name = "textFileWithTabToolStripMenuItem";
            this.textFileWithTabToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.textFileWithTabToolStripMenuItem.Text = "TextFile with Tab";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.consoleToolStripMenuItem.Text = "Console";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageLabel,
            this.searchProgress,
            this.progressLabel,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // messageLabel
            // 
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(31, 17);
            this.messageLabel.Text = "준비";
            // 
            // searchProgress
            // 
            this.searchProgress.Name = "searchProgress";
            this.searchProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // progressLabel
            // 
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(63, 17);
            this.progressLabel.Text = "(0/0) Hit: 0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6);
            this.panel2.Size = new System.Drawing.Size(624, 395);
            this.panel2.TabIndex = 9;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // MainFrm
            // 
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainFrm";
            this.Text = "문자열 검색";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileListGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox RootDirectoriesListBox;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox filenameTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox searchStringTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox nestedSearchCheckBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private Controls.ListDataGridView fileListGridView;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.ToolStripStatusLabel messageLabel;
        private System.Windows.Forms.ToolStripProgressBar searchProgress;
        private System.Windows.Forms.ToolStripStatusLabel progressLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem csvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFileWithTabToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label fileCountLabel;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}