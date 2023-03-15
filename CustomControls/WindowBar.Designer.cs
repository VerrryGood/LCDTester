
namespace CustomControls
{
    partial class WindowBar
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLayout = new System.Windows.Forms.TableLayoutPanel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.windowBarTitle = new CustomControls.AntiAliasingLabel();
            this.btnLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLayout
            // 
            this.btnLayout.ColumnCount = 2;
            this.btnLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.btnLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.btnLayout.Controls.Add(this.closeBtn, 1, 0);
            this.btnLayout.Controls.Add(this.minimizeBtn, 0, 0);
            this.btnLayout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLayout.Location = new System.Drawing.Point(590, 0);
            this.btnLayout.Name = "btnLayout";
            this.btnLayout.RowCount = 1;
            this.btnLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.btnLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.btnLayout.Size = new System.Drawing.Size(90, 33);
            this.btnLayout.TabIndex = 0;
            // 
            // closeBtn
            // 
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.closeBtn.Location = new System.Drawing.Point(45, 0);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(45, 33);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.TabStop = false;
            this.closeBtn.Text = "Ⅹ";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseLeave += new System.EventHandler(this.closeBtn_MouseLeave);
            this.closeBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.closeBtn_MouseMove);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.minimizeBtn.Location = new System.Drawing.Point(0, 0);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(45, 33);
            this.minimizeBtn.TabIndex = 0;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Text = "─";
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // iconBox
            // 
            this.iconBox.Location = new System.Drawing.Point(8, 6);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(20, 20);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 2;
            this.iconBox.TabStop = false;
            // 
            // windowBarTitle
            // 
            this.windowBarTitle.Alignment = System.Drawing.StringAlignment.Near;
            this.windowBarTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.windowBarTitle.AutoSize = true;
            this.windowBarTitle.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.windowBarTitle.LineAlignment = System.Drawing.StringAlignment.Near;
            this.windowBarTitle.Location = new System.Drawing.Point(34, 6);
            this.windowBarTitle.Name = "windowBarTitle";
            this.windowBarTitle.Size = new System.Drawing.Size(0, 20);
            this.windowBarTitle.TabIndex = 1;
            this.windowBarTitle.TextChanged += new System.EventHandler(this.windowBarTitle_TextChanged);
            // 
            // WindowBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.iconBox);
            this.Controls.Add(this.windowBarTitle);
            this.Controls.Add(this.btnLayout);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "WindowBar";
            this.Size = new System.Drawing.Size(680, 33);
            this.SizeChanged += new System.EventHandler(this.WindowBar_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowBar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowBar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowBar_MouseUp);
            this.ParentChanged += new System.EventHandler(this.WindowBar_ParentChanged);
            this.btnLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        public AntiAliasingLabel windowBarTitle;
        private System.Windows.Forms.PictureBox iconBox;
        public System.Windows.Forms.TableLayoutPanel btnLayout;
    }
}
