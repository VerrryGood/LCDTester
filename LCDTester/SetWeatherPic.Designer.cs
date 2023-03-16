
namespace LCDTester
{
    partial class SetWeatherPic
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetWeatherPic));
            this.windowBarPanel = new System.Windows.Forms.Panel();
            this.backgroundLayout = new System.Windows.Forms.TableLayoutPanel();
            this.previewGB = new System.Windows.Forms.GroupBox();
            this.previewPic = new System.Windows.Forms.PictureBox();
            this.picLinePanel = new System.Windows.Forms.Panel();
            this.picView = new System.Windows.Forms.ListView();
            this.applyPic = new System.Windows.Forms.Button();
            this.weatherPicList = new System.Windows.Forms.ImageList(this.components);
            this.backgroundLayout.SuspendLayout();
            this.previewGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPic)).BeginInit();
            this.picLinePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowBarPanel
            // 
            this.windowBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(158)))), ((int)(((byte)(254)))));
            this.windowBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowBarPanel.Location = new System.Drawing.Point(0, 0);
            this.windowBarPanel.Name = "windowBarPanel";
            this.windowBarPanel.Size = new System.Drawing.Size(770, 35);
            this.windowBarPanel.TabIndex = 0;
            // 
            // backgroundLayout
            // 
            this.backgroundLayout.ColumnCount = 2;
            this.backgroundLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.backgroundLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.backgroundLayout.Controls.Add(this.previewGB, 1, 0);
            this.backgroundLayout.Controls.Add(this.picLinePanel, 0, 0);
            this.backgroundLayout.Controls.Add(this.applyPic, 1, 2);
            this.backgroundLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundLayout.Location = new System.Drawing.Point(0, 35);
            this.backgroundLayout.Name = "backgroundLayout";
            this.backgroundLayout.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.backgroundLayout.RowCount = 3;
            this.backgroundLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.backgroundLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.backgroundLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.backgroundLayout.Size = new System.Drawing.Size(770, 574);
            this.backgroundLayout.TabIndex = 1;
            // 
            // previewGB
            // 
            this.previewGB.Controls.Add(this.previewPic);
            this.previewGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewGB.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.previewGB.Location = new System.Drawing.Point(565, 6);
            this.previewGB.Name = "previewGB";
            this.previewGB.Size = new System.Drawing.Size(194, 174);
            this.previewGB.TabIndex = 0;
            this.previewGB.TabStop = false;
            this.previewGB.Text = "미리보기";
            // 
            // previewPic
            // 
            this.previewPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPic.Location = new System.Drawing.Point(3, 25);
            this.previewPic.Name = "previewPic";
            this.previewPic.Size = new System.Drawing.Size(188, 146);
            this.previewPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPic.TabIndex = 0;
            this.previewPic.TabStop = false;
            // 
            // picLinePanel
            // 
            this.picLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(158)))), ((int)(((byte)(254)))));
            this.picLinePanel.Controls.Add(this.picView);
            this.picLinePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLinePanel.Location = new System.Drawing.Point(11, 11);
            this.picLinePanel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 3);
            this.picLinePanel.Name = "picLinePanel";
            this.picLinePanel.Padding = new System.Windows.Forms.Padding(1);
            this.backgroundLayout.SetRowSpan(this.picLinePanel, 3);
            this.picLinePanel.Size = new System.Drawing.Size(543, 552);
            this.picLinePanel.TabIndex = 1;
            // 
            // picView
            // 
            this.picView.BackColor = System.Drawing.Color.White;
            this.picView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.picView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picView.HideSelection = false;
            this.picView.Location = new System.Drawing.Point(1, 1);
            this.picView.Margin = new System.Windows.Forms.Padding(0);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(541, 550);
            this.picView.TabIndex = 0;
            this.picView.UseCompatibleStateImageBehavior = false;
            this.picView.SelectedIndexChanged += new System.EventHandler(this.picView_SelectedIndexChanged);
            // 
            // applyPic
            // 
            this.applyPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(158)))), ((int)(((byte)(254)))));
            this.applyPic.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyPic.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.applyPic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.applyPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyPic.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.applyPic.ForeColor = System.Drawing.Color.White;
            this.applyPic.Location = new System.Drawing.Point(565, 469);
            this.applyPic.Name = "applyPic";
            this.applyPic.Size = new System.Drawing.Size(194, 94);
            this.applyPic.TabIndex = 2;
            this.applyPic.Text = "적 용";
            this.applyPic.UseVisualStyleBackColor = false;
            this.applyPic.Click += new System.EventHandler(this.applyPic_Click);
            // 
            // weatherPicList
            // 
            this.weatherPicList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("weatherPicList.ImageStream")));
            this.weatherPicList.TransparentColor = System.Drawing.Color.Transparent;
            this.weatherPicList.Images.SetKeyName(0, "w_01.png");
            this.weatherPicList.Images.SetKeyName(1, "w_02.png");
            this.weatherPicList.Images.SetKeyName(2, "w_03.png");
            this.weatherPicList.Images.SetKeyName(3, "w_04.png");
            this.weatherPicList.Images.SetKeyName(4, "w_05.png");
            this.weatherPicList.Images.SetKeyName(5, "w_06.png");
            this.weatherPicList.Images.SetKeyName(6, "w_07.png");
            this.weatherPicList.Images.SetKeyName(7, "w_08.png");
            this.weatherPicList.Images.SetKeyName(8, "w_09.png");
            this.weatherPicList.Images.SetKeyName(9, "w_10.png");
            this.weatherPicList.Images.SetKeyName(10, "w_11.png");
            this.weatherPicList.Images.SetKeyName(11, "w_12.png");
            this.weatherPicList.Images.SetKeyName(12, "w_13.png");
            this.weatherPicList.Images.SetKeyName(13, "w_14.png");
            this.weatherPicList.Images.SetKeyName(14, "w_15.png");
            this.weatherPicList.Images.SetKeyName(15, "w_16.png");
            this.weatherPicList.Images.SetKeyName(16, "w_17.png");
            this.weatherPicList.Images.SetKeyName(17, "w_18.png");
            this.weatherPicList.Images.SetKeyName(18, "w_19.png");
            this.weatherPicList.Images.SetKeyName(19, "w_20.png");
            this.weatherPicList.Images.SetKeyName(20, "w_21.png");
            this.weatherPicList.Images.SetKeyName(21, "w_22.png");
            this.weatherPicList.Images.SetKeyName(22, "w_23.png");
            this.weatherPicList.Images.SetKeyName(23, "w_24.png");
            this.weatherPicList.Images.SetKeyName(24, "w_25.png");
            this.weatherPicList.Images.SetKeyName(25, "w_26.png");
            this.weatherPicList.Images.SetKeyName(26, "w_27.png");
            this.weatherPicList.Images.SetKeyName(27, "w_28.png");
            this.weatherPicList.Images.SetKeyName(28, "w_29.png");
            this.weatherPicList.Images.SetKeyName(29, "w_30.png");
            this.weatherPicList.Images.SetKeyName(30, "w_31.png");
            this.weatherPicList.Images.SetKeyName(31, "w_32.png");
            this.weatherPicList.Images.SetKeyName(32, "w_33.png");
            this.weatherPicList.Images.SetKeyName(33, "w_34.png");
            this.weatherPicList.Images.SetKeyName(34, "w_35.png");
            this.weatherPicList.Images.SetKeyName(35, "w_36.png");
            this.weatherPicList.Images.SetKeyName(36, "w_37.png");
            this.weatherPicList.Images.SetKeyName(37, "w_38.png");
            this.weatherPicList.Images.SetKeyName(38, "w_39.png");
            this.weatherPicList.Images.SetKeyName(39, "w_40.png");
            // 
            // SetWeatherPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 609);
            this.Controls.Add(this.backgroundLayout);
            this.Controls.Add(this.windowBarPanel);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SetWeatherPic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "날씨 그림 변경";
            this.Load += new System.EventHandler(this.SetWeatherPic_Load);
            this.backgroundLayout.ResumeLayout(false);
            this.previewGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewPic)).EndInit();
            this.picLinePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel windowBarPanel;
        private System.Windows.Forms.TableLayoutPanel backgroundLayout;
        private System.Windows.Forms.GroupBox previewGB;
        private System.Windows.Forms.PictureBox previewPic;
        private System.Windows.Forms.Panel picLinePanel;
        private System.Windows.Forms.ListView picView;
        private System.Windows.Forms.Button applyPic;
        private System.Windows.Forms.ImageList weatherPicList;
    }
}