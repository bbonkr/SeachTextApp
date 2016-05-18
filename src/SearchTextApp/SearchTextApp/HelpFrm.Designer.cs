namespace SearchTextApp
{
    partial class HelpFrm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.closeButton = new System.Windows.Forms.Button();
            this.manualTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(275, 404);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 25);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "닫기";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // manualTextBox
            // 
            this.manualTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manualTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.manualTextBox.Location = new System.Drawing.Point(12, 12);
            this.manualTextBox.Name = "manualTextBox";
            this.manualTextBox.ReadOnly = true;
            this.manualTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.manualTextBox.Size = new System.Drawing.Size(600, 386);
            this.manualTextBox.TabIndex = 1;
            this.manualTextBox.Text = "";
            // 
            // HelpFrm
            // 
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.manualTextBox);
            this.Controls.Add(this.closeButton);
            this.Name = "HelpFrm";
            this.Text = "Help";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.RichTextBox manualTextBox;
    }
}
