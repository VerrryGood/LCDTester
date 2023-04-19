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

        private int weatherPort = 7000;
        private WeatherSendClient weatherDataSendClient;

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

        private bool overLoad = false;
        public bool OverLoad
        {
            set
            {
                if (overLoad != value)
                {
                    overLoad = value;
                    ChangeOverLoadButton();
                }
            }
        }
        private bool full = false;
        public bool Full
        {
            set
            {
                if (full != value)
                {
                    full = value;
                    ChangeFullButtion();
                }
            }
        }
        private int errorCode;

        private bool arrowUp = false;
        private bool arrowDown = false;

        private string myIP = "127.0.0.1";
        private string[] ips;
        private byte[] byteIP;

        private string weatherIP = "127.0.0.1";
        private string[] weatherIPs;
        private byte[] weatherByteIP;

        private BitArray arrowDisplay = new BitArray(8);
        private BitArray status0 = new BitArray(8);
        private BitArray status1 = new BitArray(8);
        private BitArray opbInput1 = new BitArray(8);

        private bool doorOpened = false;
        private Timers.Timer openTimer = new Timers.Timer(10);
        private Timers.Timer closeTimer = new Timers.Timer(10);

        private SetWeatherPic setWeatherPicWindow = new SetWeatherPic();

        private void LCDTester_Load(object sender, EventArgs e)
        {
            ReadSettings(currentDir + iniName);
            ips = myIP.Split('.');
            ipText1.Text = ips[0];
            ipText2.Text = ips[1];
            ipText3.Text = ips[2];
            ipText4.Text = ips[3];

            weatherIPs = weatherIP.Split('.');
            wthrIP1.Text = weatherIPs[0];
            wthrIP2.Text = weatherIPs[1];
            wthrIP3.Text = weatherIPs[2];
            wthrIP4.Text = weatherIPs[3];

            floorDataSendClient = new FloorSendClient(floorPort);
            weatherDataSendClient = new WeatherSendClient(weatherPort);

            windowBar = new WindowBar(this);
            windowBarPanel.Controls.Add(windowBar);
            windowBar.Dock = DockStyle.Fill;
            windowBar.windowBarTitle.Text = "LCD Tester";

            preFloor = firstFloor;
            preMode = normalBtn;

            MakeLCDDataFirstTime();
            MakeElevDataFirstTime();
            testerManager.MakeDatatoByte();

            MakeProtocolDataFirstTime();
            MakeWeatherDataFirstTime();
            testerManager.MakeWeatherToByte();

            MakeCloseDataFirstTime();
            testerManager.MakeCloseToByte();
        }

        private void ReadSettings(string fullName)
        {
            if (File.Exists(fullName))
            {
                StringBuilder sb = new StringBuilder();

                BasicFunction.GetPrivateProfileString(CommonValues.baseTitle, CommonValues.ipText, string.Empty, sb, 32, fullName);
                if (!string.IsNullOrEmpty(sb.ToString()))
                    myIP = sb.ToString();

                BasicFunction.GetPrivateProfileString(CommonValues.baseTitle, CommonValues.weatherIPText, string.Empty, sb, 32, fullName);
                if (!string.IsNullOrEmpty(sb.ToString()))
                    weatherIP = sb.ToString();

                BasicFunction.GetPrivateProfileString(CommonValues.baseTitle, CommonValues.floorPortText, string.Empty, sb, 32, fullName);
                if (!string.IsNullOrEmpty(sb.ToString()))
                    if (int.TryParse(sb.ToString(), out _))
                        floorPort = int.Parse(sb.ToString());

                BasicFunction.GetPrivateProfileString(CommonValues.baseTitle, CommonValues.weatherPortText, string.Empty, sb, 32, fullName);
                if (!string.IsNullOrEmpty(sb.ToString()))
                    if (int.TryParse(sb.ToString(), out _))
                        weatherPort = int.Parse(sb.ToString());
            }
        }

        #region 프로그램 실행 시 데이터 첫 세팅 동작
        private void MakeLCDDataFirstTime()
        {
            CommonValues.lcdData.crtDisplayCounter = 3;
            CommonValues.lcdData.crtMode = (byte)CommFunction.MODENUMBER.NORMAL;
            CommonValues.lcdData.crtArrow = 0;
            CommonValues.lcdData.crtStatus0 = 0;
            CommonValues.lcdData.crtStatus1 = 0;
            CommonValues.lcdData.crtStatus4 = 0;
            CommonValues.lcdData.crtOpbOutput2 = 0;
            CommonValues.lcdData.crtOpbInput1 = 0;
            CommonValues.lcdData.crtErrorCode1 = 0;
            CommonValues.lcdData.crtErrorCode2 = 0;
            CommonValues.lcdData.crtCommonData2 = 0;
            CommonValues.lcdData.crtActionNum = (byte)CommFunction.ACTIONNUMBER.CLOSED;
            CommonValues.lcdData.thousandChar = 0x00;
            CommonValues.lcdData.hundredChar = 0x00;
            CommonValues.lcdData.tenthChar = 0x20;
            CommonValues.lcdData.firstChar = 0x31;
            byte[] tempByte = new byte[68];
            CommonValues.lcdData.elseData2 = tempByte;
        }

        private void MakeElevDataFirstTime()
        {
            CommonValues.elevData.opCode = (byte)CommFunction.OPCODE.ELEVFLOOR;

            IPtoByte();
            CommonValues.elevData.equipKind = (byte)CommFunction.EQUIPKIND.ELEVATOR;
            CommonValues.elevData.protocolKind = (byte)CommFunction.PROTOCOLKIND.SAMIL;
        }

        private void MakeWeatherDataFirstTime()
        {
            CommonValues.weatherData.weatherPic = 1;
            CommonValues.weatherData.tempMinus = 0;
            CommonValues.weatherData.temperature = 0;
            CommonValues.weatherData.decTemp = 0;
            CommonValues.weatherData.humidity = 0;
            CommonValues.weatherData.dust = 0;
            CommonValues.weatherData.percent = 0;
            CommonValues.weatherData.standard = 100;
        }

        private void MakeProtocolDataFirstTime()
        {
            CommonValues.protocolData.opCode = (byte)CommFunction.OPCODE.WEATHERINFO;
            WeatherIPtoByte();
            CommonValues.protocolData.equipKind = (byte)CommFunction.EQUIPKIND.LCDSCREEN;
        }

        private void MakeCloseDataFirstTime()
        {
            CommonValues.closeData.opCode = (byte)CommFunction.OPCODE.COMMCLOSE;
            CommonValues.closeData.equipKind = (byte)CommFunction.EQUIPKIND.LCDSCREEN;
        }
        #endregion

        #region IP 변경
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

        private void WeatherIPtoByte()
        {
            weatherIPs = weatherIP.Split('.');
            weatherByteIP = weatherIPs.Select(byte.Parse).ToArray();
            Array.Reverse(weatherByteIP);
            CommonValues.protocolData.sourceIP = weatherByteIP;
            CommonValues.closeData.sourceIP = weatherByteIP;
        }

        private void ChangeWeatherIP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                weatherIPSet.PerformClick();
        }

        private void weatherIPSet_Click(object sender, EventArgs e)
        {
            weatherIP = string.Join(".", wthrIP1.Text, wthrIP2.Text, wthrIP3.Text, wthrIP4.Text);
            WeatherIPtoByte();
            testerManager.MakeWeatherToByte();
            testerManager.MakeCloseToByte();
        }
        #endregion

        // 층 정보 변경
        private void ChangeSelectedFloor(object sender, EventArgs e)
        {
            SelectedFloor = BasicFunction.StringtoFloorNum(((Button)sender).Text);
            if (preFloor != ((Button)sender))
            {
                ((Button)sender).BackColor = CommonValues.floorSelectColor;
                ((Button)sender).ForeColor = Color.White;
                preFloor.BackColor = Color.White;
                preFloor.ForeColor = ForeColor;
                preFloor = ((Button)sender);
            }
        }

        // 서버 ON/OFF
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
                upArrow.BackColor = Color.White;
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
                downArrow.BackColor = Color.White;
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
            preMode.BackColor = Color.White;
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
        #endregion

        private void LCDTester_FormClosing(object sender, FormClosingEventArgs e)
        {
            floorDataSendClient.Stop();
            BasicFunction.WritePrivateProfileString(CommonValues.baseTitle, CommonValues.ipText, myIP, currentDir + iniName);
            BasicFunction.WritePrivateProfileString(CommonValues.baseTitle, CommonValues.weatherIPText, weatherIP, currentDir + iniName);
        }

        private void weatherPic_Click(object sender, EventArgs e)
        {
            if (setWeatherPicWindow.ShowDialog() == DialogResult.OK)
            {
                ChangeWeatherPic();
                CommonValues.weatherData.weatherPic = Convert.ToByte(CommonValues.picIndex);
                testerManager.MakeWeatherToByte();
                weatherDataSendClient.SendWeather();
            }
        }

        private void ChangeWeatherPic()
        {
            switch (CommonValues.picIndex)
            {
                case 1:
                    weatherPic.Image = Properties.Resources.w_01;
                    break;
                case 2:
                    weatherPic.Image = Properties.Resources.w_02;
                    break;
                case 3:
                    weatherPic.Image = Properties.Resources.w_03;
                    break;
                case 4:
                    weatherPic.Image = Properties.Resources.w_04;
                    break;
                case 5:
                    weatherPic.Image = Properties.Resources.w_05;
                    break;
                case 6:
                    weatherPic.Image = Properties.Resources.w_06;
                    break;
                case 7:
                    weatherPic.Image = Properties.Resources.w_07;
                    break;
                case 8:
                    weatherPic.Image = Properties.Resources.w_08;
                    break;
                case 9:
                    weatherPic.Image = Properties.Resources.w_09;
                    break;
                case 10:
                    weatherPic.Image = Properties.Resources.w_10;
                    break;
                case 11:
                    weatherPic.Image = Properties.Resources.w_11;
                    break;
                case 12:
                    weatherPic.Image = Properties.Resources.w_12;
                    break;
                case 13:
                    weatherPic.Image = Properties.Resources.w_13;
                    break;
                case 14:
                    weatherPic.Image = Properties.Resources.w_14;
                    break;
                case 15:
                    weatherPic.Image = Properties.Resources.w_15;
                    break;
                case 16:
                    weatherPic.Image = Properties.Resources.w_16;
                    break;
                case 17:
                    weatherPic.Image = Properties.Resources.w_17;
                    break;
                case 18:
                    weatherPic.Image = Properties.Resources.w_18;
                    break;
                case 19:
                    weatherPic.Image = Properties.Resources.w_19;
                    break;
                case 20:
                    weatherPic.Image = Properties.Resources.w_20;
                    break;
                case 21:
                    weatherPic.Image = Properties.Resources.w_21;
                    break;
                case 22:
                    weatherPic.Image = Properties.Resources.w_22;
                    break;
                case 23:
                    weatherPic.Image = Properties.Resources.w_23;
                    break;
                case 24:
                    weatherPic.Image = Properties.Resources.w_24;
                    break;
                case 25:
                    weatherPic.Image = Properties.Resources.w_25;
                    break;
                case 26:
                    weatherPic.Image = Properties.Resources.w_26;
                    break;
                case 27:
                    weatherPic.Image = Properties.Resources.w_27;
                    break;
                case 28:
                    weatherPic.Image = Properties.Resources.w_28;
                    break;
                case 29:
                    weatherPic.Image = Properties.Resources.w_29;
                    break;
                case 30:
                    weatherPic.Image = Properties.Resources.w_30;
                    break;
                case 31:
                    weatherPic.Image = Properties.Resources.w_31;
                    break;
                case 32:
                    weatherPic.Image = Properties.Resources.w_32;
                    break;
                case 33:
                    weatherPic.Image = Properties.Resources.w_33;
                    break;
                case 34:
                    weatherPic.Image = Properties.Resources.w_34;
                    break;
                case 35:
                    weatherPic.Image = Properties.Resources.w_35;
                    break;
                case 36:
                    weatherPic.Image = Properties.Resources.w_36;
                    break;
                case 37:
                    weatherPic.Image = Properties.Resources.w_37;
                    break;
                case 38:
                    weatherPic.Image = Properties.Resources.w_38;
                    break;
                case 39:
                    weatherPic.Image = Properties.Resources.w_39;
                    break;
                case 40:
                    weatherPic.Image = Properties.Resources.w_40;
                    break;
            }
        }

        private void applyTemp_Click(object sender, EventArgs e)
        {
            if (underZero.Checked)
                CommonValues.weatherData.tempMinus = 0xFF;
            else
                CommonValues.weatherData.tempMinus = 0;

            if (byte.TryParse(tempText.Text, out _))
                CommonValues.weatherData.temperature = byte.Parse(tempText.Text);
            else
                MessageBox.Show("기온 입력 칸에는 숫자만 입력하여 주십시오.");

            if (byte.TryParse(decTempText.Text, out _))
                CommonValues.weatherData.decTemp = byte.Parse(decTempText.Text);
            else
                MessageBox.Show("기온 입력 칸에는 숫자만 입력하여 주십시오.");

            testerManager.MakeWeatherToByte();
            weatherDataSendClient.SendWeather();
        }

        private void tempText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                applyTemp.PerformClick();
        }

        private void applyHumidity_Click(object sender, EventArgs e)
        {
            if (byte.TryParse(humText.Text, out _))
                CommonValues.weatherData.humidity = byte.Parse(humText.Text);
            else
                MessageBox.Show("습도 입력 칸에는 숫자만 입력하여 주십시오.");

            testerManager.MakeWeatherToByte();
            weatherDataSendClient.SendWeather();
        }

        private void humText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                applyHumidity.PerformClick();
        }

        private void applyDust_Click(object sender, EventArgs e)
        {
            if (byte.TryParse(dustText.Text, out _))
                CommonValues.weatherData.dust = byte.Parse(dustText.Text);
            else
                MessageBox.Show("미세먼지 입력 칸에는 숫자만 입력하여 주십시오.");

            testerManager.MakeWeatherToByte();
            weatherDataSendClient.SendWeather();
        }

        private void dustText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                applyDust.PerformClick();
        }

        private void applyStandard_Click(object sender, EventArgs e)
        {
            if (byte.TryParse(stdText.Text, out _))
                CommonValues.weatherData.percent = byte.Parse(stdText.Text);
            else
                MessageBox.Show("법적 기준 입력 칸에는 숫자만 입력하여 주십시오.");

            testerManager.MakeWeatherToByte();
            weatherDataSendClient.SendWeather();
        }

        private void stdText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                applyStandard.PerformClick();
        }

        private void ChangeWeightStatus()
        {
            opbInput1[4] = overLoad;
            opbInput1[5] = full;
            CommonValues.lcdData.crtOpbInput1 = BasicFunction.ConvertBitToByte(opbInput1);
            testerManager.MakeDatatoByte();
        }

        private void ChangeOverLoadButton()
        {
            if (overLoad)
            {
                overLoadONOFF.BackColor = CommonValues.floorSelectColor;
                overLoadONOFF.ForeColor = Color.White;
                overLoadONOFF.Text = "OVERLOAD ON";
            }
            else
            {
                overLoadONOFF.BackColor = Color.White;
                overLoadONOFF.ForeColor = ForeColor;
                overLoadONOFF.Text = "OVERLOAD OFF";
            }
        }

        private void ChangeFullButtion()
        {
            if (full)
            {
                fullONOFF.BackColor = CommonValues.floorSelectColor;
                fullONOFF.ForeColor = Color.White;
                fullONOFF.Text = "FULL ON";
            }
            else
            {
                fullONOFF.BackColor = Color.White;
                fullONOFF.ForeColor = ForeColor;
                fullONOFF.Text = "FULL OFF";
            }
        }

        private void overLoadONOFF_Click(object sender, EventArgs e)
        {
            if (overLoad)
                OverLoad = false;
            else
                OverLoad = true;

            if (full)
                Full = false;

            ChangeWeightStatus();
        }

        private void fullONOFF_Click(object sender, EventArgs e)
        {
            if (full)
                Full = false;
            else
                Full = true;

            if (overLoad)
                OverLoad = false;

            ChangeWeightStatus();
        }

        private void applyErrorCode_Click(object sender, EventArgs e)
        {
            MakeErrorCode();
        }

        private void MakeErrorCode()
        {
            if (int.TryParse(errCodeText.Text, out errorCode))
            {
                if (errorCode > 255)
                {
                    CommonValues.lcdData.crtErrorCode1 = (byte)(errorCode % 256);
                    CommonValues.lcdData.crtErrorCode2 = (byte)(errorCode / 256);
                }
                else
                {
                    CommonValues.lcdData.crtErrorCode1 = 0;
                    CommonValues.lcdData.crtErrorCode2 = (byte)errorCode;
                }

                testerManager.MakeDatatoByte();
            }
            else
                MessageBox.Show("숫자만 입력하여 주십시오", "오류");
        }
    }
}
