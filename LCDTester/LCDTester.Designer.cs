
namespace LCDTester
{
    partial class LCDTester
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
            this.windowBarPanel = new System.Windows.Forms.Panel();
            this.ipBackgroundLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ipLinePanel = new System.Windows.Forms.Panel();
            this.ipLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ipText1 = new System.Windows.Forms.TextBox();
            this.ipText2 = new System.Windows.Forms.TextBox();
            this.ipText3 = new System.Windows.Forms.TextBox();
            this.ipText4 = new System.Windows.Forms.TextBox();
            this.ipTitle = new System.Windows.Forms.Label();
            this.ipSet = new System.Windows.Forms.Button();
            this.testerOnOff = new System.Windows.Forms.Button();
            this.floorBackgroundLayout = new System.Windows.Forms.TableLayoutPanel();
            this.floorBtnLayout = new System.Windows.Forms.TableLayoutPanel();
            this.twelfthFloor = new System.Windows.Forms.Button();
            this.eleventhFloor = new System.Windows.Forms.Button();
            this.tenthFloor = new System.Windows.Forms.Button();
            this.ninthFloor = new System.Windows.Forms.Button();
            this.eighthFloor = new System.Windows.Forms.Button();
            this.seventhFloor = new System.Windows.Forms.Button();
            this.sixthFloor = new System.Windows.Forms.Button();
            this.fifthFloor = new System.Windows.Forms.Button();
            this.fourthFloor = new System.Windows.Forms.Button();
            this.thirdFloor = new System.Windows.Forms.Button();
            this.secondFloor = new System.Windows.Forms.Button();
            this.firstFloor = new System.Windows.Forms.Button();
            this.base1stFloor = new System.Windows.Forms.Button();
            this.base2ndFloor = new System.Windows.Forms.Button();
            this.base3rdFloor = new System.Windows.Forms.Button();
            this.ipBackgroundLayout.SuspendLayout();
            this.ipLinePanel.SuspendLayout();
            this.ipLayout.SuspendLayout();
            this.floorBackgroundLayout.SuspendLayout();
            this.floorBtnLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowBarPanel
            // 
            this.windowBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(158)))), ((int)(((byte)(254)))));
            this.windowBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowBarPanel.Location = new System.Drawing.Point(0, 0);
            this.windowBarPanel.Name = "windowBarPanel";
            this.windowBarPanel.Size = new System.Drawing.Size(800, 35);
            this.windowBarPanel.TabIndex = 0;
            // 
            // ipBackgroundLayout
            // 
            this.ipBackgroundLayout.ColumnCount = 3;
            this.ipBackgroundLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.ipBackgroundLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ipBackgroundLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.ipBackgroundLayout.Controls.Add(this.ipLinePanel, 0, 0);
            this.ipBackgroundLayout.Controls.Add(this.testerOnOff, 2, 0);
            this.ipBackgroundLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.ipBackgroundLayout.Location = new System.Drawing.Point(0, 35);
            this.ipBackgroundLayout.Name = "ipBackgroundLayout";
            this.ipBackgroundLayout.RowCount = 1;
            this.ipBackgroundLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ipBackgroundLayout.Size = new System.Drawing.Size(800, 80);
            this.ipBackgroundLayout.TabIndex = 1;
            // 
            // ipLinePanel
            // 
            this.ipLinePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(158)))), ((int)(((byte)(254)))));
            this.ipLinePanel.Controls.Add(this.ipLayout);
            this.ipLinePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipLinePanel.Location = new System.Drawing.Point(13, 13);
            this.ipLinePanel.Margin = new System.Windows.Forms.Padding(13, 13, 5, 13);
            this.ipLinePanel.Name = "ipLinePanel";
            this.ipLinePanel.Padding = new System.Windows.Forms.Padding(1);
            this.ipLinePanel.Size = new System.Drawing.Size(482, 54);
            this.ipLinePanel.TabIndex = 0;
            // 
            // ipLayout
            // 
            this.ipLayout.BackColor = System.Drawing.SystemColors.Control;
            this.ipLayout.ColumnCount = 9;
            this.ipLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.ipLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ipLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ipLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ipLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ipLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ipLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ipLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ipLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.ipLayout.Controls.Add(this.label3, 6, 0);
            this.ipLayout.Controls.Add(this.label2, 4, 0);
            this.ipLayout.Controls.Add(this.label1, 2, 0);
            this.ipLayout.Controls.Add(this.ipText1, 1, 0);
            this.ipLayout.Controls.Add(this.ipText2, 3, 0);
            this.ipLayout.Controls.Add(this.ipText3, 5, 0);
            this.ipLayout.Controls.Add(this.ipText4, 7, 0);
            this.ipLayout.Controls.Add(this.ipTitle, 0, 0);
            this.ipLayout.Controls.Add(this.ipSet, 8, 0);
            this.ipLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipLayout.Location = new System.Drawing.Point(1, 1);
            this.ipLayout.Name = "ipLayout";
            this.ipLayout.RowCount = 1;
            this.ipLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ipLayout.Size = new System.Drawing.Size(480, 52);
            this.ipLayout.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(319, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = ".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(237, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = ".";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(155, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = ".";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ipText1
            // 
            this.ipText1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipText1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ipText1.Location = new System.Drawing.Point(93, 11);
            this.ipText1.Name = "ipText1";
            this.ipText1.Size = new System.Drawing.Size(56, 29);
            this.ipText1.TabIndex = 0;
            this.ipText1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeIP);
            // 
            // ipText2
            // 
            this.ipText2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipText2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ipText2.Location = new System.Drawing.Point(175, 11);
            this.ipText2.Name = "ipText2";
            this.ipText2.Size = new System.Drawing.Size(56, 29);
            this.ipText2.TabIndex = 1;
            this.ipText2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeIP);
            // 
            // ipText3
            // 
            this.ipText3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipText3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ipText3.Location = new System.Drawing.Point(257, 11);
            this.ipText3.Name = "ipText3";
            this.ipText3.Size = new System.Drawing.Size(56, 29);
            this.ipText3.TabIndex = 2;
            this.ipText3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeIP);
            // 
            // ipText4
            // 
            this.ipText4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipText4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ipText4.Location = new System.Drawing.Point(339, 11);
            this.ipText4.Name = "ipText4";
            this.ipText4.Size = new System.Drawing.Size(56, 29);
            this.ipText4.TabIndex = 3;
            this.ipText4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeIP);
            // 
            // ipTitle
            // 
            this.ipTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ipTitle.AutoSize = true;
            this.ipTitle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ipTitle.Location = new System.Drawing.Point(3, 15);
            this.ipTitle.Name = "ipTitle";
            this.ipTitle.Size = new System.Drawing.Size(84, 21);
            this.ipTitle.TabIndex = 4;
            this.ipTitle.Text = "IP 주소";
            this.ipTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ipSet
            // 
            this.ipSet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ipSet.Location = new System.Drawing.Point(401, 8);
            this.ipSet.Name = "ipSet";
            this.ipSet.Size = new System.Drawing.Size(75, 35);
            this.ipSet.TabIndex = 5;
            this.ipSet.Text = "변경";
            this.ipSet.UseVisualStyleBackColor = true;
            this.ipSet.Click += new System.EventHandler(this.ipSet_Click);
            // 
            // testerOnOff
            // 
            this.testerOnOff.BackColor = System.Drawing.Color.Gray;
            this.testerOnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testerOnOff.FlatAppearance.BorderSize = 0;
            this.testerOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testerOnOff.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.testerOnOff.ForeColor = System.Drawing.Color.White;
            this.testerOnOff.Location = new System.Drawing.Point(635, 5);
            this.testerOnOff.Margin = new System.Windows.Forms.Padding(5);
            this.testerOnOff.Name = "testerOnOff";
            this.testerOnOff.Size = new System.Drawing.Size(160, 70);
            this.testerOnOff.TabIndex = 1;
            this.testerOnOff.TabStop = false;
            this.testerOnOff.Text = "서버 시작";
            this.testerOnOff.UseVisualStyleBackColor = false;
            // 
            // floorBackgroundLayout
            // 
            this.floorBackgroundLayout.ColumnCount = 2;
            this.floorBackgroundLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.floorBackgroundLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.floorBackgroundLayout.Controls.Add(this.floorBtnLayout, 0, 0);
            this.floorBackgroundLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.floorBackgroundLayout.Location = new System.Drawing.Point(0, 115);
            this.floorBackgroundLayout.Name = "floorBackgroundLayout";
            this.floorBackgroundLayout.RowCount = 1;
            this.floorBackgroundLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.floorBackgroundLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.floorBackgroundLayout.Size = new System.Drawing.Size(800, 343);
            this.floorBackgroundLayout.TabIndex = 2;
            // 
            // floorBtnLayout
            // 
            this.floorBtnLayout.ColumnCount = 5;
            this.floorBtnLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.floorBtnLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.floorBtnLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.floorBtnLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.floorBtnLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.floorBtnLayout.Controls.Add(this.twelfthFloor, 4, 2);
            this.floorBtnLayout.Controls.Add(this.eleventhFloor, 3, 2);
            this.floorBtnLayout.Controls.Add(this.tenthFloor, 2, 2);
            this.floorBtnLayout.Controls.Add(this.ninthFloor, 1, 2);
            this.floorBtnLayout.Controls.Add(this.eighthFloor, 0, 2);
            this.floorBtnLayout.Controls.Add(this.seventhFloor, 4, 1);
            this.floorBtnLayout.Controls.Add(this.sixthFloor, 3, 1);
            this.floorBtnLayout.Controls.Add(this.fifthFloor, 2, 1);
            this.floorBtnLayout.Controls.Add(this.fourthFloor, 1, 1);
            this.floorBtnLayout.Controls.Add(this.thirdFloor, 0, 1);
            this.floorBtnLayout.Controls.Add(this.secondFloor, 4, 0);
            this.floorBtnLayout.Controls.Add(this.firstFloor, 3, 0);
            this.floorBtnLayout.Controls.Add(this.base1stFloor, 2, 0);
            this.floorBtnLayout.Controls.Add(this.base2ndFloor, 1, 0);
            this.floorBtnLayout.Controls.Add(this.base3rdFloor, 0, 0);
            this.floorBtnLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floorBtnLayout.Location = new System.Drawing.Point(3, 3);
            this.floorBtnLayout.Name = "floorBtnLayout";
            this.floorBtnLayout.Padding = new System.Windows.Forms.Padding(1);
            this.floorBtnLayout.RowCount = 3;
            this.floorBtnLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.floorBtnLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.floorBtnLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.floorBtnLayout.Size = new System.Drawing.Size(624, 337);
            this.floorBtnLayout.TabIndex = 0;
            // 
            // twelfthFloor
            // 
            this.twelfthFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.twelfthFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.twelfthFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twelfthFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.twelfthFloor.Location = new System.Drawing.Point(500, 226);
            this.twelfthFloor.Name = "twelfthFloor";
            this.twelfthFloor.Size = new System.Drawing.Size(118, 105);
            this.twelfthFloor.TabIndex = 14;
            this.twelfthFloor.TabStop = false;
            this.twelfthFloor.Text = "12F";
            this.twelfthFloor.UseVisualStyleBackColor = true;
            this.twelfthFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // eleventhFloor
            // 
            this.eleventhFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.eleventhFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.eleventhFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eleventhFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.eleventhFloor.Location = new System.Drawing.Point(376, 226);
            this.eleventhFloor.Name = "eleventhFloor";
            this.eleventhFloor.Size = new System.Drawing.Size(118, 105);
            this.eleventhFloor.TabIndex = 13;
            this.eleventhFloor.TabStop = false;
            this.eleventhFloor.Text = "11F";
            this.eleventhFloor.UseVisualStyleBackColor = true;
            this.eleventhFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // tenthFloor
            // 
            this.tenthFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.tenthFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.tenthFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tenthFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tenthFloor.Location = new System.Drawing.Point(252, 226);
            this.tenthFloor.Name = "tenthFloor";
            this.tenthFloor.Size = new System.Drawing.Size(118, 105);
            this.tenthFloor.TabIndex = 12;
            this.tenthFloor.TabStop = false;
            this.tenthFloor.Text = "10F";
            this.tenthFloor.UseVisualStyleBackColor = true;
            this.tenthFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // ninthFloor
            // 
            this.ninthFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.ninthFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.ninthFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ninthFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ninthFloor.Location = new System.Drawing.Point(128, 226);
            this.ninthFloor.Name = "ninthFloor";
            this.ninthFloor.Size = new System.Drawing.Size(118, 105);
            this.ninthFloor.TabIndex = 11;
            this.ninthFloor.TabStop = false;
            this.ninthFloor.Text = "9F";
            this.ninthFloor.UseVisualStyleBackColor = true;
            this.ninthFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // eighthFloor
            // 
            this.eighthFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.eighthFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.eighthFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eighthFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.eighthFloor.Location = new System.Drawing.Point(4, 226);
            this.eighthFloor.Name = "eighthFloor";
            this.eighthFloor.Size = new System.Drawing.Size(118, 105);
            this.eighthFloor.TabIndex = 10;
            this.eighthFloor.TabStop = false;
            this.eighthFloor.Text = "8F";
            this.eighthFloor.UseVisualStyleBackColor = true;
            this.eighthFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // seventhFloor
            // 
            this.seventhFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.seventhFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.seventhFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seventhFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.seventhFloor.Location = new System.Drawing.Point(500, 115);
            this.seventhFloor.Name = "seventhFloor";
            this.seventhFloor.Size = new System.Drawing.Size(118, 105);
            this.seventhFloor.TabIndex = 9;
            this.seventhFloor.TabStop = false;
            this.seventhFloor.Text = "7F";
            this.seventhFloor.UseVisualStyleBackColor = true;
            this.seventhFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // sixthFloor
            // 
            this.sixthFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.sixthFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.sixthFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sixthFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sixthFloor.Location = new System.Drawing.Point(376, 115);
            this.sixthFloor.Name = "sixthFloor";
            this.sixthFloor.Size = new System.Drawing.Size(118, 105);
            this.sixthFloor.TabIndex = 8;
            this.sixthFloor.TabStop = false;
            this.sixthFloor.Text = "6F";
            this.sixthFloor.UseVisualStyleBackColor = true;
            this.sixthFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // fifthFloor
            // 
            this.fifthFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.fifthFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.fifthFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fifthFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fifthFloor.Location = new System.Drawing.Point(252, 115);
            this.fifthFloor.Name = "fifthFloor";
            this.fifthFloor.Size = new System.Drawing.Size(118, 105);
            this.fifthFloor.TabIndex = 7;
            this.fifthFloor.TabStop = false;
            this.fifthFloor.Text = "5F";
            this.fifthFloor.UseVisualStyleBackColor = true;
            this.fifthFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // fourthFloor
            // 
            this.fourthFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.fourthFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.fourthFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fourthFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fourthFloor.Location = new System.Drawing.Point(128, 115);
            this.fourthFloor.Name = "fourthFloor";
            this.fourthFloor.Size = new System.Drawing.Size(118, 105);
            this.fourthFloor.TabIndex = 6;
            this.fourthFloor.TabStop = false;
            this.fourthFloor.Text = "4F";
            this.fourthFloor.UseVisualStyleBackColor = true;
            this.fourthFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // thirdFloor
            // 
            this.thirdFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.thirdFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.thirdFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thirdFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.thirdFloor.Location = new System.Drawing.Point(4, 115);
            this.thirdFloor.Name = "thirdFloor";
            this.thirdFloor.Size = new System.Drawing.Size(118, 105);
            this.thirdFloor.TabIndex = 5;
            this.thirdFloor.TabStop = false;
            this.thirdFloor.Text = "3F";
            this.thirdFloor.UseVisualStyleBackColor = true;
            this.thirdFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // secondFloor
            // 
            this.secondFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.secondFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.secondFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secondFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.secondFloor.Location = new System.Drawing.Point(500, 4);
            this.secondFloor.Name = "secondFloor";
            this.secondFloor.Size = new System.Drawing.Size(118, 105);
            this.secondFloor.TabIndex = 4;
            this.secondFloor.TabStop = false;
            this.secondFloor.Text = "2F";
            this.secondFloor.UseVisualStyleBackColor = true;
            this.secondFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // firstFloor
            // 
            this.firstFloor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(225)))));
            this.firstFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.firstFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.firstFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.firstFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.firstFloor.ForeColor = System.Drawing.Color.White;
            this.firstFloor.Location = new System.Drawing.Point(376, 4);
            this.firstFloor.Name = "firstFloor";
            this.firstFloor.Size = new System.Drawing.Size(118, 105);
            this.firstFloor.TabIndex = 3;
            this.firstFloor.TabStop = false;
            this.firstFloor.Text = "1F";
            this.firstFloor.UseVisualStyleBackColor = false;
            this.firstFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // base1stFloor
            // 
            this.base1stFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.base1stFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.base1stFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.base1stFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.base1stFloor.Location = new System.Drawing.Point(252, 4);
            this.base1stFloor.Name = "base1stFloor";
            this.base1stFloor.Size = new System.Drawing.Size(118, 105);
            this.base1stFloor.TabIndex = 2;
            this.base1stFloor.TabStop = false;
            this.base1stFloor.Text = "B1";
            this.base1stFloor.UseVisualStyleBackColor = true;
            this.base1stFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // base2ndFloor
            // 
            this.base2ndFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.base2ndFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.base2ndFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.base2ndFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.base2ndFloor.Location = new System.Drawing.Point(128, 4);
            this.base2ndFloor.Name = "base2ndFloor";
            this.base2ndFloor.Size = new System.Drawing.Size(118, 105);
            this.base2ndFloor.TabIndex = 1;
            this.base2ndFloor.TabStop = false;
            this.base2ndFloor.Text = "B2";
            this.base2ndFloor.UseVisualStyleBackColor = true;
            this.base2ndFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // base3rdFloor
            // 
            this.base3rdFloor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.base3rdFloor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(158)))), ((int)(((byte)(233)))));
            this.base3rdFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.base3rdFloor.Font = new System.Drawing.Font("Noto Sans KR Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.base3rdFloor.Location = new System.Drawing.Point(4, 4);
            this.base3rdFloor.Name = "base3rdFloor";
            this.base3rdFloor.Size = new System.Drawing.Size(118, 105);
            this.base3rdFloor.TabIndex = 0;
            this.base3rdFloor.TabStop = false;
            this.base3rdFloor.Text = "B3";
            this.base3rdFloor.UseVisualStyleBackColor = true;
            this.base3rdFloor.Click += new System.EventHandler(this.ChangeSelectedFloor);
            // 
            // LCDTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 750);
            this.Controls.Add(this.floorBackgroundLayout);
            this.Controls.Add(this.ipBackgroundLayout);
            this.Controls.Add(this.windowBarPanel);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LCDTester";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LCD Tester";
            this.Load += new System.EventHandler(this.LCDTester_Load);
            this.ipBackgroundLayout.ResumeLayout(false);
            this.ipLinePanel.ResumeLayout(false);
            this.ipLayout.ResumeLayout(false);
            this.ipLayout.PerformLayout();
            this.floorBackgroundLayout.ResumeLayout(false);
            this.floorBtnLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel windowBarPanel;
        private System.Windows.Forms.TableLayoutPanel ipBackgroundLayout;
        private System.Windows.Forms.Panel ipLinePanel;
        private System.Windows.Forms.TableLayoutPanel ipLayout;
        private System.Windows.Forms.Button testerOnOff;
        private System.Windows.Forms.TextBox ipText1;
        private System.Windows.Forms.TextBox ipText2;
        private System.Windows.Forms.TextBox ipText3;
        private System.Windows.Forms.TextBox ipText4;
        private System.Windows.Forms.Label ipTitle;
        private System.Windows.Forms.Button ipSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel floorBackgroundLayout;
        private System.Windows.Forms.TableLayoutPanel floorBtnLayout;
        private System.Windows.Forms.Button base3rdFloor;
        private System.Windows.Forms.Button secondFloor;
        private System.Windows.Forms.Button firstFloor;
        private System.Windows.Forms.Button base1stFloor;
        private System.Windows.Forms.Button base2ndFloor;
        private System.Windows.Forms.Button twelfthFloor;
        private System.Windows.Forms.Button eleventhFloor;
        private System.Windows.Forms.Button tenthFloor;
        private System.Windows.Forms.Button ninthFloor;
        private System.Windows.Forms.Button eighthFloor;
        private System.Windows.Forms.Button seventhFloor;
        private System.Windows.Forms.Button sixthFloor;
        private System.Windows.Forms.Button fifthFloor;
        private System.Windows.Forms.Button fourthFloor;
        private System.Windows.Forms.Button thirdFloor;
    }
}

