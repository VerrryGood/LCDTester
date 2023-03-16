using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Timers = System.Timers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLib;
using CustomControls;

namespace LCDTester
{
    public partial class LCDTester : Form
    {
        public static Manager testerManager;
        public LCDTester()
        {
            InitializeComponent();
            testerManager = new Manager(this);

            openTimer.SynchronizingObject = this;
            closeTimer.SynchronizingObject = this;
            openTimer.Elapsed += OpenDoor;
            closeTimer.Elapsed += CloseDoor;
        }

        private WindowBar windowBar;
        private string currentDir = Application.StartupPath;
        private const string iniName = @"\Settings.ini";

        private int floorPort = 11000;
        private FloorSendClient floorDataSendClient;
        private bool serverOn = false;

        private int selectedFloor = 1;
        public int SelectedFloor
        {
            set
            {
                if (selectedFloor != value)
                {
                    if (serverOn)
                    {
                        ControlFunction.ChangeEnabled(testerOnOff, false);
                        ControlFunction.ChangeEnabled(floorBackgroundLayout, false);
                        testerManager.CurFloor = value;
                    }
                    else
                    {
                        testerManager.curFloor = value;
                        testerManager.MakeFloorData(value);
                    }
                }
                selectedFloor = value;
            }
        }
        private Button preFloor;

        private byte selectedMode = (byte)CommFunction.MODENUMBER.NORMAL;
        public byte SelectedMode
        {
            set
            {
                if (selectedMode != value)
                {
                    ChangeElevatorMode(value);
                }
                selectedMode = value;
            }
        }
        private Button preMode;

        private bool arrowUp = false;
        private bool arrowDown = false;

        private string myIP = "127.0.0.1";
        private string[] ips;
        private byte[] byteIP;

        private BitArray arrowDisplay = new BitArray(8);
        private BitArray status0 = new BitArray(8);
        private BitArray status1 = new BitArray(8);

        private bool doorOpened = false;
        private Timers.Timer openTimer = new Timers.Timer(10);
        private Timers.Timer closeTimer = new Timers.Timer(10);

        private void LCDTester_Load(object sender, EventArgs e)
        {
            ReadSettings(currentDir + iniName);
            ips = myIP.Split('.');
            ipText1.Text = ips[0];
            ipText2.Text = ips[1];
            ipText3.Text = ips[2];
            ipText4.Text = ips[3];

            floorDataSendClient = new FloorSendClient(floorPort);

            windowBar = new WindowBar(this);
            windowBarPanel.Controls.Add(windowBar);
            windowBar.Dock = DockStyle.Fill;
            windowBar.windowBarTitle.Text = "LCD Tester";

            preFloor = firstFloor;
            preMode = normalBtn;

            MakeLCDDataFirstTime();
            MakeElevDataFirstTime();
            testerManager.MakeDatatoByte();
        }

        private void ReadSettings(string fullName)
        {
            if (File.Exists(fullName))
            {
                StringBuilder sb = new StringBuilder();

                BasicFunction.GetPrivateProfileString(CommonValues.baseTitle, CommonValues.ipText, string.Empty, sb, 32, fullName);
                if (!string.IsNullOrEmpty(sb.ToString()))
                    myIP = sb.ToString();

                BasicFunction.GetPrivateProfileString(CommonValues.baseTitle, CommonValues.portText, string.Empty, sb, 32, fullName);
                if (!string.IsNullOrEmpty(sb.ToString()))
                    floorPort = int.Parse(sb.ToString());
            }
        }

        private void MakeLCDDataFirstTime()
        {
            CommonValues.lcdData.crtDisplayCounter = 3;
            CommonValues.lcdData.crtMode = (byte)CommFunction.MODENUMBER.NORMAL;
            CommonValues.lcdData.crtArrow = 0;
            CommonValues.lcdData.crtStatus0 = 0;
            CommonValues.lcdData.crtStatus1 = 0;
            byte[] tempByte = new byte[6];
            CommonValues.lcdData.elseData1 = tempByte;
            CommonValues.lcdData.crtActionNum = (byte)CommFunction.ACTIONNUMBER.CLOSED;
            CommonValues.lcdData.thousandChar = 0x00;
            CommonValues.lcdData.hundredChar = 0x00;
            CommonValues.lcdData.tenthChar = 0x20;
            CommonValues.lcdData.firstChar = 0x31;
            tempByte = new byte[68];
            CommonValues.lcdData.elseData2 = tempByte;
        }

        private void MakeElevDataFirstTime()
        {
            CommonValues.elevData.opCode = (byte)CommFunction.OPCODE.ELEVFLOOR;

            IPtoByte();
            CommonValues.elevData.equipKind = (byte)CommFunction.EQUIPKIND.ELEVATOR;
            CommonValues.elevData.protocolKind = (byte)CommFunction.PROTOCOLKIND.SAMIL;
        }

        private void IPtoByte()
        {
            ips = myIP.Split('.');
            byteIP = ips.Select(byte.Parse).ToArray();
            Array.Reverse(byteIP);
            CommonValues.elevData.sourceIP = byteIP;
        }

        private void ChangeIP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ipSet.PerformClick();
        }

        private void ipSet_Click(object sender, EventArgs e)
        {
            myIP = string.Join(".", ipText1.Text, ipText2.Text, ipText3.Text, ipText4.Text);
            IPtoByte();
            testerManager.MakeDatatoByte();
        }

        private void ChangeSelectedFloor(object sender, EventArgs e)
        {
            SelectedFloor = BasicFunction.StringtoFloorNum(((Button)sender).Text);
            if (preFloor != ((Button)sender))
            {
                ((Button)sender).BackColor = CommonValues.floorSelectColor;
                ((Button)sender).ForeColor = Color.White;
                preFloor.BackColor = BackColor;
                preFloor.ForeColor = ForeColor;
                preFloor = ((Button)sender);
            }
        }

        private void testerOnOff_Click(object sender, EventArgs e)
        {
            if (serverOn)
            {
                testerOnOff.Text = "서버 시작";
                testerOnOff.BackColor = Color.Gray;
                floorDataSendClient.Stop();
                serverOn = false;
            }
            else
            {
                testerOnOff.Text = "서버 종료";
                testerOnOff.BackColor = Color.FromArgb(133, 158, 254);
                floorDataSendClient.Start();
                serverOn = true;
            }
        }

        #region 문 관련 동작
        private void elevCar_Click(object sender, EventArgs e)
        {
            DoorMove();
        }

        public void DoorMove()
        {
            ControlFunction.ChangeVisible(leftDoor, true);
            ControlFunction.ChangeVisible(rightDoor, true);
            ControlFunction.ChangeClickEventStatus(elevCar, elevCar_Click, false);

            if (doorOpened)
            {
                CommonValues.lcdData.crtActionNum = (byte)CommFunction.ACTIONNUMBER.CLOSING;
                testerManager.MakeDatatoByte();

                ControlFunction.ChangeLoc(leftDoor, new Point(-79, 0));
                ControlFunction.ChangeLoc(rightDoor, new Point(158, 0));
                closeTimer.Start();
            }
            else
            {
                CommonValues.lcdData.crtActionNum = (byte)CommFunction.ACTIONNUMBER.OPENING;
                testerManager.MakeDatatoByte();

                ControlFunction.ChangeLoc(leftDoor, new Point(0, 0));
                ControlFunction.ChangeLoc(rightDoor, new Point(79, 0));
                ControlFunction.ChangePic(elevCar, Properties.Resources.elv_grup_일반_열림);
                openTimer.Start();
            }
        }

        private void OpenDoor(object sender, Timers.ElapsedEventArgs e)
        {
            ControlFunction.ChangeLoc(leftDoor, new Point(leftDoor.Location.X - 2, 0));
            ControlFunction.ChangeLoc(rightDoor, new Point(rightDoor.Location.X + 2, 0));

            if (leftDoor.Location.X + 79 < 2)
            {
                CommonValues.lcdData.crtActionNum = (byte)CommFunction.ACTIONNUMBER.OPENED;
                testerManager.MakeDatatoByte();

                ControlFunction.ChangeVisible(leftDoor, false);
                ControlFunction.ChangeVisible(rightDoor, false);
                doorOpened = true;
                ControlFunction.ChangeClickEventStatus(elevCar, elevCar_Click, true);
                openTimer.Stop();
            }
        }

        private void CloseDoor(object sender, Timers.ElapsedEventArgs e)
        {
            ControlFunction.ChangeLoc(leftDoor, new Point(leftDoor.Location.X + 2, 0));
            ControlFunction.ChangeLoc(rightDoor, new Point(rightDoor.Location.X - 2, 0));

            if (leftDoor.Location.X > -2)
            {
                CommonValues.lcdData.crtActionNum = (byte)CommFunction.ACTIONNUMBER.CLOSED;
                testerManager.MakeDatatoByte();

                ControlFunction.ChangePic(elevCar, Properties.Resources.elv_grup_일반_닫힘);
                ControlFunction.ChangeVisible(leftDoor, false);
                ControlFunction.ChangeVisible(rightDoor, false);
                doorOpened = false;
                ControlFunction.ChangeClickEventStatus(elevCar, elevCar_Click, true);
                closeTimer.Stop();
            }
        }

        #endregion

        #region 화살표 관련 동작
        public void MakeArrowData()
        {
            CommonValues.lcdData.crtArrow = BasicFunction.ConvertBitToByte(arrowDisplay);
            CommonValues.lcdData.crtStatus0 = BasicFunction.ConvertBitToByte(status0);
            CommonValues.lcdData.crtStatus1 = BasicFunction.ConvertBitToByte(status1);
            testerManager.MakeDatatoByte();
        }

        public void ChangeArrowUp(bool going)
        {
            arrowDisplay[0] = going;
            status0[0] = going;
            arrowUp = going;
        }

        public void ChangeArrowDown(bool going)
        {
            arrowDisplay[1] = going;
            status0[1] = going;
            arrowDown = going;
        }

        public void ChangeArrowStop()
        {
            ChangeArrowUp(false);
            ChangeArrowDown(false);
            status0[1] = false;
        }

        private void upArrow_Click(object sender, EventArgs e)
        {
            if (arrowUp)
            {
                floorBtnLayout.Enabled = true;
                upArrow.BackColor = BackColor;
                upArrow.ForeColor = ForeColor;

                ChangeArrowUp(false);
                status1[0] = false;
            }
            else
            {
                floorBtnLayout.Enabled = false;
                upArrow.BackColor = CommonValues.floorSelectColor;
                upArrow.ForeColor = Color.White;

                ChangeArrowUp(true);
                status1[0] = true;
            }

            if (arrowDown)
            {
                downArrow.BackColor = BackColor;
                downArrow.ForeColor = ForeColor;

                ChangeArrowDown(false);
            }

            MakeArrowData();
        }

        private void downArrow_Click(object sender, EventArgs e)
        {
            if (arrowDown)
            {
                floorBtnLayout.Enabled = true;
                downArrow.BackColor = BackColor;
                downArrow.ForeColor = ForeColor;

                ChangeArrowDown(false);
                status1[0] = false;
            }
            else
            {
                floorBtnLayout.Enabled = false;
                downArrow.BackColor = CommonValues.floorSelectColor;
                downArrow.ForeColor = Color.White;

                ChangeArrowDown(true);
                status1[0] = true;
            }

            if (arrowUp)
            {
                upArrow.BackColor = BackColor;
                upArrow.ForeColor = ForeColor;

                ChangeArrowUp(false);
            }

            MakeArrowData();
        }
        #endregion

        #region 엘리베이터 모드(관제) 변경
        private void ChangeElevatorMode(byte curMode)
        {
            preMode.BackColor = BackColor;
            preMode.ForeColor = ForeColor;

            switch (curMode)
            {
                case (byte)CommFunction.MODENUMBER.MAINTENANCE:
                    maintenanceBtn.BackColor = CommonValues.floorSelectColor;
                    maintenanceBtn.ForeColor = Color.White;
                    break;
                case (byte)CommFunction.MODENUMBER.PARKING:
                    parkingBtn.BackColor = CommonValues.floorSelectColor;
                    parkingBtn.ForeColor = Color.White;
                    break;
                case (byte)CommFunction.MODENUMBER.NORMAL:
                    normalBtn.BackColor = CommonValues.floorSelectColor;
                    normalBtn.ForeColor = Color.White;
                    break;
                case (byte)CommFunction.MODENUMBER.FIRE:
                    fireBtn.BackColor = CommonValues.floorSelectColor;
                    fireBtn.ForeColor = Color.White;
                    break;
                case (byte)CommFunction.MODENUMBER.EARTHQUAKE:
                    earthquakeBtn.BackColor = CommonValues.floorSelectColor;
                    earthquakeBtn.ForeColor = Color.White;
                    break;
                case (byte)CommFunction.MODENUMBER.MOVING:
                    movingBtn.BackColor = CommonValues.floorSelectColor;
                    movingBtn.ForeColor = Color.White;
                    break;
            }

            CommonValues.lcdData.crtMode = curMode;
            testerManager.MakeDatatoByte();
        }
        #endregion

        private void LCDTester_FormClosing(object sender, FormClosingEventArgs e)
        {
            floorDataSendClient.Stop();
            BasicFunction.WritePrivateProfileString(CommonValues.baseTitle, CommonValues.ipText, myIP, currentDir + iniName);
        }

        private void normalBtn_Click(object sender, EventArgs e)
        {
            SelectedMode = (byte)CommFunction.MODENUMBER.NORMAL;
            preMode = normalBtn;
        }

        private void maintenanceBtn_Click(object sender, EventArgs e)
        {
            SelectedMode = (byte)CommFunction.MODENUMBER.MAINTENANCE;
            preMode = maintenanceBtn;
        }

        private void parkingBtn_Click(object sender, EventArgs e)
        {
            SelectedMode = (byte)CommFunction.MODENUMBER.PARKING;
            preMode = parkingBtn;
        }

        private void fireBtn_Click(object sender, EventArgs e)
        {
            SelectedMode = (byte)CommFunction.MODENUMBER.FIRE;
            preMode = fireBtn;
        }

        private void earthquakeBtn_Click(object sender, EventArgs e)
        {
            SelectedMode = (byte)CommFunction.MODENUMBER.EARTHQUAKE;
            preMode = earthquakeBtn;
        }

        private void movingBtn_Click(object sender, EventArgs e)
        {
            SelectedMode = (byte)CommFunction.MODENUMBER.MOVING;
            preMode = movingBtn;
        }
    }
}
