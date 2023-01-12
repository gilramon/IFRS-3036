
using Monitor.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace Monitor
{


    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// 
        /// </summary>
		public AsyncCallback pfnWorkerCallBack;
        /// <summary>
        /// 
        /// </summary>
		public Socket m_socListener;
        /// <summary>
        /// 
        /// </summary>
		public Socket m_socWorker;
        private System.Windows.Forms.GroupBox groupBox_ServerSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPortNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        //TcpListener tcpListener;
        //private Thread listenThread;
        private CheckBox ListenBox;

        //NetworkStream clientStream;

        private bool New_Line = false;
        private bool Show_Time;
        private TabControl tabControl_Main;
        private TabPage tabPage_SerialPort;
        private IContainer components;
        private GroupBox groupBox5;
        private CheckBox checkBox_SerialPortPause;
        private Button button_ClearSerialPort;
        private RichTextBox SerialPortLogger_TextBox;
        private GroupBox S1_Configuration;
        private GroupBox groupBox12;
        private Button button13;
        private GroupBox groupBox22;
        private Button button19;
        private GroupBox groupBox28;
        private Button button25;
        private TextBox textBox_ModemPrimeryPort;
        private TextBox textBox_ModemPrimeryHost;
        private GroupBox groupBox30;
        private TextBox textBox_ForginPassword;
        private Button button27;
        private TextBox textBox_ForginAcessPoint;
        private TextBox textBox_ForginSecondaryDNS;
        private TextBox textBox_ForginUserName;
        private TextBox textBox_ForginPrimeryDNS;
        private GroupBox groupBox29;
        private TextBox textBox_HomePassword;
        private Button button26;
        private TextBox textBox_HomeAcessPoint;
        private TextBox textBox_HomeSecondaryDNS;
        private TextBox textBox_HomeUserName;
        private TextBox textBox_HomePrimeryDNS;
        private GroupBox groupBox27;
        private Button button24;
        private GroupBox groupBox26;
        private Button button23;
        private GroupBox groupBox25;
        private Button button22;
        private GroupBox groupBox24;
        private ComboBox comboBox_DispatchSpeed;
        private Button button21;
        private GroupBox groupBox23;
        private ComboBox comboBox_KillEngine;
        private Button button20;
        private GroupBox groupBox21;
        private ComboBox comboBox_TiltTowSensState;
        private Button button18;
        private GroupBox groupBox20;
        private ComboBox comboBox_HitState;
        private Button button17;
        private GroupBox groupBox19;
        private ComboBox comboBox_ShockState;
        private Button button16;
        private GroupBox groupBox18;
        private ComboBox comboBox1_TiltState;
        private Button button15;
        private GroupBox groupBox17;
        private Button button14;
        private GroupBox groupBox11;
        private ComboBox comboBox_SleepPolicy;
        private Button button12;
        private GroupBox groupBox10;
        private ComboBox comboBox_AlarmPilicy;
        private Button button11;
        private GroupBox groupBox9;
        private DateTimePicker dateTimePicker_SetTimeDate;
        private Button button10;
        private GroupBox groupBox8;
        private ComboBox comboBox_BatThreshold;
        private Button button9;
        private GroupBox groupBox7;
        private ComboBox comboBox_OutputNum;
        private ComboBox comboBox_OutputControl;
        private Button button8;
        private ComboBox comboBox_OutputPulseLevel;
        private GroupBox groupBox6;
        private ComboBox comboBox_InputNum1;
        private ComboBox comboBox_Interupt;
        private Button button7;
        private GroupBox groupBox13;
        private Button btn_ChangePassword;
        private TextBox textBox_NewPassword;
        private GroupBox groupBox14;
        private ComboBox comboBox_SMSControl;
        private Button button_SMSControl;
        private GroupBox groupBox15;
        private ComboBox comboBox_InputIndex;
        private Button button_SetFreeText;
        private GroupBox groupBox16;
        private Button button4;
        private TabPage tabPage5;
        private TextBox maskedTextBox3_Subscriber3;
        private TextBox maskedTextBox2_Subscriber2;
        private TextBox maskedTextBox1_Subscriber1;
        private TextBox maskedTextBox_OutputDuration;
        private TextBox maskedTextBox_InputDuration;
        private TextBox maskedTextBox1;
        private TextBox TextBox_NormalStatusDuration;
        private TextBox textBox_FreeText;
        private TextBox textBox_ModemSocket;
        private TextBox textBox_ModemRetries;
        private TextBox textBox_ModemTimeOut;
        private TextBox TextBox_Odometer;
        private TextBox maskedTextBox_TowDetectNum;
        private TextBox maskedTextBox_TowWindow;
        private TextBox maskedTextBox_TowAngle;
        private TextBox maskedTextBox_TiltDetectNum;
        private TextBox maskedTextBox_TiltWindow;
        private TextBox maskedTextBox_TiltAngle;
        private TextBox maskedTextBox_ShockDetectNum;
        private TextBox maskedTextBox_ShockWindow;
        private TextBox maskedTextBox_SpeedLimit2;
        private TextBox maskedTextBox_SpeedLimit3;
        private TextBox maskedTextBox_SpeedLimit1;
        private TextBox maskedTextBox_TiltTowSens;
        private TextBox maskedTextBox_HitSensitivity;
        private CheckBox checkBox_SerialPortRecordLog;
        private System.Windows.Forms.Timer timer_General_100ms;
        private TextBox textBox_NumberOfOpenConnections;
        private System.Windows.Forms.Timer timer_General_1Second;
        private GroupBox gbPortSettings;
        private ComboBox cmbBaudRate;
        private ComboBox cmbDataBits;
        private Label lblComPort;
        private Label lblStopBits;
        private Label lblBaudRate;
        private Label lblDataBits;
        private Label label3;
        private System.IO.Ports.SerialPort serialPort;
        private TextBox textBox_ServerOpen;
        private TabPage tabPage_ServerTCP;
        private TabPage tabPage4;
        private GroupBox groupBox36;
        private TextBox textBox_SMSPhoneNumber;
        private GroupBox groupBox_PhoneNumber;
        private CheckBox checkBox_EchoResponse;
        private ComboBox comboBox_ConnectionNumber;
        private GroupBox groupBox_SendSerialOrMonitorCommands;
        private Button button_SendSerialPort;
        private TextBox textBox_SerialPortRecognizePattern;
        private RichTextBox textBox_IDKey;
        private TextBox textBox_SerialPortRecognizePattern2;
        private TextBox textBox_SerialPortRecognizePattern3;
        private Button button_ReScanComPort;
        private Button button_StopwatchReset;
        private Button button_Stopwatch_Start_Stop;
        private TextBox textBox_StopWatch;
        private GroupBox groupBox_Stopwatch;
        private Button button_TimerLog;
        private CheckBox checkBox_ParseMessages;
        private GroupBox groupBox_Timer;
        private Button button_StartStopTimer;
        private Button button_ResetTimer;
        private TextBox textBox_SetTimerTime;
        private TextBox textBox_TimerTime;
        private Button button_OpenFolder;
        private CheckBox checkBox_DeleteCommand;
        private TabPage tabPage_charts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button button_ScreenShot;
        private TextBox textBox_SendSerialPort;
        private TextBox textBox_graph_XY;
        private Button button_ResetGraphs;
        private Button Button_Export_excel;
        private Button button_GraphPause;
        private Button button_OpenFolder2;
        private TabPage tabPage_ClientTCP;
        private Button button43;
        private Button button_ClientClose;
        private Button button_ClientConnect;
        private Button button3;
        private RichTextBox richTextBox_ClientTx;
        private TextBox textBox_ClientPort;
        private TextBox textBox_ClientIP;
        private Label label8;
        private Label label7;
        private Label label10;
        private Label label9;
        private Button button_ClearRx;
        private RichTextBox richTextBox_ClientRx;
        private ListBox listBox_Charts;
        private Label Label_SerialPortRx;
        private Label label_SerialPortConnected;
        private Label Label_SerialPortTx;
        private GroupBox groupBox_SerialPort;
        private Button button28;
        private CheckBox checkBox_RxHex;
        private CheckBox checkBox_SendHexdata;
        private Button button_OpenPort;
        private ComboBox comboBox_ChartUpdateTime;
        private GroupBox groupBox4;
        private TextBox textBox_SystemStatus;
        private PictureBox pictureBox1;
        private GroupBox groupBox_ClentTCPStatus;
        private Label Label_TCPClientTx;
        private Label label_ClientTCPConnected;
        private Label Label_TCPClientRx;
        private Button button_ClearServer;
        private Label label_SerialPortStatus;
        private Label label_TCPClient;
        private TabPage tabPage_Commands;
        private GroupBox groupBox40;
        private GroupBox groupBox32;
        private RichTextBox richTextBox_SSPA;
        private CheckBox checkBox_RecordMiniAda;
        private CheckBox checkBox_PauseMiniAda;
        private Button button_ClearMiniAda;
        private TabControl tabControl_System;
        private TabPage tabPage1;
        private GroupBox groupBox3;
        private CheckBox checkBox_StopLogging;
        private RichTextBox TextBox_Server;
        private CheckBox checkBox_RecordGeneral;
        private CheckBox PauseCheck;
        private Button Clear_btn;
        private TextBox textBox_ServerActive;
        private Button button_Ping;
        private CheckBox checkBox_ServerRecord;
        private CheckBox checkBox_ServerPause;
        private TextBox textBox_MinXAxis;
        private TextBox textBox_MaxXAxis;
        private Label label37;
        private Button button97;
        private Button button99;
        private CheckedListBox checkedListBox_PhoneBook;
        private Button button_AddContact;
        private Button button_RemoveContact;
        private Button button_ExportToXML;
        private Button button_ImportToXML;
        private Button button33;
        private RichTextBox richTextBox_ContactDetails;
        private Button button34;
        private RichTextBox richTextBox_TextSendSMS;
        private Button button_SendAllCheckedSMS;
        private Button button_SendSelectedSMS;
        private Label label_SMSSendCharacters;
        private CheckBox checkBox1;
        private CheckBox checkBox_SendSMSAsIs;
        private CheckBox checkBox_SMSencrypted;
        private GroupBox GrooupBox_Encryption;
        private TextBox textBox_UnitIDForSMS;
        private Label label2;
        private TextBox textBox_CodeArrayForSMS;
        private Label label5;
        private Button button_Ring;
        private RichTextBox richTextBox_ModemStatus;
        private ComboBox comboBox_ComportSMS;
        private Button button36;
        private CheckBox checkBox_OpenPortSMS;
        private CheckBox checkBox_DebugSMS;
        private Button button_ClearSMSConsole;
        private CheckBox checkBox_PauseSMSConsole;
        private CheckBox checkBox_RecordSMSConsole;
        private RichTextBox richTextBox_SMSConsole;
        private Button button41;
        private Button button40;
        private Button button39;
        private Button button38;
        private Button button37;
        private ListBox listBox_SMSCommands;
        private GroupBox groupBox42;
        private RadioButton radioButton_TCPIP;
        private RadioButton radioButton_SerialPort;
        private Button button_WriteCatalinas;
        private RichTextBox textBox_FilesToWriteForTheCatalinas;
        private RichTextBox richTextBox_SyntisazerL1;
        private RichTextBox richTextBox_SyntisazerL2;
        private ComboBox comboBox1;
        private Label label20;
        private Label label21;
        private Label label22;
        private ComboBox comboBox_SystemType;
        private Button button_WriteSystemType;
        private Button button_SynthL1;
        private Button button_WriteAllToFlash;
        private Button button_SynthL2;
        private ProgressBar progressBar_WriteToFlash;
        private ToolTip toolTip1;
        private CheckBox checkBox_ParseRxTCPBuffer;
        private CheckBox checkBox_SendEveryOneSecond;
        private TextBox textBox_SendSerialPortPeriod;
        private ProgressBar progressBar_UserStatus;
        private ListBox listBox_CLI_ALLCommands;
        private GroupBox groupBox_CLISendCommand;
        private TextBox textBox_CLIsendperodically;
        private CheckBox checkBox_CLI_SendPeriodically;
        private CheckBox checkBox_CLIDeleteAfterSend;
        private Button button_CLISend;
        private GroupBox groupBox_AllCommands;
        private TextBox txtDataTx;
        private Button button_DeleteCommandsHistory;
        private GroupBox groupBox_Help;
        private TextBox textBox_CLIrecognize3;
        private TextBox textBox_CLIrecognize2;
        private TextBox textBox_CLIrecognize1;
        private TabPage tabPage2_Script;
        private Button button_LoadScriptCLI;
        private RichTextBox richTextBox_Scripts;
        private Button button_RunScript;
        private Label label_Projectname;
        private GroupBox groupBox1;
        private CheckBox checkBox_WriteFrameInformation;
        private Button button_ClearScript;
        private Label label4;
        private TextBox textBox_TimeBetweenComands;
        private Button button_SaveScript;
        private Button button_CheckScriptValidity;
        private CheckBox checkBox_RepeatCLIScript;
        private Button button_StopRunScrip;
        private RichTextBox textBox_CommandHelp;
        private RichTextBox textBox_CLISendCommands;
        private ComboBox cmb_PortName;
        private ComboBox cmb_StopBits;
        private ComboBox cmbParity;
        private SaveFileDialog saveFileDialog_Local;
        private OpenFileDialog openFileDialog_Local;
        private CheckBox checkBox_Openall;
        private Button button_ScriptRunFromFile;
        private static readonly string PREAMBLE = "23";


        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            try
            {


                base.Dispose(disposing);



                if (m_Server != null)
                {
                    m_Server.Close_Server();
                }


            }
            catch
            {
            }


        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox_ServerSettings = new System.Windows.Forms.GroupBox();
            this.textBox_ServerOpen = new System.Windows.Forms.TextBox();
            this.textBox_ServerActive = new System.Windows.Forms.TextBox();
            this.txtPortNo = new System.Windows.Forms.TextBox();
            this.textBox_NumberOfOpenConnections = new System.Windows.Forms.TextBox();
            this.ListenBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDataTx = new System.Windows.Forms.TextBox();
            this.comboBox_ConnectionNumber = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_ServerTCP = new System.Windows.Forms.TabPage();
            this.checkBox_ParseMessages = new System.Windows.Forms.CheckBox();
            this.textBox_IDKey = new System.Windows.Forms.RichTextBox();
            this.checkBox_EchoResponse = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_ServerRecord = new System.Windows.Forms.CheckBox();
            this.checkBox_ServerPause = new System.Windows.Forms.CheckBox();
            this.button_ClearServer = new System.Windows.Forms.Button();
            this.checkBox_StopLogging = new System.Windows.Forms.CheckBox();
            this.TextBox_Server = new System.Windows.Forms.RichTextBox();
            this.checkBox_RecordGeneral = new System.Windows.Forms.CheckBox();
            this.PauseCheck = new System.Windows.Forms.CheckBox();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.tabPage_ClientTCP = new System.Windows.Forms.TabPage();
            this.checkBox_ParseRxTCPBuffer = new System.Windows.Forms.CheckBox();
            this.button_Ping = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_ClearRx = new System.Windows.Forms.Button();
            this.richTextBox_ClientRx = new System.Windows.Forms.RichTextBox();
            this.button43 = new System.Windows.Forms.Button();
            this.button_ClientClose = new System.Windows.Forms.Button();
            this.button_ClientConnect = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox_ClientTx = new System.Windows.Forms.RichTextBox();
            this.textBox_ClientPort = new System.Windows.Forms.TextBox();
            this.textBox_ClientIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage_charts = new System.Windows.Forms.TabPage();
            this.button99 = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox_MaxXAxis = new System.Windows.Forms.TextBox();
            this.textBox_MinXAxis = new System.Windows.Forms.TextBox();
            this.comboBox_ChartUpdateTime = new System.Windows.Forms.ComboBox();
            this.button28 = new System.Windows.Forms.Button();
            this.listBox_Charts = new System.Windows.Forms.ListBox();
            this.button_OpenFolder2 = new System.Windows.Forms.Button();
            this.button_GraphPause = new System.Windows.Forms.Button();
            this.Button_Export_excel = new System.Windows.Forms.Button();
            this.button_ResetGraphs = new System.Windows.Forms.Button();
            this.textBox_graph_XY = new System.Windows.Forms.TextBox();
            this.button_ScreenShot = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage_SerialPort = new System.Windows.Forms.TabPage();
            this.button_OpenPort = new System.Windows.Forms.Button();
            this.groupBox_SendSerialOrMonitorCommands = new System.Windows.Forms.GroupBox();
            this.textBox_SendSerialPortPeriod = new System.Windows.Forms.TextBox();
            this.checkBox_SendEveryOneSecond = new System.Windows.Forms.CheckBox();
            this.checkBox_SendHexdata = new System.Windows.Forms.CheckBox();
            this.textBox_SendSerialPort = new System.Windows.Forms.TextBox();
            this.checkBox_DeleteCommand = new System.Windows.Forms.CheckBox();
            this.button_SendSerialPort = new System.Windows.Forms.Button();
            this.gbPortSettings = new System.Windows.Forms.GroupBox();
            this.cmb_StopBits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmb_PortName = new System.Windows.Forms.ComboBox();
            this.button_ReScanComPort = new System.Windows.Forms.Button();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox_WriteFrameInformation = new System.Windows.Forms.CheckBox();
            this.groupBox_Timer = new System.Windows.Forms.GroupBox();
            this.textBox_TimerTime = new System.Windows.Forms.TextBox();
            this.button_StartStopTimer = new System.Windows.Forms.Button();
            this.button_ResetTimer = new System.Windows.Forms.Button();
            this.textBox_SetTimerTime = new System.Windows.Forms.TextBox();
            this.groupBox_Stopwatch = new System.Windows.Forms.GroupBox();
            this.button_TimerLog = new System.Windows.Forms.Button();
            this.button_Stopwatch_Start_Stop = new System.Windows.Forms.Button();
            this.button_StopwatchReset = new System.Windows.Forms.Button();
            this.textBox_StopWatch = new System.Windows.Forms.TextBox();
            this.checkBox_RxHex = new System.Windows.Forms.CheckBox();
            this.textBox_SerialPortRecognizePattern3 = new System.Windows.Forms.TextBox();
            this.textBox_SerialPortRecognizePattern2 = new System.Windows.Forms.TextBox();
            this.textBox_SerialPortRecognizePattern = new System.Windows.Forms.TextBox();
            this.checkBox_SerialPortRecordLog = new System.Windows.Forms.CheckBox();
            this.checkBox_SerialPortPause = new System.Windows.Forms.CheckBox();
            this.button_ClearSerialPort = new System.Windows.Forms.Button();
            this.SerialPortLogger_TextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage_Commands = new System.Windows.Forms.TabPage();
            this.groupBox40 = new System.Windows.Forms.GroupBox();
            this.tabControl_System = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox_AllCommands = new System.Windows.Forms.GroupBox();
            this.groupBox_Help = new System.Windows.Forms.GroupBox();
            this.textBox_CommandHelp = new System.Windows.Forms.RichTextBox();
            this.listBox_CLI_ALLCommands = new System.Windows.Forms.ListBox();
            this.groupBox_CLISendCommand = new System.Windows.Forms.GroupBox();
            this.textBox_CLISendCommands = new System.Windows.Forms.RichTextBox();
            this.button_DeleteCommandsHistory = new System.Windows.Forms.Button();
            this.textBox_CLIsendperodically = new System.Windows.Forms.TextBox();
            this.checkBox_CLI_SendPeriodically = new System.Windows.Forms.CheckBox();
            this.checkBox_CLIDeleteAfterSend = new System.Windows.Forms.CheckBox();
            this.button_CLISend = new System.Windows.Forms.Button();
            this.tabPage2_Script = new System.Windows.Forms.TabPage();
            this.button_StopRunScrip = new System.Windows.Forms.Button();
            this.checkBox_RepeatCLIScript = new System.Windows.Forms.CheckBox();
            this.button_CheckScriptValidity = new System.Windows.Forms.Button();
            this.button_SaveScript = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TimeBetweenComands = new System.Windows.Forms.TextBox();
            this.button_ClearScript = new System.Windows.Forms.Button();
            this.button_RunScript = new System.Windows.Forms.Button();
            this.richTextBox_Scripts = new System.Windows.Forms.RichTextBox();
            this.button_LoadScriptCLI = new System.Windows.Forms.Button();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.textBox_CLIrecognize3 = new System.Windows.Forms.TextBox();
            this.textBox_CLIrecognize2 = new System.Windows.Forms.TextBox();
            this.textBox_CLIrecognize1 = new System.Windows.Forms.TextBox();
            this.richTextBox_SSPA = new System.Windows.Forms.RichTextBox();
            this.checkBox_RecordMiniAda = new System.Windows.Forms.CheckBox();
            this.checkBox_PauseMiniAda = new System.Windows.Forms.CheckBox();
            this.button_ClearMiniAda = new System.Windows.Forms.Button();
            this.groupBox42 = new System.Windows.Forms.GroupBox();
            this.radioButton_TCPIP = new System.Windows.Forms.RadioButton();
            this.radioButton_SerialPort = new System.Windows.Forms.RadioButton();
            this.button_OpenFolder = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.S1_Configuration = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.TextBox_Odometer = new System.Windows.Forms.TextBox();
            this.button19 = new System.Windows.Forms.Button();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.textBox_ModemSocket = new System.Windows.Forms.TextBox();
            this.textBox_ModemRetries = new System.Windows.Forms.TextBox();
            this.textBox_ModemTimeOut = new System.Windows.Forms.TextBox();
            this.button25 = new System.Windows.Forms.Button();
            this.textBox_ModemPrimeryPort = new System.Windows.Forms.TextBox();
            this.textBox_ModemPrimeryHost = new System.Windows.Forms.TextBox();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.textBox_ForginPassword = new System.Windows.Forms.TextBox();
            this.button27 = new System.Windows.Forms.Button();
            this.textBox_ForginAcessPoint = new System.Windows.Forms.TextBox();
            this.textBox_ForginSecondaryDNS = new System.Windows.Forms.TextBox();
            this.textBox_ForginUserName = new System.Windows.Forms.TextBox();
            this.textBox_ForginPrimeryDNS = new System.Windows.Forms.TextBox();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.textBox_HomePassword = new System.Windows.Forms.TextBox();
            this.button26 = new System.Windows.Forms.Button();
            this.textBox_HomeAcessPoint = new System.Windows.Forms.TextBox();
            this.textBox_HomeSecondaryDNS = new System.Windows.Forms.TextBox();
            this.textBox_HomeUserName = new System.Windows.Forms.TextBox();
            this.textBox_HomePrimeryDNS = new System.Windows.Forms.TextBox();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox1 = new System.Windows.Forms.TextBox();
            this.button24 = new System.Windows.Forms.Button();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.TextBox_NormalStatusDuration = new System.Windows.Forms.TextBox();
            this.button23 = new System.Windows.Forms.Button();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_SpeedLimit2 = new System.Windows.Forms.TextBox();
            this.maskedTextBox_SpeedLimit3 = new System.Windows.Forms.TextBox();
            this.maskedTextBox_SpeedLimit1 = new System.Windows.Forms.TextBox();
            this.button22 = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.comboBox_DispatchSpeed = new System.Windows.Forms.ComboBox();
            this.button21 = new System.Windows.Forms.Button();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.comboBox_KillEngine = new System.Windows.Forms.ComboBox();
            this.button20 = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TiltTowSens = new System.Windows.Forms.TextBox();
            this.comboBox_TiltTowSensState = new System.Windows.Forms.ComboBox();
            this.button18 = new System.Windows.Forms.Button();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_HitSensitivity = new System.Windows.Forms.TextBox();
            this.comboBox_HitState = new System.Windows.Forms.ComboBox();
            this.button17 = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_ShockDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_ShockWindow = new System.Windows.Forms.TextBox();
            this.comboBox_ShockState = new System.Windows.Forms.ComboBox();
            this.button16 = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TiltDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TiltWindow = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TiltAngle = new System.Windows.Forms.TextBox();
            this.comboBox1_TiltState = new System.Windows.Forms.ComboBox();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TowDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TowWindow = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TowAngle = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.comboBox_SleepPolicy = new System.Windows.Forms.ComboBox();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBox_AlarmPilicy = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_SetTimeDate = new System.Windows.Forms.DateTimePicker();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox_BatThreshold = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_OutputDuration = new System.Windows.Forms.TextBox();
            this.comboBox_OutputNum = new System.Windows.Forms.ComboBox();
            this.comboBox_OutputControl = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.comboBox_OutputPulseLevel = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_InputDuration = new System.Windows.Forms.TextBox();
            this.comboBox_InputNum1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Interupt = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.textBox_NewPassword = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.comboBox_SMSControl = new System.Windows.Forms.ComboBox();
            this.button_SMSControl = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.textBox_FreeText = new System.Windows.Forms.TextBox();
            this.comboBox_InputIndex = new System.Windows.Forms.ComboBox();
            this.button_SetFreeText = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox3_Subscriber3 = new System.Windows.Forms.TextBox();
            this.maskedTextBox2_Subscriber2 = new System.Windows.Forms.TextBox();
            this.maskedTextBox1_Subscriber1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox_SMSPhoneNumber = new System.Windows.Forms.TextBox();
            this.button_SendAllCheckedSMS = new System.Windows.Forms.Button();
            this.button_SendSelectedSMS = new System.Windows.Forms.Button();
            this.button_Ring = new System.Windows.Forms.Button();
            this.comboBox_SystemType = new System.Windows.Forms.ComboBox();
            this.timer_General_100ms = new System.Windows.Forms.Timer(this.components);
            this.timer_General_1Second = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.groupBox_PhoneNumber = new System.Windows.Forms.GroupBox();
            this.Label_SerialPortRx = new System.Windows.Forms.Label();
            this.label_SerialPortConnected = new System.Windows.Forms.Label();
            this.Label_SerialPortTx = new System.Windows.Forms.Label();
            this.groupBox_SerialPort = new System.Windows.Forms.GroupBox();
            this.label_SerialPortStatus = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressBar_UserStatus = new System.Windows.Forms.ProgressBar();
            this.button97 = new System.Windows.Forms.Button();
            this.textBox_SystemStatus = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_ClentTCPStatus = new System.Windows.Forms.GroupBox();
            this.label_TCPClient = new System.Windows.Forms.Label();
            this.Label_TCPClientTx = new System.Windows.Forms.Label();
            this.label_ClientTCPConnected = new System.Windows.Forms.Label();
            this.Label_TCPClientRx = new System.Windows.Forms.Label();
            this.checkedListBox_PhoneBook = new System.Windows.Forms.CheckedListBox();
            this.button_AddContact = new System.Windows.Forms.Button();
            this.button_RemoveContact = new System.Windows.Forms.Button();
            this.button_ExportToXML = new System.Windows.Forms.Button();
            this.button_ImportToXML = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.richTextBox_ContactDetails = new System.Windows.Forms.RichTextBox();
            this.button34 = new System.Windows.Forms.Button();
            this.richTextBox_TextSendSMS = new System.Windows.Forms.RichTextBox();
            this.label_SMSSendCharacters = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox_SendSMSAsIs = new System.Windows.Forms.CheckBox();
            this.checkBox_SMSencrypted = new System.Windows.Forms.CheckBox();
            this.GrooupBox_Encryption = new System.Windows.Forms.GroupBox();
            this.textBox_UnitIDForSMS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_CodeArrayForSMS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox_ModemStatus = new System.Windows.Forms.RichTextBox();
            this.comboBox_ComportSMS = new System.Windows.Forms.ComboBox();
            this.button36 = new System.Windows.Forms.Button();
            this.checkBox_OpenPortSMS = new System.Windows.Forms.CheckBox();
            this.checkBox_DebugSMS = new System.Windows.Forms.CheckBox();
            this.button_ClearSMSConsole = new System.Windows.Forms.Button();
            this.checkBox_PauseSMSConsole = new System.Windows.Forms.CheckBox();
            this.checkBox_RecordSMSConsole = new System.Windows.Forms.CheckBox();
            this.richTextBox_SMSConsole = new System.Windows.Forms.RichTextBox();
            this.button41 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.listBox_SMSCommands = new System.Windows.Forms.ListBox();
            this.button_WriteCatalinas = new System.Windows.Forms.Button();
            this.textBox_FilesToWriteForTheCatalinas = new System.Windows.Forms.RichTextBox();
            this.richTextBox_SyntisazerL1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox_SyntisazerL2 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.button_WriteSystemType = new System.Windows.Forms.Button();
            this.button_SynthL1 = new System.Windows.Forms.Button();
            this.button_WriteAllToFlash = new System.Windows.Forms.Button();
            this.button_SynthL2 = new System.Windows.Forms.Button();
            this.progressBar_WriteToFlash = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_Projectname = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog_Local = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog_Local = new System.Windows.Forms.OpenFileDialog();
            this.checkBox_Openall = new System.Windows.Forms.CheckBox();
            this.button_ScriptRunFromFile = new System.Windows.Forms.Button();
            this.groupBox_ServerSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_ServerTCP.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage_ClientTCP.SuspendLayout();
            this.tabPage_charts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage_SerialPort.SuspendLayout();
            this.groupBox_SendSerialOrMonitorCommands.SuspendLayout();
            this.gbPortSettings.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox_Timer.SuspendLayout();
            this.groupBox_Stopwatch.SuspendLayout();
            this.tabPage_Commands.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.tabControl_System.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_AllCommands.SuspendLayout();
            this.groupBox_Help.SuspendLayout();
            this.groupBox_CLISendCommand.SuspendLayout();
            this.tabPage2_Script.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.groupBox42.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.S1_Configuration.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox_PhoneNumber.SuspendLayout();
            this.groupBox_SerialPort.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_ClentTCPStatus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_ServerSettings
            // 
            this.groupBox_ServerSettings.Controls.Add(this.textBox_ServerOpen);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_ServerActive);
            this.groupBox_ServerSettings.Controls.Add(this.txtPortNo);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_NumberOfOpenConnections);
            this.groupBox_ServerSettings.Controls.Add(this.ListenBox);
            this.groupBox_ServerSettings.Controls.Add(this.label1);
            this.groupBox_ServerSettings.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ServerSettings.Location = new System.Drawing.Point(6, 3);
            this.groupBox_ServerSettings.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_ServerSettings.Name = "groupBox_ServerSettings";
            this.groupBox_ServerSettings.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_ServerSettings.Size = new System.Drawing.Size(444, 56);
            this.groupBox_ServerSettings.TabIndex = 0;
            this.groupBox_ServerSettings.TabStop = false;
            this.groupBox_ServerSettings.Text = "Server Settings";
            // 
            // textBox_ServerOpen
            // 
            this.textBox_ServerOpen.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ServerOpen.ForeColor = System.Drawing.Color.White;
            this.textBox_ServerOpen.Location = new System.Drawing.Point(321, 15);
            this.textBox_ServerOpen.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ServerOpen.Multiline = true;
            this.textBox_ServerOpen.Name = "textBox_ServerOpen";
            this.textBox_ServerOpen.ReadOnly = true;
            this.textBox_ServerOpen.Size = new System.Drawing.Size(82, 25);
            this.textBox_ServerOpen.TabIndex = 7;
            this.textBox_ServerOpen.Text = "Connected";
            // 
            // textBox_ServerActive
            // 
            this.textBox_ServerActive.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ServerActive.ForeColor = System.Drawing.Color.White;
            this.textBox_ServerActive.Location = new System.Drawing.Point(261, 15);
            this.textBox_ServerActive.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ServerActive.Multiline = true;
            this.textBox_ServerActive.Name = "textBox_ServerActive";
            this.textBox_ServerActive.ReadOnly = true;
            this.textBox_ServerActive.Size = new System.Drawing.Size(56, 25);
            this.textBox_ServerActive.TabIndex = 6;
            this.textBox_ServerActive.Text = "Active";
            // 
            // txtPortNo
            // 
            this.txtPortNo.Location = new System.Drawing.Point(142, 20);
            this.txtPortNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Size = new System.Drawing.Size(38, 23);
            this.txtPortNo.TabIndex = 1;
            this.txtPortNo.Text = "7000";
            this.txtPortNo.TextChanged += new System.EventHandler(this.TxtPortNo_TextChanged);
            // 
            // textBox_NumberOfOpenConnections
            // 
            this.textBox_NumberOfOpenConnections.ForeColor = System.Drawing.Color.White;
            this.textBox_NumberOfOpenConnections.Location = new System.Drawing.Point(408, 15);
            this.textBox_NumberOfOpenConnections.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_NumberOfOpenConnections.Name = "textBox_NumberOfOpenConnections";
            this.textBox_NumberOfOpenConnections.ReadOnly = true;
            this.textBox_NumberOfOpenConnections.Size = new System.Drawing.Size(24, 23);
            this.textBox_NumberOfOpenConnections.TabIndex = 5;
            this.textBox_NumberOfOpenConnections.TextChanged += new System.EventHandler(this.TextBox_NumberOfOpenConnections_TextChanged);
            // 
            // ListenBox
            // 
            this.ListenBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ListenBox.AutoSize = true;
            this.ListenBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListenBox.Location = new System.Drawing.Point(184, 16);
            this.ListenBox.Margin = new System.Windows.Forms.Padding(2);
            this.ListenBox.Name = "ListenBox";
            this.ListenBox.Size = new System.Drawing.Size(74, 28);
            this.ListenBox.TabIndex = 4;
            this.ListenBox.Text = "Listening";
            this.ListenBox.UseVisualStyleBackColor = true;
            this.ListenBox.CheckedChanged += new System.EventHandler(this.ListenBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port Number:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDataTx);
            this.groupBox2.Controls.Add(this.comboBox_ConnectionNumber);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(2, 63);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(250, 93);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Data";
            // 
            // txtDataTx
            // 
            this.txtDataTx.Location = new System.Drawing.Point(13, 18);
            this.txtDataTx.Name = "txtDataTx";
            this.txtDataTx.Size = new System.Drawing.Size(232, 26);
            this.txtDataTx.TabIndex = 3;
            // 
            // comboBox_ConnectionNumber
            // 
            this.comboBox_ConnectionNumber.FormattingEnabled = true;
            this.comboBox_ConnectionNumber.Location = new System.Drawing.Point(89, 50);
            this.comboBox_ConnectionNumber.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_ConnectionNumber.Name = "comboBox_ConnectionNumber";
            this.comboBox_ConnectionNumber.Size = new System.Drawing.Size(156, 26);
            this.comboBox_ConnectionNumber.TabIndex = 2;
            this.comboBox_ConnectionNumber.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_ServerTCP);
            this.tabControl_Main.Controls.Add(this.tabPage_ClientTCP);
            this.tabControl_Main.Controls.Add(this.tabPage_charts);
            this.tabControl_Main.Controls.Add(this.tabPage_SerialPort);
            this.tabControl_Main.Controls.Add(this.tabPage_Commands);
            this.tabControl_Main.Location = new System.Drawing.Point(4, 5);
            this.tabControl_Main.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1422, 679);
            this.tabControl_Main.TabIndex = 8;
            this.tabControl_Main.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tabControl_Main_PreviewKeyDown);
            // 
            // tabPage_ServerTCP
            // 
            this.tabPage_ServerTCP.Controls.Add(this.checkBox_ParseMessages);
            this.tabPage_ServerTCP.Controls.Add(this.textBox_IDKey);
            this.tabPage_ServerTCP.Controls.Add(this.checkBox_EchoResponse);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox_ServerSettings);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox2);
            this.tabPage_ServerTCP.Controls.Add(this.groupBox3);
            this.tabPage_ServerTCP.Location = new System.Drawing.Point(4, 27);
            this.tabPage_ServerTCP.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_ServerTCP.Name = "tabPage_ServerTCP";
            this.tabPage_ServerTCP.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_ServerTCP.Size = new System.Drawing.Size(1414, 648);
            this.tabPage_ServerTCP.TabIndex = 0;
            this.tabPage_ServerTCP.Text = "Server TCP";
            this.tabPage_ServerTCP.UseVisualStyleBackColor = true;
            // 
            // checkBox_ParseMessages
            // 
            this.checkBox_ParseMessages.AutoSize = true;
            this.checkBox_ParseMessages.Location = new System.Drawing.Point(123, 163);
            this.checkBox_ParseMessages.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_ParseMessages.Name = "checkBox_ParseMessages";
            this.checkBox_ParseMessages.Size = new System.Drawing.Size(124, 22);
            this.checkBox_ParseMessages.TabIndex = 103;
            this.checkBox_ParseMessages.Text = "Parse messages";
            this.checkBox_ParseMessages.UseVisualStyleBackColor = true;
            this.checkBox_ParseMessages.CheckedChanged += new System.EventHandler(this.CheckBox_ParseMessages_CheckedChanged);
            // 
            // textBox_IDKey
            // 
            this.textBox_IDKey.Location = new System.Drawing.Point(1119, 75);
            this.textBox_IDKey.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_IDKey.Name = "textBox_IDKey";
            this.textBox_IDKey.Size = new System.Drawing.Size(290, 148);
            this.textBox_IDKey.TabIndex = 102;
            this.textBox_IDKey.Text = "";
            this.textBox_IDKey.Visible = false;
            // 
            // checkBox_EchoResponse
            // 
            this.checkBox_EchoResponse.AutoSize = true;
            this.checkBox_EchoResponse.Location = new System.Drawing.Point(4, 163);
            this.checkBox_EchoResponse.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_EchoResponse.Name = "checkBox_EchoResponse";
            this.checkBox_EchoResponse.Size = new System.Drawing.Size(117, 22);
            this.checkBox_EchoResponse.TabIndex = 10;
            this.checkBox_EchoResponse.Text = "Send ACK Back";
            this.checkBox_EchoResponse.UseVisualStyleBackColor = true;
            this.checkBox_EchoResponse.CheckedChanged += new System.EventHandler(this.CheckBox_EchoResponse_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_ServerRecord);
            this.groupBox3.Controls.Add(this.checkBox_ServerPause);
            this.groupBox3.Controls.Add(this.button_ClearServer);
            this.groupBox3.Controls.Add(this.checkBox_StopLogging);
            this.groupBox3.Controls.Add(this.TextBox_Server);
            this.groupBox3.Controls.Add(this.checkBox_RecordGeneral);
            this.groupBox3.Controls.Add(this.PauseCheck);
            this.groupBox3.Controls.Add(this.Clear_btn);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(258, 63);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(856, 591);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server Console";
            // 
            // checkBox_ServerRecord
            // 
            this.checkBox_ServerRecord.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_ServerRecord.AutoSize = true;
            this.checkBox_ServerRecord.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ServerRecord.Location = new System.Drawing.Point(139, 560);
            this.checkBox_ServerRecord.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_ServerRecord.Name = "checkBox_ServerRecord";
            this.checkBox_ServerRecord.Size = new System.Drawing.Size(64, 29);
            this.checkBox_ServerRecord.TabIndex = 108;
            this.checkBox_ServerRecord.Text = "Record";
            this.checkBox_ServerRecord.UseVisualStyleBackColor = true;
            // 
            // checkBox_ServerPause
            // 
            this.checkBox_ServerPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_ServerPause.AutoSize = true;
            this.checkBox_ServerPause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ServerPause.Location = new System.Drawing.Point(81, 560);
            this.checkBox_ServerPause.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_ServerPause.Name = "checkBox_ServerPause";
            this.checkBox_ServerPause.Size = new System.Drawing.Size(58, 29);
            this.checkBox_ServerPause.TabIndex = 107;
            this.checkBox_ServerPause.Text = "Pause";
            this.checkBox_ServerPause.UseVisualStyleBackColor = true;
            // 
            // button_ClearServer
            // 
            this.button_ClearServer.Location = new System.Drawing.Point(6, 560);
            this.button_ClearServer.Margin = new System.Windows.Forms.Padding(2);
            this.button_ClearServer.Name = "button_ClearServer";
            this.button_ClearServer.Size = new System.Drawing.Size(69, 22);
            this.button_ClearServer.TabIndex = 104;
            this.button_ClearServer.Text = "Clear";
            this.button_ClearServer.UseVisualStyleBackColor = true;
            // 
            // checkBox_StopLogging
            // 
            this.checkBox_StopLogging.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_StopLogging.AutoSize = true;
            this.checkBox_StopLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_StopLogging.Location = new System.Drawing.Point(279, 609);
            this.checkBox_StopLogging.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_StopLogging.Name = "checkBox_StopLogging";
            this.checkBox_StopLogging.Size = new System.Drawing.Size(105, 26);
            this.checkBox_StopLogging.TabIndex = 8;
            this.checkBox_StopLogging.Text = "Stop Printing";
            this.checkBox_StopLogging.UseVisualStyleBackColor = true;
            // 
            // TextBox_Server
            // 
            this.TextBox_Server.BackColor = System.Drawing.Color.LightGray;
            this.TextBox_Server.EnableAutoDragDrop = true;
            this.TextBox_Server.Location = new System.Drawing.Point(6, 19);
            this.TextBox_Server.Margin = new System.Windows.Forms.Padding(2);
            this.TextBox_Server.Name = "TextBox_Server";
            this.TextBox_Server.Size = new System.Drawing.Size(845, 535);
            this.TextBox_Server.TabIndex = 0;
            this.TextBox_Server.Text = "";
            this.TextBox_Server.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // checkBox_RecordGeneral
            // 
            this.checkBox_RecordGeneral.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordGeneral.AutoSize = true;
            this.checkBox_RecordGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordGeneral.Location = new System.Drawing.Point(382, 609);
            this.checkBox_RecordGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_RecordGeneral.Name = "checkBox_RecordGeneral";
            this.checkBox_RecordGeneral.Size = new System.Drawing.Size(98, 26);
            this.checkBox_RecordGeneral.TabIndex = 7;
            this.checkBox_RecordGeneral.Text = "Record Log";
            this.checkBox_RecordGeneral.UseVisualStyleBackColor = true;
            this.checkBox_RecordGeneral.CheckedChanged += new System.EventHandler(this.CheckBox_RecordGeneral_CheckedChanged);
            // 
            // PauseCheck
            // 
            this.PauseCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.PauseCheck.AutoSize = true;
            this.PauseCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseCheck.Location = new System.Drawing.Point(478, 609);
            this.PauseCheck.Margin = new System.Windows.Forms.Padding(2);
            this.PauseCheck.Name = "PauseCheck";
            this.PauseCheck.Size = new System.Drawing.Size(61, 26);
            this.PauseCheck.TabIndex = 5;
            this.PauseCheck.Text = "Pause";
            this.PauseCheck.UseVisualStyleBackColor = true;
            // 
            // Clear_btn
            // 
            this.Clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_btn.Location = new System.Drawing.Point(539, 609);
            this.Clear_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(57, 26);
            this.Clear_btn.TabIndex = 6;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            // 
            // tabPage_ClientTCP
            // 
            this.tabPage_ClientTCP.Controls.Add(this.checkBox_ParseRxTCPBuffer);
            this.tabPage_ClientTCP.Controls.Add(this.button_Ping);
            this.tabPage_ClientTCP.Controls.Add(this.label10);
            this.tabPage_ClientTCP.Controls.Add(this.label9);
            this.tabPage_ClientTCP.Controls.Add(this.button_ClearRx);
            this.tabPage_ClientTCP.Controls.Add(this.richTextBox_ClientRx);
            this.tabPage_ClientTCP.Controls.Add(this.button43);
            this.tabPage_ClientTCP.Controls.Add(this.button_ClientClose);
            this.tabPage_ClientTCP.Controls.Add(this.button_ClientConnect);
            this.tabPage_ClientTCP.Controls.Add(this.button3);
            this.tabPage_ClientTCP.Controls.Add(this.richTextBox_ClientTx);
            this.tabPage_ClientTCP.Controls.Add(this.textBox_ClientPort);
            this.tabPage_ClientTCP.Controls.Add(this.textBox_ClientIP);
            this.tabPage_ClientTCP.Controls.Add(this.label8);
            this.tabPage_ClientTCP.Controls.Add(this.label7);
            this.tabPage_ClientTCP.Location = new System.Drawing.Point(4, 27);
            this.tabPage_ClientTCP.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_ClientTCP.Name = "tabPage_ClientTCP";
            this.tabPage_ClientTCP.Size = new System.Drawing.Size(1414, 648);
            this.tabPage_ClientTCP.TabIndex = 9;
            this.tabPage_ClientTCP.Text = "Client TCP";
            this.tabPage_ClientTCP.UseVisualStyleBackColor = true;
            // 
            // checkBox_ParseRxTCPBuffer
            // 
            this.checkBox_ParseRxTCPBuffer.AutoSize = true;
            this.checkBox_ParseRxTCPBuffer.Location = new System.Drawing.Point(1084, 349);
            this.checkBox_ParseRxTCPBuffer.Name = "checkBox_ParseRxTCPBuffer";
            this.checkBox_ParseRxTCPBuffer.Size = new System.Drawing.Size(146, 22);
            this.checkBox_ParseRxTCPBuffer.TabIndex = 15;
            this.checkBox_ParseRxTCPBuffer.Text = "Parse Rx TCP Buffer";
            this.checkBox_ParseRxTCPBuffer.UseVisualStyleBackColor = true;
            // 
            // button_Ping
            // 
            this.button_Ping.Location = new System.Drawing.Point(178, 75);
            this.button_Ping.Margin = new System.Windows.Forms.Padding(2);
            this.button_Ping.Name = "button_Ping";
            this.button_Ping.Size = new System.Drawing.Size(91, 22);
            this.button_Ping.TabIndex = 14;
            this.button_Ping.Text = "Ping";
            this.button_Ping.UseVisualStyleBackColor = true;
            this.button_Ping.Click += new System.EventHandler(this.button72_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(548, 294);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "Rx - Data Received";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(548, 86);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tx - Data Send";
            // 
            // button_ClearRx
            // 
            this.button_ClearRx.Location = new System.Drawing.Point(1084, 322);
            this.button_ClearRx.Margin = new System.Windows.Forms.Padding(2);
            this.button_ClearRx.Name = "button_ClearRx";
            this.button_ClearRx.Size = new System.Drawing.Size(69, 22);
            this.button_ClearRx.TabIndex = 11;
            this.button_ClearRx.Text = "Clear Rx";
            this.button_ClearRx.UseVisualStyleBackColor = true;
            this.button_ClearRx.Click += new System.EventHandler(this.Button_ClearRx_Click);
            // 
            // richTextBox_ClientRx
            // 
            this.richTextBox_ClientRx.Location = new System.Drawing.Point(31, 323);
            this.richTextBox_ClientRx.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_ClientRx.Name = "richTextBox_ClientRx";
            this.richTextBox_ClientRx.ReadOnly = true;
            this.richTextBox_ClientRx.Size = new System.Drawing.Size(1049, 162);
            this.richTextBox_ClientRx.TabIndex = 9;
            this.richTextBox_ClientRx.Text = "";
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(1086, 141);
            this.button43.Margin = new System.Windows.Forms.Padding(2);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(68, 23);
            this.button43.TabIndex = 8;
            this.button43.Text = "Clear Tx";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.Button43_Click_1);
            // 
            // button_ClientClose
            // 
            this.button_ClientClose.Location = new System.Drawing.Point(105, 77);
            this.button_ClientClose.Margin = new System.Windows.Forms.Padding(2);
            this.button_ClientClose.Name = "button_ClientClose";
            this.button_ClientClose.Size = new System.Drawing.Size(69, 22);
            this.button_ClientClose.TabIndex = 7;
            this.button_ClientClose.Text = "Close";
            this.button_ClientClose.UseVisualStyleBackColor = true;
            this.button_ClientClose.Click += new System.EventHandler(this.Button42_Click_1);
            // 
            // button_ClientConnect
            // 
            this.button_ClientConnect.Location = new System.Drawing.Point(31, 78);
            this.button_ClientConnect.Margin = new System.Windows.Forms.Padding(2);
            this.button_ClientConnect.Name = "button_ClientConnect";
            this.button_ClientConnect.Size = new System.Drawing.Size(69, 22);
            this.button_ClientConnect.TabIndex = 6;
            this.button_ClientConnect.Text = "Connect";
            this.button_ClientConnect.UseVisualStyleBackColor = true;
            this.button_ClientConnect.Click += new System.EventHandler(this.Button_ClientConnect_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1086, 112);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 22);
            this.button3.TabIndex = 5;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click_4);
            // 
            // richTextBox_ClientTx
            // 
            this.richTextBox_ClientTx.Location = new System.Drawing.Point(31, 114);
            this.richTextBox_ClientTx.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_ClientTx.Name = "richTextBox_ClientTx";
            this.richTextBox_ClientTx.Size = new System.Drawing.Size(1050, 162);
            this.richTextBox_ClientTx.TabIndex = 4;
            this.richTextBox_ClientTx.Text = "Send Data to Server";
            // 
            // textBox_ClientPort
            // 
            this.textBox_ClientPort.Location = new System.Drawing.Point(114, 46);
            this.textBox_ClientPort.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ClientPort.Name = "textBox_ClientPort";
            this.textBox_ClientPort.Size = new System.Drawing.Size(92, 26);
            this.textBox_ClientPort.TabIndex = 3;
            this.textBox_ClientPort.Text = "7";
            this.textBox_ClientPort.TextChanged += new System.EventHandler(this.textBox_ClientPort_TextChanged);
            // 
            // textBox_ClientIP
            // 
            this.textBox_ClientIP.Location = new System.Drawing.Point(114, 17);
            this.textBox_ClientIP.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ClientIP.Name = "textBox_ClientIP";
            this.textBox_ClientIP.Size = new System.Drawing.Size(92, 26);
            this.textBox_ClientIP.TabIndex = 2;
            this.textBox_ClientIP.Text = "192.168.1.10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Host or IP";
            // 
            // tabPage_charts
            // 
            this.tabPage_charts.Controls.Add(this.button99);
            this.tabPage_charts.Controls.Add(this.label37);
            this.tabPage_charts.Controls.Add(this.textBox_MaxXAxis);
            this.tabPage_charts.Controls.Add(this.textBox_MinXAxis);
            this.tabPage_charts.Controls.Add(this.comboBox_ChartUpdateTime);
            this.tabPage_charts.Controls.Add(this.button28);
            this.tabPage_charts.Controls.Add(this.listBox_Charts);
            this.tabPage_charts.Controls.Add(this.button_OpenFolder2);
            this.tabPage_charts.Controls.Add(this.button_GraphPause);
            this.tabPage_charts.Controls.Add(this.Button_Export_excel);
            this.tabPage_charts.Controls.Add(this.button_ResetGraphs);
            this.tabPage_charts.Controls.Add(this.textBox_graph_XY);
            this.tabPage_charts.Controls.Add(this.button_ScreenShot);
            this.tabPage_charts.Controls.Add(this.chart1);
            this.tabPage_charts.Location = new System.Drawing.Point(4, 27);
            this.tabPage_charts.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_charts.Name = "tabPage_charts";
            this.tabPage_charts.Size = new System.Drawing.Size(1414, 648);
            this.tabPage_charts.TabIndex = 7;
            this.tabPage_charts.Text = "Charts";
            this.tabPage_charts.UseVisualStyleBackColor = true;
            // 
            // button99
            // 
            this.button99.Location = new System.Drawing.Point(121, 367);
            this.button99.Margin = new System.Windows.Forms.Padding(2);
            this.button99.Name = "button99";
            this.button99.Size = new System.Drawing.Size(53, 22);
            this.button99.TabIndex = 84;
            this.button99.Text = "auto";
            this.button99.UseVisualStyleBackColor = true;
            this.button99.Click += new System.EventHandler(this.button99_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(2, 343);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(102, 18);
            this.label37.TabIndex = 83;
            this.label37.Text = "Min/Max X axis";
            // 
            // textBox_MaxXAxis
            // 
            this.textBox_MaxXAxis.Location = new System.Drawing.Point(56, 366);
            this.textBox_MaxXAxis.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MaxXAxis.Name = "textBox_MaxXAxis";
            this.textBox_MaxXAxis.Size = new System.Drawing.Size(59, 26);
            this.textBox_MaxXAxis.TabIndex = 82;
            this.textBox_MaxXAxis.TextChanged += new System.EventHandler(this.textBox_MaxXAxis_TextChanged);
            // 
            // textBox_MinXAxis
            // 
            this.textBox_MinXAxis.Location = new System.Drawing.Point(2, 366);
            this.textBox_MinXAxis.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MinXAxis.Name = "textBox_MinXAxis";
            this.textBox_MinXAxis.Size = new System.Drawing.Size(44, 26);
            this.textBox_MinXAxis.TabIndex = 81;
            this.textBox_MinXAxis.TextChanged += new System.EventHandler(this.textBox_MinXAxis_TextChanged);
            // 
            // comboBox_ChartUpdateTime
            // 
            this.comboBox_ChartUpdateTime.FormattingEnabled = true;
            this.comboBox_ChartUpdateTime.Items.AddRange(new object[] {
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000",
            "10000"});
            this.comboBox_ChartUpdateTime.Location = new System.Drawing.Point(5, 593);
            this.comboBox_ChartUpdateTime.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_ChartUpdateTime.Name = "comboBox_ChartUpdateTime";
            this.comboBox_ChartUpdateTime.Size = new System.Drawing.Size(169, 26);
            this.comboBox_ChartUpdateTime.TabIndex = 80;
            this.comboBox_ChartUpdateTime.Text = "Update time ms";
            this.comboBox_ChartUpdateTime.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ChartUpdateTime_SelectedIndexChanged);
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(2, 538);
            this.button28.Margin = new System.Windows.Forms.Padding(2);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(170, 22);
            this.button28.TabIndex = 79;
            this.button28.Text = "Reset X point";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.Button28_Click_2);
            // 
            // listBox_Charts
            // 
            this.listBox_Charts.FormattingEnabled = true;
            this.listBox_Charts.ItemHeight = 18;
            this.listBox_Charts.Location = new System.Drawing.Point(2, 162);
            this.listBox_Charts.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_Charts.Name = "listBox_Charts";
            this.listBox_Charts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Charts.Size = new System.Drawing.Size(170, 148);
            this.listBox_Charts.TabIndex = 78;
            this.listBox_Charts.SelectedIndexChanged += new System.EventHandler(this.ListBox_Charts_SelectedIndexChanged);
            this.listBox_Charts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_Charts_KeyDown);
            this.listBox_Charts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox_Charts_KeyPress);
            // 
            // button_OpenFolder2
            // 
            this.button_OpenFolder2.Location = new System.Drawing.Point(4, 420);
            this.button_OpenFolder2.Margin = new System.Windows.Forms.Padding(2);
            this.button_OpenFolder2.Name = "button_OpenFolder2";
            this.button_OpenFolder2.Size = new System.Drawing.Size(169, 26);
            this.button_OpenFolder2.TabIndex = 77;
            this.button_OpenFolder2.Text = "Open Local Folder";
            this.button_OpenFolder2.UseVisualStyleBackColor = true;
            this.button_OpenFolder2.Click += new System.EventHandler(this.Button_OpenFolder2_Click);
            // 
            // button_GraphPause
            // 
            this.button_GraphPause.Location = new System.Drawing.Point(2, 565);
            this.button_GraphPause.Margin = new System.Windows.Forms.Padding(2);
            this.button_GraphPause.Name = "button_GraphPause";
            this.button_GraphPause.Size = new System.Drawing.Size(170, 22);
            this.button_GraphPause.TabIndex = 8;
            this.button_GraphPause.Text = "Pause";
            this.button_GraphPause.UseVisualStyleBackColor = true;
            this.button_GraphPause.Click += new System.EventHandler(this.Button_GraphPause_Click);
            // 
            // Button_Export_excel
            // 
            this.Button_Export_excel.Location = new System.Drawing.Point(2, 451);
            this.Button_Export_excel.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Export_excel.Name = "Button_Export_excel";
            this.Button_Export_excel.Size = new System.Drawing.Size(170, 22);
            this.Button_Export_excel.TabIndex = 7;
            this.Button_Export_excel.Text = "Export to excel";
            this.Button_Export_excel.UseVisualStyleBackColor = true;
            this.Button_Export_excel.Click += new System.EventHandler(this.Button_Export_excel_Click);
            // 
            // button_ResetGraphs
            // 
            this.button_ResetGraphs.Location = new System.Drawing.Point(2, 509);
            this.button_ResetGraphs.Margin = new System.Windows.Forms.Padding(2);
            this.button_ResetGraphs.Name = "button_ResetGraphs";
            this.button_ResetGraphs.Size = new System.Drawing.Size(170, 22);
            this.button_ResetGraphs.TabIndex = 6;
            this.button_ResetGraphs.Text = "Reset chart data";
            this.button_ResetGraphs.UseVisualStyleBackColor = true;
            this.button_ResetGraphs.Click += new System.EventHandler(this.Button_ResetGraphs_Click);
            // 
            // textBox_graph_XY
            // 
            this.textBox_graph_XY.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_graph_XY.Location = new System.Drawing.Point(4, 8);
            this.textBox_graph_XY.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_graph_XY.Multiline = true;
            this.textBox_graph_XY.Name = "textBox_graph_XY";
            this.textBox_graph_XY.ReadOnly = true;
            this.textBox_graph_XY.Size = new System.Drawing.Size(170, 149);
            this.textBox_graph_XY.TabIndex = 4;
            this.textBox_graph_XY.Text = "Message box ";
            this.textBox_graph_XY.TextChanged += new System.EventHandler(this.TextBox_graph_XY_TextChanged);
            // 
            // button_ScreenShot
            // 
            this.button_ScreenShot.Location = new System.Drawing.Point(2, 478);
            this.button_ScreenShot.Margin = new System.Windows.Forms.Padding(2);
            this.button_ScreenShot.Name = "button_ScreenShot";
            this.button_ScreenShot.Size = new System.Drawing.Size(170, 22);
            this.button_ScreenShot.TabIndex = 1;
            this.button_ScreenShot.Text = "Take screen shot";
            this.button_ScreenShot.UseVisualStyleBackColor = true;
            this.button_ScreenShot.Click += new System.EventHandler(this.Button_ScreenShot_Click);
            // 
            // chart1
            // 
            chartArea2.AxisX.Title = "Freq";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.Title = "Power [dBm]";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TitleFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(178, 2);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1234, 644);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseClick);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart1_MouseMove);
            // 
            // tabPage_SerialPort
            // 
            this.tabPage_SerialPort.Controls.Add(this.button_OpenPort);
            this.tabPage_SerialPort.Controls.Add(this.groupBox_SendSerialOrMonitorCommands);
            this.tabPage_SerialPort.Controls.Add(this.gbPortSettings);
            this.tabPage_SerialPort.Controls.Add(this.groupBox5);
            this.tabPage_SerialPort.Location = new System.Drawing.Point(4, 27);
            this.tabPage_SerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_SerialPort.Name = "tabPage_SerialPort";
            this.tabPage_SerialPort.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_SerialPort.Size = new System.Drawing.Size(1414, 648);
            this.tabPage_SerialPort.TabIndex = 1;
            this.tabPage_SerialPort.Text = "Serial Port";
            this.tabPage_SerialPort.UseVisualStyleBackColor = true;
            // 
            // button_OpenPort
            // 
            this.button_OpenPort.Location = new System.Drawing.Point(1321, 25);
            this.button_OpenPort.Margin = new System.Windows.Forms.Padding(2);
            this.button_OpenPort.Name = "button_OpenPort";
            this.button_OpenPort.Size = new System.Drawing.Size(83, 71);
            this.button_OpenPort.TabIndex = 11;
            this.button_OpenPort.Text = "Open ";
            this.button_OpenPort.UseVisualStyleBackColor = true;
            this.button_OpenPort.Click += new System.EventHandler(this.Button_OpenPort_Click);
            // 
            // groupBox_SendSerialOrMonitorCommands
            // 
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.textBox_SendSerialPortPeriod);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.checkBox_SendEveryOneSecond);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.checkBox_SendHexdata);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.textBox_SendSerialPort);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.checkBox_DeleteCommand);
            this.groupBox_SendSerialOrMonitorCommands.Controls.Add(this.button_SendSerialPort);
            this.groupBox_SendSerialOrMonitorCommands.Location = new System.Drawing.Point(4, 6);
            this.groupBox_SendSerialOrMonitorCommands.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_SendSerialOrMonitorCommands.Name = "groupBox_SendSerialOrMonitorCommands";
            this.groupBox_SendSerialOrMonitorCommands.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_SendSerialOrMonitorCommands.Size = new System.Drawing.Size(841, 90);
            this.groupBox_SendSerialOrMonitorCommands.TabIndex = 69;
            this.groupBox_SendSerialOrMonitorCommands.TabStop = false;
            this.groupBox_SendSerialOrMonitorCommands.Text = "Send Data to Serial Port";
            // 
            // textBox_SendSerialPortPeriod
            // 
            this.textBox_SendSerialPortPeriod.Location = new System.Drawing.Point(378, 55);
            this.textBox_SendSerialPortPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SendSerialPortPeriod.Name = "textBox_SendSerialPortPeriod";
            this.textBox_SendSerialPortPeriod.Size = new System.Drawing.Size(46, 26);
            this.textBox_SendSerialPortPeriod.TabIndex = 108;
            this.textBox_SendSerialPortPeriod.Text = "10";
            this.textBox_SendSerialPortPeriod.TextChanged += new System.EventHandler(this.textBox_SendSerialPortPeriod_TextChanged);
            // 
            // checkBox_SendEveryOneSecond
            // 
            this.checkBox_SendEveryOneSecond.AutoSize = true;
            this.checkBox_SendEveryOneSecond.Location = new System.Drawing.Point(439, 57);
            this.checkBox_SendEveryOneSecond.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_SendEveryOneSecond.Name = "checkBox_SendEveryOneSecond";
            this.checkBox_SendEveryOneSecond.Size = new System.Drawing.Size(189, 22);
            this.checkBox_SendEveryOneSecond.TabIndex = 6;
            this.checkBox_SendEveryOneSecond.Text = "Send Periodically (100 ms)";
            this.checkBox_SendEveryOneSecond.UseVisualStyleBackColor = true;
            this.checkBox_SendEveryOneSecond.CheckedChanged += new System.EventHandler(this.checkBox_SendEveryOneSecond_CheckedChanged);
            // 
            // checkBox_SendHexdata
            // 
            this.checkBox_SendHexdata.AutoSize = true;
            this.checkBox_SendHexdata.Checked = true;
            this.checkBox_SendHexdata.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SendHexdata.Location = new System.Drawing.Point(252, 58);
            this.checkBox_SendHexdata.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_SendHexdata.Name = "checkBox_SendHexdata";
            this.checkBox_SendHexdata.Size = new System.Drawing.Size(115, 22);
            this.checkBox_SendHexdata.TabIndex = 5;
            this.checkBox_SendHexdata.Text = "Send Hex data";
            this.checkBox_SendHexdata.UseVisualStyleBackColor = true;
            this.checkBox_SendHexdata.CheckedChanged += new System.EventHandler(this.CheckBox_SendHexdata_CheckedChanged);
            // 
            // textBox_SendSerialPort
            // 
            this.textBox_SendSerialPort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_SendSerialPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_SendSerialPort.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SendSerialPort.Location = new System.Drawing.Point(8, 20);
            this.textBox_SendSerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SendSerialPort.Name = "textBox_SendSerialPort";
            this.textBox_SendSerialPort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_SendSerialPort.Size = new System.Drawing.Size(829, 31);
            this.textBox_SendSerialPort.TabIndex = 0;
            this.textBox_SendSerialPort.TextChanged += new System.EventHandler(this.TextBox_SendSerialPort_TextChanged_1);
            this.textBox_SendSerialPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_SendSerialPort_KeyDown);
            this.textBox_SendSerialPort.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBox_SendSerialPort_PreviewKeyDown);
            // 
            // checkBox_DeleteCommand
            // 
            this.checkBox_DeleteCommand.AutoSize = true;
            this.checkBox_DeleteCommand.Location = new System.Drawing.Point(115, 59);
            this.checkBox_DeleteCommand.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_DeleteCommand.Name = "checkBox_DeleteCommand";
            this.checkBox_DeleteCommand.Size = new System.Drawing.Size(135, 22);
            this.checkBox_DeleteCommand.TabIndex = 4;
            this.checkBox_DeleteCommand.Text = "Delete after Send";
            this.checkBox_DeleteCommand.UseVisualStyleBackColor = true;
            // 
            // button_SendSerialPort
            // 
            this.button_SendSerialPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SendSerialPort.Location = new System.Drawing.Point(8, 56);
            this.button_SendSerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.button_SendSerialPort.Name = "button_SendSerialPort";
            this.button_SendSerialPort.Size = new System.Drawing.Size(96, 23);
            this.button_SendSerialPort.TabIndex = 1;
            this.button_SendSerialPort.Text = "Send";
            this.button_SendSerialPort.Click += new System.EventHandler(this.button_SendSerialPort_Click);
            // 
            // gbPortSettings
            // 
            this.gbPortSettings.Controls.Add(this.cmb_StopBits);
            this.gbPortSettings.Controls.Add(this.cmbParity);
            this.gbPortSettings.Controls.Add(this.cmb_PortName);
            this.gbPortSettings.Controls.Add(this.button_ReScanComPort);
            this.gbPortSettings.Controls.Add(this.cmbBaudRate);
            this.gbPortSettings.Controls.Add(this.cmbDataBits);
            this.gbPortSettings.Controls.Add(this.lblComPort);
            this.gbPortSettings.Controls.Add(this.lblStopBits);
            this.gbPortSettings.Controls.Add(this.lblBaudRate);
            this.gbPortSettings.Controls.Add(this.lblDataBits);
            this.gbPortSettings.Controls.Add(this.label3);
            this.gbPortSettings.Location = new System.Drawing.Point(852, 13);
            this.gbPortSettings.Margin = new System.Windows.Forms.Padding(2);
            this.gbPortSettings.Name = "gbPortSettings";
            this.gbPortSettings.Padding = new System.Windows.Forms.Padding(2);
            this.gbPortSettings.Size = new System.Drawing.Size(465, 83);
            this.gbPortSettings.TabIndex = 10;
            this.gbPortSettings.TabStop = false;
            this.gbPortSettings.Text = "COM Serial Port Settings";
            // 
            // cmb_StopBits
            // 
            this.cmb_StopBits.FormattingEnabled = true;
            this.cmb_StopBits.Location = new System.Drawing.Point(305, 35);
            this.cmb_StopBits.Name = "cmb_StopBits";
            this.cmb_StopBits.Size = new System.Drawing.Size(68, 26);
            this.cmb_StopBits.TabIndex = 13;
            this.cmb_StopBits.Text = "1";
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Location = new System.Drawing.Point(168, 35);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(59, 26);
            this.cmbParity.TabIndex = 12;
            this.cmbParity.Text = "Even";
            // 
            // cmb_PortName
            // 
            this.cmb_PortName.FormattingEnabled = true;
            this.cmb_PortName.Location = new System.Drawing.Point(11, 37);
            this.cmb_PortName.Name = "cmb_PortName";
            this.cmb_PortName.Size = new System.Drawing.Size(59, 26);
            this.cmb_PortName.TabIndex = 11;
            // 
            // button_ReScanComPort
            // 
            this.button_ReScanComPort.AutoSize = true;
            this.button_ReScanComPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ReScanComPort.Location = new System.Drawing.Point(378, 33);
            this.button_ReScanComPort.Margin = new System.Windows.Forms.Padding(2);
            this.button_ReScanComPort.Name = "button_ReScanComPort";
            this.button_ReScanComPort.Size = new System.Drawing.Size(80, 33);
            this.button_ReScanComPort.TabIndex = 10;
            this.button_ReScanComPort.Text = "ReScan";
            this.button_ReScanComPort.UseVisualStyleBackColor = true;
            this.button_ReScanComPort.Click += new System.EventHandler(this.Button_ReScanComPort_Click);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(81, 35);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(82, 26);
            this.cmbBaudRate.TabIndex = 3;
            this.cmbBaudRate.Text = "115200";
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.CmbBaudRate_SelectedIndexChanged);
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbDataBits.Location = new System.Drawing.Point(232, 37);
            this.cmbDataBits.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(56, 26);
            this.cmbDataBits.TabIndex = 7;
            this.cmbDataBits.Text = "8";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(8, 18);
            this.lblComPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(71, 18);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "COM Port:";
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(302, 18);
            this.lblStopBits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(66, 18);
            this.lblStopBits.TabIndex = 8;
            this.lblStopBits.Text = "Stop Bits:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(80, 20);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(74, 18);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(229, 19);
            this.lblDataBits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(66, 18);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "Data Bits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parity:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox_WriteFrameInformation);
            this.groupBox5.Controls.Add(this.groupBox_Timer);
            this.groupBox5.Controls.Add(this.groupBox_Stopwatch);
            this.groupBox5.Controls.Add(this.checkBox_RxHex);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern3);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern2);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern);
            this.groupBox5.Controls.Add(this.checkBox_SerialPortRecordLog);
            this.groupBox5.Controls.Add(this.checkBox_SerialPortPause);
            this.groupBox5.Controls.Add(this.button_ClearSerialPort);
            this.groupBox5.Controls.Add(this.SerialPortLogger_TextBox);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(4, 102);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(1405, 553);
            this.groupBox5.TabIndex = 68;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Serial Port Console";
            this.groupBox5.Enter += new System.EventHandler(this.GroupBox5_Enter);
            // 
            // checkBox_WriteFrameInformation
            // 
            this.checkBox_WriteFrameInformation.AutoSize = true;
            this.checkBox_WriteFrameInformation.Location = new System.Drawing.Point(710, 18);
            this.checkBox_WriteFrameInformation.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_WriteFrameInformation.Name = "checkBox_WriteFrameInformation";
            this.checkBox_WriteFrameInformation.Size = new System.Drawing.Size(135, 23);
            this.checkBox_WriteFrameInformation.TabIndex = 108;
            this.checkBox_WriteFrameInformation.Text = "Write frame info";
            this.checkBox_WriteFrameInformation.UseVisualStyleBackColor = true;
            this.checkBox_WriteFrameInformation.CheckedChanged += new System.EventHandler(this.checkBox_WriteTotalbytes_CheckedChanged);
            // 
            // groupBox_Timer
            // 
            this.groupBox_Timer.Controls.Add(this.textBox_TimerTime);
            this.groupBox_Timer.Controls.Add(this.button_StartStopTimer);
            this.groupBox_Timer.Controls.Add(this.button_ResetTimer);
            this.groupBox_Timer.Controls.Add(this.textBox_SetTimerTime);
            this.groupBox_Timer.Location = new System.Drawing.Point(38, 704);
            this.groupBox_Timer.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Timer.Name = "groupBox_Timer";
            this.groupBox_Timer.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Timer.Size = new System.Drawing.Size(246, 107);
            this.groupBox_Timer.TabIndex = 107;
            this.groupBox_Timer.TabStop = false;
            this.groupBox_Timer.Text = "Timer";
            this.groupBox_Timer.Visible = false;
            // 
            // textBox_TimerTime
            // 
            this.textBox_TimerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TimerTime.Location = new System.Drawing.Point(109, 64);
            this.textBox_TimerTime.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TimerTime.Name = "textBox_TimerTime";
            this.textBox_TimerTime.ReadOnly = true;
            this.textBox_TimerTime.Size = new System.Drawing.Size(65, 31);
            this.textBox_TimerTime.TabIndex = 106;
            this.textBox_TimerTime.Text = "0";
            // 
            // button_StartStopTimer
            // 
            this.button_StartStopTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartStopTimer.Location = new System.Drawing.Point(8, 22);
            this.button_StartStopTimer.Margin = new System.Windows.Forms.Padding(2);
            this.button_StartStopTimer.Name = "button_StartStopTimer";
            this.button_StartStopTimer.Size = new System.Drawing.Size(101, 36);
            this.button_StartStopTimer.TabIndex = 104;
            this.button_StartStopTimer.Text = "Start/Stop";
            this.button_StartStopTimer.UseVisualStyleBackColor = true;
            this.button_StartStopTimer.Click += new System.EventHandler(this.Button_StartStopTimer_Click);
            // 
            // button_ResetTimer
            // 
            this.button_ResetTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ResetTimer.Location = new System.Drawing.Point(109, 22);
            this.button_ResetTimer.Margin = new System.Windows.Forms.Padding(2);
            this.button_ResetTimer.Name = "button_ResetTimer";
            this.button_ResetTimer.Size = new System.Drawing.Size(101, 36);
            this.button_ResetTimer.TabIndex = 105;
            this.button_ResetTimer.Text = "Reset (0)";
            this.button_ResetTimer.UseVisualStyleBackColor = true;
            this.button_ResetTimer.Click += new System.EventHandler(this.Button_ResetTimer_Click);
            // 
            // textBox_SetTimerTime
            // 
            this.textBox_SetTimerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SetTimerTime.Location = new System.Drawing.Point(8, 64);
            this.textBox_SetTimerTime.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SetTimerTime.Name = "textBox_SetTimerTime";
            this.textBox_SetTimerTime.Size = new System.Drawing.Size(96, 31);
            this.textBox_SetTimerTime.TabIndex = 103;
            this.textBox_SetTimerTime.Text = "0";
            // 
            // groupBox_Stopwatch
            // 
            this.groupBox_Stopwatch.Controls.Add(this.button_TimerLog);
            this.groupBox_Stopwatch.Controls.Add(this.button_Stopwatch_Start_Stop);
            this.groupBox_Stopwatch.Controls.Add(this.button_StopwatchReset);
            this.groupBox_Stopwatch.Controls.Add(this.textBox_StopWatch);
            this.groupBox_Stopwatch.Location = new System.Drawing.Point(38, 590);
            this.groupBox_Stopwatch.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Stopwatch.Name = "groupBox_Stopwatch";
            this.groupBox_Stopwatch.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Stopwatch.Size = new System.Drawing.Size(246, 108);
            this.groupBox_Stopwatch.TabIndex = 106;
            this.groupBox_Stopwatch.TabStop = false;
            this.groupBox_Stopwatch.Text = "Stopwatch";
            this.groupBox_Stopwatch.Visible = false;
            // 
            // button_TimerLog
            // 
            this.button_TimerLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_TimerLog.Location = new System.Drawing.Point(173, 22);
            this.button_TimerLog.Margin = new System.Windows.Forms.Padding(2);
            this.button_TimerLog.Name = "button_TimerLog";
            this.button_TimerLog.Size = new System.Drawing.Size(69, 36);
            this.button_TimerLog.TabIndex = 106;
            this.button_TimerLog.Text = "Log ->";
            this.button_TimerLog.UseVisualStyleBackColor = true;
            this.button_TimerLog.Click += new System.EventHandler(this.Button_TimerLog_Click);
            // 
            // button_Stopwatch_Start_Stop
            // 
            this.button_Stopwatch_Start_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Stopwatch_Start_Stop.Location = new System.Drawing.Point(8, 22);
            this.button_Stopwatch_Start_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.button_Stopwatch_Start_Stop.Name = "button_Stopwatch_Start_Stop";
            this.button_Stopwatch_Start_Stop.Size = new System.Drawing.Size(101, 36);
            this.button_Stopwatch_Start_Stop.TabIndex = 104;
            this.button_Stopwatch_Start_Stop.Text = "Start/Stop";
            this.button_Stopwatch_Start_Stop.UseVisualStyleBackColor = true;
            this.button_Stopwatch_Start_Stop.Click += new System.EventHandler(this.Button_Stopwatch_Start_Stop_Click);
            // 
            // button_StopwatchReset
            // 
            this.button_StopwatchReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StopwatchReset.Location = new System.Drawing.Point(109, 22);
            this.button_StopwatchReset.Margin = new System.Windows.Forms.Padding(2);
            this.button_StopwatchReset.Name = "button_StopwatchReset";
            this.button_StopwatchReset.Size = new System.Drawing.Size(64, 36);
            this.button_StopwatchReset.TabIndex = 105;
            this.button_StopwatchReset.Text = "Reset";
            this.button_StopwatchReset.UseVisualStyleBackColor = true;
            this.button_StopwatchReset.Click += new System.EventHandler(this.Button_StopwatchReset_Click);
            // 
            // textBox_StopWatch
            // 
            this.textBox_StopWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_StopWatch.Location = new System.Drawing.Point(8, 64);
            this.textBox_StopWatch.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_StopWatch.Name = "textBox_StopWatch";
            this.textBox_StopWatch.ReadOnly = true;
            this.textBox_StopWatch.Size = new System.Drawing.Size(184, 31);
            this.textBox_StopWatch.TabIndex = 103;
            this.textBox_StopWatch.Text = "0";
            this.textBox_StopWatch.TextChanged += new System.EventHandler(this.TextBox_StopWatch_TextChanged);
            // 
            // checkBox_RxHex
            // 
            this.checkBox_RxHex.AutoSize = true;
            this.checkBox_RxHex.Checked = true;
            this.checkBox_RxHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RxHex.Location = new System.Drawing.Point(595, 19);
            this.checkBox_RxHex.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_RxHex.Name = "checkBox_RxHex";
            this.checkBox_RxHex.Size = new System.Drawing.Size(111, 23);
            this.checkBox_RxHex.TabIndex = 6;
            this.checkBox_RxHex.Text = "Show Rx Hex";
            this.checkBox_RxHex.UseVisualStyleBackColor = true;
            // 
            // textBox_SerialPortRecognizePattern3
            // 
            this.textBox_SerialPortRecognizePattern3.Location = new System.Drawing.Point(232, 15);
            this.textBox_SerialPortRecognizePattern3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SerialPortRecognizePattern3.Name = "textBox_SerialPortRecognizePattern3";
            this.textBox_SerialPortRecognizePattern3.Size = new System.Drawing.Size(108, 27);
            this.textBox_SerialPortRecognizePattern3.TabIndex = 75;
            // 
            // textBox_SerialPortRecognizePattern2
            // 
            this.textBox_SerialPortRecognizePattern2.Location = new System.Drawing.Point(120, 16);
            this.textBox_SerialPortRecognizePattern2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SerialPortRecognizePattern2.Name = "textBox_SerialPortRecognizePattern2";
            this.textBox_SerialPortRecognizePattern2.Size = new System.Drawing.Size(108, 27);
            this.textBox_SerialPortRecognizePattern2.TabIndex = 74;
            // 
            // textBox_SerialPortRecognizePattern
            // 
            this.textBox_SerialPortRecognizePattern.Location = new System.Drawing.Point(8, 16);
            this.textBox_SerialPortRecognizePattern.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SerialPortRecognizePattern.Name = "textBox_SerialPortRecognizePattern";
            this.textBox_SerialPortRecognizePattern.Size = new System.Drawing.Size(108, 27);
            this.textBox_SerialPortRecognizePattern.TabIndex = 73;
            // 
            // checkBox_SerialPortRecordLog
            // 
            this.checkBox_SerialPortRecordLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_SerialPortRecordLog.AutoSize = true;
            this.checkBox_SerialPortRecordLog.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_SerialPortRecordLog.Location = new System.Drawing.Point(345, 14);
            this.checkBox_SerialPortRecordLog.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_SerialPortRecordLog.Name = "checkBox_SerialPortRecordLog";
            this.checkBox_SerialPortRecordLog.Size = new System.Drawing.Size(83, 29);
            this.checkBox_SerialPortRecordLog.TabIndex = 69;
            this.checkBox_SerialPortRecordLog.Text = "Log to file";
            this.checkBox_SerialPortRecordLog.UseVisualStyleBackColor = true;
            this.checkBox_SerialPortRecordLog.CheckedChanged += new System.EventHandler(this.CheckBox_S1RecordLog_CheckedChanged);
            // 
            // checkBox_SerialPortPause
            // 
            this.checkBox_SerialPortPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_SerialPortPause.AutoSize = true;
            this.checkBox_SerialPortPause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_SerialPortPause.Location = new System.Drawing.Point(443, 13);
            this.checkBox_SerialPortPause.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_SerialPortPause.Name = "checkBox_SerialPortPause";
            this.checkBox_SerialPortPause.Size = new System.Drawing.Size(58, 29);
            this.checkBox_SerialPortPause.TabIndex = 70;
            this.checkBox_SerialPortPause.Text = "Pause";
            this.checkBox_SerialPortPause.UseVisualStyleBackColor = true;
            this.checkBox_SerialPortPause.CheckedChanged += new System.EventHandler(this.CheckBox_S1Pause_CheckedChanged);
            // 
            // button_ClearSerialPort
            // 
            this.button_ClearSerialPort.Font = new System.Drawing.Font("Calibri", 12F);
            this.button_ClearSerialPort.Location = new System.Drawing.Point(514, 13);
            this.button_ClearSerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.button_ClearSerialPort.Name = "button_ClearSerialPort";
            this.button_ClearSerialPort.Size = new System.Drawing.Size(62, 29);
            this.button_ClearSerialPort.TabIndex = 69;
            this.button_ClearSerialPort.Text = "Clear";
            this.button_ClearSerialPort.UseVisualStyleBackColor = true;
            this.button_ClearSerialPort.Click += new System.EventHandler(this.txtS1_Clear_Click);
            // 
            // SerialPortLogger_TextBox
            // 
            this.SerialPortLogger_TextBox.BackColor = System.Drawing.Color.LightGray;
            this.SerialPortLogger_TextBox.EnableAutoDragDrop = true;
            this.SerialPortLogger_TextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialPortLogger_TextBox.Location = new System.Drawing.Point(4, 47);
            this.SerialPortLogger_TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SerialPortLogger_TextBox.Name = "SerialPortLogger_TextBox";
            this.SerialPortLogger_TextBox.Size = new System.Drawing.Size(1397, 502);
            this.SerialPortLogger_TextBox.TabIndex = 0;
            this.SerialPortLogger_TextBox.Text = "";
            this.SerialPortLogger_TextBox.TextChanged += new System.EventHandler(this.SerialPortLogger_TextBox_TextChanged);
            // 
            // tabPage_Commands
            // 
            this.tabPage_Commands.Controls.Add(this.groupBox40);
            this.tabPage_Commands.Controls.Add(this.groupBox32);
            this.tabPage_Commands.Location = new System.Drawing.Point(4, 27);
            this.tabPage_Commands.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_Commands.Name = "tabPage_Commands";
            this.tabPage_Commands.Size = new System.Drawing.Size(1414, 648);
            this.tabPage_Commands.TabIndex = 11;
            this.tabPage_Commands.Text = "3036 - mIFRS CLI";
            this.tabPage_Commands.UseVisualStyleBackColor = true;
            // 
            // groupBox40
            // 
            this.groupBox40.Controls.Add(this.tabControl_System);
            this.groupBox40.Location = new System.Drawing.Point(9, 8);
            this.groupBox40.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox40.Size = new System.Drawing.Size(886, 642);
            this.groupBox40.TabIndex = 11;
            this.groupBox40.TabStop = false;
            this.groupBox40.Text = "3036 - mIFRS CLI";
            // 
            // tabControl_System
            // 
            this.tabControl_System.Controls.Add(this.tabPage1);
            this.tabControl_System.Controls.Add(this.tabPage2_Script);
            this.tabControl_System.Location = new System.Drawing.Point(6, 22);
            this.tabControl_System.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl_System.Name = "tabControl_System";
            this.tabControl_System.SelectedIndex = 0;
            this.tabControl_System.Size = new System.Drawing.Size(875, 615);
            this.tabControl_System.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox_AllCommands);
            this.tabPage1.Controls.Add(this.groupBox_CLISendCommand);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(867, 584);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "System CLI";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox_AllCommands
            // 
            this.groupBox_AllCommands.Controls.Add(this.groupBox_Help);
            this.groupBox_AllCommands.Controls.Add(this.listBox_CLI_ALLCommands);
            this.groupBox_AllCommands.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_AllCommands.Location = new System.Drawing.Point(3, 104);
            this.groupBox_AllCommands.Name = "groupBox_AllCommands";
            this.groupBox_AllCommands.Size = new System.Drawing.Size(859, 475);
            this.groupBox_AllCommands.TabIndex = 72;
            this.groupBox_AllCommands.TabStop = false;
            this.groupBox_AllCommands.Text = "Commands list";
            // 
            // groupBox_Help
            // 
            this.groupBox_Help.Controls.Add(this.textBox_CommandHelp);
            this.groupBox_Help.Location = new System.Drawing.Point(378, 11);
            this.groupBox_Help.Name = "groupBox_Help";
            this.groupBox_Help.Size = new System.Drawing.Size(475, 464);
            this.groupBox_Help.TabIndex = 115;
            this.groupBox_Help.TabStop = false;
            this.groupBox_Help.Text = "Help";
            // 
            // textBox_CommandHelp
            // 
            this.textBox_CommandHelp.Location = new System.Drawing.Point(9, 21);
            this.textBox_CommandHelp.Name = "textBox_CommandHelp";
            this.textBox_CommandHelp.Size = new System.Drawing.Size(460, 437);
            this.textBox_CommandHelp.TabIndex = 115;
            this.textBox_CommandHelp.Text = "General Format:\nCommand arg1 arg2 arg3...\n\nFor example:\nCommand 12 abc\n----------" +
    "-------------------\nUse the arrows Up, Down and Tab for autocomplition.\n\n";
            // 
            // listBox_CLI_ALLCommands
            // 
            this.listBox_CLI_ALLCommands.FormattingEnabled = true;
            this.listBox_CLI_ALLCommands.ItemHeight = 19;
            this.listBox_CLI_ALLCommands.Location = new System.Drawing.Point(6, 18);
            this.listBox_CLI_ALLCommands.Name = "listBox_CLI_ALLCommands";
            this.listBox_CLI_ALLCommands.Size = new System.Drawing.Size(366, 441);
            this.listBox_CLI_ALLCommands.TabIndex = 2;
            this.listBox_CLI_ALLCommands.Click += new System.EventHandler(this.listBox_CLI_ALLCommands_Click);
            this.listBox_CLI_ALLCommands.SelectedIndexChanged += new System.EventHandler(this.listBox_CLI_ALLCommands_SelectedIndexChanged);
            // 
            // groupBox_CLISendCommand
            // 
            this.groupBox_CLISendCommand.Controls.Add(this.textBox_CLISendCommands);
            this.groupBox_CLISendCommand.Controls.Add(this.button_DeleteCommandsHistory);
            this.groupBox_CLISendCommand.Controls.Add(this.textBox_CLIsendperodically);
            this.groupBox_CLISendCommand.Controls.Add(this.checkBox_CLI_SendPeriodically);
            this.groupBox_CLISendCommand.Controls.Add(this.checkBox_CLIDeleteAfterSend);
            this.groupBox_CLISendCommand.Controls.Add(this.button_CLISend);
            this.groupBox_CLISendCommand.Location = new System.Drawing.Point(4, 9);
            this.groupBox_CLISendCommand.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_CLISendCommand.Name = "groupBox_CLISendCommand";
            this.groupBox_CLISendCommand.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_CLISendCommand.Size = new System.Drawing.Size(841, 90);
            this.groupBox_CLISendCommand.TabIndex = 70;
            this.groupBox_CLISendCommand.TabStop = false;
            this.groupBox_CLISendCommand.Text = "CLI send command ( press F1 for help)";
            // 
            // textBox_CLISendCommands
            // 
            this.textBox_CLISendCommands.AutoWordSelection = true;
            this.textBox_CLISendCommands.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_CLISendCommands.DetectUrls = false;
            this.textBox_CLISendCommands.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CLISendCommands.Location = new System.Drawing.Point(8, 16);
            this.textBox_CLISendCommands.Multiline = false;
            this.textBox_CLISendCommands.Name = "textBox_CLISendCommands";
            this.textBox_CLISendCommands.Size = new System.Drawing.Size(828, 29);
            this.textBox_CLISendCommands.TabIndex = 110;
            this.textBox_CLISendCommands.Text = "";
            this.textBox_CLISendCommands.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_CLISendCommands_KeyDown);
            this.textBox_CLISendCommands.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_CLISendCommands_PreviewKeyDown);
            // 
            // button_DeleteCommandsHistory
            // 
            this.button_DeleteCommandsHistory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteCommandsHistory.Location = new System.Drawing.Point(713, 59);
            this.button_DeleteCommandsHistory.Margin = new System.Windows.Forms.Padding(2);
            this.button_DeleteCommandsHistory.Name = "button_DeleteCommandsHistory";
            this.button_DeleteCommandsHistory.Size = new System.Drawing.Size(124, 23);
            this.button_DeleteCommandsHistory.TabIndex = 109;
            this.button_DeleteCommandsHistory.Text = "Delete history";
            this.button_DeleteCommandsHistory.Click += new System.EventHandler(this.button_DeleteCommandsHistory_Click);
            // 
            // textBox_CLIsendperodically
            // 
            this.textBox_CLIsendperodically.Location = new System.Drawing.Point(254, 55);
            this.textBox_CLIsendperodically.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CLIsendperodically.Name = "textBox_CLIsendperodically";
            this.textBox_CLIsendperodically.Size = new System.Drawing.Size(46, 26);
            this.textBox_CLIsendperodically.TabIndex = 108;
            this.textBox_CLIsendperodically.Text = "10";
            this.textBox_CLIsendperodically.TextChanged += new System.EventHandler(this.textBox_CLIsendperodically_TextChanged);
            // 
            // checkBox_CLI_SendPeriodically
            // 
            this.checkBox_CLI_SendPeriodically.AutoSize = true;
            this.checkBox_CLI_SendPeriodically.Location = new System.Drawing.Point(315, 57);
            this.checkBox_CLI_SendPeriodically.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_CLI_SendPeriodically.Name = "checkBox_CLI_SendPeriodically";
            this.checkBox_CLI_SendPeriodically.Size = new System.Drawing.Size(189, 22);
            this.checkBox_CLI_SendPeriodically.TabIndex = 6;
            this.checkBox_CLI_SendPeriodically.Text = "Send Periodically (100 ms)";
            this.checkBox_CLI_SendPeriodically.UseVisualStyleBackColor = true;
            // 
            // checkBox_CLIDeleteAfterSend
            // 
            this.checkBox_CLIDeleteAfterSend.AutoSize = true;
            this.checkBox_CLIDeleteAfterSend.Location = new System.Drawing.Point(115, 59);
            this.checkBox_CLIDeleteAfterSend.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_CLIDeleteAfterSend.Name = "checkBox_CLIDeleteAfterSend";
            this.checkBox_CLIDeleteAfterSend.Size = new System.Drawing.Size(135, 22);
            this.checkBox_CLIDeleteAfterSend.TabIndex = 4;
            this.checkBox_CLIDeleteAfterSend.Text = "Delete after Send";
            this.checkBox_CLIDeleteAfterSend.UseVisualStyleBackColor = true;
            // 
            // button_CLISend
            // 
            this.button_CLISend.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CLISend.Location = new System.Drawing.Point(8, 56);
            this.button_CLISend.Margin = new System.Windows.Forms.Padding(2);
            this.button_CLISend.Name = "button_CLISend";
            this.button_CLISend.Size = new System.Drawing.Size(96, 23);
            this.button_CLISend.TabIndex = 11;
            this.button_CLISend.Text = "Send";
            this.button_CLISend.Click += new System.EventHandler(this.button_CLISend_Click);
            // 
            // tabPage2_Script
            // 
            this.tabPage2_Script.Controls.Add(this.button_ScriptRunFromFile);
            this.tabPage2_Script.Controls.Add(this.button_StopRunScrip);
            this.tabPage2_Script.Controls.Add(this.checkBox_RepeatCLIScript);
            this.tabPage2_Script.Controls.Add(this.button_CheckScriptValidity);
            this.tabPage2_Script.Controls.Add(this.button_SaveScript);
            this.tabPage2_Script.Controls.Add(this.label4);
            this.tabPage2_Script.Controls.Add(this.textBox_TimeBetweenComands);
            this.tabPage2_Script.Controls.Add(this.button_ClearScript);
            this.tabPage2_Script.Controls.Add(this.button_RunScript);
            this.tabPage2_Script.Controls.Add(this.richTextBox_Scripts);
            this.tabPage2_Script.Controls.Add(this.button_LoadScriptCLI);
            this.tabPage2_Script.Location = new System.Drawing.Point(4, 27);
            this.tabPage2_Script.Name = "tabPage2_Script";
            this.tabPage2_Script.Size = new System.Drawing.Size(867, 584);
            this.tabPage2_Script.TabIndex = 1;
            this.tabPage2_Script.Text = "Scripts";
            this.tabPage2_Script.UseVisualStyleBackColor = true;
            // 
            // button_StopRunScrip
            // 
            this.button_StopRunScrip.BackColor = System.Drawing.Color.Orange;
            this.button_StopRunScrip.Location = new System.Drawing.Point(558, 169);
            this.button_StopRunScrip.Name = "button_StopRunScrip";
            this.button_StopRunScrip.Size = new System.Drawing.Size(89, 45);
            this.button_StopRunScrip.TabIndex = 82;
            this.button_StopRunScrip.Text = "Stop";
            this.button_StopRunScrip.UseVisualStyleBackColor = false;
            this.button_StopRunScrip.Click += new System.EventHandler(this.button_StopRunScrip_Click);
            // 
            // checkBox_RepeatCLIScript
            // 
            this.checkBox_RepeatCLIScript.AutoSize = true;
            this.checkBox_RepeatCLIScript.Location = new System.Drawing.Point(771, 190);
            this.checkBox_RepeatCLIScript.Name = "checkBox_RepeatCLIScript";
            this.checkBox_RepeatCLIScript.Size = new System.Drawing.Size(71, 22);
            this.checkBox_RepeatCLIScript.TabIndex = 81;
            this.checkBox_RepeatCLIScript.Text = "Repeat";
            this.checkBox_RepeatCLIScript.UseVisualStyleBackColor = true;
            // 
            // button_CheckScriptValidity
            // 
            this.button_CheckScriptValidity.Location = new System.Drawing.Point(463, 116);
            this.button_CheckScriptValidity.Name = "button_CheckScriptValidity";
            this.button_CheckScriptValidity.Size = new System.Drawing.Size(89, 45);
            this.button_CheckScriptValidity.TabIndex = 80;
            this.button_CheckScriptValidity.Text = "check commands";
            this.button_CheckScriptValidity.UseVisualStyleBackColor = true;
            this.button_CheckScriptValidity.Click += new System.EventHandler(this.button_CheckScriptValidity_Click);
            // 
            // button_SaveScript
            // 
            this.button_SaveScript.Location = new System.Drawing.Point(558, 9);
            this.button_SaveScript.Name = "button_SaveScript";
            this.button_SaveScript.Size = new System.Drawing.Size(89, 45);
            this.button_SaveScript.TabIndex = 79;
            this.button_SaveScript.Text = "Save";
            this.button_SaveScript.UseVisualStyleBackColor = true;
            this.button_SaveScript.Click += new System.EventHandler(this.button_SaveScript_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(665, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 18);
            this.label4.TabIndex = 78;
            this.label4.Text = "Time between commands (ms)";
            // 
            // textBox_TimeBetweenComands
            // 
            this.textBox_TimeBetweenComands.Location = new System.Drawing.Point(665, 188);
            this.textBox_TimeBetweenComands.Name = "textBox_TimeBetweenComands";
            this.textBox_TimeBetweenComands.Size = new System.Drawing.Size(100, 26);
            this.textBox_TimeBetweenComands.TabIndex = 77;
            this.textBox_TimeBetweenComands.Text = "500";
            this.textBox_TimeBetweenComands.TextChanged += new System.EventHandler(this.textBox_TimeBetweenComands_TextChanged);
            // 
            // button_ClearScript
            // 
            this.button_ClearScript.Location = new System.Drawing.Point(463, 61);
            this.button_ClearScript.Name = "button_ClearScript";
            this.button_ClearScript.Size = new System.Drawing.Size(89, 45);
            this.button_ClearScript.TabIndex = 76;
            this.button_ClearScript.Text = "clear";
            this.button_ClearScript.UseVisualStyleBackColor = true;
            this.button_ClearScript.Click += new System.EventHandler(this.button_ClearScript_Click);
            // 
            // button_RunScript
            // 
            this.button_RunScript.BackColor = System.Drawing.Color.SkyBlue;
            this.button_RunScript.Location = new System.Drawing.Point(463, 168);
            this.button_RunScript.Name = "button_RunScript";
            this.button_RunScript.Size = new System.Drawing.Size(89, 45);
            this.button_RunScript.TabIndex = 75;
            this.button_RunScript.Text = "Run";
            this.button_RunScript.UseVisualStyleBackColor = false;
            this.button_RunScript.Click += new System.EventHandler(this.button_RunScript_Click);
            // 
            // richTextBox_Scripts
            // 
            this.richTextBox_Scripts.Location = new System.Drawing.Point(4, 9);
            this.richTextBox_Scripts.Name = "richTextBox_Scripts";
            this.richTextBox_Scripts.Size = new System.Drawing.Size(448, 564);
            this.richTextBox_Scripts.TabIndex = 74;
            this.richTextBox_Scripts.Text = "";
            this.richTextBox_Scripts.Click += new System.EventHandler(this.richTextBox_Scripts_Click);
            this.richTextBox_Scripts.TextChanged += new System.EventHandler(this.richTextBox_Scripts_TextChanged);
            // 
            // button_LoadScriptCLI
            // 
            this.button_LoadScriptCLI.Location = new System.Drawing.Point(463, 9);
            this.button_LoadScriptCLI.Name = "button_LoadScriptCLI";
            this.button_LoadScriptCLI.Size = new System.Drawing.Size(89, 45);
            this.button_LoadScriptCLI.TabIndex = 73;
            this.button_LoadScriptCLI.Text = "Load";
            this.button_LoadScriptCLI.UseVisualStyleBackColor = true;
            this.button_LoadScriptCLI.Click += new System.EventHandler(this.button_LoadScriptCLI_Click);
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.textBox_CLIrecognize3);
            this.groupBox32.Controls.Add(this.textBox_CLIrecognize2);
            this.groupBox32.Controls.Add(this.textBox_CLIrecognize1);
            this.groupBox32.Controls.Add(this.richTextBox_SSPA);
            this.groupBox32.Controls.Add(this.checkBox_RecordMiniAda);
            this.groupBox32.Controls.Add(this.checkBox_PauseMiniAda);
            this.groupBox32.Controls.Add(this.button_ClearMiniAda);
            this.groupBox32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox32.Location = new System.Drawing.Point(901, 3);
            this.groupBox32.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox32.Size = new System.Drawing.Size(510, 646);
            this.groupBox32.TabIndex = 9;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "CLI Monitor";
            // 
            // textBox_CLIrecognize3
            // 
            this.textBox_CLIrecognize3.Location = new System.Drawing.Point(235, 21);
            this.textBox_CLIrecognize3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CLIrecognize3.Name = "textBox_CLIrecognize3";
            this.textBox_CLIrecognize3.Size = new System.Drawing.Size(108, 27);
            this.textBox_CLIrecognize3.TabIndex = 78;
            // 
            // textBox_CLIrecognize2
            // 
            this.textBox_CLIrecognize2.Location = new System.Drawing.Point(123, 22);
            this.textBox_CLIrecognize2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CLIrecognize2.Name = "textBox_CLIrecognize2";
            this.textBox_CLIrecognize2.Size = new System.Drawing.Size(108, 27);
            this.textBox_CLIrecognize2.TabIndex = 77;
            // 
            // textBox_CLIrecognize1
            // 
            this.textBox_CLIrecognize1.Location = new System.Drawing.Point(11, 22);
            this.textBox_CLIrecognize1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CLIrecognize1.Name = "textBox_CLIrecognize1";
            this.textBox_CLIrecognize1.Size = new System.Drawing.Size(108, 27);
            this.textBox_CLIrecognize1.TabIndex = 76;
            // 
            // richTextBox_SSPA
            // 
            this.richTextBox_SSPA.BackColor = System.Drawing.Color.LightGray;
            this.richTextBox_SSPA.EnableAutoDragDrop = true;
            this.richTextBox_SSPA.Location = new System.Drawing.Point(6, 54);
            this.richTextBox_SSPA.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_SSPA.Name = "richTextBox_SSPA";
            this.richTextBox_SSPA.Size = new System.Drawing.Size(506, 551);
            this.richTextBox_SSPA.TabIndex = 0;
            this.richTextBox_SSPA.Text = "";
            // 
            // checkBox_RecordMiniAda
            // 
            this.checkBox_RecordMiniAda.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordMiniAda.AutoSize = true;
            this.checkBox_RecordMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordMiniAda.Location = new System.Drawing.Point(6, 610);
            this.checkBox_RecordMiniAda.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_RecordMiniAda.Name = "checkBox_RecordMiniAda";
            this.checkBox_RecordMiniAda.Size = new System.Drawing.Size(140, 26);
            this.checkBox_RecordMiniAda.TabIndex = 7;
            this.checkBox_RecordMiniAda.Text = "Record Log to file";
            this.checkBox_RecordMiniAda.UseVisualStyleBackColor = true;
            // 
            // checkBox_PauseMiniAda
            // 
            this.checkBox_PauseMiniAda.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_PauseMiniAda.AutoSize = true;
            this.checkBox_PauseMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_PauseMiniAda.Location = new System.Drawing.Point(150, 610);
            this.checkBox_PauseMiniAda.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_PauseMiniAda.Name = "checkBox_PauseMiniAda";
            this.checkBox_PauseMiniAda.Size = new System.Drawing.Size(61, 26);
            this.checkBox_PauseMiniAda.TabIndex = 5;
            this.checkBox_PauseMiniAda.Text = "Pause";
            this.checkBox_PauseMiniAda.UseVisualStyleBackColor = true;
            // 
            // button_ClearMiniAda
            // 
            this.button_ClearMiniAda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearMiniAda.Location = new System.Drawing.Point(215, 611);
            this.button_ClearMiniAda.Margin = new System.Windows.Forms.Padding(2);
            this.button_ClearMiniAda.Name = "button_ClearMiniAda";
            this.button_ClearMiniAda.Size = new System.Drawing.Size(57, 25);
            this.button_ClearMiniAda.TabIndex = 6;
            this.button_ClearMiniAda.Text = "Clear";
            this.button_ClearMiniAda.UseVisualStyleBackColor = true;
            // 
            // groupBox42
            // 
            this.groupBox42.Controls.Add(this.radioButton_TCPIP);
            this.groupBox42.Controls.Add(this.radioButton_SerialPort);
            this.groupBox42.Location = new System.Drawing.Point(1427, 400);
            this.groupBox42.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox42.Name = "groupBox42";
            this.groupBox42.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox42.Size = new System.Drawing.Size(183, 80);
            this.groupBox42.TabIndex = 33;
            this.groupBox42.TabStop = false;
            this.groupBox42.Text = "Communication gatway";
            // 
            // radioButton_TCPIP
            // 
            this.radioButton_TCPIP.AutoSize = true;
            this.radioButton_TCPIP.Location = new System.Drawing.Point(18, 54);
            this.radioButton_TCPIP.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_TCPIP.Name = "radioButton_TCPIP";
            this.radioButton_TCPIP.Size = new System.Drawing.Size(66, 22);
            this.radioButton_TCPIP.TabIndex = 1;
            this.radioButton_TCPIP.TabStop = true;
            this.radioButton_TCPIP.Text = "TCP/IP";
            this.radioButton_TCPIP.UseVisualStyleBackColor = true;
            // 
            // radioButton_SerialPort
            // 
            this.radioButton_SerialPort.AutoSize = true;
            this.radioButton_SerialPort.Checked = true;
            this.radioButton_SerialPort.Location = new System.Drawing.Point(18, 25);
            this.radioButton_SerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_SerialPort.Name = "radioButton_SerialPort";
            this.radioButton_SerialPort.Size = new System.Drawing.Size(90, 22);
            this.radioButton_SerialPort.TabIndex = 0;
            this.radioButton_SerialPort.TabStop = true;
            this.radioButton_SerialPort.Text = "Serial Port";
            this.radioButton_SerialPort.UseVisualStyleBackColor = true;
            // 
            // button_OpenFolder
            // 
            this.button_OpenFolder.Location = new System.Drawing.Point(1427, 345);
            this.button_OpenFolder.Margin = new System.Windows.Forms.Padding(2);
            this.button_OpenFolder.Name = "button_OpenFolder";
            this.button_OpenFolder.Size = new System.Drawing.Size(174, 25);
            this.button_OpenFolder.TabIndex = 76;
            this.button_OpenFolder.Text = "Open Folder";
            this.button_OpenFolder.UseVisualStyleBackColor = true;
            this.button_OpenFolder.Click += new System.EventHandler(this.Button43_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.S1_Configuration);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1406, 776);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "S1 Configuration";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // S1_Configuration
            // 
            this.S1_Configuration.Controls.Add(this.groupBox12);
            this.S1_Configuration.Controls.Add(this.groupBox22);
            this.S1_Configuration.Controls.Add(this.groupBox28);
            this.S1_Configuration.Controls.Add(this.groupBox30);
            this.S1_Configuration.Controls.Add(this.groupBox29);
            this.S1_Configuration.Controls.Add(this.groupBox27);
            this.S1_Configuration.Controls.Add(this.groupBox26);
            this.S1_Configuration.Controls.Add(this.groupBox25);
            this.S1_Configuration.Controls.Add(this.groupBox24);
            this.S1_Configuration.Controls.Add(this.groupBox23);
            this.S1_Configuration.Controls.Add(this.groupBox21);
            this.S1_Configuration.Controls.Add(this.groupBox20);
            this.S1_Configuration.Controls.Add(this.groupBox19);
            this.S1_Configuration.Controls.Add(this.groupBox18);
            this.S1_Configuration.Controls.Add(this.groupBox17);
            this.S1_Configuration.Controls.Add(this.groupBox11);
            this.S1_Configuration.Controls.Add(this.groupBox10);
            this.S1_Configuration.Controls.Add(this.groupBox9);
            this.S1_Configuration.Controls.Add(this.groupBox8);
            this.S1_Configuration.Controls.Add(this.groupBox7);
            this.S1_Configuration.Controls.Add(this.groupBox6);
            this.S1_Configuration.Controls.Add(this.groupBox13);
            this.S1_Configuration.Controls.Add(this.groupBox14);
            this.S1_Configuration.Controls.Add(this.groupBox15);
            this.S1_Configuration.Controls.Add(this.groupBox16);
            this.S1_Configuration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S1_Configuration.Location = new System.Drawing.Point(3, 3);
            this.S1_Configuration.Name = "S1_Configuration";
            this.S1_Configuration.Size = new System.Drawing.Size(924, 741);
            this.S1_Configuration.TabIndex = 12;
            this.S1_Configuration.TabStop = false;
            this.S1_Configuration.Text = "S1 Configuration";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.button13);
            this.groupBox12.Location = new System.Drawing.Point(716, 24);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(164, 58);
            this.groupBox12.TabIndex = 67;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "RF pairing";
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(10, 20);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(152, 26);
            this.button13.TabIndex = 49;
            this.button13.Text = "RF Pairing";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Button13_Click);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.TextBox_Odometer);
            this.groupBox22.Controls.Add(this.button19);
            this.groupBox22.Location = new System.Drawing.Point(718, 88);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(200, 78);
            this.groupBox22.TabIndex = 68;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Odometer";
            // 
            // TextBox_Odometer
            // 
            this.TextBox_Odometer.Location = new System.Drawing.Point(6, 23);
            this.TextBox_Odometer.Name = "TextBox_Odometer";
            this.TextBox_Odometer.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Odometer.TabIndex = 64;
            // 
            // button19
            // 
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.Location = new System.Drawing.Point(6, 50);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(74, 26);
            this.button19.TabIndex = 63;
            this.button19.Text = "Odometer Config";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.Button19_Click);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.textBox_ModemSocket);
            this.groupBox28.Controls.Add(this.textBox_ModemRetries);
            this.groupBox28.Controls.Add(this.textBox_ModemTimeOut);
            this.groupBox28.Controls.Add(this.button25);
            this.groupBox28.Controls.Add(this.textBox_ModemPrimeryPort);
            this.groupBox28.Controls.Add(this.textBox_ModemPrimeryHost);
            this.groupBox28.Location = new System.Drawing.Point(188, 499);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(146, 195);
            this.groupBox28.TabIndex = 45;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Modem Config";
            // 
            // textBox_ModemSocket
            // 
            this.textBox_ModemSocket.Location = new System.Drawing.Point(8, 77);
            this.textBox_ModemSocket.Name = "textBox_ModemSocket";
            this.textBox_ModemSocket.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemSocket.TabIndex = 80;
            // 
            // textBox_ModemRetries
            // 
            this.textBox_ModemRetries.Location = new System.Drawing.Point(8, 50);
            this.textBox_ModemRetries.Name = "textBox_ModemRetries";
            this.textBox_ModemRetries.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemRetries.TabIndex = 79;
            // 
            // textBox_ModemTimeOut
            // 
            this.textBox_ModemTimeOut.Location = new System.Drawing.Point(8, 23);
            this.textBox_ModemTimeOut.Name = "textBox_ModemTimeOut";
            this.textBox_ModemTimeOut.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemTimeOut.TabIndex = 78;
            // 
            // button25
            // 
            this.button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.Location = new System.Drawing.Point(8, 157);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(132, 26);
            this.button25.TabIndex = 44;
            this.button25.Text = "Config Modem";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.Button25_Click);
            // 
            // textBox_ModemPrimeryPort
            // 
            this.textBox_ModemPrimeryPort.Location = new System.Drawing.Point(8, 129);
            this.textBox_ModemPrimeryPort.Name = "textBox_ModemPrimeryPort";
            this.textBox_ModemPrimeryPort.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemPrimeryPort.TabIndex = 37;
            // 
            // textBox_ModemPrimeryHost
            // 
            this.textBox_ModemPrimeryHost.Location = new System.Drawing.Point(8, 101);
            this.textBox_ModemPrimeryHost.Name = "textBox_ModemPrimeryHost";
            this.textBox_ModemPrimeryHost.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemPrimeryHost.TabIndex = 36;
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.textBox_ForginPassword);
            this.groupBox30.Controls.Add(this.button27);
            this.groupBox30.Controls.Add(this.textBox_ForginAcessPoint);
            this.groupBox30.Controls.Add(this.textBox_ForginSecondaryDNS);
            this.groupBox30.Controls.Add(this.textBox_ForginUserName);
            this.groupBox30.Controls.Add(this.textBox_ForginPrimeryDNS);
            this.groupBox30.Location = new System.Drawing.Point(344, 499);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(160, 195);
            this.groupBox30.TabIndex = 47;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Config Forgin Network";
            // 
            // textBox_ForginPassword
            // 
            this.textBox_ForginPassword.Location = new System.Drawing.Point(8, 77);
            this.textBox_ForginPassword.Name = "textBox_ForginPassword";
            this.textBox_ForginPassword.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginPassword.TabIndex = 35;
            // 
            // button27
            // 
            this.button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.Location = new System.Drawing.Point(8, 157);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(146, 26);
            this.button27.TabIndex = 44;
            this.button27.Text = "Config Forgin Net";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.Button27_Click);
            // 
            // textBox_ForginAcessPoint
            // 
            this.textBox_ForginAcessPoint.Location = new System.Drawing.Point(7, 23);
            this.textBox_ForginAcessPoint.Name = "textBox_ForginAcessPoint";
            this.textBox_ForginAcessPoint.Size = new System.Drawing.Size(147, 22);
            this.textBox_ForginAcessPoint.TabIndex = 33;
            // 
            // textBox_ForginSecondaryDNS
            // 
            this.textBox_ForginSecondaryDNS.Location = new System.Drawing.Point(8, 129);
            this.textBox_ForginSecondaryDNS.Name = "textBox_ForginSecondaryDNS";
            this.textBox_ForginSecondaryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginSecondaryDNS.TabIndex = 37;
            // 
            // textBox_ForginUserName
            // 
            this.textBox_ForginUserName.Location = new System.Drawing.Point(8, 51);
            this.textBox_ForginUserName.Name = "textBox_ForginUserName";
            this.textBox_ForginUserName.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginUserName.TabIndex = 34;
            // 
            // textBox_ForginPrimeryDNS
            // 
            this.textBox_ForginPrimeryDNS.Location = new System.Drawing.Point(8, 101);
            this.textBox_ForginPrimeryDNS.Name = "textBox_ForginPrimeryDNS";
            this.textBox_ForginPrimeryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginPrimeryDNS.TabIndex = 36;
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.textBox_HomePassword);
            this.groupBox29.Controls.Add(this.button26);
            this.groupBox29.Controls.Add(this.textBox_HomeAcessPoint);
            this.groupBox29.Controls.Add(this.textBox_HomeSecondaryDNS);
            this.groupBox29.Controls.Add(this.textBox_HomeUserName);
            this.groupBox29.Controls.Add(this.textBox_HomePrimeryDNS);
            this.groupBox29.Location = new System.Drawing.Point(345, 298);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(160, 195);
            this.groupBox29.TabIndex = 46;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Config Home Net";
            // 
            // textBox_HomePassword
            // 
            this.textBox_HomePassword.Location = new System.Drawing.Point(8, 77);
            this.textBox_HomePassword.Name = "textBox_HomePassword";
            this.textBox_HomePassword.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomePassword.TabIndex = 35;
            this.textBox_HomePassword.Text = "Password";
            // 
            // button26
            // 
            this.button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.Location = new System.Drawing.Point(8, 157);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(146, 26);
            this.button26.TabIndex = 44;
            this.button26.Text = "Config Home Net";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.Button26_Click);
            // 
            // textBox_HomeAcessPoint
            // 
            this.textBox_HomeAcessPoint.Location = new System.Drawing.Point(7, 23);
            this.textBox_HomeAcessPoint.Name = "textBox_HomeAcessPoint";
            this.textBox_HomeAcessPoint.Size = new System.Drawing.Size(147, 22);
            this.textBox_HomeAcessPoint.TabIndex = 33;
            this.textBox_HomeAcessPoint.Text = "Aceess point";
            // 
            // textBox_HomeSecondaryDNS
            // 
            this.textBox_HomeSecondaryDNS.Location = new System.Drawing.Point(8, 129);
            this.textBox_HomeSecondaryDNS.Name = "textBox_HomeSecondaryDNS";
            this.textBox_HomeSecondaryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomeSecondaryDNS.TabIndex = 37;
            this.textBox_HomeSecondaryDNS.Text = "Secondary DNS";
            // 
            // textBox_HomeUserName
            // 
            this.textBox_HomeUserName.Location = new System.Drawing.Point(8, 51);
            this.textBox_HomeUserName.Name = "textBox_HomeUserName";
            this.textBox_HomeUserName.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomeUserName.TabIndex = 34;
            this.textBox_HomeUserName.Text = "User Name";
            // 
            // textBox_HomePrimeryDNS
            // 
            this.textBox_HomePrimeryDNS.Location = new System.Drawing.Point(8, 101);
            this.textBox_HomePrimeryDNS.Name = "textBox_HomePrimeryDNS";
            this.textBox_HomePrimeryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomePrimeryDNS.TabIndex = 36;
            this.textBox_HomePrimeryDNS.Text = "Primery DNS";
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.maskedTextBox1);
            this.groupBox27.Controls.Add(this.button24);
            this.groupBox27.Location = new System.Drawing.Point(315, 107);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(145, 78);
            this.groupBox27.TabIndex = 72;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Sleep Status Duration";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(6, 18);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox1.TabIndex = 71;
            // 
            // button24
            // 
            this.button24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button24.Location = new System.Drawing.Point(6, 45);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(131, 26);
            this.button24.TabIndex = 70;
            this.button24.Text = "Duration sleep";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.Button24_Click);
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.TextBox_NormalStatusDuration);
            this.groupBox26.Controls.Add(this.button23);
            this.groupBox26.Location = new System.Drawing.Point(334, 24);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(171, 77);
            this.groupBox26.TabIndex = 71;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Normal Status Duration";
            // 
            // TextBox_NormalStatusDuration
            // 
            this.TextBox_NormalStatusDuration.Location = new System.Drawing.Point(6, 17);
            this.TextBox_NormalStatusDuration.Name = "TextBox_NormalStatusDuration";
            this.TextBox_NormalStatusDuration.Size = new System.Drawing.Size(100, 22);
            this.TextBox_NormalStatusDuration.TabIndex = 71;
            // 
            // button23
            // 
            this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.Location = new System.Drawing.Point(6, 45);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(111, 26);
            this.button23.TabIndex = 70;
            this.button23.Text = "Set Duration";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.Button23_Click);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit2);
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit3);
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit1);
            this.groupBox25.Controls.Add(this.button22);
            this.groupBox25.Location = new System.Drawing.Point(510, 557);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(200, 89);
            this.groupBox25.TabIndex = 70;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Speed Limit Config";
            // 
            // maskedTextBox_SpeedLimit2
            // 
            this.maskedTextBox_SpeedLimit2.Location = new System.Drawing.Point(53, 20);
            this.maskedTextBox_SpeedLimit2.Name = "maskedTextBox_SpeedLimit2";
            this.maskedTextBox_SpeedLimit2.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit2.TabIndex = 80;
            // 
            // maskedTextBox_SpeedLimit3
            // 
            this.maskedTextBox_SpeedLimit3.Location = new System.Drawing.Point(101, 19);
            this.maskedTextBox_SpeedLimit3.Name = "maskedTextBox_SpeedLimit3";
            this.maskedTextBox_SpeedLimit3.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit3.TabIndex = 79;
            // 
            // maskedTextBox_SpeedLimit1
            // 
            this.maskedTextBox_SpeedLimit1.Location = new System.Drawing.Point(6, 20);
            this.maskedTextBox_SpeedLimit1.Name = "maskedTextBox_SpeedLimit1";
            this.maskedTextBox_SpeedLimit1.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit1.TabIndex = 78;
            // 
            // button22
            // 
            this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.Location = new System.Drawing.Point(6, 47);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(140, 26);
            this.button22.TabIndex = 65;
            this.button22.Text = "Speed Limit Alert";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.Button22_Click);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.comboBox_DispatchSpeed);
            this.groupBox24.Controls.Add(this.button21);
            this.groupBox24.Location = new System.Drawing.Point(228, 377);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(106, 103);
            this.groupBox24.TabIndex = 68;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Dispatch Speed Limit";
            // 
            // comboBox_DispatchSpeed
            // 
            this.comboBox_DispatchSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_DispatchSpeed.FormattingEnabled = true;
            this.comboBox_DispatchSpeed.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_DispatchSpeed.Location = new System.Drawing.Point(8, 44);
            this.comboBox_DispatchSpeed.Name = "comboBox_DispatchSpeed";
            this.comboBox_DispatchSpeed.Size = new System.Drawing.Size(94, 21);
            this.comboBox_DispatchSpeed.TabIndex = 63;
            this.comboBox_DispatchSpeed.Text = "Speed";
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Location = new System.Drawing.Point(8, 71);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(94, 26);
            this.button21.TabIndex = 64;
            this.button21.Text = "Dispatch Speed";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.Button21_Click);
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.comboBox_KillEngine);
            this.groupBox23.Controls.Add(this.button20);
            this.groupBox23.Location = new System.Drawing.Point(230, 287);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(109, 91);
            this.groupBox23.TabIndex = 67;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Kill Engine";
            // 
            // comboBox_KillEngine
            // 
            this.comboBox_KillEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_KillEngine.FormattingEnabled = true;
            this.comboBox_KillEngine.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_KillEngine.Location = new System.Drawing.Point(6, 20);
            this.comboBox_KillEngine.Name = "comboBox_KillEngine";
            this.comboBox_KillEngine.Size = new System.Drawing.Size(58, 21);
            this.comboBox_KillEngine.TabIndex = 63;
            this.comboBox_KillEngine.Text = "Engine";
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(6, 43);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(98, 26);
            this.button20.TabIndex = 64;
            this.button20.Text = "Kill Engine";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.Button20_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.maskedTextBox_TiltTowSens);
            this.groupBox21.Controls.Add(this.comboBox_TiltTowSensState);
            this.groupBox21.Controls.Add(this.button18);
            this.groupBox21.Location = new System.Drawing.Point(510, 451);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(200, 100);
            this.groupBox21.TabIndex = 65;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Tilt Tow Sensitivity";
            // 
            // maskedTextBox_TiltTowSens
            // 
            this.maskedTextBox_TiltTowSens.Location = new System.Drawing.Point(81, 32);
            this.maskedTextBox_TiltTowSens.Name = "maskedTextBox_TiltTowSens";
            this.maskedTextBox_TiltTowSens.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox_TiltTowSens.TabIndex = 83;
            // 
            // comboBox_TiltTowSensState
            // 
            this.comboBox_TiltTowSensState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_TiltTowSensState.FormattingEnabled = true;
            this.comboBox_TiltTowSensState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_TiltTowSensState.Location = new System.Drawing.Point(17, 32);
            this.comboBox_TiltTowSensState.Name = "comboBox_TiltTowSensState";
            this.comboBox_TiltTowSensState.Size = new System.Drawing.Size(58, 21);
            this.comboBox_TiltTowSensState.TabIndex = 82;
            this.comboBox_TiltTowSensState.Text = "State";
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(17, 59);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(140, 26);
            this.button18.TabIndex = 61;
            this.button18.Text = "Tilt/Tow Sensitivity";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.Button18_Click);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.maskedTextBox_HitSensitivity);
            this.groupBox20.Controls.Add(this.comboBox_HitState);
            this.groupBox20.Controls.Add(this.button17);
            this.groupBox20.Location = new System.Drawing.Point(510, 345);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(200, 100);
            this.groupBox20.TabIndex = 64;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Hit Sensitivity";
            // 
            // maskedTextBox_HitSensitivity
            // 
            this.maskedTextBox_HitSensitivity.Location = new System.Drawing.Point(81, 32);
            this.maskedTextBox_HitSensitivity.Name = "maskedTextBox_HitSensitivity";
            this.maskedTextBox_HitSensitivity.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox_HitSensitivity.TabIndex = 82;
            // 
            // comboBox_HitState
            // 
            this.comboBox_HitState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_HitState.FormattingEnabled = true;
            this.comboBox_HitState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_HitState.Location = new System.Drawing.Point(17, 32);
            this.comboBox_HitState.Name = "comboBox_HitState";
            this.comboBox_HitState.Size = new System.Drawing.Size(58, 21);
            this.comboBox_HitState.TabIndex = 62;
            this.comboBox_HitState.Text = "State";
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(17, 59);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(140, 26);
            this.button17.TabIndex = 61;
            this.button17.Text = "Hit Sensitivity";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.Button17_Click);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.maskedTextBox_ShockDetectNum);
            this.groupBox19.Controls.Add(this.maskedTextBox_ShockWindow);
            this.groupBox19.Controls.Add(this.comboBox_ShockState);
            this.groupBox19.Controls.Add(this.button16);
            this.groupBox19.Location = new System.Drawing.Point(718, 276);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(200, 100);
            this.groupBox19.TabIndex = 63;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Config Shock";
            // 
            // maskedTextBox_ShockDetectNum
            // 
            this.maskedTextBox_ShockDetectNum.Location = new System.Drawing.Point(111, 24);
            this.maskedTextBox_ShockDetectNum.Name = "maskedTextBox_ShockDetectNum";
            this.maskedTextBox_ShockDetectNum.Size = new System.Drawing.Size(46, 22);
            this.maskedTextBox_ShockDetectNum.TabIndex = 82;
            // 
            // maskedTextBox_ShockWindow
            // 
            this.maskedTextBox_ShockWindow.Location = new System.Drawing.Point(59, 24);
            this.maskedTextBox_ShockWindow.Name = "maskedTextBox_ShockWindow";
            this.maskedTextBox_ShockWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_ShockWindow.TabIndex = 81;
            // 
            // comboBox_ShockState
            // 
            this.comboBox_ShockState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ShockState.FormattingEnabled = true;
            this.comboBox_ShockState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_ShockState.Location = new System.Drawing.Point(1, 24);
            this.comboBox_ShockState.Name = "comboBox_ShockState";
            this.comboBox_ShockState.Size = new System.Drawing.Size(48, 21);
            this.comboBox_ShockState.TabIndex = 61;
            this.comboBox_ShockState.Text = "State";
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(6, 54);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(140, 26);
            this.button16.TabIndex = 42;
            this.button16.Text = "Config Shock";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.Button16_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltDetectNum);
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltWindow);
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltAngle);
            this.groupBox18.Controls.Add(this.comboBox1_TiltState);
            this.groupBox18.Controls.Add(this.button15);
            this.groupBox18.Location = new System.Drawing.Point(718, 170);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(200, 100);
            this.groupBox18.TabIndex = 62;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Config Tow";
            // 
            // maskedTextBox_TiltDetectNum
            // 
            this.maskedTextBox_TiltDetectNum.Location = new System.Drawing.Point(100, 29);
            this.maskedTextBox_TiltDetectNum.Name = "maskedTextBox_TiltDetectNum";
            this.maskedTextBox_TiltDetectNum.Size = new System.Drawing.Size(42, 22);
            this.maskedTextBox_TiltDetectNum.TabIndex = 83;
            // 
            // maskedTextBox_TiltWindow
            // 
            this.maskedTextBox_TiltWindow.Location = new System.Drawing.Point(53, 29);
            this.maskedTextBox_TiltWindow.Name = "maskedTextBox_TiltWindow";
            this.maskedTextBox_TiltWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_TiltWindow.TabIndex = 82;
            // 
            // maskedTextBox_TiltAngle
            // 
            this.maskedTextBox_TiltAngle.Location = new System.Drawing.Point(10, 29);
            this.maskedTextBox_TiltAngle.Name = "maskedTextBox_TiltAngle";
            this.maskedTextBox_TiltAngle.Size = new System.Drawing.Size(37, 22);
            this.maskedTextBox_TiltAngle.TabIndex = 81;
            // 
            // comboBox1_TiltState
            // 
            this.comboBox1_TiltState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1_TiltState.FormattingEnabled = true;
            this.comboBox1_TiltState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox1_TiltState.Location = new System.Drawing.Point(152, 29);
            this.comboBox1_TiltState.Name = "comboBox1_TiltState";
            this.comboBox1_TiltState.Size = new System.Drawing.Size(42, 21);
            this.comboBox1_TiltState.TabIndex = 38;
            this.comboBox1_TiltState.Text = "State";
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(6, 56);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(140, 26);
            this.button15.TabIndex = 42;
            this.button15.Text = "Config Tilt";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Button15_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.maskedTextBox_TowDetectNum);
            this.groupBox17.Controls.Add(this.maskedTextBox_TowWindow);
            this.groupBox17.Controls.Add(this.maskedTextBox_TowAngle);
            this.groupBox17.Controls.Add(this.button14);
            this.groupBox17.Location = new System.Drawing.Point(516, 17);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(157, 100);
            this.groupBox17.TabIndex = 61;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Tow Configuration";
            // 
            // maskedTextBox_TowDetectNum
            // 
            this.maskedTextBox_TowDetectNum.Location = new System.Drawing.Point(100, 24);
            this.maskedTextBox_TowDetectNum.Name = "maskedTextBox_TowDetectNum";
            this.maskedTextBox_TowDetectNum.Size = new System.Drawing.Size(42, 22);
            this.maskedTextBox_TowDetectNum.TabIndex = 80;
            // 
            // maskedTextBox_TowWindow
            // 
            this.maskedTextBox_TowWindow.Location = new System.Drawing.Point(53, 24);
            this.maskedTextBox_TowWindow.Name = "maskedTextBox_TowWindow";
            this.maskedTextBox_TowWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_TowWindow.TabIndex = 79;
            // 
            // maskedTextBox_TowAngle
            // 
            this.maskedTextBox_TowAngle.Location = new System.Drawing.Point(10, 24);
            this.maskedTextBox_TowAngle.Name = "maskedTextBox_TowAngle";
            this.maskedTextBox_TowAngle.Size = new System.Drawing.Size(37, 22);
            this.maskedTextBox_TowAngle.TabIndex = 78;
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(6, 54);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(140, 26);
            this.button14.TabIndex = 42;
            this.button14.Text = "Config Tow";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Button14_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.comboBox_SleepPolicy);
            this.groupBox11.Controls.Add(this.button12);
            this.groupBox11.Location = new System.Drawing.Point(15, 598);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(167, 84);
            this.groupBox11.TabIndex = 57;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Sleep Policy";
            // 
            // comboBox_SleepPolicy
            // 
            this.comboBox_SleepPolicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_SleepPolicy.FormattingEnabled = true;
            this.comboBox_SleepPolicy.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_SleepPolicy.Location = new System.Drawing.Point(6, 27);
            this.comboBox_SleepPolicy.Name = "comboBox_SleepPolicy";
            this.comboBox_SleepPolicy.Size = new System.Drawing.Size(80, 21);
            this.comboBox_SleepPolicy.TabIndex = 47;
            this.comboBox_SleepPolicy.Text = "Sleep Policy";
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(6, 51);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(152, 26);
            this.button12.TabIndex = 48;
            this.button12.Text = "Set Sleep Policy";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button12_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.comboBox_AlarmPilicy);
            this.groupBox10.Controls.Add(this.button11);
            this.groupBox10.Location = new System.Drawing.Point(15, 492);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(166, 100);
            this.groupBox10.TabIndex = 56;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Set Alarm Configuration";
            // 
            // comboBox_AlarmPilicy
            // 
            this.comboBox_AlarmPilicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_AlarmPilicy.FormattingEnabled = true;
            this.comboBox_AlarmPilicy.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_AlarmPilicy.Location = new System.Drawing.Point(8, 28);
            this.comboBox_AlarmPilicy.Name = "comboBox_AlarmPilicy";
            this.comboBox_AlarmPilicy.Size = new System.Drawing.Size(80, 21);
            this.comboBox_AlarmPilicy.TabIndex = 42;
            this.comboBox_AlarmPilicy.Text = "Alarm Policy";
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(8, 52);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(152, 26);
            this.button11.TabIndex = 43;
            this.button11.Text = "Set Alarm Policy";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dateTimePicker_SetTimeDate);
            this.groupBox9.Controls.Add(this.button10);
            this.groupBox9.Location = new System.Drawing.Point(353, 193);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(204, 81);
            this.groupBox9.TabIndex = 55;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Set Time and Date";
            // 
            // dateTimePicker_SetTimeDate
            // 
            this.dateTimePicker_SetTimeDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePicker_SetTimeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_SetTimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_SetTimeDate.Location = new System.Drawing.Point(6, 20);
            this.dateTimePicker_SetTimeDate.Name = "dateTimePicker_SetTimeDate";
            this.dateTimePicker_SetTimeDate.Size = new System.Drawing.Size(179, 21);
            this.dateTimePicker_SetTimeDate.TabIndex = 41;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(6, 47);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(87, 26);
            this.button10.TabIndex = 40;
            this.button10.Text = "Time Date Config";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox_BatThreshold);
            this.groupBox8.Controls.Add(this.button9);
            this.groupBox8.Location = new System.Drawing.Point(187, 183);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(160, 91);
            this.groupBox8.TabIndex = 54;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Vehicle Battery threshold ";
            // 
            // comboBox_BatThreshold
            // 
            this.comboBox_BatThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_BatThreshold.FormattingEnabled = true;
            this.comboBox_BatThreshold.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox_BatThreshold.Location = new System.Drawing.Point(6, 20);
            this.comboBox_BatThreshold.Name = "comboBox_BatThreshold";
            this.comboBox_BatThreshold.Size = new System.Drawing.Size(49, 21);
            this.comboBox_BatThreshold.TabIndex = 39;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(6, 47);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(135, 26);
            this.button9.TabIndex = 38;
            this.button9.Text = "Vehicle Battery";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.maskedTextBox_OutputDuration);
            this.groupBox7.Controls.Add(this.comboBox_OutputNum);
            this.groupBox7.Controls.Add(this.comboBox_OutputControl);
            this.groupBox7.Controls.Add(this.button8);
            this.groupBox7.Controls.Add(this.comboBox_OutputPulseLevel);
            this.groupBox7.Location = new System.Drawing.Point(9, 386);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(215, 94);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Set Input Config";
            // 
            // maskedTextBox_OutputDuration
            // 
            this.maskedTextBox_OutputDuration.Location = new System.Drawing.Point(164, 48);
            this.maskedTextBox_OutputDuration.Name = "maskedTextBox_OutputDuration";
            this.maskedTextBox_OutputDuration.Size = new System.Drawing.Size(39, 22);
            this.maskedTextBox_OutputDuration.TabIndex = 38;
            // 
            // comboBox_OutputNum
            // 
            this.comboBox_OutputNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputNum.FormattingEnabled = true;
            this.comboBox_OutputNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_OutputNum.Location = new System.Drawing.Point(6, 20);
            this.comboBox_OutputNum.Name = "comboBox_OutputNum";
            this.comboBox_OutputNum.Size = new System.Drawing.Size(71, 21);
            this.comboBox_OutputNum.TabIndex = 33;
            this.comboBox_OutputNum.Text = "Output Num";
            // 
            // comboBox_OutputControl
            // 
            this.comboBox_OutputControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputControl.FormattingEnabled = true;
            this.comboBox_OutputControl.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_OutputControl.Location = new System.Drawing.Point(83, 20);
            this.comboBox_OutputControl.Name = "comboBox_OutputControl";
            this.comboBox_OutputControl.Size = new System.Drawing.Size(71, 21);
            this.comboBox_OutputControl.TabIndex = 34;
            this.comboBox_OutputControl.Text = "Cntl";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(5, 47);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(152, 26);
            this.button8.TabIndex = 36;
            this.button8.Text = "Set Output Config";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // comboBox_OutputPulseLevel
            // 
            this.comboBox_OutputPulseLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputPulseLevel.FormattingEnabled = true;
            this.comboBox_OutputPulseLevel.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_OutputPulseLevel.Location = new System.Drawing.Point(160, 20);
            this.comboBox_OutputPulseLevel.Name = "comboBox_OutputPulseLevel";
            this.comboBox_OutputPulseLevel.Size = new System.Drawing.Size(43, 21);
            this.comboBox_OutputPulseLevel.TabIndex = 37;
            this.comboBox_OutputPulseLevel.Text = "Pulse\\Level";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.maskedTextBox_InputDuration);
            this.groupBox6.Controls.Add(this.comboBox_InputNum1);
            this.groupBox6.Controls.Add(this.comboBox_Interupt);
            this.groupBox6.Controls.Add(this.button7);
            this.groupBox6.Location = new System.Drawing.Point(9, 280);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(215, 100);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Input Configuration";
            // 
            // maskedTextBox_InputDuration
            // 
            this.maskedTextBox_InputDuration.Location = new System.Drawing.Point(157, 31);
            this.maskedTextBox_InputDuration.Name = "maskedTextBox_InputDuration";
            this.maskedTextBox_InputDuration.Size = new System.Drawing.Size(46, 22);
            this.maskedTextBox_InputDuration.TabIndex = 33;
            // 
            // comboBox_InputNum1
            // 
            this.comboBox_InputNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_InputNum1.FormattingEnabled = true;
            this.comboBox_InputNum1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_InputNum1.Location = new System.Drawing.Point(6, 31);
            this.comboBox_InputNum1.Name = "comboBox_InputNum1";
            this.comboBox_InputNum1.Size = new System.Drawing.Size(71, 21);
            this.comboBox_InputNum1.TabIndex = 29;
            this.comboBox_InputNum1.Text = "Input Num";
            // 
            // comboBox_Interupt
            // 
            this.comboBox_Interupt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Interupt.FormattingEnabled = true;
            this.comboBox_Interupt.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_Interupt.Location = new System.Drawing.Point(83, 31);
            this.comboBox_Interupt.Name = "comboBox_Interupt";
            this.comboBox_Interupt.Size = new System.Drawing.Size(71, 21);
            this.comboBox_Interupt.TabIndex = 30;
            this.comboBox_Interupt.Text = "Interrupt";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(5, 58);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(152, 26);
            this.button7.TabIndex = 32;
            this.button7.Text = "Set Input Config";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btn_ChangePassword);
            this.groupBox13.Controls.Add(this.textBox_NewPassword);
            this.groupBox13.Location = new System.Drawing.Point(9, 174);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(172, 100);
            this.groupBox13.TabIndex = 52;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Change Password";
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangePassword.Location = new System.Drawing.Point(8, 48);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(152, 26);
            this.btn_ChangePassword.TabIndex = 28;
            this.btn_ChangePassword.Text = "Change Password";
            this.btn_ChangePassword.UseVisualStyleBackColor = true;
            // 
            // textBox_NewPassword
            // 
            this.textBox_NewPassword.Location = new System.Drawing.Point(6, 19);
            this.textBox_NewPassword.Name = "textBox_NewPassword";
            this.textBox_NewPassword.Size = new System.Drawing.Size(120, 22);
            this.textBox_NewPassword.TabIndex = 27;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.comboBox_SMSControl);
            this.groupBox14.Controls.Add(this.button_SMSControl);
            this.groupBox14.Location = new System.Drawing.Point(187, 105);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(122, 80);
            this.groupBox14.TabIndex = 51;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "SMS Control";
            // 
            // comboBox_SMSControl
            // 
            this.comboBox_SMSControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_SMSControl.FormattingEnabled = true;
            this.comboBox_SMSControl.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_SMSControl.Location = new System.Drawing.Point(6, 20);
            this.comboBox_SMSControl.Name = "comboBox_SMSControl";
            this.comboBox_SMSControl.Size = new System.Drawing.Size(101, 21);
            this.comboBox_SMSControl.TabIndex = 25;
            // 
            // button_SMSControl
            // 
            this.button_SMSControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SMSControl.Location = new System.Drawing.Point(6, 47);
            this.button_SMSControl.Name = "button_SMSControl";
            this.button_SMSControl.Size = new System.Drawing.Size(113, 26);
            this.button_SMSControl.TabIndex = 26;
            this.button_SMSControl.Text = "SMS Control";
            this.button_SMSControl.UseVisualStyleBackColor = true;
            this.button_SMSControl.Click += new System.EventHandler(this.Button_SMSControl_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.textBox_FreeText);
            this.groupBox15.Controls.Add(this.comboBox_InputIndex);
            this.groupBox15.Controls.Add(this.button_SetFreeText);
            this.groupBox15.Location = new System.Drawing.Point(187, 24);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(141, 75);
            this.groupBox15.TabIndex = 50;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Set Input Free Text";
            // 
            // textBox_FreeText
            // 
            this.textBox_FreeText.Location = new System.Drawing.Point(52, 16);
            this.textBox_FreeText.Name = "textBox_FreeText";
            this.textBox_FreeText.Size = new System.Drawing.Size(67, 22);
            this.textBox_FreeText.TabIndex = 25;
            // 
            // comboBox_InputIndex
            // 
            this.comboBox_InputIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_InputIndex.FormattingEnabled = true;
            this.comboBox_InputIndex.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_InputIndex.Location = new System.Drawing.Point(8, 17);
            this.comboBox_InputIndex.Name = "comboBox_InputIndex";
            this.comboBox_InputIndex.Size = new System.Drawing.Size(37, 21);
            this.comboBox_InputIndex.TabIndex = 20;
            // 
            // button_SetFreeText
            // 
            this.button_SetFreeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SetFreeText.Location = new System.Drawing.Point(8, 40);
            this.button_SetFreeText.Name = "button_SetFreeText";
            this.button_SetFreeText.Size = new System.Drawing.Size(111, 26);
            this.button_SetFreeText.TabIndex = 24;
            this.button_SetFreeText.Text = "Set Free Text";
            this.button_SetFreeText.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.maskedTextBox3_Subscriber3);
            this.groupBox16.Controls.Add(this.maskedTextBox2_Subscriber2);
            this.groupBox16.Controls.Add(this.maskedTextBox1_Subscriber1);
            this.groupBox16.Controls.Add(this.button4);
            this.groupBox16.Location = new System.Drawing.Point(9, 20);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(172, 149);
            this.groupBox16.TabIndex = 20;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Subscribers";
            // 
            // maskedTextBox3_Subscriber3
            // 
            this.maskedTextBox3_Subscriber3.Location = new System.Drawing.Point(8, 76);
            this.maskedTextBox3_Subscriber3.Name = "maskedTextBox3_Subscriber3";
            this.maskedTextBox3_Subscriber3.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox3_Subscriber3.TabIndex = 28;
            // 
            // maskedTextBox2_Subscriber2
            // 
            this.maskedTextBox2_Subscriber2.Location = new System.Drawing.Point(8, 49);
            this.maskedTextBox2_Subscriber2.Name = "maskedTextBox2_Subscriber2";
            this.maskedTextBox2_Subscriber2.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox2_Subscriber2.TabIndex = 27;
            // 
            // maskedTextBox1_Subscriber1
            // 
            this.maskedTextBox1_Subscriber1.Location = new System.Drawing.Point(8, 24);
            this.maskedTextBox1_Subscriber1.Name = "maskedTextBox1_Subscriber1";
            this.maskedTextBox1_Subscriber1.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox1_Subscriber1.TabIndex = 26;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(6, 107);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 26);
            this.button4.TabIndex = 20;
            this.button4.Text = "Set Subscribers";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1406, 776);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "S1 Requests and Qureies";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox_SMSPhoneNumber
            // 
            this.textBox_SMSPhoneNumber.Location = new System.Drawing.Point(6, 22);
            this.textBox_SMSPhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SMSPhoneNumber.Name = "textBox_SMSPhoneNumber";
            this.textBox_SMSPhoneNumber.Size = new System.Drawing.Size(143, 26);
            this.textBox_SMSPhoneNumber.TabIndex = 10;
            // 
            // button_SendAllCheckedSMS
            // 
            this.button_SendAllCheckedSMS.Location = new System.Drawing.Point(353, 115);
            this.button_SendAllCheckedSMS.Name = "button_SendAllCheckedSMS";
            this.button_SendAllCheckedSMS.Size = new System.Drawing.Size(123, 23);
            this.button_SendAllCheckedSMS.TabIndex = 7;
            this.button_SendAllCheckedSMS.Text = "Send SMS Multi";
            this.button_SendAllCheckedSMS.UseVisualStyleBackColor = true;
            this.button_SendAllCheckedSMS.Click += new System.EventHandler(this.Button39_Click);
            // 
            // button_SendSelectedSMS
            // 
            this.button_SendSelectedSMS.Location = new System.Drawing.Point(482, 115);
            this.button_SendSelectedSMS.Name = "button_SendSelectedSMS";
            this.button_SendSelectedSMS.Size = new System.Drawing.Size(107, 23);
            this.button_SendSelectedSMS.TabIndex = 8;
            this.button_SendSelectedSMS.Text = "Send SMS One";
            this.button_SendSelectedSMS.UseVisualStyleBackColor = true;
            this.button_SendSelectedSMS.Click += new System.EventHandler(this.Button_SendSelectedSMS_Click);
            // 
            // button_Ring
            // 
            this.button_Ring.Location = new System.Drawing.Point(88, 112);
            this.button_Ring.Name = "button_Ring";
            this.button_Ring.Size = new System.Drawing.Size(141, 23);
            this.button_Ring.TabIndex = 14;
            this.button_Ring.Text = "Ring";
            this.button_Ring.UseVisualStyleBackColor = true;
            // 
            // comboBox_SystemType
            // 
            this.comboBox_SystemType.FormattingEnabled = true;
            this.comboBox_SystemType.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.comboBox_SystemType.Location = new System.Drawing.Point(5, 45);
            this.comboBox_SystemType.Name = "comboBox_SystemType";
            this.comboBox_SystemType.Size = new System.Drawing.Size(78, 21);
            this.comboBox_SystemType.TabIndex = 77;
            this.comboBox_SystemType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox2_MouseDown);
            // 
            // timer_General_100ms
            // 
            this.timer_General_100ms.Enabled = true;
            this.timer_General_100ms.Tick += new System.EventHandler(this.Timer_ConectionKeepAlive_Tick);
            // 
            // timer_General_1Second
            // 
            this.timer_General_1Second.Enabled = true;
            this.timer_General_1Second.Interval = 1000;
            this.timer_General_1Second.Tick += new System.EventHandler(this.Timer_General_Tick);
            // 
            // serialPort
            // 
            this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort_ErrorReceived);
            this.serialPort.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(this.serialPort_PinChanged);
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // groupBox36
            // 
            this.groupBox36.Location = new System.Drawing.Point(0, -58);
            this.groupBox36.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox36.Size = new System.Drawing.Size(126, 55);
            this.groupBox36.TabIndex = 11;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "Comm Interface";
            // 
            // groupBox_PhoneNumber
            // 
            this.groupBox_PhoneNumber.Controls.Add(this.textBox_SMSPhoneNumber);
            this.groupBox_PhoneNumber.Location = new System.Drawing.Point(890, 5);
            this.groupBox_PhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_PhoneNumber.Name = "groupBox_PhoneNumber";
            this.groupBox_PhoneNumber.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_PhoneNumber.Size = new System.Drawing.Size(158, 54);
            this.groupBox_PhoneNumber.TabIndex = 12;
            this.groupBox_PhoneNumber.TabStop = false;
            this.groupBox_PhoneNumber.Text = "Phone Number";
            this.groupBox_PhoneNumber.Visible = false;
            // 
            // Label_SerialPortRx
            // 
            this.Label_SerialPortRx.AutoSize = true;
            this.Label_SerialPortRx.Location = new System.Drawing.Point(12, 45);
            this.Label_SerialPortRx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_SerialPortRx.Name = "Label_SerialPortRx";
            this.Label_SerialPortRx.Size = new System.Drawing.Size(23, 18);
            this.Label_SerialPortRx.TabIndex = 108;
            this.Label_SerialPortRx.Text = "Rx";
            // 
            // label_SerialPortConnected
            // 
            this.label_SerialPortConnected.AutoSize = true;
            this.label_SerialPortConnected.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SerialPortConnected.Location = new System.Drawing.Point(8, 21);
            this.label_SerialPortConnected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SerialPortConnected.Name = "label_SerialPortConnected";
            this.label_SerialPortConnected.Size = new System.Drawing.Size(69, 18);
            this.label_SerialPortConnected.TabIndex = 109;
            this.label_SerialPortConnected.Text = "Conneted";
            // 
            // Label_SerialPortTx
            // 
            this.Label_SerialPortTx.AutoSize = true;
            this.Label_SerialPortTx.Location = new System.Drawing.Point(52, 45);
            this.Label_SerialPortTx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_SerialPortTx.Name = "Label_SerialPortTx";
            this.Label_SerialPortTx.Size = new System.Drawing.Size(21, 18);
            this.Label_SerialPortTx.TabIndex = 110;
            this.Label_SerialPortTx.Text = "Tx";
            // 
            // groupBox_SerialPort
            // 
            this.groupBox_SerialPort.Controls.Add(this.label_SerialPortStatus);
            this.groupBox_SerialPort.Controls.Add(this.Label_SerialPortTx);
            this.groupBox_SerialPort.Controls.Add(this.label_SerialPortConnected);
            this.groupBox_SerialPort.Controls.Add(this.Label_SerialPortRx);
            this.groupBox_SerialPort.Location = new System.Drawing.Point(1427, 180);
            this.groupBox_SerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_SerialPort.Name = "groupBox_SerialPort";
            this.groupBox_SerialPort.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_SerialPort.Size = new System.Drawing.Size(174, 82);
            this.groupBox_SerialPort.TabIndex = 111;
            this.groupBox_SerialPort.TabStop = false;
            this.groupBox_SerialPort.Text = "Serial port";
            this.groupBox_SerialPort.Enter += new System.EventHandler(this.groupBox_SerialPort_Enter);
            // 
            // label_SerialPortStatus
            // 
            this.label_SerialPortStatus.AutoSize = true;
            this.label_SerialPortStatus.Location = new System.Drawing.Point(80, 21);
            this.label_SerialPortStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SerialPortStatus.Name = "label_SerialPortStatus";
            this.label_SerialPortStatus.Size = new System.Drawing.Size(42, 18);
            this.label_SerialPortStatus.TabIndex = 111;
            this.label_SerialPortStatus.Text = "None";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressBar_UserStatus);
            this.groupBox4.Controls.Add(this.button97);
            this.groupBox4.Controls.Add(this.textBox_SystemStatus);
            this.groupBox4.Location = new System.Drawing.Point(1427, 482);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(174, 210);
            this.groupBox4.TabIndex = 114;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "User information";
            // 
            // progressBar_UserStatus
            // 
            this.progressBar_UserStatus.Location = new System.Drawing.Point(4, 185);
            this.progressBar_UserStatus.Name = "progressBar_UserStatus";
            this.progressBar_UserStatus.Size = new System.Drawing.Size(158, 23);
            this.progressBar_UserStatus.Step = 1;
            this.progressBar_UserStatus.TabIndex = 115;
            // 
            // button97
            // 
            this.button97.Location = new System.Drawing.Point(109, 158);
            this.button97.Margin = new System.Windows.Forms.Padding(2);
            this.button97.Name = "button97";
            this.button97.Size = new System.Drawing.Size(53, 22);
            this.button97.TabIndex = 114;
            this.button97.Text = "Clear";
            this.button97.UseVisualStyleBackColor = true;
            this.button97.Click += new System.EventHandler(this.button97_Click);
            // 
            // textBox_SystemStatus
            // 
            this.textBox_SystemStatus.Location = new System.Drawing.Point(6, 17);
            this.textBox_SystemStatus.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_SystemStatus.Multiline = true;
            this.textBox_SystemStatus.Name = "textBox_SystemStatus";
            this.textBox_SystemStatus.ReadOnly = true;
            this.textBox_SystemStatus.Size = new System.Drawing.Size(166, 135);
            this.textBox_SystemStatus.TabIndex = 113;
            this.textBox_SystemStatus.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1427, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox_ClentTCPStatus
            // 
            this.groupBox_ClentTCPStatus.Controls.Add(this.label_TCPClient);
            this.groupBox_ClentTCPStatus.Controls.Add(this.Label_TCPClientTx);
            this.groupBox_ClentTCPStatus.Controls.Add(this.label_ClientTCPConnected);
            this.groupBox_ClentTCPStatus.Controls.Add(this.Label_TCPClientRx);
            this.groupBox_ClentTCPStatus.Location = new System.Drawing.Point(1427, 268);
            this.groupBox_ClentTCPStatus.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_ClentTCPStatus.Name = "groupBox_ClentTCPStatus";
            this.groupBox_ClentTCPStatus.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_ClentTCPStatus.Size = new System.Drawing.Size(174, 72);
            this.groupBox_ClentTCPStatus.TabIndex = 112;
            this.groupBox_ClentTCPStatus.TabStop = false;
            this.groupBox_ClentTCPStatus.Text = "Client TCP";
            // 
            // label_TCPClient
            // 
            this.label_TCPClient.AutoSize = true;
            this.label_TCPClient.Location = new System.Drawing.Point(77, 21);
            this.label_TCPClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_TCPClient.Name = "label_TCPClient";
            this.label_TCPClient.Size = new System.Drawing.Size(45, 18);
            this.label_TCPClient.TabIndex = 111;
            this.label_TCPClient.Text = " None";
            // 
            // Label_TCPClientTx
            // 
            this.Label_TCPClientTx.AutoSize = true;
            this.Label_TCPClientTx.Location = new System.Drawing.Point(52, 45);
            this.Label_TCPClientTx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_TCPClientTx.Name = "Label_TCPClientTx";
            this.Label_TCPClientTx.Size = new System.Drawing.Size(21, 18);
            this.Label_TCPClientTx.TabIndex = 110;
            this.Label_TCPClientTx.Text = "Tx";
            // 
            // label_ClientTCPConnected
            // 
            this.label_ClientTCPConnected.AutoSize = true;
            this.label_ClientTCPConnected.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ClientTCPConnected.Location = new System.Drawing.Point(8, 21);
            this.label_ClientTCPConnected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ClientTCPConnected.Name = "label_ClientTCPConnected";
            this.label_ClientTCPConnected.Size = new System.Drawing.Size(69, 18);
            this.label_ClientTCPConnected.TabIndex = 109;
            this.label_ClientTCPConnected.Text = "Conneted";
            // 
            // Label_TCPClientRx
            // 
            this.Label_TCPClientRx.AutoSize = true;
            this.Label_TCPClientRx.Location = new System.Drawing.Point(12, 45);
            this.Label_TCPClientRx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_TCPClientRx.Name = "Label_TCPClientRx";
            this.Label_TCPClientRx.Size = new System.Drawing.Size(23, 18);
            this.Label_TCPClientRx.TabIndex = 108;
            this.Label_TCPClientRx.Text = "Rx";
            // 
            // checkedListBox_PhoneBook
            // 
            this.checkedListBox_PhoneBook.FormattingEnabled = true;
            this.checkedListBox_PhoneBook.Location = new System.Drawing.Point(5, 19);
            this.checkedListBox_PhoneBook.Name = "checkedListBox_PhoneBook";
            this.checkedListBox_PhoneBook.Size = new System.Drawing.Size(279, 289);
            this.checkedListBox_PhoneBook.TabIndex = 0;
            this.checkedListBox_PhoneBook.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox_PhoneBook_SelectedIndexChanged);
            this.checkedListBox_PhoneBook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckedListBox_PhoneBook_KeyDown);
            this.checkedListBox_PhoneBook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckedListBox_PhoneBook_MouseDown);
            // 
            // button_AddContact
            // 
            this.button_AddContact.Location = new System.Drawing.Point(7, 371);
            this.button_AddContact.Name = "button_AddContact";
            this.button_AddContact.Size = new System.Drawing.Size(75, 23);
            this.button_AddContact.TabIndex = 1;
            this.button_AddContact.Text = "Add";
            this.button_AddContact.UseVisualStyleBackColor = true;
            // 
            // button_RemoveContact
            // 
            this.button_RemoveContact.Location = new System.Drawing.Point(88, 371);
            this.button_RemoveContact.Name = "button_RemoveContact";
            this.button_RemoveContact.Size = new System.Drawing.Size(75, 23);
            this.button_RemoveContact.TabIndex = 2;
            this.button_RemoveContact.Text = "Remove";
            this.button_RemoveContact.UseVisualStyleBackColor = true;
            this.button_RemoveContact.Click += new System.EventHandler(this.Button_RemoveContact_Click);
            // 
            // button_ExportToXML
            // 
            this.button_ExportToXML.Location = new System.Drawing.Point(7, 400);
            this.button_ExportToXML.Name = "button_ExportToXML";
            this.button_ExportToXML.Size = new System.Drawing.Size(75, 23);
            this.button_ExportToXML.TabIndex = 3;
            this.button_ExportToXML.Text = "Export";
            this.button_ExportToXML.UseVisualStyleBackColor = true;
            this.button_ExportToXML.Click += new System.EventHandler(this.Button_ExportToXML_Click);
            // 
            // button_ImportToXML
            // 
            this.button_ImportToXML.Location = new System.Drawing.Point(88, 400);
            this.button_ImportToXML.Name = "button_ImportToXML";
            this.button_ImportToXML.Size = new System.Drawing.Size(75, 23);
            this.button_ImportToXML.TabIndex = 4;
            this.button_ImportToXML.Text = "Import";
            this.button_ImportToXML.UseVisualStyleBackColor = true;
            this.button_ImportToXML.Click += new System.EventHandler(this.Button_ImportToXML_Click);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(169, 371);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(75, 23);
            this.button33.TabIndex = 5;
            this.button33.Text = "Edit";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.Button33_Click_2);
            // 
            // richTextBox_ContactDetails
            // 
            this.richTextBox_ContactDetails.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_ContactDetails.Location = new System.Drawing.Point(290, 19);
            this.richTextBox_ContactDetails.Name = "richTextBox_ContactDetails";
            this.richTextBox_ContactDetails.Size = new System.Drawing.Size(166, 328);
            this.richTextBox_ContactDetails.TabIndex = 6;
            this.richTextBox_ContactDetails.Text = "";
            this.richTextBox_ContactDetails.TextChanged += new System.EventHandler(this.RichTextBox_ContactDetails_TextChanged);
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(169, 400);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(75, 23);
            this.button34.TabIndex = 7;
            this.button34.Text = "Backup";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.Button34_Click_2);
            // 
            // richTextBox_TextSendSMS
            // 
            this.richTextBox_TextSendSMS.AutoWordSelection = true;
            this.richTextBox_TextSendSMS.EnableAutoDragDrop = true;
            this.richTextBox_TextSendSMS.Location = new System.Drawing.Point(10, 18);
            this.richTextBox_TextSendSMS.Name = "richTextBox_TextSendSMS";
            this.richTextBox_TextSendSMS.Size = new System.Drawing.Size(579, 91);
            this.richTextBox_TextSendSMS.TabIndex = 2;
            this.richTextBox_TextSendSMS.Text = "";
            this.richTextBox_TextSendSMS.TextChanged += new System.EventHandler(this.RichTextBox_TextSendSMS_TextChanged);
            // 
            // label_SMSSendCharacters
            // 
            this.label_SMSSendCharacters.AutoSize = true;
            this.label_SMSSendCharacters.Location = new System.Drawing.Point(12, 119);
            this.label_SMSSendCharacters.Name = "label_SMSSendCharacters";
            this.label_SMSSendCharacters.Size = new System.Drawing.Size(36, 13);
            this.label_SMSSendCharacters.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(145, 145);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 22);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox_SendSMSAsIs
            // 
            this.checkBox_SendSMSAsIs.AutoSize = true;
            this.checkBox_SendSMSAsIs.Location = new System.Drawing.Point(240, 115);
            this.checkBox_SendSMSAsIs.Name = "checkBox_SendSMSAsIs";
            this.checkBox_SendSMSAsIs.Size = new System.Drawing.Size(116, 22);
            this.checkBox_SendSMSAsIs.TabIndex = 11;
            this.checkBox_SendSMSAsIs.Text = "Send SMS as is";
            this.checkBox_SendSMSAsIs.UseVisualStyleBackColor = true;
            this.checkBox_SendSMSAsIs.CheckedChanged += new System.EventHandler(this.CheckBox_SendSMSAsIs_CheckedChanged);
            // 
            // checkBox_SMSencrypted
            // 
            this.checkBox_SMSencrypted.AutoSize = true;
            this.checkBox_SMSencrypted.Location = new System.Drawing.Point(595, 20);
            this.checkBox_SMSencrypted.Name = "checkBox_SMSencrypted";
            this.checkBox_SMSencrypted.Size = new System.Drawing.Size(89, 22);
            this.checkBox_SMSencrypted.TabIndex = 12;
            this.checkBox_SMSencrypted.Text = "Encrypted";
            this.checkBox_SMSencrypted.UseVisualStyleBackColor = true;
            this.checkBox_SMSencrypted.CheckedChanged += new System.EventHandler(this.CheckBox_SMSencrypted_CheckedChanged);
            // 
            // GrooupBox_Encryption
            // 
            this.GrooupBox_Encryption.Enabled = false;
            this.GrooupBox_Encryption.Location = new System.Drawing.Point(595, 38);
            this.GrooupBox_Encryption.Name = "GrooupBox_Encryption";
            this.GrooupBox_Encryption.Size = new System.Drawing.Size(184, 103);
            this.GrooupBox_Encryption.TabIndex = 13;
            this.GrooupBox_Encryption.TabStop = false;
            // 
            // textBox_UnitIDForSMS
            // 
            this.textBox_UnitIDForSMS.Location = new System.Drawing.Point(54, 17);
            this.textBox_UnitIDForSMS.MaxLength = 16;
            this.textBox_UnitIDForSMS.Name = "textBox_UnitIDForSMS";
            this.textBox_UnitIDForSMS.Size = new System.Drawing.Size(124, 20);
            this.textBox_UnitIDForSMS.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            // 
            // textBox_CodeArrayForSMS
            // 
            this.textBox_CodeArrayForSMS.Location = new System.Drawing.Point(54, 46);
            this.textBox_CodeArrayForSMS.MaxLength = 4;
            this.textBox_CodeArrayForSMS.Name = "textBox_CodeArrayForSMS";
            this.textBox_CodeArrayForSMS.Size = new System.Drawing.Size(124, 20);
            this.textBox_CodeArrayForSMS.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 3;
            // 
            // richTextBox_ModemStatus
            // 
            this.richTextBox_ModemStatus.Location = new System.Drawing.Point(7, 19);
            this.richTextBox_ModemStatus.Name = "richTextBox_ModemStatus";
            this.richTextBox_ModemStatus.Size = new System.Drawing.Size(256, 115);
            this.richTextBox_ModemStatus.TabIndex = 0;
            this.richTextBox_ModemStatus.Text = "";
            // 
            // comboBox_ComportSMS
            // 
            this.comboBox_ComportSMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ComportSMS.FormattingEnabled = true;
            this.comboBox_ComportSMS.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.comboBox_ComportSMS.Location = new System.Drawing.Point(290, 22);
            this.comboBox_ComportSMS.Name = "comboBox_ComportSMS";
            this.comboBox_ComportSMS.Size = new System.Drawing.Size(67, 21);
            this.comboBox_ComportSMS.TabIndex = 9;
            this.comboBox_ComportSMS.Tag = "1";
            this.comboBox_ComportSMS.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged_2);
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(269, 109);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(75, 23);
            this.button36.TabIndex = 6;
            this.button36.Text = "Clear";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.Button36_Click);
            // 
            // checkBox_OpenPortSMS
            // 
            this.checkBox_OpenPortSMS.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_OpenPortSMS.AutoSize = true;
            this.checkBox_OpenPortSMS.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_OpenPortSMS.Location = new System.Drawing.Point(363, 20);
            this.checkBox_OpenPortSMS.Name = "checkBox_OpenPortSMS";
            this.checkBox_OpenPortSMS.Size = new System.Drawing.Size(84, 29);
            this.checkBox_OpenPortSMS.TabIndex = 10;
            this.checkBox_OpenPortSMS.Text = "Open Port";
            this.checkBox_OpenPortSMS.UseVisualStyleBackColor = true;
            this.checkBox_OpenPortSMS.CheckedChanged += new System.EventHandler(this.CheckBox_OpenPortSMS_CheckedChanged);
            // 
            // checkBox_DebugSMS
            // 
            this.checkBox_DebugSMS.AutoSize = true;
            this.checkBox_DebugSMS.Location = new System.Drawing.Point(390, 54);
            this.checkBox_DebugSMS.Name = "checkBox_DebugSMS";
            this.checkBox_DebugSMS.Size = new System.Drawing.Size(67, 22);
            this.checkBox_DebugSMS.TabIndex = 11;
            this.checkBox_DebugSMS.Text = "Debug";
            this.checkBox_DebugSMS.UseVisualStyleBackColor = true;
            // 
            // button_ClearSMSConsole
            // 
            this.button_ClearSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearSMSConsole.Location = new System.Drawing.Point(395, 630);
            this.button_ClearSMSConsole.Name = "button_ClearSMSConsole";
            this.button_ClearSMSConsole.Size = new System.Drawing.Size(62, 26);
            this.button_ClearSMSConsole.TabIndex = 6;
            this.button_ClearSMSConsole.Text = "Clear";
            this.button_ClearSMSConsole.UseVisualStyleBackColor = true;
            // 
            // checkBox_PauseSMSConsole
            // 
            this.checkBox_PauseSMSConsole.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_PauseSMSConsole.AutoSize = true;
            this.checkBox_PauseSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_PauseSMSConsole.Location = new System.Drawing.Point(327, 630);
            this.checkBox_PauseSMSConsole.Name = "checkBox_PauseSMSConsole";
            this.checkBox_PauseSMSConsole.Size = new System.Drawing.Size(62, 26);
            this.checkBox_PauseSMSConsole.TabIndex = 5;
            this.checkBox_PauseSMSConsole.Text = "Pause";
            this.checkBox_PauseSMSConsole.UseVisualStyleBackColor = true;
            // 
            // checkBox_RecordSMSConsole
            // 
            this.checkBox_RecordSMSConsole.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordSMSConsole.AutoSize = true;
            this.checkBox_RecordSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordSMSConsole.Location = new System.Drawing.Point(222, 630);
            this.checkBox_RecordSMSConsole.Name = "checkBox_RecordSMSConsole";
            this.checkBox_RecordSMSConsole.Size = new System.Drawing.Size(99, 26);
            this.checkBox_RecordSMSConsole.TabIndex = 7;
            this.checkBox_RecordSMSConsole.Text = "Record Log";
            this.checkBox_RecordSMSConsole.UseVisualStyleBackColor = true;
            // 
            // richTextBox_SMSConsole
            // 
            this.richTextBox_SMSConsole.EnableAutoDragDrop = true;
            this.richTextBox_SMSConsole.Location = new System.Drawing.Point(6, 17);
            this.richTextBox_SMSConsole.Name = "richTextBox_SMSConsole";
            this.richTextBox_SMSConsole.Size = new System.Drawing.Size(451, 607);
            this.richTextBox_SMSConsole.TabIndex = 0;
            this.richTextBox_SMSConsole.Text = "";
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(7, 359);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(75, 23);
            this.button41.TabIndex = 1;
            this.button41.Text = "Add";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.Button41_Click);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(88, 359);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(75, 23);
            this.button40.TabIndex = 2;
            this.button40.Text = "Remove";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.Button40_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(7, 395);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(75, 23);
            this.button39.TabIndex = 3;
            this.button39.Text = "Export";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.Button39_Click_1);
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(88, 395);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(75, 23);
            this.button38.TabIndex = 4;
            this.button38.Text = "Import";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.Button38_Click);
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(169, 359);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(75, 23);
            this.button37.TabIndex = 5;
            this.button37.Text = "Edit";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.Button37_Click);
            // 
            // listBox_SMSCommands
            // 
            this.listBox_SMSCommands.FormattingEnabled = true;
            this.listBox_SMSCommands.Location = new System.Drawing.Point(6, 17);
            this.listBox_SMSCommands.Name = "listBox_SMSCommands";
            this.listBox_SMSCommands.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_SMSCommands.Size = new System.Drawing.Size(303, 290);
            this.listBox_SMSCommands.TabIndex = 6;
            this.listBox_SMSCommands.SelectedIndexChanged += new System.EventHandler(this.ListBox_SMSCommands_SelectedIndexChanged_1);
            // 
            // button_WriteCatalinas
            // 
            this.button_WriteCatalinas.Location = new System.Drawing.Point(789, 449);
            this.button_WriteCatalinas.Name = "button_WriteCatalinas";
            this.button_WriteCatalinas.Size = new System.Drawing.Size(144, 23);
            this.button_WriteCatalinas.TabIndex = 69;
            this.button_WriteCatalinas.Text = "Write Files To Flash";
            this.button_WriteCatalinas.UseVisualStyleBackColor = true;
            this.button_WriteCatalinas.Click += new System.EventHandler(this.button72_Click_2);
            // 
            // textBox_FilesToWriteForTheCatalinas
            // 
            this.textBox_FilesToWriteForTheCatalinas.Location = new System.Drawing.Point(0, 311);
            this.textBox_FilesToWriteForTheCatalinas.Name = "textBox_FilesToWriteForTheCatalinas";
            this.textBox_FilesToWriteForTheCatalinas.Size = new System.Drawing.Size(933, 131);
            this.textBox_FilesToWriteForTheCatalinas.TabIndex = 70;
            this.textBox_FilesToWriteForTheCatalinas.Text = "";
            this.textBox_FilesToWriteForTheCatalinas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_FilesToWriteForTheCatalinas2_MouseDown);
            // 
            // richTextBox_SyntisazerL1
            // 
            this.richTextBox_SyntisazerL1.Location = new System.Drawing.Point(5, 111);
            this.richTextBox_SyntisazerL1.Name = "richTextBox_SyntisazerL1";
            this.richTextBox_SyntisazerL1.Size = new System.Drawing.Size(161, 124);
            this.richTextBox_SyntisazerL1.TabIndex = 71;
            this.richTextBox_SyntisazerL1.Text = "";
            this.richTextBox_SyntisazerL1.TextChanged += new System.EventHandler(this.richTextBox_SyntisazerL1_TextChanged);
            this.richTextBox_SyntisazerL1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox_SyntisazerL1_MouseDown);
            // 
            // richTextBox_SyntisazerL2
            // 
            this.richTextBox_SyntisazerL2.Location = new System.Drawing.Point(243, 108);
            this.richTextBox_SyntisazerL2.Name = "richTextBox_SyntisazerL2";
            this.richTextBox_SyntisazerL2.Size = new System.Drawing.Size(161, 132);
            this.richTextBox_SyntisazerL2.TabIndex = 72;
            this.richTextBox_SyntisazerL2.Text = "";
            this.richTextBox_SyntisazerL2.TextChanged += new System.EventHandler(this.richTextBox_SyntisazerL2_TextChanged);
            this.richTextBox_SyntisazerL2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox_SyntisazerL2_MouseDown);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A",
            "B"});
            this.comboBox1.Location = new System.Drawing.Point(371, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(37, 21);
            this.comboBox1.TabIndex = 73;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_3);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 87);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 13);
            this.label20.TabIndex = 74;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(240, 83);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 13);
            this.label21.TabIndex = 75;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 13);
            this.label22.TabIndex = 76;
            // 
            // button_WriteSystemType
            // 
            this.button_WriteSystemType.Location = new System.Drawing.Point(89, 45);
            this.button_WriteSystemType.Name = "button_WriteSystemType";
            this.button_WriteSystemType.Size = new System.Drawing.Size(188, 23);
            this.button_WriteSystemType.TabIndex = 78;
            this.button_WriteSystemType.Text = "Write System type to flash";
            this.button_WriteSystemType.UseVisualStyleBackColor = true;
            this.button_WriteSystemType.Click += new System.EventHandler(this.button73_Click_1);
            // 
            // button_SynthL1
            // 
            this.button_SynthL1.Location = new System.Drawing.Point(2, 244);
            this.button_SynthL1.Name = "button_SynthL1";
            this.button_SynthL1.Size = new System.Drawing.Size(227, 23);
            this.button_SynthL1.TabIndex = 79;
            this.button_SynthL1.Text = "Write Synthesizer L1";
            this.button_SynthL1.UseVisualStyleBackColor = true;
            this.button_SynthL1.Click += new System.EventHandler(this.button96_Click_2);
            // 
            // button_WriteAllToFlash
            // 
            this.button_WriteAllToFlash.BackColor = System.Drawing.Color.Transparent;
            this.button_WriteAllToFlash.Location = new System.Drawing.Point(789, 24);
            this.button_WriteAllToFlash.Name = "button_WriteAllToFlash";
            this.button_WriteAllToFlash.Size = new System.Drawing.Size(144, 34);
            this.button_WriteAllToFlash.TabIndex = 80;
            this.button_WriteAllToFlash.Text = "Write all to flash";
            this.button_WriteAllToFlash.UseVisualStyleBackColor = false;
            this.button_WriteAllToFlash.Click += new System.EventHandler(this.button100_Click_2);
            // 
            // button_SynthL2
            // 
            this.button_SynthL2.Location = new System.Drawing.Point(243, 244);
            this.button_SynthL2.Name = "button_SynthL2";
            this.button_SynthL2.Size = new System.Drawing.Size(227, 23);
            this.button_SynthL2.TabIndex = 81;
            this.button_SynthL2.Text = "Write Synthesizer L2";
            this.button_SynthL2.UseVisualStyleBackColor = true;
            this.button_SynthL2.Click += new System.EventHandler(this.button101_Click);
            // 
            // progressBar_WriteToFlash
            // 
            this.progressBar_WriteToFlash.Location = new System.Drawing.Point(789, 68);
            this.progressBar_WriteToFlash.Name = "progressBar_WriteToFlash";
            this.progressBar_WriteToFlash.Size = new System.Drawing.Size(144, 23);
            this.progressBar_WriteToFlash.TabIndex = 82;
            // 
            // label_Projectname
            // 
            this.label_Projectname.AutoSize = true;
            this.label_Projectname.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Projectname.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_Projectname.Location = new System.Drawing.Point(6, 14);
            this.label_Projectname.Name = "label_Projectname";
            this.label_Projectname.Size = new System.Drawing.Size(127, 26);
            this.label_Projectname.TabIndex = 116;
            this.label_Projectname.Text = "Project name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_Projectname);
            this.groupBox1.Location = new System.Drawing.Point(1427, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 50);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project name";
            // 
            // saveFileDialog_Local
            // 
            this.saveFileDialog_Local.FileName = "Script.txt";
            this.saveFileDialog_Local.RestoreDirectory = true;
            // 
            // openFileDialog_Local
            // 
            this.openFileDialog_Local.InitialDirectory = ".";
            this.openFileDialog_Local.RestoreDirectory = true;
            // 
            // checkBox_Openall
            // 
            this.checkBox_Openall.AutoSize = true;
            this.checkBox_Openall.Location = new System.Drawing.Point(1433, 375);
            this.checkBox_Openall.Name = "checkBox_Openall";
            this.checkBox_Openall.Size = new System.Drawing.Size(109, 22);
            this.checkBox_Openall.TabIndex = 118;
            this.checkBox_Openall.Text = "Open all Tabs";
            this.checkBox_Openall.UseVisualStyleBackColor = true;
            this.checkBox_Openall.CheckedChanged += new System.EventHandler(this.checkBox_Openall_CheckedChanged);
            // 
            // button_ScriptRunFromFile
            // 
            this.button_ScriptRunFromFile.BackColor = System.Drawing.Color.SkyBlue;
            this.button_ScriptRunFromFile.Location = new System.Drawing.Point(463, 219);
            this.button_ScriptRunFromFile.Name = "button_ScriptRunFromFile";
            this.button_ScriptRunFromFile.Size = new System.Drawing.Size(89, 45);
            this.button_ScriptRunFromFile.TabIndex = 83;
            this.button_ScriptRunFromFile.Text = "Run From File";
            this.button_ScriptRunFromFile.UseVisualStyleBackColor = false;
            this.button_ScriptRunFromFile.Click += new System.EventHandler(this.button_ScriptRunFromFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1543, 728);
            this.Controls.Add(this.checkBox_Openall);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_ClentTCPStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button_OpenFolder);
            this.Controls.Add(this.groupBox_SerialPort);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.groupBox36);
            this.Controls.Add(this.groupBox_PhoneNumber);
            this.Controls.Add(this.groupBox42);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "3036 - mIFRS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox_ServerSettings.ResumeLayout(false);
            this.groupBox_ServerSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_ServerTCP.ResumeLayout(false);
            this.tabPage_ServerTCP.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage_ClientTCP.ResumeLayout(false);
            this.tabPage_ClientTCP.PerformLayout();
            this.tabPage_charts.ResumeLayout(false);
            this.tabPage_charts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage_SerialPort.ResumeLayout(false);
            this.groupBox_SendSerialOrMonitorCommands.ResumeLayout(false);
            this.groupBox_SendSerialOrMonitorCommands.PerformLayout();
            this.gbPortSettings.ResumeLayout(false);
            this.gbPortSettings.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox_Timer.ResumeLayout(false);
            this.groupBox_Timer.PerformLayout();
            this.groupBox_Stopwatch.ResumeLayout(false);
            this.groupBox_Stopwatch.PerformLayout();
            this.tabPage_Commands.ResumeLayout(false);
            this.groupBox40.ResumeLayout(false);
            this.tabControl_System.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox_AllCommands.ResumeLayout(false);
            this.groupBox_Help.ResumeLayout(false);
            this.groupBox_CLISendCommand.ResumeLayout(false);
            this.groupBox_CLISendCommand.PerformLayout();
            this.tabPage2_Script.ResumeLayout(false);
            this.tabPage2_Script.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.groupBox42.ResumeLayout(false);
            this.groupBox42.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.S1_Configuration.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox_PhoneNumber.ResumeLayout(false);
            this.groupBox_PhoneNumber.PerformLayout();
            this.groupBox_SerialPort.ResumeLayout(false);
            this.groupBox_SerialPort.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_ClentTCPStatus.ResumeLayout(false);
            this.groupBox_ClentTCPStatus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private readonly List<string> CommandsHistoy = new List<string>();
        //   private readonly List<string> CLI_CommandsHistoy = new List<string>();
        private int HistoryIndex = -1;
        private int CLI_HistoryIndex = Monitor.Properties.Settings.Default.CLICommad_History.Count - 1;
        // bool SelfMonitorCommandsMode = false;


        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //Change appearance of tabcontrol
            Brush backBrush;
            Brush foreBrush;

            backBrush = new SolidBrush(Color.Red);
            foreBrush = new SolidBrush(Color.Blue);

            e.Graphics.FillRectangle(backBrush, e.Bounds);

            //You may need to write the label here also?
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString("my label", e.Font, foreBrush, r, sf);
        }

        private void ListBox_SMSCommands_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;
            if (itemIndex >= 0 && itemIndex < listBox_SMSCommands.Items.Count)
            {
                Graphics g = e.Graphics;

                // Background Color
                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? Color.Red : Color.White);
                g.FillRectangle(backgroundColorBrush, e.Bounds);

                // Set text color
                string itemText = listBox_SMSCommands.Items[itemIndex].ToString();

                SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(Color.White) : new SolidBrush(Color.Black);
                g.DrawString(itemText, e.Font, itemTextColorBrush, listBox_SMSCommands.GetItemRectangle(itemIndex).Location);

                // Clean up
                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }

            e.DrawFocusRectangle();
        }

        private void ListBox_SMSCommands_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedCommand();
            }
        }

        private void CheckedListBox_PhoneBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedContact();
            }
        }

        private static bool PhoneBookIsChecked = false;

        private void CheckedListBox_PhoneBook_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PhoneBookIsChecked = !PhoneBookIsChecked;

                if (PhoneBookIsChecked == true)
                {
                    for (int x = 0; x < checkedListBox_PhoneBook.Items.Count; x++)
                    {
                        checkedListBox_PhoneBook.SetItemChecked(x, true);
                    }
                }
                else
                {
                    for (int x = 0; x < checkedListBox_PhoneBook.Items.Count; x++)
                    {
                        checkedListBox_PhoneBook.SetItemChecked(x, false);
                    }
                }

            }
        }

        private void TextBox_GeneralMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Then Enter key was pressed

                //button29.PerformClick();
            }
        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            Application.Run(new MainForm());


        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }





        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (comboBox_ConnectionNumber.Text == "None")
            {
                return;
            }
            try
            {
                //int ConNum = int.Parse(comboBox_ConnectionNumber.Text);
                string SendString =/*tempcount.ToString() + "  " +*/ txtDataTx.Text;
                object objData = SendString;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                SendDataToServer(comboBox_ConnectionNumber.SelectedItem.ToString(), byData);
            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }
        }

        private bool SerialPortSendData(byte[] i_SendData)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    // Send the binary data out the port
                    serialPort.Write(i_SendData, 0, i_SendData.Length);

                    return true;

                }
            }
            catch (Exception ex)
            {
                SendExceptionToTheMonitor(ex.Message.ToString());

            }


            return false;
        }

        private void SendExceptionToTheMonitor(string i_Message)
        {
            SerialPortLogger.LogMessage(Color.Red, Color.LightGray, i_Message, New_Line = true, Show_Time = true);
        }

        //Color oldColor;
        private Gil_Server.Server m_Server;
        private void ListenBox_CheckedChanged(object sender, EventArgs e)
        {
            // Gil: Just to remove the warnings
            New_Line = !New_Line;
            Show_Time = !Show_Time;


            if (ListenBox.Checked)
            {
                //m_Exit = false;
                //oldColor = ListenBox.BackColor;
                ListenBox.BackColor = Color.Gray;
                try
                {


                    m_Server = new Gil_Server.Server(txtPortNo.Text);
                    m_Server.DataRecievedNotifyDelegate += new EventHandler(GilServer_DataRecievedNotifyDelegate);
                    m_Server.InformationNotifyDelegate += new EventHandler(Server_InformationNotifyDelegate);

                    m_Server.Open_Server();

                    txtPortNo.Enabled = false;



                }
                catch (SocketException se)
                {
                    ServerLogger.LogMessage(Color.Black, Color.White, "Exception:  " + se.ToString(), true, true);
                }
            }
            else
            {
                ListenBox.BackColor = default;

                m_Server.Close_Server();

                txtPortNo.Enabled = true;

            }
        }

        private void Server_InformationNotifyDelegate(object sender, EventArgs e)
        {
            Gil_Server.Server.stringEventArgs mye = (Gil_Server.Server.stringEventArgs)e;

            ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            ServerLogger.LogMessage(Color.Brown, Color.White, "[Internal Server] ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.Black, Color.White, mye.StrData, New_Line = true, Show_Time = false);
        }



        //string[] UnitNumberToConnections = new string[30];
        private readonly Dictionary<string, string> ConnectionToIDdictionary = new Dictionary<string, string>();
        private readonly Dictionary<string, string> IDToFOTA_Status = new Dictionary<string, string>();

        private void GilServer_DataRecievedNotifyDelegate(object sender, EventArgs e)
        {
            Gil_Server.Server.DataEventArgs mye = (Gil_Server.Server.DataEventArgs)e;

            var RecievedString = System.Text.Encoding.Default.GetString(mye.BytesData);

            //ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            //ServerLogger.LogMessage(Color.Brown, Color.White, "[Internal Server] ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.Black, Color.White, RecievedString, New_Line = true, Show_Time = true);
            ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = true, Show_Time = false);

            if (checkBox_EchoResponse.Checked == true)
            {

                string ACKBack = string.Format("[{0}],ACK", RecievedString);
                //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                SendDataToServer(mye.ConnectionNumber, b2);
            }











        }

        private void PrintFotaIDStatus()
        {

        }

        //void SendToConfigPage(string i_ConfigString, string i_Source)
        //{
        //    bool SuccessParse = ParseConfigString(i_ConfigString);

        //    if (SuccessParse == true)
        //    {
        //        textBox_SourceConfig.Invoke(new EventHandler(delegate
        //        {
        //            textBox_SourceConfig.Text = "Configuration Loaded successfully from " + i_Source + "\nDate: " + DateTime.Now.ToString();
        //            textBox_SourceConfig.BackColor = Color.LightGreen;
        //        }));

        //    }
        //    else
        //    {
        //    }
        //}

        private byte CalcCheckSumbufferSize(byte[] i_buffer)
        {
            byte ret = 0;
            for (int i = 0; i < i_buffer.Length; i++)
            {
                ret += i_buffer[i];
            }
            return ret;
        }

        private byte CalcCheckSumbuffer(byte[] i_buffer)
        {
            byte ret = 0;
            for (int i = 0; i < 1280; i++)
            {
                ret += i_buffer[i];
            }
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private void SendDataToServer(string i_Connection, byte[] i_Data)
        {
            bool Issent;

            Issent = WriteDataToServer(i_Connection, i_Data);

            ASCIIEncoding encoder = new ASCIIEncoding();

            string Str = encoder.GetString(i_Data);

            if (Issent == true)
            {
                ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                ServerLogger.LogMessage(Color.DarkViolet, Color.White, "Send Data: ", false, false);
                ServerLogger.LogMessage(Color.DarkViolet, Color.White, " Connection: " + i_Connection, false, false);
                ServerLogger.LogMessage(Color.DarkGreen, Color.White, "   " + Str, true, false);

            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void TxtDataTx_TextChanged(object sender, EventArgs e)
        {
            Monitor.Properties.Settings.Default.Default_Server_Message = txtDataTx.Text;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                //List<string> S1frameArray = new List<string>();
                //S1frameArray.Add(S1_Protocol.S1_Messege_Builder.Get_Status());
                //SendS1Message(S1frameArray);


            }
            catch (SocketException ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
        }


        //private void button5_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        List<string> S1frameArray = new List<string>();
        //        S1frameArray.Add(S1_Protocol.S1_Messege_Builder.Arm_Disarm_Unit(comboBox_ArmDisArm.Text));
        //        SendS1Message(S1frameArray);


        //    }
        //    catch (SocketException ex)
        //    {
        //        ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
        //    }
        //}




        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="i_S1frameArray"></param>
        ///// <returns>return bool if sent or not</returns>
        //bool SendS1Message(List<string> i_S1frameArray)
        //{
        //    bool ret = false;

        //    return ret;
        //}

        private bool WriteDataToServer(string i_ConnectionNumber, byte[] i_Data)
        {
            if (m_Server != null && m_Server.IsConnectedToClient && m_Server.IsServerActive)
            {
                m_Server.WriteDataToServer(i_ConnectionNumber, i_Data);
                return true;
            }

            return false;
        }



        private void ComboBox_InputIndex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void Button23_Click(object sender, EventArgs e)
        {

        }


        private void Button24_Click(object sender, EventArgs e)
        {

        }

        private void Button_SMSControl_Click(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void Button13_Click(object sender, EventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {

        }

        private void Button19_Click(object sender, EventArgs e)
        {

        }

        private void Button22_Click(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {

        }

        private void Button21_Click(object sender, EventArgs e)
        {

        }

        private void Button14_Click(object sender, EventArgs e)
        {

        }


        private void Button15_Click(object sender, EventArgs e)
        {

        }

        private void Button16_Click(object sender, EventArgs e)
        {

        }

        private void Button17_Click(object sender, EventArgs e)
        {

        }

        private void Button18_Click(object sender, EventArgs e)
        {

        }

        private void Button26_Click(object sender, EventArgs e)
        {

        }

        private void Button27_Click(object sender, EventArgs e)
        {

        }

        private void Button25_Click(object sender, EventArgs e)
        {

        }

        private void Button20_Click(object sender, EventArgs e)
        {

        }

        private void TxtS1_Clear_Click_1(object sender, EventArgs e)
        {
            try
            {
                SerialPortLogger_TextBox.Invoke(new EventHandler(delegate
                {

                    SerialPortLogger_TextBox.Text = "";

                }));
            }
            catch
            {
            }
        }


        //void ClacPhoneBookTimeForPeriodOfSystem()
        //{
        //    System.Windows.Forms.Application.Exit();
        //}
        private TextBox_Logger SystemLogger;
        private TextBox_Logger ServerLogger ;
        private TextBox_Logger SerialPortLogger;

        //   Logger LogIWatcher;
        // TextBox_Logger LogSMS;
        //   PhoneBook MyPhoneBook;
        //    readonly List<Series> List_SeriesCharts = new List<Series>();
        //    readonly Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series
        //    {
        //        Name = "Raw Data",
        //        //    Color = System.Drawing.Color.Green,
        //        IsVisibleInLegend = true,
        //        IsXValueIndexed = false,
        //        ChartType = SeriesChartType.Line,
        //        MarkerStyle = MarkerStyle.Diamond

        //};
        //    readonly Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series
        //    {
        //        Name = "Moving Avarage 30",
        //        //    Color = System.Drawing.Color.Blue,
        //        IsVisibleInLegend = true,
        //        IsXValueIndexed = false,
        //        ChartType = SeriesChartType.Line
        //    };
        //    readonly Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series
        //    {
        //        Name = "0-100",
        //        //    Color = System.Drawing.Color.Blue,
        //        IsVisibleInLegend = true,
        //        IsXValueIndexed = false,
        //        ChartType = SeriesChartType.Line,
        //        MarkerStyle = MarkerStyle.Circle
        //    };

        private Point? prevPosition = null;
        private readonly ToolTip tooltip = new ToolTip();

        private void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
            {
                return;
            }

            tooltip.RemoveAll();
            prevPosition = pos;
            HitTestResult[] results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (HitTestResult result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        double pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        double pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 3 &&
                            Math.Abs(pos.Y - pointYPixel) < 3)
                        {
                            //textBox_graph_XY.Text = "Chart=" + result.Series.Name + "\n, X=" + prop.XValue.ToString() + ", Y=" + prop.YValues[0].ToString();

                            tooltip.Show("X=" + prop.XValue.ToString("0.##E+0") + ", Y=" + prop.YValues[0], chart1,
                                            pos.X, pos.Y - 15, 9999999);
                        }
                    }
                }
            }
        }

        private void Chart1_MouseClick(object sender, MouseEventArgs e)
        {
            Point pos = e.Location;
            //if (prevPosition.HasValue && pos == prevPosition.Value)
            //    return;
            tooltip.RemoveAll();
            prevPosition = pos;
            HitTestResult[] results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (HitTestResult result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    if (result.Object is DataPoint prop)
                    {
                        double pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        double pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 3 &&
                            Math.Abs(pos.Y - pointYPixel) < 3)
                        {
                            // chart1.Series[result.Series.Name].Points[(int)prop.XValue].Label = "X=" + prop.XValue + ", Y=" + prop.YValues[0].ToString("0.00");
                            prop.Label = "X=" + prop.XValue.ToString(".#E+0") + ", Y=" + prop.YValues[0].ToString("0.00");
                        }
                    }
                }
            }
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            ClientSocket.Close();

            if (ReceiveThread != null)
            {
                ReceiveThread.Abort();
                //   m_Exit = true;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_cmd"></param>
        /// <param name="i_InputArgs"></param>
        //public void System1_parser_sum_CB(OneSystemCommand i_cmd, String[] i_InputArgs)
        //{
        //    int sum = 0;
        //    if (i_InputArgs[0] == "?")
        //    {
        //        SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "Sum CB: " + i_cmd.Help, New_Line = true, Show_Time = true);
        //    }
        //    else
        //    {
        //        foreach (String str in i_InputArgs)
        //        {
        //            sum += Int32.Parse(str);

        //        }

        //        SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "Sum CB: sum = " + sum, New_Line = true, Show_Time = true);
        //    }
        //}



        //readonly System1_parser system1_Parser = new System1_parser();

        static List<DataGridView> List_AllDataGrids = new List<DataGridView>();
        static List<CommandClass> List_AllCommands = new List<CommandClass>();
 

      

        private void FindControls(Control ctl)
        {

            if (ctl.GetType().FullName == "System.Windows.Forms.TextBox")
            {
                TextBox txt = (TextBox)ctl;
                string temp = txt.Text;
                txt.Text = " ";
                txt.Text = temp;
            }

            if (ctl.GetType().FullName == "System.Windows.Forms.RichTextBox")
            {
                RichTextBox txt = (RichTextBox)ctl;

                txt.Invoke(new EventHandler(delegate
                {

                    string temp = txt.Text;
                    txt.Text = "";
                    txt.AppendText(temp);
                }));

            }

            if (ctl.GetType().FullName == "System.Windows.Forms.CheckBox")
            {
                CheckBox chk = (CheckBox)ctl;
            }

            foreach (Control ctrl in ctl.Controls)
            {
                FindControls(ctrl);
            }

        }



        private void Txtbx_GotFocus(object sender, EventArgs e)
        {
            //  TextBox txtbx = (TextBox)sender;
            // textBox_ConfigurationHelp.Text = "";
            //textBox_ConfigurationHelp.Text = txtbx.Name + "\n" + toolTip1.GetToolTip(txtbx);

        }

        private void TextBox_SerialPortRecognizePattern3_GotFocus(object sender, EventArgs e)
        {
            SerialPortLogger.LogMessage(Color.Black, Color.Yellow, "Got focus", New_Line = true, Show_Time = true);
        }

        private void TextBox_SendSerialPort_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                // MessageBox.Show("Tab");
                e.IsInputKey = true;
            }
            if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                //  MessageBox.Show("Shift + Tab");
                e.IsInputKey = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseClentConnection();
            m_Exit = true;
            System.GC.Collect();
        }

        //Color Tab0Color;
        //Color Tab1Color;
        //Color Tab2Color;
        //Color Tab3Color;
        private void TabControl1_DrawItem1(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl_Main.TabPages[e.Index];
            Color TabColor;
            if (e.Index == tabControl_Main.SelectedIndex)
            {
                TabColor = Color.Aqua;
            }
            else
            {
                TabColor = default;
            }

            //switch (e.Index)
            //{
            //    case 0:
            //        e.Graphics.FillRectangle(new SolidBrush(Tab0Color), e.Bounds);
            //        break;
            //    case 1:
            //        e.Graphics.FillRectangle(new SolidBrush(Tab1Color), e.Bounds);
            //        break;
            //    default:
            //        break;
            //}

            e.Graphics.FillRectangle(new SolidBrush(TabColor), e.Bounds);
            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, page.ForeColor);
        }

        private void TextBox_SendNumberOfTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_SendSerialDiff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SaveCommandsAndContacts()
        {
            string subPath = Directory.GetCurrentDirectory() + "\\SMS_Backup\\";
            string m_log_file_name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_Contacts" + ".xml";
            string filesName = m_log_file_name;

            bool isExists = System.IO.Directory.Exists(subPath);

            if (!isExists)
            {
                System.IO.Directory.CreateDirectory(subPath);
            }


            m_log_file_name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "____________Commands" + ".xml";
            filesName += "\n" + m_log_file_name;
            using (Stream myStream = File.Create(subPath + m_log_file_name))
            {
                List<string> templist = new List<string>();
                foreach (object item in listBox_SMSCommands.Items)
                {
                    templist.Add((string)item);
                }
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                TextWriter textWriter = new StreamWriter(myStream);

                serializer.Serialize(textWriter, templist);
                textWriter.Close();
                // Code to write the stream goes here.
                myStream.Close();
            }


            Monitor.Properties.Settings.Default.Save();

            // LogSMS.LogMessage(Color.Brown, Color.White, " 2 Backup files of contacts and commands Created at \n" + subPath + "\n" + filesName, New_Line = true, Show_Time = true);


        }

        //void ShowHidePages()
        //{
        //    if (Monitor.Properties.Settings.Default.RemovePages != null)
        //    {
        //        int i = 0;
        //        foreach (string str in Monitor.Properties.Settings.Default.RemovePages)
        //        {
        //            try
        //            {
        //                // comboBox_SerialPortHistory.Items.Add((object)str);
        //                // comboBox_SMSCommands.Items.Add(str);
        //                Int32 indexToRemove = Int32.Parse(str);

        //                tabControl1.TabPages.RemoveAt(indexToRemove - i);
        //                i++;
        //            }
        //            catch
        //            {
        //                break;
        //            }

        //        }
        //    }
        //}

        // Dictionary<string, TextBox> Dictionary_ConfigurationTextBoxes;
        private readonly List<TextBox> List_ConfigurationTextBoxes = new List<TextBox>();


        //static public List<string> GetAllCommands()
        //{
        //    Type type = typeof(S1_Protocol.S1_Messege_Builder);
        //    MethodInfo[] info = type.GetMethods();
        //    List<string> ret = new List<string>();

        //    Type type_Object = typeof(Object);
        //    MethodInfo[] info_Object = type_Object.GetMethods();
        //    foreach (MethodInfo inf in info)
        //    {
        //        bool Add = true;
        //        foreach (MethodInfo inf_Obj in info_Object)
        //        {
        //            if (inf_Obj.Name == inf.Name)
        //            {
        //                Add = false;
        //            }
        //        }
        //        if (Add)
        //        {
        //            ret.Add(inf.Name);
        //        }

        //    }
        //    return ret;

        //}

        //void toolStripMenuItem_CopyToSingle_Click(object sender, EventArgs e)
        //{
        //    textBox_AddSendSingleCommand.Text = richTextBox_GetConfig.SelectedText;
        //}




        private void Txtbox_Password_TextChanged(object sender, EventArgs e)
        {
            //if (txtbox_Password.Text.Length < 4)
            //{
            //    txtbox_Password.BackColor = Color.OrangeRed;
            //}
            //else
            //{
            //    txtbox_Password.BackColor = Color.White;
            //}
        }



        private int NumOfRemainCommands = 0;
        private void BackgroundWorker_ConfigSystem_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            NumOfRemainCommands = 0;
            //ConfigProcessExit = false;

            // Gil Calculate the percentage
            //int percent = CalculateProgressDonePercentage();
            worker.ReportProgress(0);

            while (CalculateProgressDonePercentage() < 100)
            {





            }

            //Config_Sys.Invoke(new EventHandler(delegate
            //        {
            //            Config_Sys.Enabled = true;
            //        }));
            //worker.ReportProgress(CalculateProgressDonePercentage());
        }









        private int CalculateProgressDonePercentage()
        {
            float ret = (NumOfRemainCommands / (float)CommandsToSend.Count) * 100;
            return (int)ret;
        }






        //Color originColor_LatLong;
        //string log_file_S1_LatLong;
        //  readonly List<string> KMl_text = new List<string>();
        //       int KML_Index = 0;
        //   int DrivingNumber = 0;
        private void CheckBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            //if (checkBox_RecordLatLong.Checked)
            //{
            //    KMl_text.Clear();
            //    DrivingNumber++;
            //    originColor_LatLong = checkBox_RecordLatLong.BackColor;
            //    checkBox_RecordLatLong.BackColor = Color.Yellow;

            //    log_file_S1_LatLong = "Log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_LatLong_Record_DRVNUM_" + DrivingNumber + ".kml";
            //    try
            //    {

            //        while (File.Exists(log_file_S1_LatLong))
            //        {
            //            log_file_S1_LatLong = "Log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_LatLong_Record" + ".kml";
            //        }


            //        NumOfPositionMessage = 0;
            //        KMl_text.Add("<?xml version=\"1.0\" encoding=\"UTF-8\"?>"); 
            //        KMl_text.Add("<kml xmlns=\"http://www.google.com/earth/kml/2\">");
            //        KMl_text.Add("<Document>");




            //        SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "File " + log_file_S1_LatLong + " opened in directory \" " + Directory.GetCurrentDirectory() + "\" \n\n", true, true);
            //        //}


            //    }
            //    catch (Exception)
            //    {
            //        SerialPortLogger.LogMessage(Color.Orange, Color.LightGray, "Can't Open File", true, true);
            //    }

            //}
            //else
            //{
            //    checkBox_RecordLatLong.BackColor = default(Color);

            //    SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "File " + log_file_S1_LatLong + " closed \n\n", true, true);
            //}
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private readonly List<List<string>> CommandsToSend = new List<List<string>>();












        private void Button29_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox_GeneralMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private double ChartCntX = 0, ChartCntY = 0;
        private double ChartCntY2 = 0;
        private double ChartCntY3 = 0;
        private bool OppositeCount = false, SerialRxBlinklled = false, SerialTxBlinklled = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string PrintTimeSpan(TimeSpan t)
        {
            string answer;
            if (t.TotalMinutes < 1.0)
            {
                answer = string.Format("{0}.{1:D2}s", t.Seconds, t.Milliseconds / 10);
            }
            else if (t.TotalHours < 1.0)
            {
                //answer = String.Format("{0}m:{1:D2}.{2:D2}s", t.Minutes, t.Seconds, t.Milliseconds % 100);
                answer = string.Format("{0}m:{1:D2}", t.Minutes, t.Seconds);
            }
            else // more than 1 hour
            {
                answer = string.Format("{0}h:{1:D2}m:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);
            }

            return answer;
        }

        private static int GetDataIntervalCounter;
        private bool IsTimedOutTimerEnabled = false;

        /// <summary>
        /// 
        /// </summary>
        private int Timer_100ms = 0;

        private void ClientTCpipProcessing()
        {
            try
            {
                if (ClientSocket == null || ClientSocket.Client == null)
                {
                    button_ClientConnect.BackColor = default;
                }
                else

                    if (ClientSocket.Connected && ClientSocket.Client.Connected && ClientSocket.GetStream() != null)
                {
                    button_ClientConnect.BackColor = Color.LightGreen;
                }
                else
                {
                    button_ClientConnect.BackColor = default;
                }




            }
            catch
            {
                button_ClientConnect.BackColor = default;
            }

        }

        private int TimeOutKeepAlivein100ms = 3000000;
        private int RxLabelTimerBlink = 0, TxLabelTimerBlink = 0;
        private void Timer_ConectionKeepAlive_Tick(object sender, EventArgs e)
        {
            Timer_100ms++;

            if (checkBox_SendEveryOneSecond.CheckState == CheckState.Checked)
            {
                if (textBox_SendSerialPortPeriod.BackColor == Color.LightGreen)
                {
                    if (int.TryParse(textBox_SendSerialPortPeriod.Text, out int TimeSend))
                    {
                        if (Timer_100ms % TimeSend == 0)
                        {
                            button_SendSerialPort.PerformClick();
                        }
                    }

                }
            }

            if (checkBox_CLI_SendPeriodically.CheckState == CheckState.Checked)
            {
                if (int.TryParse(textBox_CLIsendperodically.Text, out int TimeSend))
                {
                    if (Timer_100ms % TimeSend == 0)
                    {
                        button_CLISend.PerformClick();
                    }
                }
            }

            ClientTCpipProcessing();

            if (stopwatch.IsRunning == true)
            {
                textBox_StopWatch.Text = PrintTimeSpan(stopwatch.Elapsed);
            }

            // Gil: In case Time Out Expiered close all the threads and connections
            if (IsTimedOutTimerEnabled == true)
            {
                GetDataIntervalCounter++;
                if (GetDataIntervalCounter >= TimeOutKeepAlivein100ms)
                {
                    //IsTimedOutTimerEnabled = false;
                    GetDataIntervalCounter = 0;
                    ServerLogger.LogMessage(Color.Orange, Color.White, "Connection Time Out ", New_Line = true, Show_Time = true);
                    ListenBox.Checked = !ListenBox.Checked;
                    ListenBox.Checked = !ListenBox.Checked;
                }
            }




            if (m_Server != null)
            {
                try
                {
                    if (m_Server.IsServerActive)
                    {
                        textBox_ServerActive.BackColor = Color.Green;
                    }
                    else
                    {
                        textBox_ServerActive.BackColor = default;
                    }


                    if (m_Server.IsConnectedToClient)
                    {
                        IsTimedOutTimerEnabled = true;
                        textBox_ServerOpen.BackColor = Color.Green;
                        //ListenBox.BackColor = Color.Green;
                    }
                    else
                    {
                        IsTimedOutTimerEnabled = false;
                        textBox_ServerOpen.BackColor = default;
                        // ListenBox.BackColor = Color.Yellow;
                    }


                    textBox_NumberOfOpenConnections.Text = m_Server.NumberOfOpenConnections.ToString();

                }
                catch (Exception ex)
                {
                    ServerLogger.LogMessage(Color.Red, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
                }
            }



            if (IsPauseGraphs == false)
            {

                if (Timer_100ms % (ChartUpdateTime / 100) == 0)
                {
                    //GraphPrint();
                }
            }

            if (serialPort.IsOpen == true)
            {
                SerialTerminalRxTxLights();
            }







        }

        private void SerialTerminalRxTxLights()
        {
            if (RxLabelTimerBlink > 0)
            {
                RxLabelTimerBlink--;
                //if (Timer_100ms % 2 == 0)
                //{
                    SerialRxBlinklled = !SerialRxBlinklled;
                    if (SerialRxBlinklled == true)
                    {
                        Label_SerialPortRx.BackColor = Color.Green;
                    }
                    else
                    {
                        Label_SerialPortRx.BackColor = default;
                    }
           //     }
            }
            else
            if (RxLabelTimerBlink == 0)
            {
                Label_SerialPortRx.BackColor = default;
            }

            if (TxLabelTimerBlink > 0)
            {
                TxLabelTimerBlink--;
                //if (Timer_100ms % 2 == 0)
                //{
                    SerialTxBlinklled = !SerialTxBlinklled;
                    if (SerialTxBlinklled == true)
                    {
                        Label_SerialPortTx.BackColor = Color.Green;
                    }
                    else
                    {
                        Label_SerialPortTx.BackColor = default;
                    }
             //   }
            }
            else
            if (TxLabelTimerBlink == 0)
            {
                Label_SerialPortTx.BackColor = default;
            }
        }

        private readonly List<double> ChartMem = new List<double>();
        private readonly List<double> ChartMem2 = new List<double>();
        private readonly Random rand = new Random();
        private int GreenCnt = 0, RedCnt = 0;
        private const int MOVING_AVARAGE_SIZE = 30;

        private void GraphPrint()
        {
            try
            {



                if (OppositeCount == true)
                {
                    ChartCntY3++;
                    ChartCntY3 *= 1.1;
                    if (ChartCntY3 >= 100)
                    {
                        OppositeCount = false;
                    }
                }
                else
                {
                    ChartCntY3--;
                    ChartCntY3 *= 0.9;
                    if (ChartCntY3 <= 0)
                    {
                        OppositeCount = true;
                    }
                }

                ChartCntY2 = 0;
                int cnt = 0;
                for (int i = chart1.Series[0].Points.Count - 1; i >= (chart1.Series[0].Points.Count - MOVING_AVARAGE_SIZE) && i >= 0; i--)
                {
                    cnt++;
                    ChartCntY2 += (int)chart1.Series[0].Points[i].YValues[0];
                }
                ChartCntY2 /= cnt;

                if (IsPauseGraphs == false)
                {
                    chart1.Series[0].Points.AddXY(ChartCntX, ChartCntY);
                    chart1.Series[0].Name = $"Data 1 [{ChartCntY}]";

                    chart1.Series[1].Points.AddXY(ChartCntX, ChartCntY2);
                    chart1.Series[1].Name = $"Data 2 [{ChartCntY2}]";

                    chart1.Series[2].Points.AddXY(ChartCntX, ChartCntY3);
                    chart1.Series[2].Name = $"Data 3 [{ChartCntY3}]";
                }
                else
                {
                    ChartMem.Add(ChartCntY);
                    ChartMem2.Add(ChartCntY2);
                }

                ChartCntX++;
                double temp = rand.Next(-1, 2);
                temp *= rand.NextDouble();
                ChartCntY += temp;

                if (ChartCntY > ChartCntY2)
                {
                    chart1.BackColor = Color.LightGreen;
                    GreenCnt++;
                }
                else
                {
                    chart1.BackColor = Color.Red;
                    RedCnt++;
                }
                if (Timer_100ms % 50 == 0)
                {
                    textBox_graph_XY.Text = "Green = " + GreenCnt + "  Red = " + RedCnt;
                }
                //  ChartCntY2 = ChartCntY2 + rnd.Next(-1, 2);

                if (ChartCntX % 1000 == 0)
                {
                    chart1.ChartAreas[0].AxisX.Minimum = ChartCntX;
                }


                chart1.Refresh();
                chart1.Invalidate();
            }
            catch (Exception ex)
            {
                textBox_graph_XY.Text = ex.Message;
                textBox_graph_XY.BackColor = Color.Red;
            }

        }

        //static float NextFloat(Random random)
        //{
        //    double mantissa = (random.NextDouble() * 2.0) - 1.0;
        //    // choose -149 instead of -126 to also generate subnormal floats (*)
        //    double exponent = Math.Pow(2.0, random.Next(-126, 128));
        //    return (float)(mantissa * exponent);
        //}

        private void TakeCroppedScreenShot()
        {
            string FileLocation = @".\MyPanelImage.bmp";
            Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
            chart1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(FileLocation);

            string filePath = FileLocation;
            ProcessStartInfo Info = new ProcessStartInfo()
            {
                FileName = "mspaint.exe",
                WindowStyle = ProcessWindowStyle.Maximized,
                Arguments = filePath
            };
            Process.Start(Info);
        }


        private void TabPage6_Click(object sender, EventArgs e)
        {

        }

        private void Button_Set2_Click(object sender, EventArgs e)
        {

        }

        private void Button_GenerateConfigFile_Click(object sender, EventArgs e)
        {

        }

        private void Button_Set1_Click(object sender, EventArgs e)
        {



        }

        private int FindZeroPaddingSize(int i_SignalLength)
        {
            uint mLogN = 0;
            bool found = false;
            double FFTBufferSize = i_SignalLength;

            while (found != true)
            {

                mLogN++;
                FFTBufferSize = Math.Pow(2.0, mLogN);
                if (FFTBufferSize > i_SignalLength)
                {
                    found = true;
                }
            }

            return (int)FFTBufferSize - i_SignalLength;
        }

        private int WaitforBufferFull = -1;

        //DSPLib.DSP.Window.Type windowToApply;
        //void CheckForMiniAdaDataFFT(SSPA_Parser i_MiniAdaParser)
        //{



        //    //  double samplingRate = Convert.ToDouble(TextBoxFsSamplingRate.Text); ;
        //    //UInt32 zeroPadding = 9000;
        //    double scale = 2 ^ 11 - 1;


        //    double[] IQ1Sigal = new double[i_MiniAdaParser.IQData.I1.Length];
        //    double[] IQ2Sigal = new double[i_MiniAdaParser.IQData.I2.Length];

        //    for (int i = 0; i < i_MiniAdaParser.IQData.I1.Length; i++)
        //    {
        //        IQ1Sigal[i] = (double)(i_MiniAdaParser.IQData.I1[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q1[i] / scale / 2);
        //    }


        //    for (int i = 0; i < i_MiniAdaParser.IQData.I2.Length; i++)
        //    {
        //        IQ2Sigal[i] = (double)(i_MiniAdaParser.IQData.I2[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q2[i] / scale / 2);
        //    }

        //    int zeroPadding = FindZeroPaddingSize(IQ1Sigal.Length);
        //    int zeroPadding2 = FindZeroPaddingSize(IQ2Sigal.Length);





        //    // Instantiate & Initialize a new DFT
        //    DSPLib.FFT fft = new DSPLib.FFT();
        //    DSPLib.FFT fft2 = new DSPLib.FFT();
        //    //DSPLib.DFT dft = new DSPLib.DFT();
        //    fft.Initialize((uint)IQ1Sigal.Length, (uint)zeroPadding); // NOTE: Zero Padding
        //    fft2.Initialize((uint)IQ2Sigal.Length, (uint)zeroPadding2);

        //    // Call the DFT and get the scaled spectrum back

        //    // Convert the complex spectrum to note: Magnitude Format


        //    //double[] lmSpectrum = DSP.ConvertMagnitude.ToMagnitudeDBV(temp);
        //    // double[] lmSpectrum2 = DSP.ConvertMagnitude.ToMagnitudeDBV(temp2);
        //    // Properly scale the spectrum for the added window




        //    // For plotting on an XY Scatter plot generate the X Axis frequency Span
        //    //   double[] freqSpan = fft.FrequencySpan(samplingRate);
        //    //  double[] freqSpan2 = fft2.FrequencySpan(samplingRate);
        //    // At this point a XY Scatter plot can be generated from,
        //    // X axis => freqSpan
        //    // Y axis => lmSpectrum
        //    //double Mean = DSP.Analyze.FindMean(IQ1Sigal);
        //    //double Mean2 = DSP.Analyze.FindMean(IQ2Sigal);

        //    //double RMS = DSP.Analyze.FindRms(IQ1Sigal);
        //    //double RMS2 = DSP.Analyze.FindRms(IQ2Sigal);

        //    //double MaxAmplitude = DSP.Analyze.FindMaxAmplitude(lmSpectrum);
        //    //double MaxPosition = DSP.Analyze.FindMaxPosition(lmSpectrum);
        //    //double MaxFrequency = DSP.Analyze.FindMaxFrequency(lmSpectrum, freqSpan);

        //    //textBox_graph_XY.BeginInvoke(new EventHandler(delegate
        //    //{
        //    //    textBox_graph_XY.Text = String.Format(" \n CH1 : Mean [{0}] RMS [{1}] \n", Mean.ToString("0.00"),RMS.ToString("0.00"));
        //    //    textBox_graph_XY.Text += String.Format(" \n CH2 : Mean [{0}] RMS [{1}]  \n ", Mean2.ToString("0.00"), RMS2.ToString("0.00"));
        //    //    textBox_graph_XY.Text += String.Format(" \n CH1 : MaxAmplitude [{0}] MaxPosition [{1}] MaxFrequency [{2}] \n ", MaxAmplitude.ToString("0.00"), MaxPosition.ToString("0.00"), MaxFrequency.ToString("0.00"));

        //    //}));

        //    listBox_Charts.BeginInvoke(new EventHandler(delegate
        //    {
        //        var series1 = new Series("CH1 " + ChartIndex.ToString());
        //        //var series2 = new Series("IQ1 Time " + ChartIndex.ToString());
        //        var series3 = new Series("CH2 " + ChartIndex.ToString());
        //        //  var series4 = new Series("IQ2 Time " + ChartIndex.ToString());

        //        series1.ChartType = SeriesChartType.Line;
        //        series3.ChartType = SeriesChartType.Line;

        //        ChartIndex++;

        //        //  listBox_Charts.Items.Add(series4.Name);
        //        // Frist parameter is X-Axis and Second is Collection of Y- Axis
        //        // double[] xData = DSP.Generate.LinSpace(-(freqSpan.Length) / 2 , (freqSpan.Length) / 2, (UInt32)(freqSpan.Length));
        //        //       series1.Points.DataBindXY(freqSpan, lmSpectrum);
        //        for (int i = 0; i < IQ1Sigal.Length; i++)
        //        {
        //            //         series2.Points.AddXY(i, IQ1Sigal[i]);
        //        }
        //        //     series2.ChartType = SeriesChartType.Line;
        //        chart1.Series.Add(series1);
        //        //     chart1.Series.Add(series2);

        //        //  series3.Points.DataBindXY(freqSpan, lmSpectrum2);

        //        for (int i = 0; i < IQ1Sigal.Length; i++)
        //        {
        //            //         series4.Points.AddXY(i, IQ1Sigal[i]);
        //        }
        //        //      series4.ChartType = SeriesChartType.Line;
        //        chart1.Series.Add(series3);
        //        //   chart1.Series.Add(series4);

        //        PlotGraphTimer = -1;
        //        textBox_SystemStatus.Text = "Graphs is ready;\n";
        //        textBox_SystemStatus.BackColor = Color.LightGreen;

        //        //Gil: Find the maximum and minimum points
        //        //      MarkTheBiggestFreq(series1, lmSpectrum, freqSpan);
        //        //      MarkTheBiggestFreq(series3, lmSpectrum2, freqSpan2);


        //    }));


        //}

        private void MarkTheBiggestFreq(Series i_serias, double[] i_lmSpectrum, double[] i_freqSpan)
        {
            //double minX = i_serias.Points.Select(v => v.XValue).Min();
            //double maxX = i_serias.Points.Select(v => v.XValue).Max();
            //double minY = i_serias.Points.Select(v => v.YValues[0]).Min();
            //double maxY = i_serias.Points.Select(v => v.YValues[0]).Max();

            //// find datapoints from left..
            //DataPoint minXpt = i_serias.Points.Select(p => p)
            //                    .Where(p => p.XValue == minX)
            //                    .DefaultIfEmpty(i_serias.Points.First()).First();
            //DataPoint minYpt = i_serias.Points.Select(p => p)
            //                    .Where(p => p.YValues[0] == minY)
            //                    .DefaultIfEmpty(i_serias.Points.First()).First();
            ////..or from right
            //DataPoint maxXpt = i_serias.Points.Select(p => p)
            //                    .Where(p => p.XValue == maxX)
            //                    .DefaultIfEmpty(i_serias.Points.Last()).Last();
            //DataPoint maxYpt = i_serias.Points.Select(p => p)
            //                    .Where(p => p.YValues[0] == maxY)
            //                    .DefaultIfEmpty(i_serias.Points.Last()).Last();

            //textBox_MaxXAxis.Text = maxXpt.XValue.ToString();
            //textBox_MinXAxis.Text = minXpt.XValue.ToString();

            //// textBox_SystemStatus.Text += maxYpt.ToString();




            //Color c = Color.Red;
            ////  minXpt.MarkerColor = c;
            ////   minYpt.MarkerColor = c;
            ////   maxXpt.MarkerColor = c;
            //maxYpt.MarkerColor = c;
            ////   minXpt.MarkerSize = 12;
            ////   minYpt.MarkerSize = 12;
            ////    maxXpt.MarkerSize = 12;
            //maxYpt.MarkerSize = 20;
            //maxYpt.MarkerStyle = MarkerStyle.Triangle;
            //maxYpt.Label = string.Format("X= {0} Y= {1} dBm", maxYpt.XValue.ToString("0.##E+0"), maxYpt.YValues[0].ToString("0.00"));
            ////Plot fig3 = new Plot("Figure 3 - FFT Log Magnitude ", "Frequency (Hz)", "Mag (dBV)");
            ////fig3.PlotData(freqSpan, lmSpectrum);


            ////double MaxAmplitude = DSP.Analyze.FindMaxAmplitude(i_lmSpectrum);
            ////double MaxPosition = DSP.Analyze.FindMaxPosition(i_lmSpectrum);
            ////double MaxFrequency = DSP.Analyze.FindMaxFrequency(i_lmSpectrum, i_freqSpan);

            ////double Mean = DSP.Analyze.FindMean(i_lmSpectrum);


            ////double RMS = DSP.Analyze.FindRms(i_lmSpectrum);



            //// Create a new legend called "Legend2".
            ////  chart1.Legends.Add(new Legend(i_serias.Name));
            //// Set Docking of the Legend chart to the Default Chart Area.
            ////chart1.Legends[i_serias.Name].DockToChartArea = "Default";
            //// Assign the legend to Series1.

            //DataPoint prop = new DataPoint(0, 0);
            ////chart1.Series[i_serias.Name].Points[(int)prop.XValue].Label = String.Format(" \n Mean [{0}] RMS [{1}]  MaxAmplitude [{2}] MaxPosition [{3}] MaxFrequency [{4}] \n \n", Mean.ToString("0.00"), RMS.ToString("0.00"), MaxAmplitude.ToString("0.00"), MaxPosition.ToString("0.00"), MaxFrequency.ToString("0.00"));

            //int index = listBox_Charts.Items.Add(i_serias.Name);
            //i_serias.LegendToolTip = string.Format(" \n{0} \n Mean [{1}] \n RMS [{2}] \n MaxAmplitude [{3}] \n MaxPosition [{4}] \n MaxFrequency [{5}] \n \n", i_serias.Name, Mean.ToString("0.00"), RMS.ToString("0.00"), MaxAmplitude.ToString("0.00"), MaxPosition.ToString("0.00"), MaxFrequency.ToString("0.##E+0"));
        }

        //void CheckForMiniAdaDataDFT(SSPA_Parser i_MiniAdaParser)
        //{
        //    //// Same Input Signal as Example 1 - Except a fractional cycle for frequency.
        //    //double amplitude = 1.0; double frequency = 20000.5;
        //    //UInt32 length = 1000; UInt32 zeroPadding = 9000; // NOTE: Zero Padding
        //    //double samplingRate = 100000;
        //    //double[] inputSignal = DSPLib.DSP.Generate.ToneSampling(amplitude, frequency, samplingRate, length);
        //    //// Apply window to the Input Data & calculate Scale Factor
        //    //double[] wCoefs = DSP.Window.Coefficients(DSP.Window.Type.FTNI, length);
        //    //double[] wInputData = DSP.Math.Multiply(inputSignal, wCoefs);
        //    //double wScaleFactor = DSP.Window.ScaleFactor.Signal(wCoefs);
        //    //// Instantiate & Initialize a new DFT
        //    //DSPLib.DFT dft = new DSPLib.DFT();
        //    //dft.Initialize(length, zeroPadding); // NOTE: Zero Padding
        //    //                                     // Call the DFT and get the scaled spectrum back
        //    //Complex[] cSpectrum = dft.Execute(wInputData);
        //    //// Convert the complex spectrum to note: Magnitude Format
        //    //double[] lmSpectrum = DSPLib.DSP.ConvertComplex.ToMagnitude(cSpectrum);
        //    //// Properly scale the spectrum for the added window
        //    //lmSpectrum = DSP.Math.Multiply(lmSpectrum, wScaleFactor);
        //    //// For plotting on an XY Scatter plot generate the X Axis frequency Span
        //    //double[] freqSpan = dft.FrequencySpan(samplingRate);
        //    //// At this point a XY Scatter plot can be generated from,
        //    //// X axis => freqSpan
        //    //// Y axis => lmSpectrum

        //    //var series = new Series("Freq 2");
        //    //var series2 = new Series("Time 2");
        //    //listBox_Charts.Items.Add(series.Name);
        //    //listBox_Charts.Items.Add(series2.Name);
        //    //// Frist parameter is X-Axis and Second is Collection of Y- Axis
        //    //series.Points.DataBindXY(freqSpan, lmSpectrum);

        //    //for (int i = 0; i < inputSignal.Length / 10; i++)
        //    //{
        //    //    series2.Points.AddXY(i, inputSignal[i]);
        //    //}
        //    //series2.ChartType = SeriesChartType.Line;
        //    //chart1.Series.Add(series);
        //    //chart1.Series.Add(series2);

        //    //  double samplingRate = Convert.ToDouble(TextBoxFsSamplingRate.Text); ;
        //    //UInt32 zeroPadding = 9000;
        //    double scale = 2 ^ 11 - 1;


        //    double[] IQ1Sigal = new double[i_MiniAdaParser.IQData.I1.Length];
        //    double[] IQ2Sigal = new double[i_MiniAdaParser.IQData.I2.Length];

        //    for (int i = 0; i < i_MiniAdaParser.IQData.I1.Length; i++)
        //    {
        //        IQ1Sigal[i] = (double)(i_MiniAdaParser.IQData.I1[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q1[i] / scale / 2);
        //    }


        //    for (int i = 0; i < i_MiniAdaParser.IQData.I2.Length; i++)
        //    {
        //        IQ2Sigal[i] = (double)(i_MiniAdaParser.IQData.I2[i] / scale / 2) + (double)(i_MiniAdaParser.IQData.Q2[i] / scale / 2);
        //    }

        //    int zeroPadding = 0;
        //    //   Int32.TryParse(TextBox_Zeropadding.Text, out zeroPadding);



        //    // Instantiate & Initialize a new DFT
        //    DSPLib.DFT dft = new DSPLib.DFT();
        //    DSPLib.DFT dft2 = new DSPLib.DFT();
        //    //DSPLib.DFT dft = new DSPLib.DFT();
        //    dft.Initialize((uint)IQ1Sigal.Length, (uint)zeroPadding); // NOTE: Zero Padding
        //    dft2.Initialize((uint)IQ2Sigal.Length, (uint)zeroPadding);

        //    // Call the DFT and get the scaled spectrum back

        //    // Convert the complex spectrum to note: Magnitude Format

        //    // Properly scale the spectrum for the added window

        //    // For plotting on an XY Scatter plot generate the X Axis frequency Span
        //    //double[] freqSpan = dft.FrequencySpan(samplingRate);
        //    //double[] freqSpan2 = dft2.FrequencySpan(samplingRate);
        //    // At this point a XY Scatter plot can be generated from,
        //    // X axis => freqSpan
        //    // Y axis => lmSpectrum

        //    listBox_Charts.BeginInvoke(new EventHandler(delegate
        //    {
        //        var series1 = new Series("IQ1 Freq " + ChartIndex.ToString());
        //        var series2 = new Series("IQ1 Time " + ChartIndex.ToString());
        //        var series3 = new Series("IQ2 Freq " + ChartIndex.ToString());
        //        var series4 = new Series("IQ2 Time " + ChartIndex.ToString());

        //        ChartIndex++;
        //        listBox_Charts.Items.Add(series1.Name);
        //        listBox_Charts.Items.Add(series2.Name);
        //        listBox_Charts.Items.Add(series3.Name);
        //        listBox_Charts.Items.Add(series4.Name);
        //        // Frist parameter is X-Axis and Second is Collection of Y- Axis
        //        //       series1.Points.DataBindXY(freqSpan, lmSpectrum);

        //        for (int i = 0; i < IQ1Sigal.Length; i++)
        //        {
        //            series2.Points.AddXY(i, IQ1Sigal[i]);
        //        }
        //        series2.ChartType = SeriesChartType.Line;
        //        chart1.Series.Add(series1);
        //        chart1.Series.Add(series2);

        //        //    series3.Points.DataBindXY(freqSpan, lmSpectrum);

        //        for (int i = 0; i < IQ1Sigal.Length; i++)
        //        {
        //            series4.Points.AddXY(i, IQ1Sigal[i]);
        //        }
        //        series4.ChartType = SeriesChartType.Line;
        //        chart1.Series.Add(series3);
        //        chart1.Series.Add(series4);

        //        PlotGraphTimer = -1;
        //        textBox_SystemStatus.Text = "Graphs is ready;";
        //        textBox_SystemStatus.BackColor = Color.LightGreen;
        //    }));


        //}

        public string ConvertHex(string hexString)
        {
            try
            {
                string ascii = string.Empty;
                for (int i = 0; i < hexString.Length; i += 2)
                {
                    string hs = string.Empty;
                    hs = hexString.Substring(i, 2);
                    if (hs != "00")
                    {
                        uint decval = System.Convert.ToUInt32(hs, 16);
                        char character = System.Convert.ToChar(decval);
                        ascii += character;
                    }

                }
                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return string.Empty;
        }


        public float ConvertFloat(string hexString)
        {
            try
            {
                //string hexString = "43480170";
                uint num = uint.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);
                byte[] floatVals = BitConverter.GetBytes(num).Reverse().ToArray();

                float f = BitConverter.ToSingle(floatVals, 0);
                return f;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return 0;
        }

        private byte[] StringToByteArray(string hex)
        {
            hex = Regex.Replace(hex, @"\s+", "");
            try
            {
                return Enumerable.Range(0, hex.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                 .ToArray();
            }
            catch
            {
                return null;
            }


        }

        public class CLI_Command
        {
            public String Opcode;
            public String Description;

        }

        // object ReturnValue =null;
        public class GetRecodIQDataClass
        {
            public short[] I1;
            public short[] Q1;
            public short[] I2;
            public short[] Q2;
        }
        public GetRecodIQDataClass IQData = new GetRecodIQDataClass();

        //public object GetDataFromParser()
        //{
        //    object ret = ReturnValue;
        //    ReturnValue = null;
        //    return ret;
        //}


        private string UnHandaledPreample(KratosProtocolFrame i_Parsedframe)
        {
            string ret = string.Format("\n Unkown Preample Unhandled: [{0}] \n", i_Parsedframe.Preamble);
            textBox_SystemStatus.Text = ret;

            return ret;
        }

        void WriteToSystemStatus(String i_Message, uint i_Time, Color i_Color)
        {
            textBox_SystemStatus.AppendText(i_Message + Environment.NewLine + Environment.NewLine);
            textBox_SystemStatus.BackColor = i_Color;
            textBox_SystemStatus_Timer += i_Time;
        }

        private string UnHandledOpcode(KratosProtocolFrame i_Parsedframe)
        {

            string ret = string.Format("\n Opcode Unhandled: [{0}] \n", i_Parsedframe.Opcode);

            WriteToSystemStatus(ret, 4, Color.Orange);

            return ret;

        }



        private string UnHandledAddressSimulator(String i_Address)
        {

            string ret = string.Format("\n Address Unhandled Simulator: [{0}] \n", i_Address);
            WriteToSystemStatus(ret, 4, Color.Orange);



            return ret;

        }
        private string UnHandledAddressFlash(String i_Address)
        {

            string ret = string.Format("\n Flash Address Unhandled UUT: [{0}] \n", i_Address);
            WriteToSystemStatus(ret, 4, Color.Orange);



            return ret;

        }
        private string UnHandledAddress(String i_Address)
        {

            string ret = string.Format("\n Flash Address Unhandled UUT: [{0}] \n", i_Address);
            WriteToSystemStatus(ret, 4, Color.Orange);



            return ret;

        }
        uint textBox_SystemStatus_Timer = 0;

        //string RetriveIQData(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n IQ data retrive: [{0}] \n", i_Parsedframe.Data);
        //}
        //string PlayIQData(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n IQ Data sent to play \n");
        //}
        //string GetUbloxData(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Ublox data: [{0}] \n", ConvertHex(i_Parsedframe.Data));
        //}

        //string SetRxChannelStateCal(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n RX channel state RX/CAL have been set \n");
        //}
        //string RecordIQDaraSelectSource(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n Record IQ data source selected \n");
        //}
        //string RecordIQData(KratosProtocolFrame i_Parsedframe)
        //{
        //    byte[] DataBytes = StringToByteArray(i_Parsedframe.Data);



        //    int NumberOfSamples = DataBytes.Length;
        //    NumberOfSamples /= 8;

        //    IQData = new GetRecodIQDataClass();
        //    IQData.I1 = new Int16[NumberOfSamples - 1];
        //    IQData.Q1 = new Int16[NumberOfSamples - 1];
        //    IQData.I2 = new Int16[NumberOfSamples - 1];
        //    IQData.Q2 = new Int16[NumberOfSamples - 1];

        //    for (int i = 1; i < (DataBytes.Length / 8) - 1; i++)// Gil: i=1 beacuse we throw the first sample
        //    {
        //        int Index = i * 8;
        //        IQData.I1[i] = (Int16)(DataBytes[Index] | DataBytes[Index + 1] << 8);
        //        IQData.Q1[i] = (Int16)(DataBytes[Index + 2] | DataBytes[Index + 3] << 8);
        //        IQData.I2[i] = (Int16)(DataBytes[Index + 4] | DataBytes[Index + 5] << 8);
        //        IQData.Q2[i] = (Int16)(DataBytes[Index + 6] | DataBytes[Index + 7] << 8);
        //    }




        //    return String.Format("\n IQ samples Data: [{0}]  Data Length: [{1}] Bytes\n", i_Parsedframe.Data, DataBytes.Length);
        //}
        //string SetGPIOValue(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n GPIO value have been set \n");
        //}

        //string GetGPIOValue(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n GPIO Value  [{0}]  \n", i_Parsedframe.Data);
        //}
        //string SetGPIODirection(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n GPIO direction have been set \n");
        //}

        //string GetGPIODirection(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n GPIO direction  [{0}]  \n", i_Parsedframe.Data);
        //}
        //string TxGetRFPLLlockDetect(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n Tx Get RF PLL lock Detect [{0}]  \n", i_Parsedframe.Data);
        //}
        //string RxGetRFPLLlockDetect(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n Rx Get RF PLL lock Detect [{0}]  \n", i_Parsedframe.Data);
        //}
        //string GetDCA(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n DCA [{0}] dBm \n", ConvertFloat(i_Parsedframe.Data));
        //}

        //string SetDCA(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n DCA has been set \n");
        //}
        //string GetRXChannelGain(KratosProtocolFrame i_Parsedframe)
        //{
        //    int intValue = int.Parse(i_Parsedframe.Data, System.Globalization.NumberStyles.HexNumber);
        //    return String.Format("\n Rx channel Gain [{0}] \n", intValue);
        //}
        //string SetRXChannelGain(KratosProtocolFrame i_Parsedframe)
        //{
        //    byte[] DataBytes = StringToByteArray(i_Parsedframe.Data);
        //    return String.Format("\n RX Channel Gain has been set\n");
        //}
        //string LoadDataInFlash(KratosProtocolFrame i_Parsedframe)
        //{
        //    byte[] DataBytes = StringToByteArray(i_Parsedframe.Data);
        //    return String.Format("\n Loaded Data: [{0}]  Data Length: [{1}] Bytes\n", i_Parsedframe.Data, DataBytes.Length);
        //}



        //string EraseSectorintFlash(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Sector has been erased \n");
        //}
        //string StoreDataInFlash(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Data stored in the flash \n");
        //}
        //string Write_FPGA_Data(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n FPGA value have been set \n");
        //}

        //string Read_FPGA_Data(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n FPGA value [{0}] \n", i_Parsedframe.Data);
        //}
        //string SetTXCO_ON_OFF(KratosProtocolFrame i_Parsedframe)
        //{


        //    return String.Format("\n TCXO have been set \n");
        //}
        //string GetOutputPower(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Output Power [{0}] dBm \n", ConvertFloat(i_Parsedframe.Data));
        //}
        //string SetOutputPower(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n System Output power havs been set \n");
        //}
        //string GetSytemState(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n System State [{0}] \n", ConvertHex(i_Parsedframe.Data));
        //}
        //string SetSytemState(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n System state have been changed \n");
        //}
        //string DoSync(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Sync received \n");
        //}
        //string GetTxAD936X(KratosProtocolFrame i_Parsedframe)
        //{
        //    return String.Format("\n Tx AD936X  [{0}] \n", i_Parsedframe.Data);

        //}
        //string SetTxAD936X(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Tx AD936X data Has been Set [OK] \n");
        //}
        //string SetSynthesizerL2(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Synthesizer L2 Has been Set [OK] \n");
        //}
        //string SetSynthesizerL1(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Synthesizer L1 Has been Set [OK] \n");

        //}
        //string GetPSUCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n PSU card Information [{0}] \n", ConvertHex(i_Parsedframe.Data));
        //}

        //string SetPSUCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n PSU card Information Has been Set [OK] \n");
        //}

        //string GetRFCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n RF card Information [{0}] \n", ConvertHex(i_Parsedframe.Data));
        //}

        //string SetRFCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Core RF Information Has been Set [OK] \n");
        //}

        //string SetCoreCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    return String.Format("\n Core card Information Has been Set [OK] \n");
        //}


        //void GetCoreCardInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    SendMessageToSystemLogger(String.Format("\n Core card Information [{0}] \n", ConvertHex(i_Parsedframe.Data)));
        //}
        //void SetIdentityInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    SendMessageToSystemLogger(String.Format("\n Identity Information Has been Set [OK] \n"));
        //}
        //void GetIdentityInformation(KratosProtocolFrame i_Parsedframe)
        //{

        //    SendMessageToSystemLogger(String.Format("\n Identity Information [{0}] \n", ConvertHex(i_Parsedframe.Data)));
        //}
        //void GetSystemType(KratosProtocolFrame i_Parsedframe)
        //{

        //    int SystemType = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);

        //    SendMessageToSystemLogger(String.Format("\n System type [{0}] \n", SystemType));
        //}

        //void IsSystemBusy(KratosProtocolFrame i_Parsedframe)
        //{
        //    //2 bytes Serial number:
        //    //2 bytes - Serial number, range: 0 – 65535
        //    int BusyStatus = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        //    //int SerialNumber = int.Parse(i_Parsedframe.Data.Substring(2, 2) + i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        //    if (BusyStatus == 0)
        //    {
        //        SendMessageToSystemLogger( String.Format("\n Ready [OK] [{0}] \n", BusyStatus));
        //    }
        //    else
        //    {
        //        SendMessageToSystemLogger(String.Format("\n Busy  [{0}] \n", BusyStatus));
        //    }
        //}
        //void SetLogLevel(KratosProtocolFrame i_Parsedframe)
        //{
        //    //2 bytes Serial number:
        //    //2 bytes - Serial number, range: 0 – 65535

        //    //int SerialNumber = int.Parse(i_Parsedframe.Data.Substring(2, 2) + i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);

        //    SendMessageToSystemLogger( String.Format("\n Log Level has been set. \n"));
        //}
        private void GetSerialNumber(KratosProtocolFrame i_Parsedframe)
        {
            //2 bytes Serial number:
            //2 bytes - Serial number, range: 0 – 65535

            int SerialNumber = int.Parse(i_Parsedframe.Data.Substring(2, 2) + i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);


            // SendMessageToSystemLogger( String.Format("\n Serial Number : <<{0}>>\n", SerialNumber));
        }

        private string GetBytesFromData(string i_data, int i_ByteStartIndex, int i_NumOfBytes)
        {
            string Data_Without_Spaces = Regex.Replace(i_data, @"\s+", "");

            int StartIndex = i_ByteStartIndex * 2;
            int MaxIndex = (StartIndex + i_NumOfBytes * 2);
            if (Data_Without_Spaces.Length < MaxIndex)
            {
                return "////";
                // return string.Format("Out of range Current Length [{0}] - Wanted byte:[{1}]", Data_Without_Spaces.Length/2, MaxIndex/2);
            }
            else
            {
                return Data_Without_Spaces.Substring(StartIndex, i_NumOfBytes * 2);

            }

        }
        private void GetSystemStatus(KratosProtocolFrame i_Parsedframe)
        {
            if (int.TryParse(i_Parsedframe.LengthOfEntireMessage, out int DataLength) == true)
            {


            }

            //  SendMessageToSystemLogger(ret);
        }

        private string GetBit(byte b, int bitNumber)
        {
            return (b & (1 << bitNumber)).ToString();
        }

        private void GetDiscreteStatusBusmode(KratosProtocolFrame i_Parsedframe)
        {
            if (int.TryParse(i_Parsedframe.LengthOfEntireMessage, out int DataLength) == true)
            {
                // byte Data = byte.Parse(GetBytesFromData(i_Parsedframe.Data, 0, 2), System.Globalization.NumberStyles.HexNumber);


            }

            //   SendMessageToSystemLogger(ret);
        }

        private void GetSystemTableIndexes(KratosProtocolFrame i_Parsedframe)
        {
            if (int.TryParse(i_Parsedframe.LengthOfEntireMessage, out int DataLength) == true)
            {
                // byte Data = byte.Parse(GetBytesFromData(i_Parsedframe.Data, 0, 2), System.Globalization.NumberStyles.HexNumber);


            }
        }

        private void ReadFromFlash(KratosProtocolFrame i_Parsedframe)
        {
            string ret = "";
            int.TryParse(i_Parsedframe.LengthOfEntireMessage, out int DataLength);

            for (int i = 0; i < DataLength - 2; i = i + 2)
            {
                ret += "<<" + i_Parsedframe.Data.Substring(i, i + 2) + ">>";
            }

            //    SendMessageToSystemLogger(ret);
        }

        private void ACK_Received(KratosProtocolFrame i_Parsedframe)
        {
            string ret = string.Format("\n recieved OK, Opcode :[{0}] \n", i_Parsedframe.Opcode);

            //       SendMessageToSystemLogger(ret);
        }

        private void ACK_ReceivedUUT(KratosProtocolFrame i_Parsedframe)
        {

        }

        private void ACK_ReceivedSimulator(KratosProtocolFrame i_Parsedframe)
        {

        }

        private void GetThermalSuperVisor(KratosProtocolFrame i_Parsedframe)
        {


            string ret = string.Format("\n recieved OK, Opcode :[{0}], Thermal <<{1}>> \n", i_Parsedframe.Opcode, i_Parsedframe.Data);
            //         SendMessageToSystemLogger(ret);
        }

        private void GetHardwareVertion(KratosProtocolFrame i_Parsedframe)
        {
            //    Unit major version – 	1 byte
            //Unit minor version – 	1 byte
            //Version day –		1 bytes
            //Version month –	1 bytes
            //Version year –		2 bytes

        }

        private void GetFirmwareVertion(KratosProtocolFrame i_Parsedframe)
        {
            //    Unit major version – 	1 byte
            //Unit minor version – 	1 byte
            //Version day –		1 bytes
            //Version month –	1 bytes
            //Version year –		2 bytes


        }

        private void GetSimulatorStatus(KratosProtocolFrame i_Parsedframe)
        {

            //int Ready_count = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            //int Int_under_voltage_count = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            //int Int_over_voltage_count = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            //int Protection_count = int.Parse(i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            //int Protection_count = int.Parse(i_Parsedframe.Data.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            //int Protection_count = int.Parse(i_Parsedframe.Data.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            //       SendMessageToSystemLogger(String.Format("\n Simulator ID <<0x{0}>>\n ", i_Parsedframe.Data));

        }

        private void GetSimulatorID(KratosProtocolFrame i_Parsedframe)
        {


        }

        private void GetSystemHardwareVersion(KratosProtocolFrame i_Parsedframe)
        {

        }

        private void GetSystemFirmwareVersion(KratosProtocolFrame i_Parsedframe)
        {

        }



        private void GetSystemID(KratosProtocolFrame i_Parsedframe)
        {



        }

        private void GetSystemSN(KratosProtocolFrame i_Parsedframe)
        {



        }

        private void GetSoftwareVertion(KratosProtocolFrame i_Parsedframe)
        {
            //    ICD major version – 	1 byte
            //ICD minor version – 	1 byte
            //Unit major version – 	1 byte
            //Unit minor version – 	1 byte
            //Version day –		1 bytes
            //Version month –	1 bytes
            //Version year –		2 bytes


            int ICDMajor = int.Parse(i_Parsedframe.Data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int ICDMinor = int.Parse(i_Parsedframe.Data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int UnitMajorNumber = int.Parse(i_Parsedframe.Data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            int UnitMinorNumber = int.Parse(i_Parsedframe.Data.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            string VersionDateTime = ConvertHex(i_Parsedframe.Data.Substring(8));


            //        SendMessageToSystemLogger(String.Format("\n ICD major version [{0}]\n ICD minor version [{1}]\n Unit major version [{2}]\n Unit minor version [{3}]" +
            //"\n Version date time  [{4}]\n ",
            //ICDMajor, ICDMinor, UnitMajorNumber, UnitMinorNumber, VersionDateTime));
            //        //int VersionDay = int.Parse(i_Parsedframe.Data.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            //        //int VersionMonth = int.Parse(i_Parsedframe.Data.Substring(10, 2), System.Globalization.NumberStyles.HexNumber);
            //        //int VersionYear = int.Parse(i_Parsedframe.Data.Substring(14, 2) + i_Parsedframe.Data.Substring(12, 2), System.Globalization.NumberStyles.HexNumber);  //Gil: because it is little endian so I need to reverse the bytes
            //        //return String.Format("\n ICD major version [{0}]\n ICD minor version [{1}]\n Unit major version [{2}]\n Unit minor version [{3}]" +
            //        //    "\n Version day  [{4}]\n Version month [{5}]\n Version year [{6}]\n",
            //        //    ICDMajor, ICDMinor ,UnitMajorNumber, UnitMinorNumber, VersionDay, VersionMonth, VersionYear);
        }



        private void ACK_ReadRegisterReceivedSimulator(KratosProtocolFrame i_Parsedframe)
        {

        }


        void WriteFlashACKReceived(KratosProtocolFrame i_Parsedframe)
        {
            try
            {

                String str_Address = GetBytesFromData(i_Parsedframe.Data, 1, 2);
                String str_InternalAddress = GetBytesFromData(i_Parsedframe.Data, 3, 2);
                String str_Status = GetBytesFromData(i_Parsedframe.Data, 5, 4);

                String message = String.Format("Flash Write ACK recieved :  Address[{0}] Internal Address [{1}] Status: [{1}]", str_Address, str_InternalAddress, str_Status);

                WriteToSystemStatus(message, 2, Color.Aqua);
                //  int m_Address = int.Parse(str_Address, System.Globalization.NumberStyles.HexNumber);


                //switch (str_Address)
                //{
                //    case "0000":

                //        for (int i = 0; i < dataGridView_ValPage0.Rows.Count; i++)
                //        {

                //            dataGridView_ValPage0.Rows[i].Cells[0].Value = GetBytesFromData(i_Parsedframe.Data, (i * 2) + 5, 2);

                //        }

                //        break;



                //    default:
                //        UnHandledAddress(str_Address);
                //        break;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void EraseFlashACKReceived(KratosProtocolFrame i_Parsedframe)
        {
            try
            {
                String str_Control = GetBytesFromData(i_Parsedframe.Data, 0, 1);
                String str_Address = GetBytesFromData(i_Parsedframe.Data, 1, 2);
                String str_Status = GetBytesFromData(i_Parsedframe.Data, 5, 4);




                //  int m_Address = int.Parse(str_Address, System.Globalization.NumberStyles.HexNumber);


                switch (str_Control)
                {
                    case "11":

                        String message = String.Format("Chip Flash erased :  Address[{0}] Status: [{1}]", str_Address, str_Status);
                        WriteToSystemStatus(message, 4, Color.Turquoise);

                        break;

                    case "31":

                        message = String.Format(" Block Flash erased :  Address[{0}] Status: [{1}]", str_Address, str_Status);
                        WriteToSystemStatus(message, 4, Color.Cyan);

                        break;


                    default:
                        UnHandledAddress(str_Address);
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        void ReadFlashACKReceived(KratosProtocolFrame i_Parsedframe)
        {
            try
            {

                String str_Address = GetBytesFromData(i_Parsedframe.Data, 1, 2);
                String str_InternalAddress = GetBytesFromData(i_Parsedframe.Data, 3, 2);
                int m_InternalAddress = int.Parse(str_InternalAddress, System.Globalization.NumberStyles.HexNumber);

                WriteToSystemStatus(String.Format("Flash Address received: [{0}] internal Address [{1}]", str_Address, str_InternalAddress), 1, Color.White);







                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ReadRegisterAckFrameUUT(KratosProtocolFrame i_Parsedframe)
        {
        }




        /// <summary>
        /// Gil: Income frame parser *********************************************************
        /// *********************************************************************************
        /// ***********************************************************************************
        /// **********************************************************************************
        /// </summary>
        /// <param name="i_Parsedframe"></param>
        private void ParseSystemFrame(KratosProtocolFrame i_Parsedframe)
        {
            if (i_Parsedframe == null)
            {
                textBox_SystemStatus.Text = "frame received as null";
            }

            int Received_Preamble = int.Parse(i_Parsedframe.Preamble, System.Globalization.NumberStyles.HexNumber);
            int Expected_Preamble = int.Parse(PREAMBLE, System.Globalization.NumberStyles.HexNumber);

            if (Received_Preamble != Expected_Preamble)
            {
                UnHandaledPreample(i_Parsedframe);
            }
            else
            {
                switch (i_Parsedframe.Opcode)
                {

                    case "00":
                        GetSystemID(i_Parsedframe);

                        break;

                    case "02":
                        GetSystemFirmwareVersion(i_Parsedframe);

                        break;

                    case "03":
                        GetSystemHardwareVersion(i_Parsedframe);

                        break;

                    case "04":
                        GetSystemSN(i_Parsedframe);

                        break;

                    case "11":
                        GetSystemStatus(i_Parsedframe);

                        break;

                    case "25":
                        GetDiscreteStatusBusmode(i_Parsedframe);

                        break;

                    case "26":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "27":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "33":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "35":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "36":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "37":
                        GetSystemTableIndexes(i_Parsedframe);

                        break;

                    case "51":
                        ACK_ReceivedUUT(i_Parsedframe);

                        break;

                    case "53":
                        ReadRegisterAckFrameUUT(i_Parsedframe);

                        break;

                    case "70":
                        ReadFromFlash(i_Parsedframe);

                        break;

                    case "38":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "39":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "71":
                        ReadFlashACKReceived(i_Parsedframe);

                        break;

                    case "73":
                        WriteFlashACKReceived(i_Parsedframe);

                        break;

                    case "75":
                        EraseFlashACKReceived(i_Parsedframe);

                        break;

                    case "80":
                        GetSimulatorID(i_Parsedframe);

                        break;

                    case "81":
                        GetSoftwareVertion(i_Parsedframe);

                        break;

                    case "82":
                        GetFirmwareVertion(i_Parsedframe);

                        break;

                    case "83":
                        GetHardwareVertion(i_Parsedframe);

                        break;

                    case "85":
                        GetSerialNumber(i_Parsedframe);

                        break;


                    case "90":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "91":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "92":
                        GetSimulatorStatus(i_Parsedframe);

                        break;

                    case "93":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "94":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "95":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "96":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "97":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "98":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "99":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "9A":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "9B":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "9C":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "9D":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "9E":
                        GetThermalSuperVisor(i_Parsedframe);

                        break;

                    case "9F":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "A0":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "A1":
                        ACK_Received(i_Parsedframe);

                        break;

                    case "B1":
                        ACK_ReceivedSimulator(i_Parsedframe);

                        break;

                    case "B3":
                        ACK_ReadRegisterReceivedSimulator(i_Parsedframe);

                        break;


                    default:
                        UnHandledOpcode(i_Parsedframe);
                        break;
                }

            }
        }

        private void SendMessageToSystemLogger(string i_msg)
        {

            SystemLogger.LogMessage(Color.Blue, Color.Azure, "", New_Line = false, Show_Time = true);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, "Rx:>", false, false);

            //if (i_msg.Contains("ACK") == true)
            //{
            //    SystemLogger.LogMessage(Color.DarkGreen, Color.White, i_msg, true, false);
            //}
            //else
            //{
            SystemLogger.LogMessage(Color.Blue, Color.LightGray, i_msg, true, false);
            //}

            GlobalSystemResultReceived += i_msg;
        }

        void DecodeStatus(byte[] i_IncomingBytes)
        {
            if(ShowStatus == false)
            {
                return;
            }
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("System mode: [{0}]", i_IncomingBytes[32]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Serial number: [{0}]", ConvertByteArraytToString(i_IncomingBytes.Skip(33).Take(2).Reverse().ToArray())), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FW version: [{0}]", ConvertByteArraytToString(i_IncomingBytes.Skip(35).Take(2).Reverse().ToArray())), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("SW version: [{0}]", ConvertByteArraytToString(i_IncomingBytes.Skip(37).Take(2).Reverse().ToArray())), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("INPUT_VOLTAGE : [{0}]", i_IncomingBytes[40]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("INPUT_CURRENT : [{0}]", i_IncomingBytes[41]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("DIGITAL_3V3  : [{0}]", i_IncomingBytes[42]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("RF_3V8: [{0}]", i_IncomingBytes[43]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_CORE_1V : [{0}]", i_IncomingBytes[44]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_DDR_1V35  : [{0}]", i_IncomingBytes[45]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_AUX_1V8  [{0}]", i_IncomingBytes[46]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("AFE79XX_0V95  : [{0}]", i_IncomingBytes[47]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("AFE79XX_1V2  : [{0}]", i_IncomingBytes[48]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("AFE79XX_1V8  : [{0}]", i_IncomingBytes[49]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_TEMP   : [{0}]", i_IncomingBytes[50]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("ADC_TEMP    : [{0}]", i_IncomingBytes[51]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("INPUT_VOLTAGE_OV_COUNTER    : [{0}]", i_IncomingBytes[52]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("INPUT_VOLTAGE_UV_COUNTER    : [{0}]", i_IncomingBytes[53]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("INPUT_VOLTAGE_OI_COUNTER   : [{0}]", i_IncomingBytes[54]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("INPUT_VOLTAGE_UI_COUNTER  : [{0}]", i_IncomingBytes[55]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("DIGITAL_3V3_OV_COUNTER  : [{0}]", i_IncomingBytes[56]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("DIGITAL_3V3_UV_COUNTER : [{0}]", i_IncomingBytes[57]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("RF_3V8_OV_COUNTER : [{0}]", i_IncomingBytes[58]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("RF_3V8_UV_COUNTER : [{0}]", i_IncomingBytes[59]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_CORE_OV_COUNTER : [{0}]", i_IncomingBytes[60]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_CORE_UV_COUNTER : [{0}]", i_IncomingBytes[61]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_DDR_OV_COUNTER : [{0}]", i_IncomingBytes[62]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_DDR_UV_COUNTER : [{0}]", i_IncomingBytes[63]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_AUX_OV_COUNTER : [{0}]", i_IncomingBytes[64]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_AUX_UV_COUNTER : [{0}]", i_IncomingBytes[65]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("AFE79XX_0V95_OV_COUNTER : [{0}]", i_IncomingBytes[66]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("AFE79XX_0V95_UV_COUNTER : [{0}]", i_IncomingBytes[67]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("AFE79XX_1V2_OV_COUNTER : [{0}]", i_IncomingBytes[68]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("AFE79XX_1V2_UV_COUNTER : [{0}]", i_IncomingBytes[69]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("AFE79XX_1V8_OV_COUNTER : [{0}]", i_IncomingBytes[70]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("AFE79XX_1V8_UV_COUNTER : [{0}]", i_IncomingBytes[71]), true, false);
          //  SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("AFE79XX_0V95_UV_COUNTER : [{0}]", i_IncomingBytes[72]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("SUM_COUNTER_ALARMS : [{0} {1}]", i_IncomingBytes[73], i_IncomingBytes[74]), true, false);


            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_DDR_OV_COUNTER : [{0}]", i_IncomingBytes[62]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_DDR_OV_COUNTER : [{0}]", i_IncomingBytes[62]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_DDR_OV_COUNTER : [{0}]", i_IncomingBytes[62]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_DDR_OV_COUNTER : [{0}]", i_IncomingBytes[62]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("FPGA_DDR_OV_COUNTER : [{0}]", i_IncomingBytes[62]), true, false);


            ShowStatus = false;


        }

        void DecodeReadCommand(byte[] i_IncomingBytes)
        {
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Read Recieved:"), true, true);
            byte[] Counter = i_IncomingBytes.Skip(2).Take(2).ToArray();
          // int x = BitConverter.ToInt32(i_IncomingBytes.Skip(3).Take(2).Reverse().ToArray(), 0);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Counter: [{0}]", BitConverter.ToInt16(i_IncomingBytes.Skip(2).Take(2).ToArray(),0)) , true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Register Address: [{0}]", ConvertByteArraytToString( i_IncomingBytes.Skip(4).Take(4).Reverse().ToArray())), true, false);
            GlobalReadRegister = BitConverter.ToInt32(i_IncomingBytes.Skip(8).Take(4).Reverse().ToArray(),0);
            SystemLogger.LogMessage(Color.Black, Color.Azure, String.Format("Read Data: [{0}]", ConvertByteArraytToString(i_IncomingBytes.Skip(8).Take(4).Reverse().ToArray())), true, false);

            DecodeStatus(i_IncomingBytes);
        }

        void DecodeWriteCommand(byte[] i_IncomingBytes)
        {
            SystemLogger.LogMessage(Color.Blue, Color.LightGreen, String.Format("Write Recieved: OK"), true, true);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Counter: [{0}]", BitConverter.ToInt16(i_IncomingBytes.Skip(2).Take(2).ToArray(), 0)), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Register Address: [{0}]", ConvertByteArraytToString(i_IncomingBytes.Skip(4).Take(4).Reverse().ToArray())), true, false);
           // SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Read Data: [{0}]", ConvertByteArraytToString(i_IncomingBytes.Skip(8).Take(4).Reverse().ToArray())), true, false);

            DecodeStatus(i_IncomingBytes);
        }

        void DecodeSetFullParamsCommand(byte[] i_IncomingBytes)
        {
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Set Full Params:"), true, true);
            // int x = BitConverter.ToInt32(i_IncomingBytes.Skip(3).Take(2).Reverse().ToArray(), 0);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Counter: [{0}]", BitConverter.ToInt16(i_IncomingBytes.Skip(2).Take(2).ToArray(), 0)), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Length [{0}]", BitConverter.ToInt32(i_IncomingBytes.Skip(4).Take(4).ToArray(),0)), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Activation [{0}]", i_IncomingBytes[8]), true, false);
            SystemLogger.LogMessage(Color.Blue, Color.Azure, String.Format("Message Time [{0}]", BitConverter.ToInt32(i_IncomingBytes.Skip(12).Take(4).ToArray(),0)), true, false);
            DecodeStatus(i_IncomingBytes);
        }
        
        void ParseOneIFRSFrame(byte[] i_IncomingBytes)
        {
            if(i_IncomingBytes[0] != 0x83)
            {
                SystemLogger.LogMessage(Color.Orange, Color.LightGray, String.Format("Frame not start with 0x83"), true, true);
                return;
            }

            switch(i_IncomingBytes[1])
            {
                //Read conmmand
                case 0x22:
                    DecodeReadCommand(i_IncomingBytes);
                    break;

                //Write conmmand
                case 0x21:
                    DecodeWriteCommand(i_IncomingBytes);
                    break;
                //SetFullParams commmand
                case 0x51:
                    DecodeSetFullParamsCommand(i_IncomingBytes);
                    break;

                case 0xF0:
                    SystemLogger.LogMessage(Color.OrangeRed, Color.LightGray, String.Format("Header error [{0}]", i_IncomingBytes[1].ToString("X")), true, true);
                    break;

                case 0xF1:
                    SystemLogger.LogMessage(Color.OrangeRed, Color.LightGray, String.Format("Command error [{0}]", i_IncomingBytes[1].ToString("X")), true, true);
                    break;

                case 0xF2:
                    SystemLogger.LogMessage(Color.OrangeRed, Color.LightGray, String.Format("Checksum error [{0}]", i_IncomingBytes[1].ToString("X")), true, true);
                    break;

                case 0xF3:
                    SystemLogger.LogMessage(Color.OrangeRed, Color.LightGray, String.Format("Data error [{0}]", i_IncomingBytes[1].ToString("X")), true, true);
                    break;

                case 0xF4:
                    SystemLogger.LogMessage(Color.OrangeRed, Color.LightGray, String.Format("Execution Error  [{0}]", i_IncomingBytes[1].ToString("X")), true, true);
                    break;

                case 0xF5:
                    SystemLogger.LogMessage(Color.OrangeRed, Color.LightGray, String.Format("Time-out Error type 1  [{0}]", i_IncomingBytes[1].ToString("X")), true, true);
                    break;

                case 0xF6:
                    SystemLogger.LogMessage(Color.OrangeRed, Color.LightGray, String.Format("Time-out Error type 2 [{0}]", i_IncomingBytes[1].ToString("X")), true, true);
                    break;

                case 0xF7:
                    SystemLogger.LogMessage(Color.OrangeRed, Color.LightGray, String.Format("Time-out Error type 3 [{0}]", i_IncomingBytes[1].ToString("X")), true, true);
                    break;

                default:
                    SystemLogger.LogMessage(Color.OrangeRed, Color.LightGray, String.Format("Not recognize CMD opcode [{0}]", i_IncomingBytes[1].ToString("X")), true, true);
                    break;
            }
        }

        public void DecodeIFRSProtocol(ref byte[] i_IncomingBytes)
        {
            var newArray = i_IncomingBytes.Skip(76).Take(4).Reverse().ToArray();
            UInt32 RecievedCheckSum = BitConverter.ToUInt32(newArray, 0);

            UInt32 CalculatedCheckSum = CalculateChecksum(i_IncomingBytes.Take(76).ToArray());

            if (RecievedCheckSum == CalculatedCheckSum)
            {
                ParseOneIFRSFrame(i_IncomingBytes);
            }
            else
            {
                SystemLogger.LogMessage(Color.OrangeRed, Color.Azure, String.Format( "Frame check sum error Recieved [{0}] Claculated [{1}]", RecievedCheckSum.ToString("X8"), CalculatedCheckSum.ToString("X8")), New_Line = true, Show_Time = true);
            }
            i_IncomingBytes = i_IncomingBytes.Skip(80).ToArray();

        }

        private void ParseKratosIncomeFrame(byte[] i_IncomeBuffer)
        {
            try
            {
                if (i_IncomeBuffer.Length == 0 || i_IncomeBuffer.Length < 80 || i_IncomeBuffer[0] != 0x83)
                {
                    return;
                }
                while (i_IncomeBuffer.Length != 0)
                {
                    DecodeIFRSProtocol(ref i_IncomeBuffer);


                    TCPClientBuffer = new byte[0];

                }
            }
            catch (Exception ex)
            {
                SystemLogger.LogMessage(Color.Red, Color.White, ex.ToString(), true, false);
            }
        }

        private string GlobalSystemResultReceived;

        // int ChartIndex = 0;
        //SSPA_Parser MiniAdaParser = new SSPA_Parser();
        private void ParseIncomeBuffer_TCPIP()
        {
            try
            {
                TcpClient PClientSocket = ClientSocket;
                if (TCPClientBuffer.Length > 0)
                {

                    ParseKratosIncomeFrame(TCPClientBuffer);

                    PClientSocket = ClientSocket;
                }
            }
            catch (Exception ex)
            {
                SystemLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = false, Show_Time = true);
            }
        }

        private void TCPClientConnection()
        {
            if (ClientSocket == null || ClientSocket.Client == null)
            {
                button_ClientConnect.BackColor = default;
            }
            label_ClientTCPConnected.BackColor = button_ClientConnect.BackColor;


            if (label_ClientTCPConnected.BackColor == Color.LightGreen)
            {
                label_TCPClient.Text = textBox_ClientIP.Text + "  \n" + textBox_ClientPort.Text;
            }
            else
            {
                label_TCPClient.Text = "None";
            }

            if (WaitforBufferFull > 0)
            {
                WaitforBufferFull--;
                textBox_SystemStatus.Text = string.Format("Wait for income buffer [{0}] ", WaitforBufferFull);
                textBox_SystemStatus.BackColor = Color.Yellow;


            }
            else
            {
                if (checkBox_ParseRxTCPBuffer.Checked == true)
                {

                    try
                    {
                        TcpClient PClientSocket = ClientSocket;
                        if (TCPClientBuffer.Length > 0)
                        {

                            ParseKratosIncomeFrame(TCPClientBuffer);

                            PClientSocket = ClientSocket;
                        }
                    }
                    catch (Exception ex)
                    {
                        SystemLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = false, Show_Time = true);
                    }
                }
                else
                {
                    try
                    {
                        TcpClient PClientSocket = ClientSocket;
                        if (TCPClientBuffer.Length > 0)
                        {

                            string str = System.Text.Encoding.Default.GetString(TCPClientBuffer);
                            richTextBox_ClientRxPrintText("[" + DateTime.Now.TimeOfDay.ToString().Substring(0, 11) + "] " + str + "\n \n");
                            TCPClientBuffer = new byte[0];
                            PClientSocket = ClientSocket;
                        }
                    }
                    catch (Exception ex)
                    {
                        SystemLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = false, Show_Time = true);
                    }



                }



            }

        }



        //bool timer_General_TranssmitionPeriodicallyEnable = false;
        //uint NumbeOfTransmmitions = 0;
        //private int progressBar_UserStatusTimer = -1;

        //uint IntervalTimeBetweenTransmitions = 1;
        private void Timer_General_Tick(object sender, EventArgs e)
        {
            if (textBox_SystemStatus_Timer > 0)
            {
                textBox_SystemStatus_Timer--;
            }
            else
            {
                textBox_SystemStatus.Text = "";
                textBox_SystemStatus.ForeColor = default;
                textBox_SystemStatus.BackColor = default;

                progressBar_UserStatus.ForeColor = Color.Blue;
                progressBar_UserStatus.BackColor = default;

                if (progressBar_UserStatus.Value == 100)
                {
                    progressBar_UserStatus.Value = 0;
                }

            }

            //if(progressBar_UserStatus.Value == 100)
            //{
            //    progressBar_UserStatus.ForeColor = Color.Green;
            //    progressBar_UserStatusTimer = 2;
            //}

            //if (progressBar_UserStatusTimer > 0)
            //{
            //    progressBar_UserStatusTimer--;
            //}
            //else
            //{
            //    progressBar_UserStatus.Value = 0;
            //    progressBar_UserStatus.ForeColor = default;
            //    progressBar_UserStatusTimer--;

            //    // CheckIfSerialPortOpen();
            //}

            TCPClientConnection();

            if (PlotGraphTimer > 0)
            {
                textBox_SystemStatus.Text = string.Format("Generating graph [{0}] ", PlotGraphTimer);
                textBox_SystemStatus.BackColor = Color.AliceBlue;
                PlotGraphTimer--;
            }
            else
            {
                if (PlotGraphTimer == 0)
                {
                    textBox_SystemStatus.Text = string.Empty;
                    textBox_SystemStatus.BackColor = default;
                    PlotGraphTimer--;
                }
            }
            //Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab0Color = randomColor;

            //randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab1Color = randomColor;

            //randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab2Color = randomColor;

            //randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //Tab3Color = randomColor;
            tabControl_Main.Invalidate();

            if (IsTimerRunning == true)
            {
                int.TryParse(textBox_TimerTime.Text, out int Result);
                if (Result != 0)
                {
                    Result--;
                    if (Result == 0)
                    {
                        SerialPortLogger.LogMessage(Color.White, Color.DarkOrange, "Timer End", true, true);
                        checkBox_SerialPortPause.Checked = true;

                        ResetTimer();
                    }
                    else
                    {

                    }
                    textBox_TimerTime.Text = Result.ToString();
                }
            }


            //         label_TimeDate.Text = DateTime.Now.ToString();
            //label_TimeDate2.Text = DateTime.Now.ToString();
            //label_TimeDate3.Text = DateTime.Now.ToString();


            //TimerExportContactsCommandsToFile++;








            //if (CloseSerialPortTimer == true)
            //{
            //    CloseSerialPortConter++;
            //    if (CloseSerialPortConter > 1)
            //    {
            //        SerialPort_DataReceived(null, null);
            //        CloseSerialPortConter = 0;
            //    }
            //}
            try
            {
                if (m_Server != null)
                {

                    if (m_Server.NumberOfOpenConnections == 0)
                    {
                        List<string> dataSource = new List<string>
                        {
                            "None"
                        };
                        comboBox_ConnectionNumber.DataSource = dataSource;
                        LastConNum = m_Server.NumberOfOpenConnections;

                        ConnectionToIDdictionary.Clear();
                        //for (int i = 0; i < UnitNumberToConnections.Length; i++)
                        //{
                        //    UnitNumberToConnections[i] = "";
                        //}
                    }
                    else
                        if (LastConNum != m_Server.NumberOfOpenConnections)
                    {
                        List<string> ret = m_Server.GetAllOpenConnections();

                        List<string> listkeys = new List<string>(ConnectionToIDdictionary.Keys);
                        foreach (string str in listkeys)
                        {
                            bool found = false;

                            foreach (string str2 in ret)
                            {
                                if (str == str2)
                                {
                                    found = true;

                                }
                            }

                            if (found == false)
                            {
                                ConnectionToIDdictionary.Remove(str);
                            }
                        }

                        comboBox_ConnectionNumber.DataSource = ret;

                        LastConNum = m_Server.NumberOfOpenConnections;


                    }
                    PrintDictineryIDKeys();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void PrintDictineryIDKeys()
        {
            textBox_IDKey.Invoke(new EventHandler(delegate
            {
                textBox_IDKey.Text = "Connection       |      Unit ID \n";
                textBox_IDKey.AppendText("------------------------------------- \n");
            }));

            foreach (KeyValuePair<string, string> pair in ConnectionToIDdictionary)
            {
                textBox_IDKey.Invoke(new EventHandler(delegate
                {
                    textBox_IDKey.AppendText(pair.Key + " | " + pair.Value.Replace(';', ' ') + " \n");
                }));
            }

        }

        private static int LastConNum = 0;
        //private static int CloseSerialPortConter = 0;
        //private bool CloseSerialPortTimer = false;
        //private bool ComPortClosing = false;

        //List<byte> temp_serialBuff = new List<byte>();
        void WriteBufferInfo(byte[] i_buffer)
        {
            SerialPortLogger.LogMessage(Color.Green, Color.White, String.Format("Total bytes: [{0}]" ,i_buffer.Length.ToString()), New_Line = true, Show_Time = false);
            SerialPortLogger.LogMessage(Color.Green, Color.White, "Check sum calculation", New_Line = true, Show_Time = false);
            SerialPortLogger.LogMessage(Color.Green, Color.White, FrameAnalizer, New_Line = true, Show_Time = false);
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            // If the com port has been closed, do nothing
            if (!serialPort.IsOpen)
            {
                return;
            }

            //if (ComPortClosing == true)
            //{
            //    //Thread.Sleep(400);
            //    serialPort.Close();
            //    ComPortClosing = false;

            //    //checkBox_ComportOpen.Checked = false;

            //    cmbBaudRate.Invoke(new EventHandler(delegate
            //    {
            //        //button_OpenPort.Checked = false;
            //        button_OpenPort.Enabled = true;
            //        gbPortSettings.Enabled = true;

            //        button_OpenPort.BackColor = default;
            //        label_SerialPortConnected.BackColor = default;
            //        label_SerialPortStatus.Text = "";

            //        //cmbBaudRate.Enabled = true;
            //        //cmbDataBits.Enabled = true;
            //        //cmbParity.Enabled = true;
            //        //cmb_PortName.Enabled = true;
            //        //cmb_StopBits.Enabled = true;
            //    }));

            //    CloseSerialPortTimer = false;

            //    SerialPortLogger.LogMessage(Color.Orange, Color.LightGray, "Serial port Closed", New_Line = true, Show_Time = true);
            //    return;
            //}

            // This method will be called when there is data waiting in the port's buffer
            Thread.Sleep(300);



            

            // Obtain the number of bytes waiting in the port's buffer
            int bytes = serialPort.BytesToRead;

            // Create a byte array buffer to hold the incoming data
            byte[] buffer = new byte[bytes];

            if (buffer == null || buffer.Length == 0)
            {
                return;
            }

            RxLabelTimerBlink = 5;

            // Read the data from the port and store it in our buffer
            serialPort.Read(buffer, 0, bytes);

            SerialPortLogger.LogMessage(Color.Blue, Color.Azure, "", New_Line = false, Show_Time = true);
            SerialPortLogger.LogMessage(Color.Blue, Color.Azure, "Rx:>", false, false);

            if (checkBox_RxHex.Checked == true)
            {


                if (buffer[0] == 0x83)
                {
                    SerialPortLogger.LogMessage(Color.Blue, Color.Pink, ConvertByteArraytToString(buffer.Take(2).ToArray()), New_Line = false, Show_Time = false);
                    SerialPortLogger.LogMessage(Color.Blue, Color.Cyan, ConvertByteArraytToString(buffer.Skip(2).Take(23).ToArray()), New_Line = false, Show_Time = false);
                    SerialPortLogger.LogMessage(Color.Blue, Color.Azure, ConvertByteArraytToString(buffer.Skip(25).Take(55).ToArray()), New_Line = false, Show_Time = false);
                    SerialPortLogger.LogMessage(Color.Blue, Color.PeachPuff, ConvertByteArraytToString(buffer.Skip(76).Take(4).ToArray()), New_Line = true, Show_Time = false);
                }
                else
                {
                    string IncomingHexMessage = ConvertByteArraytToString(buffer);
                    SerialPortLogger.LogMessage(Color.Blue, Color.Azure, IncomingHexMessage, New_Line = true, Show_Time = false);
                }

                

                



                ParseKratosIncomeFrame(buffer);
            }
            else
            {

                string IncomingString = System.Text.Encoding.Default.GetString(buffer);




                string[] lines = Regex.Split(IncomingString, "\r\n");

                foreach (string line in lines)
                {
                    SerialPortLogger.LogMessage(Color.Blue, Color.Azure, line, New_Line = true, Show_Time = false);
                }

            }

            if (checkBox_WriteFrameInformation.Checked == true)
            {
                WriteBufferInfo(buffer);
            }



        }

        private string ConvertByteArraytToString(byte[] i_Buffer)
        {
            string IncomingHexMessage = "";
            foreach (byte by in i_Buffer)
            {
                IncomingHexMessage += by.ToString("X2") + " ";

            }

            return IncomingHexMessage;
        }

        private enum SourceMessage
        {
            SMS,
            SerialPort,
            Server
        };

        private void ParseStatuPos(string IncomingString)
        {
            string[] ParseStrings = { "" };
            string[] Key = { "" };
            try
            {
                if (IncomingString.Contains(","))
                {
                    ParseStrings = IncomingString.Split(',');
                    Key = ParseStrings[1].Split('=');
                }
            }
            catch
            {
                //ServerLogger.LogMessage(Color.Black, Color.White, "Data Not Valid: " + IncomingString, New_Line = true, Show_Time = true);
                return;
            }

            bool IwatcherPrint = false;


            if (Key[0] == "POS")
            {

                if (IwatcherPrint == true)
                {

                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n STATE = " + Key[1] +
                        "\n GSM LINK QUALITY = " + ParseStrings[2] +
                        "\n GPS STATUS = " + ParseStrings[3] +
                        "\n GPS NUM OF SATELLITES = " + ParseStrings[4] +
                        "\n CURRENT TIME AND DATE = " + ParseStrings[5] + " " + ParseStrings[6] +
                        "\n LAST GPS TIME AND DATE = " + ParseStrings[7] + " " + ParseStrings[8] +
                        "\n GPS LATITUDE = " + ParseStrings[9] +
                        "\n GPS LONGTITUDE = " + ParseStrings[10] +
                        "\n GPS SPEED = " + ParseStrings[11] +
                        "\n GPS DIRECTION =" + ParseStrings[12] +
                        "\n TRIP DISTANCE  = " + ParseStrings[13] +
                        "\n TOTAL DISTANCE = " + ParseStrings[14];
                    //  "\n GPRS MESSAGE  NUMBER = " + PosStrings[15];

                    //string.Format("\n UNIT ID = {0} \n STATE = {1}\n GSM LINK QUALITY = {2}", PosStrings[0].Replace(";",""), Key[1], PosStrings[2]); 
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                }

                //string ret = "";
                //if (checkBox_ShowURL.Checked)
                //{
                //    string ret = "http://maps.google.com/maps?q=" + ParseStrings[9] + "," + ParseStrings[10] + "( " + " Current Time: " + DateTime.Now + "\r\n   S1TimeStamp: " + " )" + "&z=14&ll=" + "," + "&z=17";
                //    Show_WebBrowserUrl(ret);
                //}

                //if (checkBox_RecordLatLong.Checked)
                //{

                //    NumOfPositionMessage++;
                //    //354869050154426,POS=1,GSMLinkQual,5,8,12/9/2013,10:55:11,12/9/2013,10:55:11,32.155636,34.920308,0,304.2,


                //    KMl_text.Add("<Placemark>");
                //    KMl_text.Add("<name>" + "[" + NumOfPositionMessage + "]" + " " + DateTime.Now + "  </name>");
                //    KMl_text.Add("<Point>");
                //    KMl_text.Add("<coordinates>" + ParseStrings[10] + "," + ParseStrings[9] + "</coordinates> ");
                //    KMl_text.Add("</Point>");
                //    KMl_text.Add("</Placemark> ");
                //    KMl_text.Add("</Document> \n");
                //    KMl_text.Add("</kml> \n");

                //    File.Delete(log_file_S1_LatLong);
                //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(log_file_S1_LatLong))
                //    {
                //        foreach (string str in KMl_text)
                //        {
                //            file.WriteLine(str);
                //        }
                //        //for (int i = 0; i < KML_Index; i++)
                //        //{

                //        //}
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        // KML_Index -= 2;
                //    }


                //}

                //if (checkBox_EchoResponse.Checked == true)
                //{

                //    string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                //    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                //    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                //    SendDataToServer(mye.ConnectionNumber, b2);
                //}


            }
            else
                if (Key[0] == "STAT")
            {
                if (IwatcherPrint == true)
                {
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: " + i_SourceMessage.ToString(), New_Line = false, Show_Time = true);
                    //if (i_Contact != null)
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: " + i_Contact.Name, New_Line = false, Show_Time = false);
                    //}
                    //else
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: ", New_Line = false, Show_Time = false);
                    //}
                    //LogIWatcher.LogMessage(Color.DarkOrange, Color.White, "\nSTATUS Message Received: ", New_Line = false, Show_Time = false);

                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n SYSTEM STATE = " + Key[1] +
                        "\n IGN STATE = " + ParseStrings[2] +
                        "\n GP1 = " + ParseStrings[3] +
                        "\n GP2 = " + ParseStrings[4] +
                        "\n GP3 = " + ParseStrings[5] +
                        "\n Main Power Source = " + ParseStrings[6] +
                        "\n Back Up Battery problem indication = " + ParseStrings[7] +
                        "\n OUTPUT 1  STATE = " + ParseStrings[8] +
                        "\n OUTPUT 2  STATE = " + ParseStrings[9] +
                        "\n OUTPUT 3  STATE = " + ParseStrings[10] +
                        "\n OUTPUT 4  STATE = " + ParseStrings[11] +
                        "\n DATE = " + ParseStrings[12] +
                        "\n TIME  = " + ParseStrings[13] +
                        "\n GPS LATITUDE = " + ParseStrings[14] +
                        "\n GPS LONGTITUDE = " + ParseStrings[15] +
                        "\n VEHICLE SPEED = " + ParseStrings[16] +
                        "\n SPEED EVENT  = " + ParseStrings[17] +
                        "\n BATTERY LOW EVENT =" + ParseStrings[18] +
                        "\n BATTERY CUT OFF EVENT  = " + ParseStrings[19] +
                        "\n ACCIDENT EVENT = " + ParseStrings[20] +
                        "\n TOWING EVENT = " + ParseStrings[21] +
                        "\n TILT EVENT = " + ParseStrings[22];

                    //LogIWatcher.LogMessage(Color.Blue, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
            else
                    if (Key[0] == "GETCONFIG?")
            {
                if (IwatcherPrint == true)
                {


                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n SUBSCRIBER 1 = " + ParseStrings[2] +
                        "\n SUBSCRIBER 2 = " + ParseStrings[3] +
                        "\n SUBSCRIBER 3 = " + ParseStrings[4] +
                        "\n SPEED LIMIT = " + ParseStrings[5] +
                        "\n vehicle battery threshold = " + ParseStrings[6] +
                        "\n pos message duration time interval = " + ParseStrings[7] +
                        "\n pos message according distance interval = " + ParseStrings[8] +
                        "\n status message duration time interval on sleep = " + ParseStrings[9] +
                        "\n Logger Counter = " + ParseStrings[10] +
                        "\n Tilt angle= " + ParseStrings[11] +
                        "\n Tilt sensitivity = " + ParseStrings[12] +
                        "\n Tilt Constant = " + ParseStrings[13] +
                        "\n TOW angle  = " + ParseStrings[14] +
                        "\n TOW sensitivity = " + ParseStrings[15] +
                        "\n TOW Constant = " + ParseStrings[16] +
                        "\n Anti Jamming detection = " + ParseStrings[17] +
                        "\n Anti Jamming configuration = " + ParseStrings[18] +
                        "\n GPRS reconnection = " + ParseStrings[19] +
                        "\n Satellite type = " + ParseStrings[20];

                    //LogIWatcher.LogMessage(Color.Blue, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
            else
                        if (Key[0] == "GETCONFIG2?")
            {
                if (IwatcherPrint == true)
                {

                    _ =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n password = " + ParseStrings[2] +
                        "\n primary host address + port = " + ParseStrings[3] +
                        "\n primary access point name = " + ParseStrings[4] +
                        "\n fota host address + port = " + ParseStrings[5] +
                        "\n fota access point name = " + ParseStrings[6] +
                        "\n software version = " + ParseStrings[7] +
                        "\n GPS num of used satellites = " + ParseStrings[8] +
                        "\n GPS last timestamp  = " + ParseStrings[9];

                    //LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
        }
        private static readonly Mutex mutexACKSMSReceived = new Mutex();

        private void ParseSerialPortSMSString(string IncomingString)
        {

        }

        private void ParseSerialPortString(string IncomingString)
        {
            // Boolean ret;
            try
            {
                ParseUnitVersion(IncomingString.Replace(System.Environment.NewLine, " "));
                IncomingString = IncomingString.Replace(System.Environment.NewLine, "");
                //ParseConfigCommand(IncomingString);
                //ret = ParseSMSCommand(IncomingString);

               // ParseStatuPos(IncomingString);

                // ParseUnitVersion(IncomingString);





            }
            catch (Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = true, Show_Time = true);
                //    return;
            }
        }

        private bool ParseSMSCommand(string IncomingString)
        {
            bool ret = false;
            bool IsCommandFound = true;
            while (IsCommandFound == true)
            {

                int StartCommand = IncomingString.IndexOf("{COMMAND_SMS_START}");
                int EndCommand = IncomingString.IndexOf("{COMMAND_SMS_END}");
                if (StartCommand >= 0 && EndCommand >= 0 && (EndCommand > StartCommand))
                {
                    ret = true;
                    StartCommand += "{COMMAND_SMS_START}".Length;
                    string CommandString = IncomingString.Substring(StartCommand, EndCommand - StartCommand);

                    //       LogSMS.LogMessage(Color.Cyan, Color.White, CommandString, New_Line = true, Show_Time = true);

                    EndCommand += "{COMMAND_SMS_END}".Length;
                    IncomingString = IncomingString.Substring(EndCommand);
                    IsCommandFound = true;

                    //ModemStatus mdmStat = new ModemStatus(ref CommandString);



                    if (CommandString.Contains("SMS was Send To the Modem"))
                    {
                        mutexACKSMSReceived.WaitOne();
                        //   ACKSMSReceived = true;
                        mutexACKSMSReceived.ReleaseMutex();

                        //LogSMS.LogMessage(Color.DarkBlue, Color.White, "SMS Send ACK received", New_Line = true, Show_Time = true);

                        if (checkBox_SMSencrypted.Checked == true)
                        {
                            string[] temp = CommandString.Split('[', ']');
                            //   LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                            //   LogSMS.LogMessage(Color.Green, Color.White, "Encrypted SMS (Copy to server Tab):\n" + temp[5], New_Line = true, Show_Time = false);

                            txtDataTx.Invoke(new EventHandler(delegate
                            {
                                txtDataTx.Text = temp[5];
                            }));

                        }
                    }
                    else
                    if (CommandString.Contains("Modem ring to Contact."))
                    {
                        string[] temp = CommandString.Split('[', ']');
                        //LogSMS.LogMessage(Color.DarkBlue, Color.White, "Ring to contact, Phone Number: " + temp[3] + " Hangout: " + temp[5], New_Line = true, Show_Time = true);

                    }

                    if (CommandString.Contains("SMS_received Decrypted"))
                    {
                        string[] strsplit = CommandString.Split('[', ']');


                        ParseSMSText(strsplit[1], strsplit[3], Color.Brown);
                    }
                    else
                        if (CommandString.Contains("SMS_received"))
                    {
                        string[] strsplit = CommandString.Split('[', ']');


                        ParseSMSText(strsplit[1], strsplit[3], Color.Blue);
                    }
                }
                else
                {
                    IsCommandFound = false;
                }
            }

            return ret;
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private void ParseSMSText(string i_Subscriber, string i_SMSText, Color i_ColorDisplay)
        {




        }

        private string UnitVersion;

        private void ParseUnitVersion(string IncomingString)
        {
            if (IncomingString.Contains("******START******") == true)
            {
                int StartConfig = IncomingString.IndexOf("******START******");
                StartConfig += "******START******".Length;
                UnitVersion = IncomingString.Substring(StartConfig);
                int EndConfig = UnitVersion.IndexOf("*********************");
                UnitVersion = UnitVersion.Substring(0, EndConfig);



            }

        }

        private void ParseConfigCommand(string IncomingString)
        {
            int StartConfig = IncomingString.IndexOf("{CONFIG_START}");
            int EndConfig = IncomingString.IndexOf("{CONFIG_END}");
            if (StartConfig >= 0 && EndConfig > 0 && (EndConfig > StartConfig))
            {
                StartConfig += "{CONFIG_START}".Length;
                string ConfigString = IncomingString.Substring(StartConfig, EndConfig - StartConfig);

                if (ConfigString.Contains("CONFIGOK"))
                {
                    //TextBox_GenerateConfigFile_Text("Config OK", Color.LightGreen);
                }
                else
                {
                    //SendToConfigPage(ConfigString, "Serial Port");
                }
            }
        }


        private void Button_StopPeriodaclly_Click(object sender, EventArgs e)
        {


        }

        private DateTime RetrieveLinkerTimestamp()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }




        //  static int LastNumOfConnections = 0;
        private void TextBox_NumberOfOpenConnections_TextChanged(object sender, EventArgs e)
        {

            if (m_Server != null)
            {

                if (m_Server.NumberOfOpenConnections > 1)
                {
                    // IsTimedOutTimerEnabled = true;
                    textBox_NumberOfOpenConnections.BackColor = Color.Orange;
                    //ListenBox.BackColor = Color.Green;

                    ServerLogger.LogMessage(Color.Orange, Color.White, "Num Of Connections is bigger than one, " + m_Server.NumberOfOpenConnections, true, true);

                }
                else
                    if (m_Server.NumberOfOpenConnections == 1)
                {
                    //IsTimedOutTimerEnabled = true;
                    //ListenBox.BackColor = Color.Green;
                    textBox_NumberOfOpenConnections.BackColor = Color.Green;
                }
                else
                {
                    // IsTimedOutTimerEnabled = false;
                    textBox_NumberOfOpenConnections.BackColor = default;
                }

                GetDataIntervalCounter = 0;


                //if (LastNumOfConnections > m_Server.NumberOfOpenConnections)
                //{
                //    //ListenBox.BackColor = Color.Yellow;
                //}

                // LastNumOfConnections = m_Server.NumberOfOpenConnections;
            }

        }

        private void Button_AddDendSingleCommand_Click(object sender, EventArgs e)
        {
            try
            {
                //textBox_AddSendSingleCommand.Text = CommandsDescription[comboBox_AddSendSingleCommand.SelectedIndex].Format;
            }
            catch
            {
            }
        }

        private void ComboBox_AddSendSingleCommand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button_ValidateCommand_Click(object sender, EventArgs e)
        {


        }


        private void Button6_Click(object sender, EventArgs e)
        {
            //button_ValidateCommand.Enabled = true;
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            //Config_Sys.Enabled = true;
            //ConfigProcessExit = true;
        }


        private void CheckBox_EchoResponse_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private readonly Dictionary<int, string> FOTAData = new Dictionary<int, string>();
        private void Button5_Click(object sender, EventArgs e)
        {





        }





        private void TextBox_TotalFrames256Bytes_TextChanged(object sender, EventArgs e)
        {
            //if (textBox_TotalFrames256Bytes.Text.Length > 0)
            //{
            //    textBox_TotalFrames256Bytes.BackColor = Color.White;
            //}
        }

        private void Button33_Click(object sender, EventArgs e)
        {
            //if (textBox_TotalFrames1280Bytes.Text.Length > 0 && textBox_TotalFileLength.Text.Length > 0)
            //{
            //    //txtDataTx.Text = ";<" + Monitor.Properties.Settings.Default.SystemPassword + ">STARTFOTA=," + textBox_TotalFrames1280Bytes.Text + "," + textBox_TotalFileLength.Text + ",;";
            //    txtDataTx.Text = string.Format(";<{0}>STARTFOTA=,{1},{2},;", Monitor.Properties.Settings.Default.SystemPassword, textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);           
            //}


            ServerLogger.LogMessage(Color.Blue, Color.White, "****************** System ID's Status ****************** ", New_Line = true, Show_Time = true);
            foreach (KeyValuePair<string, string> pair in IDToFOTA_Status)
            {
                ServerLogger.LogMessage(Color.Blue, Color.White, pair.Key + "   " + pair.Value + " \n", New_Line = false, Show_Time = false);

            }
        }





        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateCommandCLIHistory(string i_SendString)
        {
        Monitor.Properties.Settings.Default.CLICommad_History.Remove(i_SendString);
        Monitor.Properties.Settings.Default.CLICommad_History.Add(i_SendString);
        Monitor.Properties.Settings.Default.CLICommad_History.Remove("");
        Monitor.Properties.Settings.Default.Save();
            
        CLI_HistoryIndex = Settings.Default.CLICommad_History.Count;

        }

            private void UpdateSerialPortHistory(string i_SendString)
        {
            if(i_SendString == "")
            {
                return;
            }

            bool Found = false;

            foreach (string str in Monitor.Properties.Settings.Default.SerialPort_History)
            {
                //comboBox_SerialPortHistory.Items.Add((object)str);
                // comboBox_SMSCommands.Items.Add(str);
                if (str == i_SendString)
                {
                    Found = true;
                }
            }

            if (Found == false)
            {
                Monitor.Properties.Settings.Default.SerialPort_History.Add(i_SendString);
                Monitor.Properties.Settings.Default.Save();
            }

            if (CommandsHistoy.Count > 0)
            {
                string LastCommand = CommandsHistoy[CommandsHistoy.Count - 1];

                if (LastCommand != i_SendString)
                {
                    CommandsHistoy.Add(i_SendString);
                }
            }




            //if (Monitor.Properties.Settings.Default.SerialPort_History != null)
            //{
            //    CommandsHistoy.Clear();
            //    foreach (string str in Monitor.Properties.Settings.Default.SerialPort_History)
            //    {
            //        CommandsHistoy.Add(str);
            //        // comboBox_SMSCommands.Items.Add(str);
            //    }
            //}
        }

        private void UpdateSerialPortComboBox()
        {
            if (Monitor.Properties.Settings.Default.SerialPort_History != null)
            {
                CommandsHistoy.Clear();
                foreach (string str in Monitor.Properties.Settings.Default.SerialPort_History)
                {
                    CommandsHistoy.Add(str);
                    // comboBox_SMSCommands.Items.Add(str);
                }
            }
        }


      



   

        private void Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void Button6_Click_2(object sender, EventArgs e)
        {
            //   textBox_SendSerialPort.Text = "<1234>READ?,;";
            //TextBox_SourceConfig_Clear();

            string Sendstr = string.Format(";READ?,;");
            byte[] buffer = Encoding.ASCII.GetBytes(Sendstr);
            bool IsSent = SerialPortSendData(buffer);

            if (IsSent == true)
            {
                //textBox_SourceConfig.Text = "Command sent";

            }

        }




        private enum ConfigDataType
        {
            PosPeriod5Sec,
            AutoARM,
            Angel,
            PeriodStatus,
            SpeedLimit,
            Number,
            Float,
            BatLevel,
            JammingSens,
            EveryThing,
            AlarmViaSMS,
            Unit_ID,
            Subscriber,
            Password,
            Boolean,
            IpAddress,
            Port,
            GPRSDisconnectNum,
            GPSType,
            DISARMCODE,
            CutSpeed
        };

        private bool CheckSubscriberValid(string i_String, ConfigDataType i_DataType)
        {
            bool ret;
            try
            {


                switch (i_DataType)
                {
                    case ConfigDataType.CutSpeed:
                        if (i_String.Length <= 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 20 || Num == 255)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.DISARMCODE:
                        if (i_String.Length == 4 && (Regex.IsMatch(i_String, @"^[1-5]+$") || Regex.IsMatch(i_String, @"^[0]+$") || i_String == "9999"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.GPSType:
                        if (i_String.Length == 1 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 2)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.PosPeriod5Sec:
                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num > 0)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.AutoARM:
                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 2 && Num <= 300)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.EveryThing:
                        ret = true;
                        break;

                    case ConfigDataType.PeriodStatus:

                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 96)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Angel:

                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 360)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.SpeedLimit:

                        ret = false;

                        break;

                    case ConfigDataType.BatLevel:

                        if (i_String.Length < 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 9)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.JammingSens:

                        if (i_String.Length < 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Jamming = int.Parse(i_String);

                            if (Jamming >= 20 && Jamming <= 70)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Float:
                        float f;

                        if (float.TryParse(i_String, out f))
                        {

                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }



                        break;

                    case ConfigDataType.Number:
                        if (Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.GPRSDisconnectNum:
                        if (i_String.Length < 6 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.Port:
                        if (i_String.Length < 6 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.AlarmViaSMS:
                        if (i_String.Length < 8 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                            UpdateAlarmCheckBoxes();
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.IpAddress:
                        //                IPAddress address;
                        //if (IPAddress.TryParse(i_String, out address))
                        if (i_String.Length > 4)
                        {
                            //Valid IP, with address containing the IP
                            ret = true;
                        }
                        else
                        {
                            //Invalid IP
                            ret = false;
                        }
                        break;
                    case ConfigDataType.Subscriber:
                        if (i_String == "0")
                        {
                            ret = true;
                        }
                        else
                        if (i_String.Length < 6)
                        {
                            ret = false;
                        }
                        else
                            if (i_String.Length < 20 && (i_String.StartsWith("+") || i_String.StartsWith("00")) && Regex.IsMatch(i_String.Substring(1), @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Password:

                        if (i_String.Length < 15)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Boolean:
                        if (i_String == "0" || i_String == "1")
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Unit_ID:
                        if (i_String.Length > 14 && i_String.Length < 17 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    default:
                        ret = false;
                        break;
                }
            }
            catch
            {
                //TextBox_GenerateConfigFile_Text(ex.ToString(), Color.Red);
                ret = false;
            }

            return ret;
        }

        private bool CheckAllTextboxConfig()
        {

            //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            //// Loop through list
            ////bool IsAllGreen = true;
            //foreach (string k in list)
            //{
            //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];
            //    if (temp.BackColor == Color.Red && temp.Visible == true)
            //    {
            //        return false;
            //    }
            //}

            return true;
        }

        private void TextBox_Config1_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        private void TextBox_Config2_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        private void TextBox_Config3_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        private void CheckConfigTextboxValidData(TextBox i_TextBox, ConfigDataType i_ConfigDataType)
        {

            i_TextBox.Invoke(new EventHandler(delegate
            {
                if (i_TextBox.Text == "" || i_TextBox.Text == "@%@")
                {
                    i_TextBox.Text = "";
                    i_TextBox.BackColor = default;
                }
                else
                    if (CheckSubscriberValid(i_TextBox.Text, i_ConfigDataType) == true)
                {
                    i_TextBox.BackColor = Color.LightGreen;
                }
                else
                {
                    //  i_TextBox.Visible = true;
                    i_TextBox.BackColor = Color.Red;
                }
            }));
        }

        private void TextBox_Config4_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Password);
        }

        private void TextBox_Config5_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.BatLevel);
        }

        //void TextBox_SourceConfig_Clear()
        //{
        //    textBox_SourceConfig.BackColor = default;
        //    textBox_SourceConfig.Text = "";
        //}

        private void Button3_Click_2(object sender, EventArgs e)
        {
            //   textBox_SendSerialPort.Text = "<1234>READ?,;"

            //TextBox_SourceConfig_Clear();

        }

        private void Password_form_Load(object sender, EventArgs e)
        {

        }

        private string GenerateConfigCommand()
        {

            //sw.Write(";" + UnitID + ",CONFIG=,");
            //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            //// Loop through list

            //foreach (string k in list)
            //{
            //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];
            //    string Field = temp.Text;
            //    if (Field == "")
            //    {
            //        Field = "@%@";
            //    }
            //    SendStr += Field + ",";
            //}

            string SendStr = ";";

            return SendStr;
        }


        //void CleartextBox_GenerateConfigFile()
        //{
        //    textBox_GenerateConfigFile.Text = "";
        //    textBox_GenerateConfigFile.BackColor = default(Color);
        //}

        private void Button28_Click_1(object sender, EventArgs e)
        {
            try
            {
                TextBox_GenerateConfigFile_Clear();

                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {
                    //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
                }






                //string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";


                // This text is always added, making the file longer over time 
                // if it is not deleted. 

                //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();




                //textBox_GenerateConfigFile.BackColor = Color.Green;

            }
            catch (Exception ex)
            {
                ex.ToString(); //Gil: just remove warning.
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void Button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                TextBox_GenerateConfigFile_Clear();
                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {

                }


                //string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";


                // This text is always added, making the file longer over time 
                // if it is not deleted. 

                //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();

                string SendStr = GenerateConfigCommand();

                SendStr = SendStr.Replace(";", ",");

                byte[] buf = Encoding.ASCII.GetBytes(SendStr);
                int Size = buf.Length;
                byte CheckSum = CalcCheckSumbufferSize(buf);


                SendStr = ";{CONFIG_START}," + SendStr + "," + Size + "," + CheckSum + ",{CONFIG_END};";
                byte[] buffer = Encoding.ASCII.GetBytes(SendStr);
                bool IsSent = SerialPortSendData(buffer);

                if (IsSent == true)
                {
                    //textBox_GenerateConfigFile.BackColor = Color.Yellow;
                    //textBox_GenerateConfigFile.Text = "Config has been sent";

                }

                //textBox_GenerateConfigFile.BackColor = Color.Green;
                //textBox_GenerateConfigFile.Text = "File " +  + " saved in directory \n" + Directory.GetCurrentDirectory();
            }
            catch (Exception ex)
            {
                ex.ToString(); //Gil: just remove warning.
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void Button30_Click(object sender, EventArgs e)
        {

        }

        //textBox_UnitVersion



        private void TextBox_GenerateConfigFile_Clear()
        {
            //textBox_GenerateConfigFile.Invoke(new EventHandler(delegate
            //    {
            //        textBox_GenerateConfigFile.Text = "";
            //        textBox_GenerateConfigFile.BackColor = default(Color);
            //    }));
        }




        private void TextBox_ConfigUnitID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            //// Loop through list

            //foreach (string k in list)
            //{
            //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];
            //    temp.Visible = true;
            //}

        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox_LoadedConfig_Enter(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void TextBox_Config13_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.AlarmViaSMS);

        }

        private void UpdateAlarmCheckBoxes()
        {

        }

        private void CheckBox_config_Bit0_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void UpdateTextBox13()
        {



        }

        private void CheckBox_config_Bit4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit5_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit6_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit7_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit8_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit9_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void CheckBox_config_Bit10_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void Button32_Click(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void TextBox_Config10_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.IpAddress);
        }

        private void TextBox_Config11_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.IpAddress);
        }

        private void TextBox_Config12_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Port);
        }

        private void TextBox_Config24_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config23_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config27_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPRSDisconnectNum);
        }

        private void TextBox_Config9_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.EveryThing);
        }

        private void TextBox_Config29_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void TextBox_Config26_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.JammingSens);
        }

        private void TextBox_Config6_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Port);
        }

        private void TextBox_Config7_TextChanged(object sender, EventArgs e)
        {

            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.SpeedLimit);


        }

        private void TextBox_Config8_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.PeriodStatus);
        }

        private void TextBox_Config14_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void TextBox_Config15_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config16_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config17_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void TextBox_Config18_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config19_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config20_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void TextBox_Config21_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config22_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.PosPeriod5Sec);
        }

        private void TextBox_Config28_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config30_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void TextBox_Config25_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Float);
        }

        private void CheckBox_RecordGeneral_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void TextBox_IDKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPortNo_TextChanged(object sender, EventArgs e)
        {
            Monitor.Properties.Settings.Default.Start_Port = txtPortNo.Text.ToString();

            Monitor.Properties.Settings.Default.Save();
        }







        private void Button39_Click(object sender, EventArgs e)
        {
            //groupBox34.Enabled = false;
            foreach (object item in checkedListBox_PhoneBook.CheckedItems)
            {
                if (item != null)
                {
                    //    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)item);
                    //SendSMSToContact((PhoneBookContact)item, SMSText);
                }
            }
            //     AddCommandToCommands(richTextBox_TextSendSMS.Text);
            //    groupBox34.Enabled = true;
        }

        private void RemoveSelectedContact()
        {

        }

        private void Button_RemoveContact_Click(object sender, EventArgs e)
        {
            RemoveSelectedContact();
        }

        private void Button_ExportToXML_Click(object sender, EventArgs e)
        {






        }

        private void Button_ImportToXML_Click(object sender, EventArgs e)
        {


        }

        private void AddCommandToCommands(string i_SMSText)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        //  bool ACKSMSReceived = false;
        //void SendSMSToContact(PhoneBookContact i_Contact, string i_SMSText)
        //{
        //    // AddCommandToCommands(i_SMSText);
        //    int PosStr = 0;
        //    if (i_Contact == null)
        //    {
        //        return;
        //    }

        //    //i_SMSText = i_SMSText.Replace("\n", string.Empty);
        //    //i_SMSText = i_SMSText.Replace("\r", string.Empty);
        //    while (PosStr < i_SMSText.Length)
        //    {

        //        string SMSToSend ;
        //        int CharsLeft = i_SMSText.Length - PosStr;
        //        //.SubString( 0, dec.Length > 240 ? 240 : dec.Length )

        //        if (CharsLeft > 160)
        //        {
        //            SMSToSend = i_SMSText.Substring(PosStr, 160);

        //        }
        //        else
        //        {
        //            SMSToSend = i_SMSText.Substring(PosStr, CharsLeft);
        //        }
        //        PosStr += 160;

        //        string StrToSend = "{SMS_SEND}," + i_Contact.Phone + "," + SMSToSend + "\r{SMS_END}";

        //        StrToSend = ReturnSMSEncryiepted(StrToSend);

        //        byte[] buffer = Encoding.ASCII.GetBytes(StrToSend);

        //        bool IsSent = SerialPortSMSSendData(buffer);

        //        if (IsSent == true)
        //        {

        //  //          LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
        //            //LogSMS.LogMessage(Color.Green, Color.White, "  SMS was Sent:\n Contact: " + i_Contact.ToString() + "\n Text:  " + SMSToSend, New_Line = true, Show_Time = false);

        //            Thread.Sleep(1500);

        //        }
        //    }
        //}

        //bool ACKSMSReceived = false;


        private string ReturnSMSEncryiepted(string i_SMSText)
        {
            if (checkBox_SMSencrypted.Checked == true)
            {
                return "{ENCRYPED," + textBox_UnitIDForSMS.Text + "," + textBox_CodeArrayForSMS.Text + "," + i_SMSText;
            }
            else
            {
                return i_SMSText;
            }
        }

        private void Button_SendSelectedSMS_Click(object sender, EventArgs e)
        {

        }

        private void Button33_Click_2(object sender, EventArgs e)
        {

        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void Button36_Click(object sender, EventArgs e)
        {
            richTextBox_ModemStatus.BackColor = default;
            richTextBox_ModemStatus.Text = "";
        }

        private void RichTextBox_TextSendSMS_TextChanged(object sender, EventArgs e)
        {
            label_SMSSendCharacters.Text = richTextBox_TextSendSMS.Text.Length.ToString() + "/160 = " + (richTextBox_TextSendSMS.Text.Length / 160 + 1);
            //if (richTextBox_TextSendSMS.Text.Length < 160)
            //{
            //    richTextBox_TextSendSMS.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    richTextBox_TextSendSMS.BackColor = Color.Red;
            //}
        }

        private void Button_SMSOpenPort_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_Config31_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.AutoARM);
        }

        private void PictureBox_logo_Click(object sender, EventArgs e)
        {

        }

        private void Button_SetConfigSMS_Click(object sender, EventArgs e)
        {

        }



        private void TextBox_Config32_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPSType);
        }

        private void CheckBox_S1RecordLog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button_AddToSendSMS_Click(object sender, EventArgs e)
        {

        }







        private void Button41_Click(object sender, EventArgs e)
        {

        }

        private void Button37_Click(object sender, EventArgs e)
        {

        }

        private void SortSMSCommands()
        {
            ArrayList q = new ArrayList();
            foreach (object o in listBox_SMSCommands.Items)
            {
                q.Add(o);
            }
            q.Sort();
            listBox_SMSCommands.Items.Clear();
            foreach (object o in q)
            {

                listBox_SMSCommands.Items.Add(o);
            }
        }

        private void SMSCommandForm_Load(object sender, EventArgs e)
        {

        }

        ///
        private void RemoveSelectedCommand()
        {




        }

        private void Button40_Click(object sender, EventArgs e)
        {
            RemoveSelectedCommand();

        }

        private void Button39_Click_1(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                FileName = "MySMSCommands",
                Filter = "XML files (*.xml)|*.xml",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    List<string> templist = new List<string>();
                    foreach (object item in listBox_SMSCommands.Items)
                    {
                        templist.Add((string)item);
                    }
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    TextWriter textWriter = new StreamWriter(myStream);

                    serializer.Serialize(textWriter, templist);
                    textWriter.Close();
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void Button38_Click(object sender, EventArgs e)
        {



        }





        private void CheckedListBox_PhoneBook_SelectedIndexChanged(object sender, EventArgs e)
        {


        }










        private void ComboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void CheckBox_OpenPortSMS_CheckedChanged(object sender, EventArgs e)
        {


        }













        private void CheckBox_SendSMSAsIs_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox_SMSencrypted_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SMSencrypted.Checked == true)
            {
                GrooupBox_Encryption.Enabled = true;
            }
            else
            {
                GrooupBox_Encryption.Enabled = false;
            }
        }



        private void SetSpeedThreeSpeedLimit()
        {

            //Int32.TryParse(textBox_SpeedLimit1.Text, out int Speed1);
            //Int32.TryParse(textBox_SpeedLimit2.Text, out int Speed2);
            //Int32.TryParse(textBox_SpeedLimit3.Text, out int Speed3);


            //int temp;




        }





        private void Button34_Click_2(object sender, EventArgs e)
        {
            SaveCommandsAndContacts();
        }

        private void CheckBox_S1Pause_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox33_Enter(object sender, EventArgs e)
        {

        }

        private void RichTextBox_ContactDetails_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox39_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox_Config40_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.CutSpeed);
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }




        private void ScanComports()
        {
            cmb_PortName.Items.Clear();
            comboBox_ComportSMS.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmb_PortName.Items.Add(port);
                comboBox_ComportSMS.Items.Add(port);
            }
            if (ports.Length > 0)
            {
                cmb_PortName.SelectedIndex = 0;
                comboBox_ComportSMS.SelectedIndex = 0;
            }
        }

        private void Button_ReScanComPort_Click(object sender, EventArgs e)
        {
            ScanComports();
        }

        private void TextBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private readonly Stopwatch stopwatch = new Stopwatch();

        private void TextBox_StopWatch_TextChanged(object sender, EventArgs e)
        {

        }

        private int TimerLogNumber = 0;
        private void Button_StopwatchReset_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            TimerLogNumber = 0;
            textBox_StopWatch.Text = PrintTimeSpan(stopwatch.Elapsed);
            button_Stopwatch_Start_Stop.BackColor = default;
        }

        private void Button_Stopwatch_Start_Stop_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning == false)
            {
                button_Stopwatch_Start_Stop.BackColor = Color.LightGreen;
                stopwatch.Start();
            }
            else
            {
                button_Stopwatch_Start_Stop.BackColor = default;
                stopwatch.Stop();
            }

        }

        private void Button_TimerLog_Click(object sender, EventArgs e)
        {
            TimerLogNumber++;
            SerialPortLogger.LogMessage(Color.DarkBlue, Color.White, "Stopwatch Log: " + TimerLogNumber + ">  " + PrintTimeSpan(stopwatch.Elapsed), true, true);
        }

        private void CheckBox_ParseMessages_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_Config42_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private bool IsTimerRunning = false;
        private int TimerMemory = 0;
        private void Button_StartStopTimer_Click(object sender, EventArgs e)
        {
            IsTimerRunning = !IsTimerRunning;
            if (IsTimerRunning == true && (textBox_SetTimerTime.Text != "0" || textBox_TimerTime.Text != "0"))
            {


                int.TryParse(textBox_SetTimerTime.Text, out int Result);
                if (Result != 0)
                {
                    button_StartStopTimer.BackColor = Color.LightGreen;
                    TimerMemory = Result;
                    button_ResetTimer.Text = "Reset (" + TimerMemory + ")";
                    textBox_TimerTime.Text = textBox_SetTimerTime.Text;
                    textBox_SetTimerTime.Text = "0";
                }
                else
                {

                }
            }
            else
            {
                button_StartStopTimer.BackColor = default;

            }
        }

        private void CmbPortName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button42_Click(object sender, EventArgs e)
        {
            tabControl_Main.TabPages[5].BackColor = Color.Red;
        }

        private void Button43_Click(object sender, EventArgs e)
        {
            Process.Start(@".");
        }

        private void TextBox_SendSerialPort_TextChanged(object sender, EventArgs e)
        {
            //textBox_SendSerialPort.SelectionStart = textBox_SendSerialPort.Text.Length;
            //textBox_SendSerialPort.SelectionLength = 0;
        }

        private void TextBox_SourceConfig_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox_SendTimer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_SendSerialDiff_TextChanged(object sender, EventArgs e)
        {

        }

        // private Random rnd = new Random();

        private void Button_ScreenShot_Click(object sender, EventArgs e)
        {
            TakeCroppedScreenShot();


        }


        private void ListBox_SMSCommands_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //      LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            for (int i = 0; i < listBox_SMSCommands.Items.Count; i++)
            {
                if (listBox_SMSCommands.GetSelected(i) == true)
                {
                    //           LogSMS.LogMessage(Color.Black, Color.White, "[" + listBox_SMSCommands.Items[i].ToString() + "]", New_Line = true, Show_Time = false);
                }
            }
            //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = true, Show_Time = false);
        }

        private void Button_ResetGraphs_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            ChartCntX = 0;
            foreach (Series ser in chart1.Series)
            {
                ser.Points.Clear();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public System.Data.DataTable ExportToExcel(Series ser)
        //{
        //    System.Data.DataTable table = new System.Data.DataTable();
        //    table.Columns.Add("Chart name", typeof(string));
        //    table.Columns.Add("X", typeof(double));
        //    table.Columns.Add("Y", typeof(double));

        //    //foreach (var ser in chart1.Series)
        //    //{
        //    DataPoint[] TotalPoints = new DataPoint[ser.Points.Count];
        //    ser.Points.CopyTo(TotalPoints,0);
        //        foreach(var Point in TotalPoints)
        //        {
        //            table.Rows.Add(ser.Name , Point.XValue,Point.YValues[0]);
        //        }
        //    //}

        //    //table.Columns.Add("Chart", typeof(int));
        //    //table.Columns.Add("X", typeof(string));
        //    //table.Columns.Add("Y", typeof(string));

        //    //table.Columns.Add("Subject1", typeof(int));
        //    //table.Columns.Add("Subject2", typeof(int));
        //    //table.Columns.Add("Subject3", typeof(int));
        //    //table.Columns.Add("Subject4", typeof(int));
        //    //table.Columns.Add("Subject5", typeof(int));
        //    //table.Columns.Add("Subject6", typeof(int));
        //    //table.Rows.Add(1, "Amar", "M", 78, 59, 72, 95, 83, 77);
        //    //table.Rows.Add(2, "Mohit", "M", 76, 65, 85, 87, 72, 90);
        //    //table.Rows.Add(3, "Garima", "F", 77, 73, 83, 64, 86, 63);
        //    //table.Rows.Add(4, "jyoti", "F", 55, 77, 85, 69, 70, 86);
        //    //table.Rows.Add(5, "Avinash", "M", 87, 73, 69, 75, 67, 81);
        //    //table.Rows.Add(6, "Devesh", "M", 92, 87, 78, 73, 75, 72);
        //    return table;
        //}


        private void Button_Export_excel_Click(object sender, EventArgs e)
        {
            // writetext.WriteLine("writing in text file");


            Invoke((MethodInvoker)delegate ()
            {
                textBox_graph_XY.Text = "";
            });

            Series[] Serias_Graphs = new Series[chart1.Series.Count];
            chart1.Series.CopyTo(Serias_Graphs, 0);
            foreach (Series ser in Serias_Graphs)
            {
                string fileName = ser.Name;
                string Location = AppDomain.CurrentDomain.BaseDirectory + fileName + DateTime.Now.ToString("MM_DD_HH_mm_ss") + ".csv";
                using (StreamWriter writetext = new StreamWriter(@Location))
                {

                    foreach (DataPoint point_ in ser.Points)
                    {
                        writetext.WriteLine(point_.XValue + "," + point_.YValues[0]);
                    }

                    Invoke((MethodInvoker)delegate ()
                    {
                        textBox_graph_XY.Text += "Excel Generated at " + Location;
                    });
                }
            }


        }

        private void Button3_Click_3(object sender, EventArgs e)
        {
            // Color randomColor ;
            //Tab0Color = randomColor;
        }

        private bool IsPauseGraphs = false;
        private void Button_GraphPause_Click(object sender, EventArgs e)
        {

            if (IsPauseGraphs == false)
            {
                IsPauseGraphs = true;
                button_GraphPause.BackColor = Color.Yellow;
            }
            else
            {

                IsPauseGraphs = false;
                button_GraphPause.BackColor = default;
            }
        }

        private void Button1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "helpfile.chm", HelpNavigator.TopicId, "1234");
        }

        private void Button_OpenFolder2_Click(object sender, EventArgs e)
        {
            Process.Start(@".");
        }

        private void CloseClentConnection()
        {
            if (ClientSocket != null)
            {
                //ClientSocket.GetStream().Close();
                ClientSocket.Close();
            }

            if (ReceiveThread != null)
            {
                ReceiveThread.Abort();
                //   m_Exit = true;

            }

            button_Ping.BackColor = default;
            button_ClientConnect.BackColor = default;

            richTextBox_ClientRx.AppendText("Connection closed \n");
        }
        private void Button42_Click_1(object sender, EventArgs e)
        {
            CloseClentConnection();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2} ", b);
            }

            return hex.ToString();
        }

        private byte[] TCPClientBuffer = new byte[0];

        private void ReceiveData()
        {
            TcpClient PClientSocket = ClientSocket;
            try
            {
                while (true)
                {
                    if (m_Exit == true)
                    {
                        return;
                    }

                    if (PClientSocket != null)
                    {
                        try
                        {
                            byte[] buffer = new byte[1000000];
                            Stream stm = PClientSocket.GetStream();



                            int NumOfReceivedBytes = stm.Read(buffer, 0, buffer.Length);
                            if (WaitforBufferFull == 0)
                            {
                                TCPClientBuffer = new byte[NumOfReceivedBytes];
                                Array.Copy(buffer, 0, TCPClientBuffer, 0, NumOfReceivedBytes);


                            }
                            else
                            {
                                byte[] temp = new byte[NumOfReceivedBytes + TCPClientBuffer.Length];
                                TCPClientBuffer.CopyTo(temp, 0);
                                Array.Copy(buffer, 0, temp, TCPClientBuffer.Length, NumOfReceivedBytes);
                                //buffer.CopyTo(temp, NumOfReceivedBytes);
                                TCPClientBuffer = temp;


                            }






                        }
                        catch (Exception ex)
                        {


                            SystemLogger.LogMessage(Color.Black, Color.Red, "Gil: " + ex.ToString(), New_Line = true, Show_Time = true);


                            return;



                        }
                    }
                    else
                    {
                        PClientSocket.Close();
                    }

                }
            }
            catch (System.Net.Sockets.SocketException se)
            {
                se.ToString(); //Gil: just remove warning.
                //MessageBox.Show(se.Message);
            }
        }

        private bool m_Exit = false;
        private TcpClient ClientSocket;
        private Thread ReceiveThread;
        private void Button_ClientConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //create a new client socket ...
                m_Exit = false;
                //m_socWorker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                string szIPSelected = textBox_ClientIP.Text;
                string szPort = textBox_ClientPort.Text;
                int alPort = System.Convert.ToInt16(szPort, 10);

                ClientSocket = new TcpClient();
                IAsyncResult result = ClientSocket.BeginConnect(textBox_ClientIP.Text, alPort, null, null);

                bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                if (!success)
                {
                    richTextBox_ClientRxPrintText(string.Format("Failed to connect to [{0}] [{1}]\n", szIPSelected, szPort));
                    return;
                }
                else
                {
                    Monitor.Properties.Settings.Default.IP_Client = textBox_ClientIP.Text;
                    Monitor.Properties.Settings.Default.Port_Client= textBox_ClientPort.Text;
                    Monitor.Properties.Settings.Default.Save();

                }    
                // we have connected
                ClientSocket.EndConnect(result);


                //System.Net.IPAddress	remoteIPAddress	 = System.Net.IPAddress.Parse(szIPSelected);
                //System.Net.IPEndPoint	remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);
                //m_socWorker.Connect(remoteEndPoint);

                if (ClientSocket.Connected)
                {
                    ReceiveThread = new Thread(new ThreadStart(ReceiveData));
                    ReceiveThread.Start();
                }
            }
            catch (System.Net.Sockets.SocketException se)
            {
                richTextBox_ClientRx.AppendText(se.Message + "\n");
            }
        }

        private int ClentSendData = 0;
        private void Button3_Click_4(object sender, EventArgs e)
        {
            try
            {
                string str = richTextBox_ClientTx.Text;
                Stream stm = ClientSocket.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);

                //byte[] sspData = SSP_Protocol.SSP_Protocol.SSPPacket_Encoder(SSP_Protocol.eMessegeType.TRACE, ba);

                // Console.WriteLine("Sending...");

                stm.Write(ba, 0, ba.Length);

                //WaitforBufferFull = 1;

                ClentSendData++;
                richTextBox_ClientTx.Text = "Send Data to Server " + ClentSendData;

                // byte[] bb = new byte[100];

            }
            catch
            {
                //MessageBox.Show (se.Message );
            }
        }

        private void Button43_Click_1(object sender, EventArgs e)
        {
            richTextBox_ClientTx.Text = "";
        }

        private void Button28_Click_2(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = ChartCntX;
        }

        private void TextBox_graph_XY_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_SendSerialPort_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void SerialTerminalPrintHelp()
        {
            SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "F1 function - Help", New_Line = true, Show_Time = true);
        }

        private void TextBox_SendSerialPort_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        SerialTerminalPrintHelp();

                        break;

                    case Keys.F2:
                        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "F2 function reads all commands to history", New_Line = true, Show_Time = true);
                        break;

                    //case Keys.ControlKey:
                    //    SelfMonitorCommandsMode = !SelfMonitorCommandsMode;
                    //    if (SelfMonitorCommandsMode == true)
                    //    {
                    //        textBox_SendSerialPort.BackColor = SystemColors.Info;
                    //        groupBox_SendSerialOrMonitorCommands.BackColor = SystemColors.Info;
                    //        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "Change to Monitor commands mode", New_Line = true, Show_Time = true);
                    //    }
                    //    else
                    //    {
                    //        groupBox_SendSerialOrMonitorCommands.BackColor = default(Color);
                    //        textBox_SendSerialPort.BackColor = SystemColors.ActiveCaption;
                    //        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "Change to Send to serial port mode", New_Line = true, Show_Time = true);


                    //    }
                    //    break;


                    case Keys.Enter:
                        //if (SelfMonitorCommandsMode == true)
                        //{

                        //}
                        //else
                        //{
                        button_SendSerialPort.PerformClick();
                        //}

                        break;

                    case Keys.Up:
                        //SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, " History Index: " + HistoryIndex.ToString(), New_Line = true, Show_Time = false);
                        if(CommandsHistoy.Count == 0)
                        {
                            return;
                        }
                        
                        if (HistoryIndex > CommandsHistoy.Count - 1 || HistoryIndex < 0)
                        {
                            HistoryIndex = CommandsHistoy.Count;
                        }

                        //if(textBox_SendSerialPort.Text == string.Empty)
                        //{
                        //    HistoryIndex = CommandsHistoy.Count;
                        //}


                        if (HistoryIndex > 0)
                        {
                            HistoryIndex--;
                        }
                        textBox_SendSerialPort.Text = CommandsHistoy[HistoryIndex];
                        break;

                    case Keys.Down:

                        if (CommandsHistoy.Count == 0)
                        {
                            return;
                        }

                        textBox_SendSerialPort.Text = CommandsHistoy[HistoryIndex];
                        if (HistoryIndex < CommandsHistoy.Count - 1)
                        {
                            HistoryIndex++;
                        }
                        break;

                    case Keys.Tab:
                        List<string> Strlist = new List<string>();
                        foreach (string str in CommandsHistoy)
                        {
                            if (str.StartsWith(textBox_SendSerialPort.Text))
                            {
                                Strlist.Add(str);
                            }
                        }

                        if (Strlist.Count > 1)
                        {
                            SerialPortLogger.LogMessage(Color.Black, Color.Yellow, "Total sub commands: " + Strlist.Count.ToString() + " ", New_Line = true, Show_Time = true);
                            foreach (string str in Strlist)
                            {
                                SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, str, New_Line = true, Show_Time = false);
                                if (HistoryIndex == Strlist.IndexOf(str))
                                {
                                    SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "<------", New_Line = false, Show_Time = false);
                                }
                            }
                        }
                        else
                            if (Strlist.Count == 1)
                        {
                            textBox_SendSerialPort.Text = Strlist[0];
                        }
                        break;

                    default:
                        HistoryIndex = CommandsHistoy.Count - 1;
                        break;
                }

                //  CommandsHistoy.SelectedIndex = HistoryIndex;
            }
            catch (Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Blue, Color.White, ex.ToString(), New_Line = true, Show_Time = false);
            }
        }


        private void Button_OpenPort_Click(object sender, EventArgs e)
        {
            try
            {
            if (serialPort.IsOpen == false)
            {
                
                    button_OpenPort.BackColor = Color.Yellow;
                    label_SerialPortConnected.BackColor = Color.Yellow;

                //    ComPortClosing = false;

                  //  CloseSerialPortTimer = false;



                    // Set the port's settings

                    serialPort.BaudRate = int.Parse(cmbBaudRate.Text);

                    if (cmbBaudRate.Items.Contains(cmbBaudRate.Text) == false)
                    {
                        cmbBaudRate.Items.Add(cmbBaudRate.Text);
                    }

                    serialPort.DataBits = int.Parse(cmbDataBits.Text);
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmb_StopBits.Text);
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
                    serialPort.PortName = cmb_PortName.Text;
                    serialPort.WriteTimeout = 500;

                    serialPort.Open();

                    SerialPortLogger.LogMessage(Color.Green, Color.LightGray,
                     " Serial port Opened with  " + " ,PortName = " + serialPort.PortName
                     + " ,BaudRate = " + serialPort.BaudRate +
                     " ,DataBits = " + serialPort.DataBits +
                     " ,StopBits = " + serialPort.StopBits +
                     " ,Parity = " + serialPort.Parity,
                     New_Line = true, Show_Time = true);

                    //  button_OpenPort.Text = "Close";
                    button_OpenPort.BackColor = Color.LightGreen;
                    label_SerialPortConnected.BackColor = Color.LightGreen;
                    label_SerialPortStatus.Text = cmb_PortName.Text + "   \n" + cmbBaudRate.Text;


                    gbPortSettings.Enabled = false;

                    Monitor.Properties.Settings.Default.Comport_BaudRate = cmbBaudRate.Text;
                    Monitor.Properties.Settings.Default.Comport_DataBits = cmbDataBits.Text;
                    Monitor.Properties.Settings.Default.Comport_StopBit = cmb_StopBits.Text;
                    Monitor.Properties.Settings.Default.Comport_Parity = cmbParity.Text;
                    Monitor.Properties.Settings.Default.Comport_Port = cmb_PortName.Text;

                    Monitor.Properties.Settings.Default.Save();


               




            }
            else
            {

                //  ComPortClosing = true;
                
                button_OpenPort.BackColor = default;
                label_SerialPortConnected.BackColor = default;
                label_SerialPortStatus.Text = "";
                gbPortSettings.Enabled = true;
                serialPort.Close();
                //checkBox_ComportOpen.Enabled = false;
                //button_OpenPort.Text = "Open";

                //CloseSerialPortTimer = true;
                //CloseSerialPortConter = 0;




                //groupBox_ServerSettings.Enabled = true;
            }

            }
            catch (Exception ex)
            {
                //checkBox_ComportOpen.Checked = false;

                //SerialException = true;

                SerialPortLogger.LogMessage(Color.Red, Color.LightGray, ex.Message.ToString(), New_Line = true, Show_Time = true);
                return;
            }
        }

        private void TabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        SerialTerminalPrintHelp();

                        break;

                    case Keys.F2:
                        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "F2 function reads all commands to history", New_Line = true, Show_Time = true);
                        break;

                    case Keys.Enter:
                        if (tabControl_Main.SelectedIndex == 3 && button_ClientConnect.BackColor == Color.LightGreen)
                        {
                            button_Send_Click(this, new EventArgs());
                        }
                        break;
                }


            }
            catch (Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Black, Color.Red, ex.Message, New_Line = true, Show_Time = true);
            }

        }

        private int ChartUpdateTime = 100;
        private void ComboBox_ChartUpdateTime_SelectedIndexChanged(object sender, EventArgs e)
        {

            int.TryParse(comboBox_ChartUpdateTime.Text, out int UpdateTime);
            ChartUpdateTime = UpdateTime;


        }

        private void CheckBox_SendHexdata_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SerialPortLogger_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_3(object sender, EventArgs e)
        {
            //Color TextColor = Color.FromName(textBox1.Text);
            //if(TextColor.ToArgb() == 0)
            //{
            //    textBox1.BackColor = default;
            //}
            //else
            //{
            //    textBox1.BackColor = TextColor;
            //}




        }

        private void TextBox_SendSerialPort_TextChanged_1(object sender, EventArgs e)
        {

        }



        private void Button_ClearRx_Click(object sender, EventArgs e)
        {
            richTextBox_ClientRx.Text = "";
        }

        private void GroupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void ClearRxTextBox()
        {

        }

        private void ClearallTextBoxsTCPClient()
        {


        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientSocket == null)
                {
                    return;
                }
                ClearRxTextBox();
                textBox_Preamble_TextChanged(null, null);
                textBox_Opcode_TextChanged(null, null);
                textBox_data_TextChanged(null, null);


                List<byte> ListBytes = new List<byte>();
                // Kratos_Protocol KratusP = new Kratos_Protocol();

                Stream stm = ClientSocket.GetStream();

                if (stm != null)
                {


                    //KratosProtocolFrame SentFrame = Kratos_Protocol.DecodeKratusProtocol_Standard(ref Result);
                    //textBox_AllDataSent.Text = String.Format("Preamble: [{0}] Opcode: [{1}] Data : [{2}] Data length: [{3}] CheckSum: [{4}]",Ret.Preamble,Ret.Opcode,Ret.Data,Ret.DataLength,Ret.CheckSum);


                //    byte[] WriteData = Kratos_Protocol.EncodeKratusProtocol_Standard(SentFrame);
//                      stm.Write(WriteData, 0, WriteData.Length);
                }



            }
            catch
            {
                //MessageBox.Show (se.Message );
            }
        }

        private void textBox_Preamble_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbx = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbx.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 1)
            {
                txtbx.BackColor = Color.LightGreen;
            }
            else
            {
                txtbx.BackColor = Color.Red;
            }
        }

        private void textBox_Opcode_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbx = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbx.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 1)
            {
                txtbx.BackColor = Color.LightGreen;
            }
            else
            {
                txtbx.BackColor = Color.Red;
            }
        }

        private void textBox_data_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbx = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbx.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 20)
            {
                txtbx.BackColor = Color.LightGreen;
            }
            else
            {
                txtbx.BackColor = Color.Red;
            }
        }

        private void txtS1_Clear_Click(object sender, EventArgs e)
        {

        }

        private void textBox_RxClientData_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox_SerialPort_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage_GenericFrame_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage_GenericFrame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void groupBox_clientTX_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void textBox_Preamble_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void textBox_Opcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void textBox_data_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send_Click(this, new EventArgs());
            }
        }

        private void SendThrouthSerialPort()
        {
            //button_Send_Click(null, null);

            if (serialPort.IsOpen == false)
            {
                SystemLogger.LogMessage(Color.Red, Color.White, "Serial Port is not open", true, true);

                


                //textBox_SystemStatus.Text = "Serial Port is not open";
                //textBox_SystemStatus.BackColor = Color.Orange;
                //textBox_SystemStatus_Timer = 3;
                return;
            }
            else
            {
                //button_SendProtocolSerialPort_Click(null, null);
                //button_SendProtocolSerialPort.PerformClick();


            }
        }

        private void SendThrouthTCPIP()
        {

        }

        private void SendDataToSystem()
        {
            if (radioButton_SerialPort.Checked == true)
            {
                SendThrouthSerialPort();
            }

            if (radioButton_TCPIP.Checked == true)
            {
                SendThrouthTCPIP();

            }


        }

        private void button_GetSoftwareVersion_Click(object sender, EventArgs e)
        {

        }

        private void button45_Click(object sender, EventArgs e)
        {

        }

        private void button46_Click(object sender, EventArgs e)
        {

        }





        private void button48_Click(object sender, EventArgs e)
        {

        }

        private void button49_Click(object sender, EventArgs e)
        {


            SendDataToSystem();
        }

        private void button50_Click(object sender, EventArgs e)
        {


            SendDataToSystem();
        }




        





















        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox_RxClientPreamble_TextChanged(object sender, EventArgs e)
        {

        }

        private void button59_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void button59_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
Description:   Set register value to synthesizer L1
Command: 	0x1E
TX data: 	4 bytes – 32bit register value
TX frame: 	0x004D 0x0016 + Tx Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x0016 0x00000000 0x63


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button61_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"Help:
Set Tx AD936X data :
4 bytes 
byte – band type: 0x00 - L1, 0x01 - L2 
2 bytes – address 
1 bytes - data");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }



        private void textBox_SetSyestemState_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

















        private void richTextBox_ClientRxPrintText(string i_string)
        {
            richTextBox_ClientRx.BeginInvoke(new EventHandler(delegate
            {
                richTextBox_ClientRx.AppendText(i_string);
                richTextBox_ClientRx.ScrollToCaret();
            }));
        }

        // int PingWaitTime = 0;
        private void button72_Click(object sender, EventArgs e)
        {

            try
            {
                string szIPSelected = textBox_ClientIP.Text;

                new Thread(() =>
                {
                    button_Ping.BackColor = Color.Yellow;

                    Thread.CurrentThread.IsBackground = true;
                    /* run your code here */
                    Ping myPing = new Ping();
                    PingReply reply = myPing.Send(szIPSelected);
                    if (reply != null)
                    {
                        //  PingWaitTime = 0;
                        // richTextBox_ClientRx.AppendText(String.Format("Failed to connect to [{0}] [{1}]\n", szIPSelected, szPort));
                        richTextBox_ClientRxPrintText("\n Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);

                        button_Ping.Text = "Ping";
                        if (reply.Status == IPStatus.Success)
                        {
                            button_Ping.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            button_Ping.BackColor = Color.Orange;
                        }
                    }
                }).Start();



                //System.Threading.Thread.Sleep(500);


                //Console.WriteLine(reply.ToString());

            }

            catch
            {
                richTextBox_ClientRx.AppendText("ERROR: You have Some TIMEOUT issue");
            }
        }


        private void button72_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"4.2.2.12	Store data in Flash 
Description:   Store data in flash device 
Command: 	0x0030
TX data: 	8 bytes + N byte:
		4 bytes – address
		4 bytes – size of data to be stored
		N bytes – data to be stored
TX frame: 	0x0044 0x0030 + size + TX Data + CRC
RX data: 	N.A
RX frame: 	0x0044 0x0030 0x00000000 + CRC

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }



        private void button73_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"4.2.2.13	Load data from Flash by address 
Description:   Load data from flash by address
Command: 	0x0031
TX data: 	8 bytes:
4 byte – address
4 bytes – bytes to read. 
TX frame: 	0x0044 0x0031 0x00000008 + TX Data + CRC
RX data: 	N bytes – read data content 
RX frame: 	0x0044 0x0031 + size + RX Data + CRC

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }



        private void button78_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"Help:
4.2.3.7	AD9361 Rx RF PLL lock detect 

Description:   Get RF PLL lock detect
Command: 	0x5C
TX data: 	2 byte
1 byte – Xcvr ID: 0x0 ÷ 0x3
1 byte – RF Synth.: 0x1 = Tx; 0x0 = Rx	
TX frame: 	0x004D 0x005C 0x00000002 + TX Data + checksum
RX data: 	1 byte 
Lock detect: 0x1=Locked; 0x0 = Not locked
RX frame: 	0x004D 0x005C 0x00000001 + RX Data + checksum

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }









        private void textBox_WriteQSPIFlashData_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }











        private void button90_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "5B 00";
            //textBox_data.Text = textBox_GetInternalLOFreq.Text;

            //SendDataToSystem();
        }

        private void button_RecordIQData_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
                4.2.5.1 Record IQ data - day 1

Description: Initiate recording of I/ Q data and send the data on completion
Command: 	0x80
TX data: 	5 bytes
1 byte -Number of data blocks
4 byte -Number of samples
TX frame: 	0x004D 0x0080 0x00000005 + Tx Data + checksum
RX data: 	N bytes
Recorded samples
RX frame: 	0x004D 0x0080 + Length + RX Data + checksum

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }

        }

        private void button77_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
Description:   Set the Gain to the RX channels
Command: 	0x56
TX data: 	2 bytes 
1 byte – band: 	0 – Broadcast; 1 – Band L1; 2 – Band L2
1 byte - Gain Value 1 ÷ 76 (dB)
TX frame: 	0x004D 0x0056 + Tx Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x0056 0x00000000 0xA3


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button76_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
                4.2.5.1 Record IQ data - day 1

Description: Initiate recording of I/ Q data and send the data on completion
Command: 	0x80
TX data: 	5 bytes
1 byte -Number of data blocks
4 byte -Number of samples
TX frame: 	0x004D 0x0080 0x00000005 + Tx Data + checksum
RX data: 	N bytes
Recorded samples
RX frame: 	0x004D 0x0080 + Length + RX Data + checksum

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button75_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
Description:   Set DCA in the system
Command: 	0x58
TX data: 	4 bytes 
DCA value [Float]
TX frame: 	0x004D 0x0058 + Tx Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x0058 0x00000000 0xA5


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button91_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
Description:   Set internal LO frequency in Hz
Command: 	0x5A
TX data: 	9 byte
		1 byte – Band type: 0x0 – L1; 0x1 – L2
		8 byte - Frequency [Hz]		
TX frame: 	0x004D 0x005A 0x00000009 + TX Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x005A 0x00000000 0xA7


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button69_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
4.2.2.11	Set TCXO Trim 
Description:   Change the frequency of the clock generation TCXO
Command: 	0x2F
TX data: 	4 byte – fraction of pulse per minute [-10:10]
TX frame: 	0x004D 0x002F 0x00000004+ TX Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x002F 0x00000000 0x7A


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button84_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
Description:   Initiate recording of I/Q data and send the data on completion
Command: 	0x81
TX data: 	3 bytes 
1 byte – Record source :
 0x00 - Xcvr RX
 0x01 – Playback
 0x02 -  Counter
 0x03 -  Zero
		1 byte - Channel 1 data source:
0x00 – Catalina 1, channel 1
0x01 – Catalina 1, channel 2
0x02 -  Catalina 2, channel 1
0x03 -  Catalina 2 channel 2
0x04 – Catalina 3, channel 1
0x05 – Catalina 3, channel 2
0x06 -  Catalina 4, channel 1
0x07 -  Catalina 4 channel 2

1 byte - Channel 2 data source – same as Channel 1			  
		
TX frame: 	0x004D 0x0081 0x00000001 + Tx Data + checksum
RX data: 	N.A 
RX frame: 	0x004D 0x0081 0x00000000 0xCE

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void button85_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
Description:   Set the state to RX Channel
Command: 	0x87
TX data: 	2 bytes 
1 byte - Channel number: 0 ÷7
1 byte – State: 0x0 – Rx; 0x1 - CAL
TX frame: 	0x004D 0x0087 0x00000002 + Tx Data + checksum
RX data: 	N.A 
RX frame: 	0x004D 0x0087 0x00000000 0xD4


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void textBox_PlayIQData_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_PlayIQData.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null )
            //{
            //    textBox_PlayIQData.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_PlayIQData.BackColor = Color.Red;
            //}
        }

        private void button93_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "82 00";
            //textBox_data.Text = textBox_PlayIQData.Text;

            //SendDataToSystem();
        }

        private void textBox_RetriveIQData_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_RetriveIQData.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null)
            //{
            //    if (buffer.Length == 5)
            //    { 
            //        textBox_RetriveIQData.BackColor = Color.LightGreen;
            //    }
            //    else
            //    {
            //        textBox_RetriveIQData.BackColor = Color.Red;
            //    }
            //}
        }

        private void button92_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "84 00";
            //textBox_data.Text = textBox_RetriveIQData.Text;

            //SendDataToSystem();
        }

        private void button94_Click(object sender, EventArgs e)
        {
            //// Generate a test signal,
            ////  1 Vrms at 20,000 Hz
            ////  Sampling Rate = 100,000 Hz
            ////  DFT Length is 1000 Points
            //double amplitude = 1.0;
            //double frequency = 20000;
            //uint length = 1000;
            //double samplingRate = 100000;
            //double[] inputSignal = DSP.Generate.ToneSampling(amplitude, frequency, samplingRate, length);
            //// Instantiate a new DFT
            //DFT dft = new DFT();
            //// Initialize the DFT
            //// You only need to do this once or if you change any of the DFT parameters.
            //dft.Initialize(length);
            //// Call the DFT and get the scaled spectrum back
            //Complex[] cSpectrum = dft.Execute(inputSignal);
            //// Convert the complex spectrum to magnitude
            //double[] lmSpectrum = DSP.ConvertComplex.ToMagnitude(cSpectrum);
            //// Note: At this point, lmSpectrum is a 501 byte array that 
            //// contains a properly scaled Spectrum from 0 - 50,000 Hz (1/2 the Sampling Frequency)
            //// For plotting on an XY Scatter plot, generate the X Axis frequency Span
            //double[] freqSpan = dft.FrequencySpan(samplingRate);
            //// At this point a XY Scatter plot can be generated from,
            //// X axis => freqSpan
            //// Y axis => lmSpectrum
            //// In this example, the maximum value of 1 Vrms is located at bin 200 (20,000 Hz)
            //Series series = new Series("Freq");
            //Series series2 = new Series("Time");
            //listBox_Charts.Items.Add(series.Name);
            //listBox_Charts.Items.Add(series2.Name);
            //// Frist parameter is X-Axis and Second is Collection of Y- Axis
            //series.Points.DataBindXY(freqSpan, lmSpectrum);

            //for (int i = 0; i < inputSignal.Length / 10; i++)
            //{
            //    series2.Points.AddXY(i, inputSignal[i]);
            //}
            //series2.ChartType = SeriesChartType.Line;
            //chart1.Series.Add(series);
            //chart1.Series.Add(series2);

        }

        private void button95_Click(object sender, EventArgs e)
        {
            //// Same Input Signal as Example 1 - Except a fractional cycle for frequency.
            //double amplitude = 1.0; double frequency = 20000.5;
            //uint length = 1000; uint zeroPadding = 9000; // NOTE: Zero Padding
            //double samplingRate = 100000;
            ////double[] inputSignal = DSPLib.DSP.Generate.ToneSampling(amplitude, frequency, samplingRate, length);
            ////// Apply window to the Input Data & calculate Scale Factor
            ////double[] wCoefs = DSP.Window.Coefficients(DSP.Window.Type.FTNI, length);
            ////double[] wInputData = DSP.Math.Multiply(inputSignal, wCoefs);
            ////double wScaleFactor = DSP.Window.ScaleFactor.Signal(wCoefs);
            ////// Instantiate & Initialize a new DFT
            ////DSPLib.DFT dft = new DSPLib.DFT();
            ////dft.Initialize(length, zeroPadding); // NOTE: Zero Padding
            ////                                     // Call the DFT and get the scaled spectrum back
            ////Complex[] cSpectrum = dft.Execute(wInputData);
            ////// Convert the complex spectrum to note: Magnitude Format
            ////double[] lmSpectrum = DSPLib.DSP.ConvertComplex.ToMagnitude(cSpectrum);
            //// Properly scale the spectrum for the added window
            ////lmSpectrum = DSP.Math.Multiply(lmSpectrum, wScaleFactor);
            //// For plotting on an XY Scatter plot generate the X Axis frequency Span
            ////double[] freqSpan = dft.FrequencySpan(samplingRate);
            //// At this point a XY Scatter plot can be generated from,
            //// X axis => freqSpan
            //// Y axis => lmSpectrum

            //Series series = new Series("Freq 2");
            //Series series2 = new Series("Time 2");
            //listBox_Charts.Items.Add(series.Name);
            //listBox_Charts.Items.Add(series2.Name);
            //// Frist parameter is X-Axis and Second is Collection of Y- Axis
            //series.Points.DataBindXY(freqSpan, lmSpectrum);

            //for (int i = 0; i < inputSignal.Length / 10; i++)
            //{
            //    series2.Points.AddXY(i, inputSignal[i]);
            //}
            //series2.ChartType = SeriesChartType.Line;
            //chart1.Series.Add(series);
            //chart1.Series.Add(series2);
        }

        private void textBox_MinXAxis_TextChanged(object sender, EventArgs e)
        {
            if (long.TryParse(textBox_MinXAxis.Text, out long x))
            {
                if (x < chart1.ChartAreas[0].AxisX.Maximum)
                {
                    // you know that the parsing attempt
                    // was successful
                    textBox_MinXAxis.BackColor = Color.LightGreen;
                    chart1.ChartAreas[0].AxisX.Minimum = x;
                }
                else
                {
                    textBox_MinXAxis.BackColor = Color.Orange;
                }
            }
            else
            {
                textBox_MinXAxis.BackColor = Color.Orange;
            }

        }

        private void textBox_MaxXAxis_TextChanged(object sender, EventArgs e)
        {
            if (long.TryParse(textBox_MaxXAxis.Text, out long x))
            {
                if (x > chart1.ChartAreas[0].AxisX.Minimum)
                {
                    // you know that the parsing attempt
                    // was successful
                    textBox_MaxXAxis.BackColor = Color.LightGreen;
                    chart1.ChartAreas[0].AxisX.Maximum = x;
                }
                else
                {
                    textBox_MaxXAxis.BackColor = Color.Orange;
                }
            }
            else
            {
                textBox_MaxXAxis.BackColor = Color.Orange;
            }

        }

        private int PlotGraphTimer = 0;
        //private void button96_Click(object sender, EventArgs e)
        //{
        //    PlotGraphTimer = 60;
        //    new Thread(() =>
        //    {
        //        CheckForMiniAdaDataFFT(MiniAdaParser);

        //    }).Start();

        //}

        private void button97_Click(object sender, EventArgs e)
        {
            textBox_SystemStatus.Text = string.Empty;
            textBox_SystemStatus.BackColor = default;
            progressBar_UserStatus.Value = 0;
            progressBar_UserStatus.BackColor = default;
            progressBar_UserStatus.ForeColor = default;
        }

        private void comboBox_WindowsDSPLib_SelectedIndexChanged(object sender, EventArgs e)
        {
            //       string selectedWindowName = comboBox_WindowsDSPLib.SelectedValue.ToString();
            //  windowToApply = (DSPLib.DSP.Window.Type)Enum.Parse(typeof(DSPLib.DSP.Window.Type), selectedWindowName);
        }

        //private void button98_Click(object sender, EventArgs e)
        //{
        //    PlotGraphTimer = 120;
        //    new Thread(() =>
        //    {


        //        CheckForMiniAdaDataDFT(MiniAdaParser);

        //    }).Start();
        //}

        private void button99_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisX.RoundAxisValues();
            // textBox_MinXAxis.Text = "3000"
            //chart1.ChartAreas[0].AxisX.Minimum = -30000;
            //  chart1.ChartAreas[0].AxisX.Maximum = 30000;
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void listBox_Charts_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listBox_Charts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listBox_Charts.SelectedItem != null)
            {
                chart1.Series.Remove(chart1.Series[listBox_Charts.SelectedItem.ToString()]);
                listBox_Charts.Items.Remove(listBox_Charts.SelectedItem);
                if (listBox_Charts.Items.Count > 0)
                {
                    listBox_Charts.SelectedIndex = 0;
                }

            }
        }

        private void textBox_RecordIQDataNumbers_TextChanged(object sender, EventArgs e)
        {
            // try
            // {
            //     string[] words = textBox_RecordIQDataNumbers.Text.Split(',');
            //     if (words.Length == 2)
            //     {
            //         byte.TryParse(words[0], out byte NumOfBlocks);
            //         int.TryParse(words[1], out int BlockSize);

            //         byte[] BSize = BitConverter.GetBytes(BlockSize);

            //         byte[] SendArray = new byte[5];
            //         SendArray[0] = NumOfBlocks;
            //         SendArray[1] = BSize[0];
            //         SendArray[2] = BSize[1];
            //         SendArray[3] = BSize[2];
            //         SendArray[4] = BSize[3];

            //         //textBox_RecordIQData.Text = ByteArrayToString(SendArray);
            //      //   textBox_RecordIQDataNumbers.BackColor = Color.LightGreen;
            //         //Array.Reverse(intBytes);
            //         //byte[] result = intBytes;
            //     }

            // }
            // catch(Exception ex)
            // {
            //     SystemLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), true, true);
            ////     textBox_RecordIQDataNumbers.BackColor = Color.Red;
            // }
        }

        private void button71_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
4.2.4.1	Read FPGA register 

Description:   Read register value from FPGA
Command: 	0x70
TX data: 	4 bytes 
address
TX frame: 	0x004D 0x0070 0x00000004 + Tx Data + checksum
RX data: 	4 bytes 
value
RX frame: 	0x004D 0x0056 0x00000004 + RX Data + checksum



");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button70_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
4.2.4.2	Write FPGA register 

Description:   Write register value to FPGA
Command: 	0x71
TX data: 	8 bytes 
4 byte - address
4 byte - value
TX frame: 	0x004D 0x0071 0x00000008 + Tx Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x0071 0x00000000 0Xbe


");

                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }


        }

        private void button60_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
4.2.2.2	Set Synthesizer L2 register - day 1

Description:   Set register value to synthesizer L2
Command: 	0x1F
TX data: 	4 bytes – 32bit register value
TX frame: 	0x004D 0x0017 + Tx Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x0017 0x00000000 0x64


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button62_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
Description:   Get Tx AD9361 register
Command: 	0x21
TX data: 	3 byte
1 byte – Band type
2 bytes – Address
TX frame: 	0x004D 0x0021 0x00000003 + Tx Data + checksum
RX data: 	1 byte - data
RX frame: 	0x004D 0x0021 0x00000001 + Rx Date + checksum


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button63_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button65_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
4.2.2.7	Get system state - day 1

Description:   Get the system state: Cal/Normal
Command: 	0x29
TX data: 	N.A
TX frame: 	0x004D 0x0029 0x00000000 0x76
RX data: 	1 byte – System state: 0x1 – CAL; 0x2 – Normal
RX frame: 	0x004D 0x0029 0x00000000 + RX Data + checksum


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button67_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button68_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
4.2.2.10	Switch TCXO on/off 

Description:   Switch the TCXO on or off
Command: 	0x2E
TX data: 	1 byte – Switch 0x1 - On; 0x0 - Off
TX frame: 	0x004D 0x002E 0x00000001 + TX Data + checksum
RX data: 	N.A
RX frame: 	0x004D 0x002E 0x00000000 0x79


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button89_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button87_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void button88_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);


            }
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
The textbox contain 4 files for the 4 Catalinas
Raw1 - Catalina 1
Raw2 - Catalina 2
Raw3 - Catalina 3
Raw4 - Catalina 4


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void WriteFileToFlash(string i_FilePathName, string i_AD936X_ADDR)
        {
            string DataToSend = "";
            int DataLength = 0;
            byte CheckSumCalc = 0;
            //Gil: Catalina 1
            string[] lines = File.ReadAllLines(i_FilePathName);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                // Process line
                DataToSend += line;
                line = Regex.Replace(line, @"\s+", "");
                byte[] LineBytes = StringToByteArray(line);

                DataLength += LineBytes.Length;
                foreach (byte by in LineBytes)
                {
                    CheckSumCalc += by;
                }
            }
            //CheckSumCalc = CheckSumCalc % 256;
            //            % Header Structure:
            //% ver_major   1
            //% ver_minor   1
            //% ver_day     1
            //% ver_month   1
            //% ver_year    2
            //% Block_size  4
            //% CHK         1
            //% Dummy(0)   1

            // 1	0	17	3	230	7	16	11	0	0	219	0
            byte[] FlashHeader = CreateMiniAdaFlashHeader(0, 0, DateTime.Now, DataLength, CheckSumCalc);
            //byte[] FlashHeader = new byte[12];
            //FlashHeader[0] = 1;
            //FlashHeader[1] = 0;
            //FlashHeader[2] = (byte)DateTime.Now.Day;
            //FlashHeader[3] = (byte)DateTime.Now.Month;
            //FlashHeader[4] = (byte)(DateTime.Now.Year);
            //FlashHeader[5] = (byte)(DateTime.Now.Year >> 8);
            //FlashHeader[6] = (byte)(DataLength);
            //FlashHeader[7] = (byte)(DataLength >> 8);
            //FlashHeader[8] = (byte)(DataLength >> 16);
            //FlashHeader[9] = (byte)(DataLength >> 24);
            //FlashHeader[10] = (byte)(CheckSumCalc);
            //FlashHeader[11] = (byte)(0);

            DataLength += 12;
            string TotalframeDataToSend = ConvertByteArraytToString(FlashHeader) + DataToSend;
            byte[] temp = StringToByteArray(Regex.Replace(TotalframeDataToSend, @"\s+", ""));
            // Erase the Sector
            //textBox_EraseDataFromFlash.Text = i_AD936X_ADDR;
            //button_EraseFlash.PerformClick();
            //wait(2000);
            ////Store the Data in flash
            //byte[] intBytes = BitConverter.GetBytes(DataLength);
            //String NumOfBytesstr = ConvertByteArraytToString(intBytes);
            //textBox_StoreDatainFlash.Text = i_AD936X_ADDR /* + NumOfBytesstr */+ TotalframeDataToSend;
            //temp = StringToByteArray(Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", "") );
            //button_StoreDatainFlash.PerformClick();
        }
        private void button_WriteFilesToFlash_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[0], "00500000");
            //    wait(2000);
            //    WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[1], "00600000");
            //    wait(2000);
            //    WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[2], "00700000");
            //    wait(2000);
            //    WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[3], "00800000");
            //}
            //catch(Exception ex)
            //{
            //    SystemLogger.LogMessage(Color.Red, Color.White, ex.Message, true, false);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="milliseconds"></param>
        public void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0)
            {
                return;
            }
            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        private void textBox_EraseDataFromFlash_TextChanged(object sender, EventArgs e)
        {

            //string WithoutSpaces = Regex.Replace(textBox_EraseDataFromFlash.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 4)
            //{
            //    textBox_EraseDataFromFlash.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_EraseDataFromFlash.BackColor = Color.Red;
            //}
        }

        private void button100_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "32 00";
            //textBox_data.Text = textBox_EraseDataFromFlash.Text;

            //SendDataToSystem();
        }

        private void textBox_FilesToWriteForTheCatalinas_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
The textbox contain 4 files for the 4 Catalinas
Raw1 - Catalina 1
Raw2 - Catalina 2
Raw3 - Catalina 3
Raw4 - Catalina 4


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void textBox_SetRxChannelGainNumber_TextChanged(object sender, EventArgs e)
        {
            //int gain;
            //bool result = int.TryParse(textBox_SetRxChannelGainNumber.Text, out gain);
            //if (result == true)
            //{
            //    if (gain >= 0 && gain <= 76)
            //    {
            //        string hexValue = gain.ToString("X2");
            //        textBox_SetRXChannelGain.Text = textBox_SetRXChannelGain.Text.Substring(0,2) + " " + hexValue;
            //        textBox_SetRxChannelGainNumber.BackColor = Color.LightGreen;
            //    }
            //    else
            //    {
            //        textBox_SetRxChannelGainNumber.BackColor = Color.Red;
            //    }
            //}
            //else
            //{
            //    textBox_SetRxChannelGainNumber.BackColor = Color.Red;
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_HexString"></param>
        /// <returns></returns>
        private string ReverseHexStringLittleBigEndian(string i_HexString)
        {
            if(i_HexString == null)
            {
                return "";
            }
            byte[] temp = StringToByteArray(i_HexString);
            temp = temp.Reverse().ToArray();
            return ConvertByteArraytToString(temp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_SetInternalLOFreqNumber_TextChanged(object sender, EventArgs e)
        {
            //long freq =0;
            //bool result = long.TryParse(textBox_SetInternalLOFreqNumber.Text, out freq);
            //if (result == true)
            //{
            //    if (freq >= 0 && freq <= 9999999999999)
            //    {
            //        string hexValue = freq.ToString("X16");

            //        textBox_SetInternalLOFreq.Text = textBox_SetInternalLOFreq.Text.Substring(0, 2) + " " + ReverseHexStringLittleBigEndian(hexValue);

            //        textBox_SetInternalLOFreqNumber.BackColor = Color.LightGreen;
            //    }
            //    else
            //    {
            //        textBox_SetInternalLOFreqNumber.BackColor = Color.Red;
            //    }
            //}
            //else
            //{
            //    textBox_SetInternalLOFreqNumber.BackColor = Color.Red;
            //}
        }

        private void button98_Click_1(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "31 00";
            //textBox_data.Text = textBox_LoadDatainFlash.Text;

            //SendDataToSystem();
        }

        private void button100_Click_1(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "30 00";
            //textBox_data.Text = textBox_StoreDatainFlash.Text;

            //SendDataToSystem();
        }

        private void button98_Click_2(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "31 00";
            //textBox_data.Text = textBox_LoadDatainFlash.Text;

            //SendDataToSystem();
        }



        private readonly string CATALINA_1_ADDRESS = "00500000";
        private readonly string CATALINA_2_ADDRESS = "00600000";
        private readonly string CATALINA_3_ADDRESS = "00700000";
        private readonly string CATALINA_4_ADDRESS = "00800000";
        private void button72_Click_2(object sender, EventArgs e)
        {
            try
            {
                WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[0], CATALINA_1_ADDRESS);
                wait(2000);
                progressBar_WriteToFlash.Value = 70;
                WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[1], CATALINA_2_ADDRESS);
                wait(2000);
                progressBar_WriteToFlash.Value = 80;
                WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[2], CATALINA_3_ADDRESS);
                wait(2000);
                progressBar_WriteToFlash.Value = 90;
                WriteFileToFlash(textBox_FilesToWriteForTheCatalinas.Lines[3], CATALINA_4_ADDRESS);
            }
            catch (Exception ex)
            {
                SystemLogger.LogMessage(Color.Red, Color.White, ex.ToString(), true, false);
            }
        }

        private void textBox_FilesToWriteForTheCatalinas2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
The textbox contain 4 files for the 4 Catalinas
Raw1 - Catalina 1
Raw2 - Catalina 2
Raw3 - Catalina 3
Raw4 - Catalina 4


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void richTextBox_SyntisazerL2_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(richTextBox_SyntisazerL2.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                richTextBox_SyntisazerL2.BackColor = Color.LightGreen;
            }
            else
            {
                richTextBox_SyntisazerL2.BackColor = Color.Red;
            }
        }

        private void comboBox1_SelectedIndexChanged_3(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox_SyntisazerL2.Text =
@"00618000
08008011
00004542
004004B3
00883034
00580005
";
            }
            else
            {
                richTextBox_SyntisazerL2.Text =
@"004B0000
08008011
00004542
004004B3
00883024
00580005
";
            }
        }

        private void richTextBox_SyntisazerL1_TextChanged(object sender, EventArgs e)
        {
            string WithoutSpaces = Regex.Replace(richTextBox_SyntisazerL1.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                richTextBox_SyntisazerL1.BackColor = Color.LightGreen;
            }
            else
            {
                richTextBox_SyntisazerL1.BackColor = Color.Red;
            }
        }

        private void textBox_StoreDatainFlash_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox_SyntisazerL1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
%synth_data_L1=[hex2dec('00C08000') ...   % Frequency change  % LO_L1=2*(1575.42)=2*1575.42 MHz. INT-N. Fpfd=16.368 MHz.
synth_data_L1=[hex2dec('00618000') ...   % Frequency change  % LO_L1=2*(1575.42+20.46)=2*1595.88 MHz. INT-N. Fpfd=16.368 MHz.
    hex2dec('08008011') ...              %
    hex2dec('00004542') ...              % charge pump change (4542 for 0.94mA , 4742 for 1.25mA) (for LO = 1595.88 SET 00004542 for LO = 1575.42 SET 00008542)
    hex2dec('004004B3') ...
    hex2dec('00883034') ...             %   Arie : hex2dec('0088303C') . 15dBm Required after Amplifier (34 instead 3C)

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private void comboBox2_MouseDown(object sender, MouseEventArgs e)
        {

            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
            % mini_ada_write_sys_type(type)
%
% PURPOSE: To write system mini ADA TYPE to proper location in data FLASH.
% INPUT: type - '0' - ALL L1(A) , '1' - L1 & L2(B) , '2' - L1 - CAT4 & 1 ONLY(C).

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }


        }

        private void richTextBox_SyntisazerL2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
%synth_data_L1=[hex2dec('00C08000') ...   % Frequency change  % LO_L1=2*(1575.42)=2*1575.42 MHz. INT-N. Fpfd=16.368 MHz.
synth_data_L1=[hex2dec('00618000') ...   % Frequency change  % LO_L1=2*(1575.42+20.46)=2*1595.88 MHz. INT-N. Fpfd=16.368 MHz.
    hex2dec('08008011') ...              %
    hex2dec('00004542') ...              % charge pump change (4542 for 0.94mA , 4742 for 1.25mA) (for LO = 1595.88 SET 00004542 for LO = 1575.42 SET 00008542)
    hex2dec('004004B3') ...
    hex2dec('00883034') ...             %   Arie : hex2dec('0088303C') . 15dBm Required after Amplifier (34 instead 3C)

");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }

        private byte[] CreateMiniAdaFlashHeader(byte i_ver_major, byte i_ver_minor, DateTime i_ver_date, int i_block_size, byte i_checksum)
        {
            //CheckSumCalc = CheckSumCalc % 256;
            //            % Header Structure:
            //% ver_major   1
            //% ver_minor   1
            //% ver_day     1
            //% ver_month   1
            //% ver_year    2
            //% Block_size  4
            //% CHK         1
            //% Dummy(0)   1
            byte[] FlashHeader = new byte[12];
            FlashHeader[0] = i_ver_major;
            FlashHeader[1] = i_ver_minor;
            FlashHeader[2] = (byte)i_ver_date.Day;
            FlashHeader[3] = (byte)i_ver_date.Month;
            FlashHeader[4] = (byte)(i_ver_date.Year);
            FlashHeader[5] = (byte)(i_ver_date.Year >> 8);
            FlashHeader[6] = (byte)(i_block_size);
            FlashHeader[7] = (byte)(i_block_size >> 8);
            FlashHeader[8] = (byte)(i_block_size >> 16);
            FlashHeader[9] = (byte)(i_block_size >> 24);
            FlashHeader[10] = i_checksum; // Check Sum is the same as the system type
            FlashHeader[11] = 0;

            return FlashHeader;
        }

        private readonly string SYSTEM_TYPE_ADDRESS = "00000000";
        private void button73_Click_1(object sender, EventArgs e)
        {
            string DataToSend = "";
            int DataLength = 1;
            //  byte CheckSumCalc = 0;
            byte SystemType = (byte)comboBox_SystemType.SelectedIndex;


            //            % mini_ada_write_sys_type(type)
            //%
            //% PURPOSE: To write system mini ADA TYPE to proper location in data FLASH.
            //% INPUT: type - '0' - ALL L1(A) , '1' - L1 & L2(B) , '2' - L1 - CAT4 & 1 ONLY(C).
            //Gil: Catalina 1

            //CheckSumCalc = CheckSumCalc % 256;
            //            % Header Structure:
            //% ver_major   1
            //% ver_minor   1
            //% ver_day     1
            //% ver_month   1
            //% ver_year    2
            //% Block_size  4
            //% CHK         1
            //% Dummy(0)   1

            // 1	0	17	3	230	7	16	11	0	0	219	0

            DataToSend = SystemType.ToString("X2");

            byte[] FlashHeader = CreateMiniAdaFlashHeader(0, 0, DateTime.Now, DataLength, SystemType);

            DataLength += 12;
            string TotalframeDataToSend = ConvertByteArraytToString(FlashHeader) + DataToSend;
            byte[] temp = StringToByteArray(Regex.Replace(TotalframeDataToSend, @"\s+", ""));
            // Erase the Sector
            //textBox_EraseDataFromFlash.Text = SYSTEM_TYPE_ADDRESS;
            //button_EraseFlash.PerformClick();
            //wait(2000);
            ////Store the Data in flash
            //byte[] intBytes = BitConverter.GetBytes(DataLength);
            //String NumOfBytesstr = ConvertByteArraytToString(intBytes);
            //textBox_StoreDatainFlash.Text = "00000000" /* + NumOfBytesstr */+ TotalframeDataToSend;
            //temp = StringToByteArray(Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", ""));
            //button_StoreDatainFlash.PerformClick();
        }

        private readonly string SYNTHESIZER_L1_ADDRESS = "00300000";
        private void button96_Click_2(object sender, EventArgs e)
        {
            //// 1	0	21	3	230	7	24	0	0	0	65	0	5	0	88	0	52	48	136	0	179	4	64	0	66	69	0	0	17	128	0	8	0	128	97	0
            //String DataToSend = "";
            //int DataLength = 0;
            //byte CheckSumCalc = 0;

            //var lines = richTextBox_SyntisazerL1.Lines;
            //for (var i = 0; i < lines.Length ; i++)
            //{
            //    String line = lines[i];
            //    // Process line


            //    line = Regex.Replace(line, @"\s+", "");

            //    byte[] LineBytes = StringToByteArray(line);
            //    LineBytes = LineBytes.Reverse().ToArray();
            //    DataToSend = ByteArrayToString(LineBytes) + DataToSend;// Gil: We need to make it in reverse order, Icompare it exactly to the Matlab code.

            //    DataLength += LineBytes.Length;
            //    foreach (byte by in LineBytes)
            //    {
            //        CheckSumCalc += by;
            //    }
            //}



            //byte[] FlashHeader = CreateMiniAdaFlashHeader(1, 0, DateTime.Now, DataLength, CheckSumCalc);


            //DataLength += 12;
            //string TotalframeDataToSend = ConvertByteArraytToString(FlashHeader) + DataToSend;
            //byte[] temp = StringToByteArray(Regex.Replace(TotalframeDataToSend, @"\s+", ""));
            //// Erase the Sector
            //textBox_EraseDataFromFlash.Text = SYNTHESIZER_L1_ADDRESS;
            //button_EraseFlash.PerformClick();
            //wait(2000);
            ////Store the Data in flash
            //byte[] intBytes = BitConverter.GetBytes(DataLength);
            //String NumOfBytesstr = ConvertByteArraytToString(intBytes);
            //textBox_StoreDatainFlash.Text = SYNTHESIZER_L1_ADDRESS /* + NumOfBytesstr */+ TotalframeDataToSend;
            //temp = StringToByteArray(Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", ""));
            //button_StoreDatainFlash.PerformClick();
        }

        private readonly string SYNTHESIZER_L2_ADDRESS = "00400000";
        private void button101_Click(object sender, EventArgs e)
        {
            string DataToSend = "";
            int DataLength = 0;
            byte CheckSumCalc = 0;

            string[] lines = richTextBox_SyntisazerL2.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                // Process line


                line = Regex.Replace(line, @"\s+", "");

                byte[] LineBytes = StringToByteArray(line);
                LineBytes = LineBytes.Reverse().ToArray();
                DataToSend = ByteArrayToString(LineBytes) + DataToSend;// Gil: We need to make it in reverse order, Icompare it exactly to the Matlab code.

                DataLength += LineBytes.Length;
                foreach (byte by in LineBytes)
                {
                    CheckSumCalc += by;
                }
            }



            byte[] FlashHeader = CreateMiniAdaFlashHeader(1, 0, DateTime.Now, DataLength, CheckSumCalc);


            DataLength += 12;
            string TotalframeDataToSend = ConvertByteArraytToString(FlashHeader) + DataToSend;
            byte[] temp = StringToByteArray(Regex.Replace(TotalframeDataToSend, @"\s+", ""));
            // Erase the Sector
            //      textBox_EraseDataFromFlash.Text = SYNTHESIZER_L2_ADDRESS;
            //      button_EraseFlash.PerformClick();
            wait(2000);
            //Store the Data in flash
            byte[] intBytes = BitConverter.GetBytes(DataLength);
            string NumOfBytesstr = ConvertByteArraytToString(intBytes);
            //    textBox_StoreDatainFlash.Text = SYNTHESIZER_L2_ADDRESS /* + NumOfBytesstr */+ TotalframeDataToSend;
            //       temp = StringToByteArray(Regex.Replace(textBox_StoreDatainFlash.Text, @"\s+", ""));
            //button_StoreDatainFlash.PerformClick();
        }

        private void button100_Click_2(object sender, EventArgs e)
        {
            button_WriteAllToFlash.BackColor = Color.Yellow;
            progressBar_WriteToFlash.Value = 0;
            SystemLogger.LogMessage(Color.Orange, Color.White, string.Format("Writing System Type to [{0}]", SYSTEM_TYPE_ADDRESS), true, true);
            button_WriteSystemType.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 20;
            SystemLogger.LogMessage(Color.Orange, Color.White, string.Format("Synthesizer L1 [{0}]", SYNTHESIZER_L1_ADDRESS), true, true);
            button_SynthL1.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 40;
            SystemLogger.LogMessage(Color.Orange, Color.White, string.Format("Synthesizer L2 [{0}]", SYNTHESIZER_L2_ADDRESS), true, true);
            button_SynthL2.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 60;
            SystemLogger.LogMessage(Color.Orange, Color.White, string.Format("Catalina 1-4 [{0}] [{1}] [{2}] [{3}]", CATALINA_1_ADDRESS, CATALINA_2_ADDRESS, CATALINA_3_ADDRESS, CATALINA_4_ADDRESS), true, true);
            button_WriteCatalinas.PerformClick();
            wait(3000);
            progressBar_WriteToFlash.Value = 100;
            button_WriteAllToFlash.BackColor = default;
        }

        private void richTextBox_RegisterCommands_TextChanged(object sender, EventArgs e)
        {
            //    Monitor.Properties.Settings.Default.RegisterCommands = richTextBox_RegisterCommands.Text;
            //    Monitor.Properties.Settings.Default.Save();
        }

        private void button72_Click_3(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "8A 00";
            //textBox_data.Text = textBox_RecordingTests.Text;

            //SendDataToSystem();
        }

        private void textBox_RecordingTests_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_RecordingTests.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length ==1)
            //{
            //    textBox_RecordingTests.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_RecordingTests.BackColor = Color.Red;
            //}
        }

        private void button72_MouseDown_1(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"
Description:   Select recording test
Command: 	0x8A
TX data: 	1 byte - Select test:
0x0 - Record the RX channel state RX/CAL (CAL_TX_CTRL signal) 
along with 1 of the Rx channel (1 from 1…8) at the same time
0x1 - Record the bit(Rx/CAL) that represent the end of command.
along with 1 of the Rx channel (1 from 1…8) at the same time
0x2 - Record the bit that represent the end of command change Syn. Freq.  
        and record the bit Syn Lock at the same time.

Note: “at the same time” – meaning when saving the samples there is time alignment between bot sampled signals

TX frame: 	0x004D 0x008A 0x00000001 + Tx Data + checksum
RX data: 	1 byte – Test result: 0x0 – Ok, 0x1 - Failed
RX frame: 	0x004D 0x008A 0x00000001 + RX Data + checksum



");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }


        private void textBox_GetMonitoredData_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_GetMonitoredData.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 1)
            //{
            //    textBox_GetMonitoredData.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_GetMonitoredData.BackColor = Color.Red;
            //}
        }

        private void button94_Click_1(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "91 00";
            //textBox_data.Text = textBox_GetMonitoredData.Text;

            //SendDataToSystem();
        }

        private void button94_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string str = string.Format(@"

Description:   Get a block of next monitored data from selected group
Command: 	0x91
TX data: 	1 byte - Monitored group enum: 	0x0 - Group Temperature
							0x1 - Group Voltage
							0x2 - Group Current
							0x3 - Group Flags
TX frame: 	0x004D 0x0091 0x00000001 + TX Data + checksum
RX data: 	64 byte
		2 byte - The ID of this object Discrete 
1 byte - Current value
1 byte - Discrete is Alarm. Boolean level (1/0) for generating an Alarm
4 byte - Minimum value allowed
4 byte - Maximum value allowed
4 byte - Analog Current value
40 byte - The Name of this object, String type.
4byte - Alarm type, eStatus enum
4byte - Alarm rules (Min-Only, Max-Only, Min-Max, No), eStatus enum
RX frame: 	0x004D 0x0091 0x00000040 + RX Data + checksum
Note: eStatus enum 
	0x0 - NO - Alarm is not generated/Current reading is in range. Ok!
0x1 - HIGH - Alarm when value to high / Current reading is too high.
0x2 - LOW - Alarm when value to low / Current reading is too low.
0x3 - MIN_MAX- Alarm when value to high or to low / not applicable for reading
 


");
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "Help: ", true, true);
                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, true, false);
            }
        }










        private void button102_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "99 00";
            //textBox_data.Text = textBox_SetLOFreq.Text;

            //SendDataToSystem();

        }

        private void textBox_SetLOFreqStep_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SetLOFreqStep.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 9)
            //{
            //    textBox_SetLOFreqStep.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SetLOFreqStep.BackColor = Color.Red;
            //}
        }

        private void button103_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "9A 00";
            //textBox_data.Text = textBox_SetLOFreqStep.Text;

            //SendDataToSystem();

        }

  


        private void textBox_SelectLOSource_TextChanged(object sender, EventArgs e)
        {
            //string WithoutSpaces = Regex.Replace(textBox_SelectLOSource.Text, @"\s+", "");
            //byte[] buffer = StringToByteArray(WithoutSpaces);

            //if (buffer != null && buffer.Length == 1)
            //{
            //    textBox_SelectLOSource.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    textBox_SelectLOSource.BackColor = Color.Red;
            //}
        }

        private void button107_Click(object sender, EventArgs e)
        {
            //textBox_Preamble.Text = PREAMBLE;
            //textBox_Opcode.Text = "9D 00";
            //textBox_data.Text = textBox_SelectLOSource.Text;

            //SendDataToSystem();
        }



     //   private KratosProtocolFrame SentFrameGlobal = null;
        















        void Not_Implemented()
        {
            string message = "Gil Ramon: Not Implemented";
            MessageBox.Show(message);
        }
        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckBox Checkbx = (CheckBox)sender;
            Not_Implemented();

        }



        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            TextBox m_Textbox = (TextBox)sender;
            if (int.TryParse(m_Textbox.Text, out int Num) == true)
            {
                if (Num >= 0 && Num <= 1000)
                {
                    m_Textbox.BackColor = Color.LightGreen;
                }
                else
                {
                    m_Textbox.BackColor = Color.Red;
                }
            }
            else
            {
                m_Textbox.BackColor = Color.Red;
            }
        }



      
     



        void testRFTextboxs()
        {

        }

        void testPulseGenTextBoxs()
        {
            //textBox_PulsePeriod2.Text = textBox_PulsePeriod.Text;
            //textBox_RFPeriod.Text = textBox_PulsePeriod.Text;

            //textBox_PulseWidth2.Text = textBox_PulseWidth.Text;
            //textBox_RFWidth.Text = textBox_PulseWidth.Text;

        }

        void testPulseGenTextBoxs2()
        {

        }

        private void textBox_RFWidth_TextChanged(object sender, EventArgs e)
        {
            testRFTextboxs();
        }

        private void textBox_PulseWidth_TextChanged(object sender, EventArgs e)
        {
            testPulseGenTextBoxs();
        }

        private void textBox_PulsePeriod_TextChanged(object sender, EventArgs e)
        {
            testPulseGenTextBoxs();
            //testRFTextboxs();
            //testPulseGenTextBoxs2();
        }

        private void textBox_PulseWidth2_TextChanged(object sender, EventArgs e)
        {
            testPulseGenTextBoxs2();
        }

        private void textBox_PulsePeriod2_TextChanged(object sender, EventArgs e)
        {
            testPulseGenTextBoxs2();
        }

        private void button74_Click_1(object sender, EventArgs e)
        {
           
            


        }

        private void Ctr_TextChanged(object sender, EventArgs e)
        {
            textBox_StatusUUT1_TextChanged(sender, e);
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (int.TryParse(txtbox.Text, out int Num) == true)
            {
                if (Num >= 0 && Num <= 4095)
                {
                    txtbox.BackColor = Color.LightGreen;
                }
                else
                {
                    txtbox.BackColor = Color.Red;
                }
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (int.TryParse(txtbox.Text, out int Num) == true)
            {
                if (Num >= 0 && Num <= 4095)
                {
                    txtbox.BackColor = Color.LightGreen;
                }
                else
                {
                    txtbox.BackColor = Color.Red;
                }
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (int.TryParse(txtbox.Text, out int Num) == true)
            {
                if (Num >= 0 && Num <= 4095)
                {
                    txtbox.BackColor = Color.LightGreen;
                }
                else
                {
                    txtbox.BackColor = Color.Red;
                }
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (int.TryParse(txtbox.Text, out int Num) == true)
            {
                if (Num >= 0 && Num <= 255)
                {
                    txtbox.BackColor = Color.LightGreen;
                }
                else
                {
                    txtbox.BackColor = Color.Red;
                }
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void checkBox_SendEveryOneSecond_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox_SendSerialPortPeriod_TextChanged(object sender, EventArgs e)
        {
            TextBox Txtbx = (TextBox)sender;
            if (int.TryParse(Txtbx.Text, out int result) == true)
            {
                Txtbx.BackColor = Color.LightGreen;
            }
            else
            {
                Txtbx.BackColor = Color.Red;
            }
        }

        private void textBox1_TextChanged_4(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }









        private void SetTextBoxTextChangedColor(TextBox i_textbox)
        {

            if (i_textbox.BackColor == Color.White)
            {

                i_textbox.BackColor = default;

            }
            else
            {

                i_textbox.BackColor = Color.White;
            }
        }

        private void textBox_StatusUUT1_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);




        }

        private void textBox_StatusUUT2_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT3_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT4_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT5_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT6_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT7_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT18_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT19_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT29_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT17_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT8_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT9_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT10_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT11_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT23_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT22_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT21_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT20_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT16_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT15_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT14_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT13_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT12_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT26_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT25_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT24_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT32_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT31_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT30_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT28_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        private void textBox_StatusUUT27_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }

        

        private void textBox95_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxTextChangedColor((TextBox)sender);
        }


        private void textBox_SystemMode_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 2)
            {
                if (txtbox.Text == "0007")
                {
                    txtbox.BackColor = Color.LightGreen;
                }
                else
                {
                    txtbox.BackColor = Color.Orange;
                }
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }

        }

        private void button_SystemMode_Click(object sender, EventArgs e)
        {
            //TextBox m_TextBox = (TextBox)sender;



        }

        private void textBox_FTbit_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (int.TryParse(txtbox.Text, out int Num) == true)
            {
                if (Num >= 0 && Num <= 15)
                {
                    txtbox.BackColor = Color.LightGreen;
                }
                else
                {
                    txtbox.BackColor = Color.Red;
                }
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox_ATTBit_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            if (int.TryParse(txtbox.Text, out int Num) == true)
            {
                if (Num >= 0 && Num <= 31)
                {
                    txtbox.BackColor = Color.LightGreen;
                }
                else
                {
                    txtbox.BackColor = Color.Red;
                }
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void tabPage6_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox45_Enter(object sender, EventArgs e)
        {

        }

        private void label127_Click(object sender, EventArgs e)
        {

        }

        private void label128_Click(object sender, EventArgs e)
        {

        }

        private void label129_Click(object sender, EventArgs e)
        {

        }

        private void label133_Click(object sender, EventArgs e)
        {

        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            TextBox m_Textbox = (TextBox)sender;
            if (int.TryParse(m_Textbox.Text, out int Num) == true)
            {
                m_Textbox.BackColor = Color.LightGreen;
                //if (Num >= 0 && Num <= 4095)
                //{
                //    m_Textbox.BackColor = Color.LightGreen;
                //}
                //else
                //{
                //    m_Textbox.BackColor = Color.Red;
                //}
            }
            else
            {
                m_Textbox.BackColor = Color.Red;
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            TextBox m_Textbox = (TextBox)sender;
            if (int.TryParse(m_Textbox.Text, out int Num) == true)
            {
                m_Textbox.BackColor = Color.LightGreen;
                //if (Num >= 0 && Num <= 4095)
                //{
                //    m_Textbox.BackColor = Color.LightGreen;
                //}
                //else
                //{
                //    m_Textbox.BackColor = Color.Red;
                //}
            }
            else
            {
                m_Textbox.BackColor = Color.Red;
            }
        }

        private void label131_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void button59_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_WriteReadRegister_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }


        private void textBox_ReadRegister_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }





        private void tabPage3_Click(object sender, EventArgs e)
        {

        }


        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 2)
            {
                //WriteFromRegister(textBox36.Text, textBox38.Text);
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }


        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 2)
            {
                // ReadFromRegister(textBox37.Text);
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }


        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 2)
            {
                // Write_Register(textBox36.Text, textBox38.Text);
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }





        void Erase_Flash(String i_Settings = "11 00 00")
        {
            //textBox_EraseFlash.Text = i_Settings;


        }




        private void textBox_EraseFlash_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 3)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox_WriteFlash_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }

        private void textBox_ReadFlash_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 5)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }











    



  

        private void textBox_SPA_Ton_TextChanged(object sender, EventArgs e)
        {
            TextBox m_Textbox = (TextBox)sender;
            if (int.TryParse(m_Textbox.Text, out int Num) == true)
            {
                m_Textbox.BackColor = Color.LightGreen;
                //if (Num >= 0 && Num <= 4095)
                //{
                //    m_Textbox.BackColor = Color.LightGreen;
                //}
                //else
                //{
                //    m_Textbox.BackColor = Color.Red;
                //}
            }
            else
            {
                m_Textbox.BackColor = Color.Red;
            }
        }

        private void textBox_SPA_Toff_TextChanged(object sender, EventArgs e)
        {
            TextBox m_Textbox = (TextBox)sender;
            if (int.TryParse(m_Textbox.Text, out int Num) == true)
            {
                m_Textbox.BackColor = Color.LightGreen;
                //if (Num >= 0 && Num <= 4095)
                //{
                //    m_Textbox.BackColor = Color.LightGreen;
                //}
                //else
                //{
                //    m_Textbox.BackColor = Color.Red;
                //}
            }
            else
            {
                m_Textbox.BackColor = Color.Red;
            }
        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {
            TextBox m_Textbox = (TextBox)sender;
            if (int.TryParse(m_Textbox.Text, out int Num) == true)
            {
                if (Num >= 0 && Num <= 4095)
                {
                    m_Textbox.BackColor = Color.LightGreen;
                }
                else
                {
                    m_Textbox.BackColor = Color.Red;
                }
            }
            else
            {
                m_Textbox.BackColor = Color.Red;
            }
        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {
            TextBox m_Textbox = (TextBox)sender;
            if (int.TryParse(m_Textbox.Text, out int Num) == true)
            {
                m_Textbox.BackColor = Color.LightGreen;
                //if (Num >= 0 && Num <= 4095)
                //{
                //    m_Textbox.BackColor = Color.LightGreen;
                //}
                //else
                //{
                //    m_Textbox.BackColor = Color.Red;
                //}
            }
            else
            {
                m_Textbox.BackColor = Color.Red;
            }
        }

        private void textBox1_TextChanged_5(object sender, EventArgs e)
        {
            TextBox m_Textbox = (TextBox)sender;
            if (int.TryParse(m_Textbox.Text, out int Num) == true)
            {
                m_Textbox.BackColor = Color.LightGreen;
                //if (Num >= 0 && Num <= 4095)
                //{
                //    m_Textbox.BackColor = Color.LightGreen;
                //}
                //else
                //{
                //    m_Textbox.BackColor = Color.Red;
                //}
            }
            else
            {
                m_Textbox.BackColor = Color.Red;
            }
        }

        private void label65_Click(object sender, EventArgs e)
        {

        }











        private void button_SystemMode_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button_SystemMode_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void textBox_SystemMode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox_RFDelay_TextChanged(object sender, EventArgs e)
        {
            testRFTextboxs();
        }

        private void textBox_PulseDelay_TextChanged(object sender, EventArgs e)
        {
            testPulseGenTextBoxs();
        }

        private void textBox_PulseDelay2_TextChanged(object sender, EventArgs e)
        {
            testPulseGenTextBoxs2();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox m_TextBox = (TextBox)sender;

                if ((e.KeyCode == Keys.Enter) && m_TextBox.BackColor == Color.LightGreen)
                {

                    //textBox2.Text = GetBytesFromData(textBox1.Text, 1, 2);

                }


            }
            catch
            {

            }
        }

        private void textBox1_TextChanged_6(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbox.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null)
            {
                txtbox.BackColor = Color.LightGreen;
            }
            else
            {
                txtbox.BackColor = Color.Red;
            }
        }
































        private void button32_Click_3(object sender, EventArgs e)
        {

            //textBox1_KeyDown(textBox1, new KeyEventArgs(Keys.Enter));
        }

        private void textBox25_KeyDown_1(object sender, KeyEventArgs e)
        {

        }













       

      

        



  





























        async void ReadDataGridToFlash(DataGridView i_DataGrid)
        {

            if (Int32.TryParse(GetLast(i_DataGrid.Name, 2), out int GridNumber))
            {
                String BlockAddress = String.Format("00 0{0}", GridNumber.ToString("X"));

                int TotalBytesToRead = (i_DataGrid.Rows.Count - 1) * 2;
                int InternalFlashAddress = 0;


                while (TotalBytesToRead > 0)
                {
                    await Task.Delay(1000);

                    //for (i = InternalFlashAddress; (i < i_DataGrid.Rows.Count - 1 && ByteCounter < 255); i++)
                    //{
                    //    DataToWrite += i_DataGrid.Rows[i].Cells[0].Value;
                    //    TotalBytesToSend -= 2;
                    //    InternalFlashAddress = +2;
                    //    ByteCounter += 2;
                    //}



                    InternalFlashAddress += 0x0100;
                    TotalBytesToRead -= 0x0100;
                }



                // Read_Flash(BlockAddress);
            }
        }




        private static string GetLast(string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
        async Task WriteDataGridToFlash(DataGridView i_DataGrid, bool i_DoErase)
        {
            int i = 0;
            //   tabControl_SSPA_WB_GUI.Enabled = false;

            if (Int32.TryParse(GetLast(i_DataGrid.Name, 2), out int GridNumber))
            {
                // String BlockAddress = String.Format("{0}0 00", GridNumber.ToString("X")); 
                String BlockAddress = String.Format("00 0{0}", GridNumber.ToString("X"));

                for (i = 0; i < i_DataGrid.Rows.Count - 1; i++)
                {
                    if (i_DataGrid.Rows[i].Cells[0].Style.BackColor != Color.LightGreen)
                    {
                        if (i_DataGrid.Rows[i].Cells[0].Value == null)
                        {
                            i_DataGrid.Rows[i].Cells[0].Value = "";
                        }
                        String message = String.Format("DataGrid [{0}] at Raw[{1}] is not OK[{2}] ", i_DataGrid.Name, i, i_DataGrid.Rows[i].Cells[0].Value.ToString());
                        WriteToSystemStatus(message, 4, Color.Orange);
                        return;
                    }
                }

                if (i_DoErase == true)
                {
                    Erase_Flash("31 " + BlockAddress);
                    await Task.Delay(5000);
                }

                String DataToWrite = "";
                int TotalBytesToSend = (i_DataGrid.Rows.Count - 1) * 2;
                int InternalFlashAddress = 0;
                int ByteCounter = 0;
                int row = 0;
                while (TotalBytesToSend > 0)
                {
                    await Task.Delay(3000);
                    DataToWrite = "";
                    ByteCounter = 0;
                    // String InternalAddressInFlash = InternalFlashAddress.ToString("X4");
                    for (i = 0; (i < TotalBytesToSend && row < i_DataGrid.Rows.Count - 1 && ByteCounter < 256); i++)
                    {
                        DataToWrite += i_DataGrid.Rows[row].Cells[0].Value;
                        //             TotalBytesToSend -= 2;
                        //                        InternalFlashAddress = +2;
                        ByteCounter += 2;
                        row++;
                    }



                    InternalFlashAddress += 256;
                    TotalBytesToSend -= 256;
                }

                //for (i = 0; i < i_DataGrid.Rows.Count - 1; i++)
                //{
                //    DataToWrite += i_DataGrid.Rows[i].Cells[0].Value;
                //}

                //Write_Flash(BlockAddress, "00 00", DataToWrite);

            }

            //    tabControl_SSPA_WB_GUI.Enabled = true;
        }



       

        void dgGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;


            int.TryParse(GetLast(grid.Name, 2), out int GridNumber);

            String FlashAddress = GridNumber.ToString("X") + (e.RowIndex * 2).ToString("X3");
            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(e.RowIndex.ToString(), this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        void UpdateTestDataToGrid(DataGridView i_DataGrid)
        {
            if (Int32.TryParse(GetLast(i_DataGrid.Name, 2), out int GridNumber))
            {
                // String BlockAddress = String.Format("00 0{0}", GridNumber.ToString("X"));

                for (int i = 0; i < i_DataGrid.Rows.Count - 1; i++)
                {
                    i_DataGrid.Rows[i].Cells[0].Value = String.Format("{0}{1}", GridNumber.ToString("X2"), i.ToString("X2"));
                }
            }
        }








        String GetLinefromToCSVFromDataGrid(DataGridView i_Datagrid)
        {
            String ret = "";
            for (int i = 0; i < i_Datagrid.Rows.Count; i++)
            {
                if (i_Datagrid.Rows[i].Cells[0].Value == null)
                {
                    i_Datagrid.Rows[i].Cells[0].Value = "";
                }
                ret += i_Datagrid.Rows[i].Cells[0].Value + ",";
            }
            return ret;
        }
        private void button_WriteToCSV_Click(object sender, EventArgs e)
        {
            try
            {
                ////before your loop
                var CSV_bulder = new StringBuilder();
                var newLine = "";

                foreach (DataGridView datagrid in List_AllDataGrids)
                {
                    newLine = GetLinefromToCSVFromDataGrid(datagrid);
                    CSV_bulder.AppendLine(newLine);
                }

                //Suggestion made by KyleMit
                //var newLine = string.Format("{0},{1}", 1, 2);



                //after your loop
                //File.WriteAllText(".", csv.ToString());

                // Displays a SaveFileDialog so the user can save the Image
                // assigned to Button2.
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "csv|*.csv";
                saveFileDialog1.Title = "Save a csv file";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveFileDialog1.OpenFile();
                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    //switch (saveFileDialog1.FilterIndex)
                    //{
                    //    case 1:
                    //        this.button2.Image.Save(fs,
                    //          System.Drawing.Imaging.ImageFormat.Jpeg);
                    //        break;

                    //    case 2:
                    //        this.button2.Image.Save(fs,
                    //          System.Drawing.Imaging.ImageFormat.Bmp);
                    //        break;

                    //    case 3:
                    //        this.button2.Image.Save(fs,
                    //          System.Drawing.Imaging.ImageFormat.Gif);
                    //        break;
                    //}

                    byte[] info = new UTF8Encoding(true).GetBytes(CSV_bulder.ToString());
                    fs.Write(info, 0, info.Length);

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: File is Open Original error: " + ex.Message);
            }


        }

        void WriteLineToDataGrid(DataGridView i_Datagrid, String i_line)
        {
            String[] temp = i_line.Split(',');

            for (int i = 0; i < i_Datagrid.Rows.Count; i++)
            {
                if (i_Datagrid.Rows[i].Cells[0].Value == null)
                {
                    i_Datagrid.Rows[i].Cells[0].Value = "";
                }
                i_Datagrid.Rows[i].Cells[0].Value = temp[i];
            }
            return;
        }
        private void button_ReadCSVFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open CSV File";
            theDialog.Filter = "CSV files|*.csv";
            //theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.


                            StreamReader reader = new StreamReader(myStream);

                            foreach (DataGridView datagrid in List_AllDataGrids)
                            {
                                WriteLineToDataGrid(datagrid, reader.ReadLine());
                            }



                            //for (int i = 0; i < 12; i++)
                            //{
                            //    reader.ReadLine();
                            //    WriteLineToDataGrid
                            //}

                            reader.Close();
                            //string message = text;
                            //MessageBox.Show(message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        void ClearallColumnsinGrid(DataGridView i_DataGrid, bool i_OnlyFlashData)
        {
            if (i_OnlyFlashData == true)
            {
                for (int i = 0; i < i_DataGrid.Rows.Count - 1; i++)
                {
                    i_DataGrid.Rows[i].Cells[0].Value = "";
                }
            }
            else
            {
                for (int i = 0; i < i_DataGrid.Rows.Count; i++)
                {
                    i_DataGrid.Rows[i].Cells[0].Value = "";
                    i_DataGrid.Rows[i].Cells[1].Value = "";
                    i_DataGrid.Rows[i].Cells[2].Value = "";
                }
            }
        }

        bool CompareDatatoValidationColumn(DataGridView i_DataGrid)
        {
            bool ret = true;
            for (int i = 0; i < i_DataGrid.Rows.Count - 1; i++)
            {
                String RawCell0 = i_DataGrid.Rows[i].Cells[0].Value.ToString();
                String RawCell2 = i_DataGrid.Rows[i].Cells[2].Value.ToString();
                if (RawCell0 != RawCell2)
                {
                    WriteToSystemStatus(String.Format("[{0}] in Row [{1}] is not equal", i_DataGrid.Name, i), 120, Color.OrangeRed);
                    ret = false;
                }

            }

            return ret;
        }

        void CopyDatatoValidationColumn(DataGridView i_DataGrid)
        {
            for (int i = 0; i < i_DataGrid.Rows.Count - 1; i++)
            {
                if (i_DataGrid.Rows[i].Cells[0].Value == null)
                {
                    i_DataGrid.Rows[i].Cells[0].Value = "";
                }
                i_DataGrid.Rows[i].Cells[2].Value = i_DataGrid.Rows[i].Cells[0].Value.ToString();
            }
        }

        private async void button_Writeallblockstoflash_Click(object sender, EventArgs e)
        {

            if (serialPort.IsOpen == false)
            {
                WriteToSystemStatus("port not open", 3, Color.Orange);
                return;
            }

            //    tabControl_SSPA_WB_GUI.Enabled = false;


            progressBar_UserStatus.Value = 0;



            //int Delay = 1000;
            string message = @"
Are you sure write all to flash?
This Process can take 1 minute.";
            string title = "Write Flash";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {

                // Gil: Erase flash
                Erase_Flash();
                await Task.Delay(4000);



                progressBar_UserStatus.Value = 10;
                // Gil: Write all blocks flash

                foreach (DataGridView datagrid in List_AllDataGrids)
                {

                    await WriteDataGridToFlash(datagrid, false);
                    await Task.Delay(1000);
                    progressBar_UserStatus.Value += 5;
                }





                // Gil: Copy all the data to the other columns

                foreach (DataGridView datagrid in List_AllDataGrids)
                {
                    CopyDatatoValidationColumn(datagrid);
                }



                //progressBar_UserStatus.Value = 60;
                // Gil: Clear

                foreach (DataGridView datagrid in List_AllDataGrids)
                {
                    ClearallColumnsinGrid(datagrid, true);
                }



                progressBar_UserStatus.Value = 80;
                // Gil: Read all from flash

                foreach (DataGridView datagrid in List_AllDataGrids)
                {
                    ReadDataGridToFlash(datagrid);
                    await Task.Delay(800);
                }


                // Gil compare
                await Task.Delay(1000);
                bool FlashCheck = true;
                foreach (DataGridView datagrid in List_AllDataGrids)
                {
                    bool ret = CompareDatatoValidationColumn(datagrid);
                    if (ret != true)
                    {
                        FlashCheck = false;
                    }
                }


                if (FlashCheck == true)
                {

                    WriteToSystemStatus(String.Format(Environment.NewLine + " Data Written to the flash and verified :-) "), 60, Color.LightGreen);
                    progressBar_UserStatus.Value = 100;
                    progressBar_UserStatus.BackColor = Color.Green;
                    progressBar_UserStatus.ForeColor = Color.Green;
                }
                else
                {
                    WriteToSystemStatus(String.Format(Environment.NewLine + " Something got wrong during verification :-( "), 120, Color.OrangeRed);
                    progressBar_UserStatus.Value = 100;
                    progressBar_UserStatus.BackColor = Color.OrangeRed;
                    progressBar_UserStatus.ForeColor = Color.OrangeRed;
                }





            }
            else
            {
                // Do something  
            }

            //   tabControl_SSPA_WB_GUI.Enabled = true;
        }








       




 

        private void button136_Click(object sender, EventArgs e)
        {
            foreach (DataGridView datagrid in List_AllDataGrids)
            {
                UpdateTestDataToGrid(datagrid);
            }
        }



        private void button_SendSerialPort_Click(object sender, EventArgs e)
        {
            bool IsSent = false;
           // 

            if (serialPort.IsOpen == false)
            {
                WriteToSystemStatus("Serial Port is not open", 3, Color.Orange);
                return;
            }

            byte[] buffer = null;

            if (checkBox_SendHexdata.Checked == true)
            {
                string tempStr = textBox_SendSerialPort.Text.Replace(" ", "");

                buffer = StringToByteArray(tempStr);

                if (buffer != null)
                {
                    IsSent = SerialPortSendData(buffer);
                }
                else
                {
                    SerialPortLogger.LogMessage(Color.Red, Color.LightGray, "Not Hex data format for example: aabbcc is 0xAA 0xBB 0xCC", New_Line = true, Show_Time = false);
                    return;
                }

                if (IsSent == true)
                {
                    UpdateSerialPortHistory(textBox_SendSerialPort.Text);

                    //    UpdateSerialPortComboBox();

                    if (checkBox_DeleteCommand.Checked == true)
                    {
                        textBox_SendSerialPort.Text = "";
                    }



                    SerialPortLogger.LogMessage(Color.Purple, Color.Yellow, "", New_Line = false, Show_Time = true);
                    SerialPortLogger.LogMessage(Color.Purple, Color.Yellow, "Tx:>", false, false);
                    SerialPortLogger.LogMessage(Color.Purple, Color.Yellow, ConvertByteArraytToString(buffer), true, false);

                    TxLabelTimerBlink = 5;

                }


            }
            else
            {


                string tempStr = textBox_SendSerialPort.Text.Replace("\\n", "\n");
                tempStr = tempStr.Replace("\\r", "\r");
                buffer = Encoding.ASCII.GetBytes(tempStr);

                IsSent = SerialPortSendData(buffer);

                if (IsSent == true)
                {
                    UpdateSerialPortHistory(textBox_SendSerialPort.Text);

                    //    UpdateSerialPortComboBox();

                    if (checkBox_DeleteCommand.Checked == true)
                    {
                        textBox_SendSerialPort.Text = "";
                    }



                    SerialPortLogger.LogMessage(Color.Purple, Color.Yellow, "", New_Line = false, Show_Time = true);
                    SerialPortLogger.LogMessage(Color.Purple, Color.Yellow, "Tx:>", false, false);
                    SerialPortLogger.LogMessage(Color.Purple, Color.Yellow, Encoding.ASCII.GetString(buffer), true, false);

                    TxLabelTimerBlink = 5;

                }


            }

            if (checkBox_WriteFrameInformation.Checked == true)
            {
                WriteBufferInfo(buffer);
            }

        }

        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            SerialPortLogger.LogMessage(Color.White, Color.Red, "SerialPort Error received: ", New_Line = true, Show_Time = true);
            SerialPortLogger.LogMessage(Color.White, Color.Red, e.ToString(), New_Line = true, Show_Time = true);
            //SerialPortLogger.LogMessage(Color.Purple, Color.Azure, "Tx:>", false, false);
            // SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, Encoding.ASCII.GetString(buffer), true, false);
        }

        private void textBox_CLISendCommands_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                RichTextBox m_textBox = (RichTextBox)sender;
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        textBox_CommandHelp.Text = CLI_Help;

                        break;

                    //case Keys.F2:
                    //    SystemLogger.LogMessage(Color.Black, Color.Chartreuse, "F2 function reads all commands to history", New_Line = true, Show_Time = true);
                    //    break;

                    //case Keys.ControlKey:
                    //    SelfMonitorCommandsMode = !SelfMonitorCommandsMode;
                    //    if (SelfMonitorCommandsMode == true)
                    //    {
                    //        textBox_SendSerialPort.BackColor = SystemColors.Info;
                    //        groupBox_SendSerialOrMonitorCommands.BackColor = SystemColors.Info;
                    //        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "Change to Monitor commands mode", New_Line = true, Show_Time = true);
                    //    }
                    //    else
                    //    {
                    //        groupBox_SendSerialOrMonitorCommands.BackColor = default(Color);
                    //        textBox_SendSerialPort.BackColor = SystemColors.ActiveCaption;
                    //        SerialPortLogger.LogMessage(Color.Black, Color.Chartreuse, "Change to Send to serial port mode", New_Line = true, Show_Time = true);


                    //    }
                    //    break;


                    case Keys.Enter:
                        //if (SelfMonitorCommandsMode == true)
                        //{

                        //}
                        //else
                        //{
                        button_CLISend.PerformClick();
                        //}

                        break;

                    case Keys.Up:

                        if (Monitor.Properties.Settings.Default.CLICommad_History.Count == 0)
                        {
                            return;
                        }

                        //SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, " History Index: " + HistoryIndex.ToString(), New_Line = true, Show_Time = false);
                        if (CLI_HistoryIndex <= Monitor.Properties.Settings.Default.CLICommad_History.Count - 1 && CLI_HistoryIndex > 0)
                        { 

                            CLI_HistoryIndex--;
                        }
                        else
                        {
                            CLI_HistoryIndex = Monitor.Properties.Settings.Default.CLICommad_History.Count - 1;
                        }

                        textBox_CLISendCommands.Text = Monitor.Properties.Settings.Default.CLICommad_History[CLI_HistoryIndex];


                        //if (CLI_HistoryIndex > 0)
                        //{
                        //    CLI_HistoryIndex--;
                        //}
                        //textBox_CLISendCommands.Text = Monitor.Properties.Settings.Default.CLICommad_History[CLI_HistoryIndex];

                        m_textBox.SelectionStart = m_textBox.Text.Length;
                        m_textBox.SelectionLength = 0;

                        break;

                    case Keys.Down:

                        if (Monitor.Properties.Settings.Default.CLICommad_History.Count == 0)
                        {
                            return;
                        }

                        if (CLI_HistoryIndex < Monitor.Properties.Settings.Default.CLICommad_History.Count - 1 && CLI_HistoryIndex >= 0)
                        {
 
                            CLI_HistoryIndex++;
                        }
                        else
                        {
                            CLI_HistoryIndex = 0;
                        }

                        textBox_CLISendCommands.Text = Monitor.Properties.Settings.Default.CLICommad_History[CLI_HistoryIndex];

                        m_textBox.SelectionStart = m_textBox.Text.Length;
                        m_textBox.SelectionLength = 0;
                        break;

                    case Keys.Tab:
                        e.Handled = false;
                        e.SuppressKeyPress = true;
                        List<string> Strlist = new List<string>();
                        foreach (string str in Monitor.Properties.Settings.Default.CLICommad_History)
                        {
                            if (str.StartsWith(textBox_CLISendCommands.Text))
                            {
                                Strlist.Add(str);
                            }
                        }

                        if (Strlist.Count > 1)
                        {
                            SystemLogger.LogMessage(Color.Black, Color.AliceBlue, "History commands: " + Strlist.Count.ToString() + " ", New_Line = true, Show_Time = true);
                            foreach (string str in Strlist)
                            {
                                if (CLI_HistoryIndex == Strlist.IndexOf(str))
                                {
                                    SystemLogger.LogMessage(Color.Black, Color.Chartreuse, CLI_HistoryIndex + " <------", New_Line = false, Show_Time = false);
                                }

                                SystemLogger.LogMessage(Color.Black, Color.Chartreuse, str, New_Line = true, Show_Time = false);
                            }
                        }
                        else
                        if (Strlist.Count == 1)
                        {
                            textBox_CLISendCommands.Text = Strlist[0];
                        }
                        break;

                    //default:
                    //    CLI_HistoryIndex = Monitor.Properties.Settings.Default.CLICommad_History.Count - 1;
                    //    break;
                }





                //  CommandsHistoy.SelectedIndex = HistoryIndex;
            }
            catch (Exception ex)
            {
                SystemLogger.LogMessage(Color.Blue, Color.White, ex.ToString(), New_Line = true, Show_Time = false);
            }
        }

        private void tabControl_Main_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                // MessageBox.Show("Tab");
                e.IsInputKey = true;
            }
            if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                //  MessageBox.Show("Shift + Tab");
                e.IsInputKey = true;
            }
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static int ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return (int)diff.Ticks;
        }

        Int32 GlobalReadRegister = 0;
       // bool GlobalReadRegisterWritten = false;
        int MessageCounter = 0;
        async Task<String> WriteReg32(String i_Command, bool i_OnlyCheckValidity)
        {
            String ret = "";
            int DelayBetweenReadWrite = 0;

            String[] tempStr = i_Command.Split(' ');

            //Check Validity of the command first and retuen string error if something wrong. //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////
            ///

            
            int NumOfArguments = tempStr.Length;
            if ( !(NumOfArguments == 5 || NumOfArguments == 3))
            {
                ret += String.Format("\n Arguments number should be 3 or 5, see example", NumOfArguments);
                return ret;
            }

            if (tempStr[1].Contains("_s") == true)
            {
                tempStr[1] = tempStr[1].Replace("_s", "");
                ShowStatus = true;
            }

            byte[] buffer = StringToByteArray(tempStr[1]);
            if (buffer == null || buffer.Length != 4)
            {
                ret += String.Format("\n Argument [{0}] invalid not hex value or not 4 bytes", tempStr[1]);
             //   return ret;
            }



            buffer = StringToByteArray(tempStr[2]);

            if (buffer == null || buffer.Length != 4)
            {
                ret += String.Format("\n Argument [{0}] invalid not hex value or not 4 bytes", tempStr[2]);
            //    return ret;
            }

            if (NumOfArguments == 5)
            {
                buffer = StringToByteArray(tempStr[3]);

                if (buffer == null || buffer.Length != 4)
                {
                    ret += String.Format("\n Argument [{0}] invalid not hex value or not 4 bytes", tempStr[3]);
                    //  return ret;
                }



                if (int.TryParse(tempStr[4], out DelayBetweenReadWrite) == false)
                {
                    ret += String.Format("\n Argument [{0}] invalid not int", tempStr[4]);
                    //  return ret;
                }
            }

            if (i_OnlyCheckValidity == true || ret != "")
            {
                return ret;
            }
            String Command = tempStr[0];
            String RegisterAddress32bits = tempStr[1];
            String DataToWrite32bits = tempStr[2];

            if (NumOfArguments == 5)
            {
                PrintToSystemLogerTxMessage(i_Command);
                String MaskString = tempStr[3];
                //String NotMaskValue = "FFFFFFFF";
                //if (MaskString != NotMaskValue)
                //{
                    GlobalReadRegister = 0;
                //GlobalReadRegisterWritten = false;
                    Int32 MaskInt32 = Int32.Parse(MaskString, System.Globalization.NumberStyles.HexNumber);
                    Int32 DataToWrite = Int32.Parse(DataToWrite32bits, System.Globalization.NumberStyles.HexNumber);

                //ReadReg32(String.Format("ReadReg {0}", RegisterAddress32bits), false);
                await ExecuteCLICommand(String.Format("ReadReg32 {0}", RegisterAddress32bits),false);

                    await Task.Delay(DelayBetweenReadWrite);

                //while (GlobalReadRegisterWritten == false)
                //{
                //    await Task.Delay(100);
                //}

                // prefer number = number & ~(1 << n) | (x << n); for Changing the n-th bit to x. – 

                for (int i = 0; i < 32; i++)
                    {
                        if (((MaskInt32 >> i) & 1U) == 0)
                        {
                            int BitStatus = (DataToWrite >> i) & 1;
                            GlobalReadRegister = (GlobalReadRegister & ~(1 << i)) | (BitStatus << i);
                        }

                    }

                //await WriteReg32(String.Format("WriteReg32 {0} {1}", RegisterAddress32bits, GlobalReadRegister.ToString("X8")),false);
                await ExecuteCLICommand(String.Format("WriteReg32 {0} {1}", RegisterAddress32bits, GlobalReadRegister.ToString("X8")), false);


                //       }
            }
            else
            {




                List<byte> ListBytes = new List<byte>();


                //Preamble
                String Preamble = "82";
                ListBytes.AddRange(StringToByteArray(Preamble));


                //Opcode
                String Opcode = "21";
                ListBytes.AddRange(StringToByteArray(Opcode));


                //Messagecounter
                ListBytes.AddRange(StringToByteArray(ReverseHexStringLittleBigEndian(MessageCounter.ToString("X4"))));


                MessageCounter++;
                //RegisterAddress
                ListBytes.AddRange(StringToByteArray(ReverseHexStringLittleBigEndian(RegisterAddress32bits)));


                //DatatoWrite
                ListBytes.AddRange(StringToByteArray(ReverseHexStringLittleBigEndian(DataToWrite32bits)));


                //TimeTag
                // String TimeTag = ConvertToUnixTimestamp(DateTime.Now).ToString("X4");
                String TimeTag = "00 00 00 00";
                ListBytes.AddRange(StringToByteArray(ReverseHexStringLittleBigEndian(TimeTag)));



                //Data
                byte[] DataBytes = StringToByteArray(string.Concat(Enumerable.Repeat("00", 20)));
                ListBytes.AddRange(DataBytes);





                //Calculate check sum
                UInt32 CheckSum = CalculateChecksum(ListBytes.ToArray());

                ListBytes.AddRange(StringToByteArray(CheckSum.ToString("X8")));






                if (ret == "" && i_OnlyCheckValidity == false)
                {
                    //Execute the command
                    PrintToSystemLogerTxMessage(i_Command);
                    textBox_SendSerialPort.Text = ConvertByteArraytToString(ListBytes.ToArray());

                    button_SendSerialPort_Click(null, null);

                }
            }

            return ret;
        }



        String SetFullParams(String i_Command, bool i_OnlyCheckValidity)
        {
            //        Syntax:
            //            SetFullParams[system mode]
            //            [reset alarm counter]
            //            [Tx frequency]
            //            [Tx input power]
            //            [Tx Duty Cycle]
            //            [Rx Frequency]
            //            [Rx CH#1 IF Attenuator]
            //[Rx CH#2 IF Attenuator] 
            //[Rx CH#3 IF Attenuator]
            //[Rx CH#4 IF Attenuator]
            //[Rx GRD CH IF Attenuator]


            //            In order to mask the field put x int he end of the parameter.

            //            Examples:


            //            SetFullParams 0 1 80 2 35 80 20 20 20 20 20
            //            SetFullParams 0 1x 80x 2x 35 80x 20x 20x 20x 20 20

            byte[] SendFrame = new byte[40];
            String ret = "";
            int Num = 0;
            String[] tempStr = i_Command.Split(' ');

            int Num_Of_Arguments = 13;
            if (tempStr.Length != Num_Of_Arguments)
            {
                ret += String.Format("\n Arguments number should be {0}, see example", Num_Of_Arguments);
                return ret;
            }

            int i =0;
            String Command = tempStr[0];
            if (tempStr[1].Contains("_s") == true)
            {
                tempStr[1] = tempStr[1].Replace("_s", "");
                ShowStatus = true;
            }

            String CMD_Activation = tempStr[1];
            String SystemMode = tempStr[2];
            String ResetAlarmCounter = tempStr[3];
            String TxFrequency = tempStr[4];
            String TxInputPower = tempStr[5];
            String TxDutyCycle = tempStr[6];
            String RxFrequency = tempStr[7];
            String RxCh1Att = tempStr[8];
            String RxCh2Att = tempStr[9];
            String RxCh3Att = tempStr[10];
            String RxCh4Att = tempStr[11];
            String RxChGRDAtt = tempStr[12];

            List<byte> ListBytes = new List<byte>();



            //Preamble
            SendFrame[0] = 0x82;


            //Opcode
            SendFrame[1] = 0x51;


            //Messagecounter
            byte[] temp = (StringToByteArray(ReverseHexStringLittleBigEndian(MessageCounter.ToString("X4"))));
            temp.CopyTo(SendFrame, 2);
            MessageCounter++;

            //Length
            temp = StringToByteArray("28 00 00 00");
            temp.CopyTo(SendFrame, 2);

            //Activation
            if (int.TryParse(CMD_Activation, out Num) && (Num == 1 || Num == 2 || Num == 4))
            {
                temp = StringToByteArray(Num.ToString("X2"));
                temp.CopyTo(SendFrame, 8);
            }
            else
            {
                ret += String.Format("\n Argument 1 [{0}] invalid ",CMD_Activation);
            }

            //Spare
            temp = (StringToByteArray("00 00 00"));
            temp.CopyTo(SendFrame, 9);

            //TimeTag
            //String TimeTag = ConvertToUnixTimestamp(DateTime.Now).ToString("X4");
            String TimeTag = "00 00 00 00";
            temp = StringToByteArray(ReverseHexStringLittleBigEndian(TimeTag));
            temp.CopyTo(SendFrame, 12);

            //Tx Data



            if (SystemMode.EndsWith("x"))
            {
                SendFrame[16] |= (1 << 7);
                SystemMode =  SystemMode.Remove(SystemMode.Length - 1);
            }
            if (int.TryParse(SystemMode, out Num) && (Num >=0  && Num <= 3))
            {
                SendFrame[19] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 2 [{0}] invalid ", SystemMode);
            }
            i++;



            if (ResetAlarmCounter.EndsWith("x"))
            {
                SendFrame[16] |= (1 << 6);
                ResetAlarmCounter = ResetAlarmCounter.Remove(ResetAlarmCounter.Length - 1);
            }
            if (int.TryParse(ResetAlarmCounter, out Num) && (Num >= 0 && Num <= 1))
            {
                SendFrame[20] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 3 [{0}] invalid", ResetAlarmCounter);
            }
            i++;


            if (TxFrequency.EndsWith("x"))
            {
                SendFrame[16] |= (1 << 4);
                TxFrequency = TxFrequency.Remove(TxFrequency.Length - 1);
            }
            if (int.TryParse(TxFrequency, out Num) && (Num >= 0 && Num <= 80))
            {
                SendFrame[22] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 4 [{0}] invalid ", TxFrequency);
            }
            i++;

            if (TxInputPower.EndsWith("x"))
            {
                SendFrame[16] |= (1 << 3);
                TxInputPower =  TxInputPower.Remove(TxInputPower.Length - 1);
            }
            if (int.TryParse(TxInputPower, out Num) && (Num >= 0 && Num <= 80))
            {
                SendFrame[23] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 5 [{0}] invalid ", TxInputPower);
            }
            i++;

            if (TxDutyCycle.EndsWith("x"))
            {
                SendFrame[16] |= (1 << 2);
                TxDutyCycle = TxDutyCycle.Remove(TxDutyCycle.Length - 1);
            }
            if (int.TryParse(TxDutyCycle, out Num) && (Num >= 0 && Num <= 35))
            {
                SendFrame[24] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 6 [{0}] invalid ", TxDutyCycle);
            }
            i++;

            if (RxFrequency.EndsWith("x"))
            {
                SendFrame[17] |= (1 << 7);
                RxFrequency = RxFrequency.Remove(RxFrequency.Length - 1);
            }
            if (int.TryParse(RxFrequency, out Num) && (Num >= 0 && Num <= 80))
            {
                SendFrame[27] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 7 [{0}] invalid ", RxFrequency);
            }
            i++;

            if (RxCh1Att.EndsWith("x"))
            {
                SendFrame[17] |= (1 << 6);
                RxCh1Att = RxCh1Att.Remove(RxCh1Att.Length - 1);
            }
            if (int.TryParse(RxCh1Att, out Num) && (Num >= 0 && Num <= 20))
            {
                SendFrame[28] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 8 [{0}] invalid ", RxCh1Att);
            }
            i++;

            if (RxCh2Att.EndsWith("x"))
            {
                SendFrame[17] |= (1 << 5);
                RxCh2Att = RxCh2Att.Remove(RxCh2Att.Length - 1);
            }
            if (int.TryParse(RxCh2Att, out Num) && (Num >= 0 && Num <= 20))
            {
                SendFrame[29] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 9 [{0}] invalid ", RxCh2Att);
            }
            i++;

            if (RxCh3Att.EndsWith("x"))
            {
                SendFrame[17] |= (1 << 4);
                RxCh3Att = RxCh3Att.Remove(RxCh3Att.Length - 1);
            }
            if (int.TryParse(RxCh3Att, out Num) && (Num >= 0 && Num <= 20))
            {
                SendFrame[30] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 10 [{0}] invalid ", RxCh3Att);
            }
            i++;


            if (RxCh4Att.EndsWith("x"))
            {
                SendFrame[17] |= (1 << 3);
                RxCh4Att = RxCh4Att.Remove(RxCh4Att.Length - 1);
            }
            if (int.TryParse(RxCh4Att, out Num) && (Num >= 0 && Num <= 20))
            {
                SendFrame[31] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 11 [{0}] invalid ", RxCh4Att);
            }
            i++;

            if (RxChGRDAtt.EndsWith("x"))
            {
                SendFrame[17] |= (1 << 2);
                RxChGRDAtt = RxChGRDAtt.Remove(RxChGRDAtt.Length - 1);
            }
            if (int.TryParse(RxChGRDAtt, out Num) && (Num >= 0 && Num <= 20))
            {
                SendFrame[32] = (byte)Num;

            }
            else
            {
                ret += String.Format("\n Argument 12 [{0}] invalid ",  RxChGRDAtt);
            }
            i++;



            //Calculate check sum
            UInt32 CheckSum = CalculateChecksum(SendFrame);

            temp = StringToByteArray(CheckSum.ToString("X8"));
            temp.CopyTo(SendFrame, 36);


            if (ret == "" && i_OnlyCheckValidity == false)
            {
                //Execute the command
                PrintToSystemLogerTxMessage(i_Command);
                textBox_SendSerialPort.Text = ConvertByteArraytToString(SendFrame);

                button_SendSerialPort_Click(null, null);

            }

            return ret;
        }

        UInt32 CalculateChecksum(byte[] i_Bufffer)
        {
            FrameAnalizer = "";
            UInt32 CheckSum = 0;
            for (int i = 0; i < i_Bufffer.Length; i = i + 4)
            {
                byte[] tempArr = i_Bufffer.Skip(i).Take(4).ToArray();
                //byte[] temp = SendFrame.(i, 4);
                //byte[] tempArr = temp.ToArray();

                //tempArr = tempArr.Reverse().ToArray();

                FrameAnalizer += ConvertByteArraytToString(tempArr) + " +  \n";

                UInt32 Value = BitConverter.ToUInt32(tempArr, 0);

                CheckSum += Value;
            }

            FrameAnalizer += " -------------\n";
            FrameAnalizer += CheckSum.ToString("X8") + " \n";

            byte[] bytes = BitConverter.GetBytes(CheckSum);
            bytes = bytes.Reverse().ToArray();
            CheckSum = BitConverter.ToUInt32(bytes, 0);

            return CheckSum;
        }

        String FrameAnalizer = "";

        bool ShowStatus = false;
        String ReadReg32(String i_Command, bool i_OnlyCheckValidity)
        {
            String ret = "";


            String[] tempStr = i_Command.Split(' ');

            //Check Validity of the command first and retuen string error if something wrong. //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////
            ///

            if (tempStr.Length != 2)
            {
                ret += String.Format("\n Arguments number should be 2, see example");
                return ret;
            }

            if(tempStr[1].Contains("_s") == true)
            {
                tempStr[1] = tempStr[1].Replace("_s", "");
                ShowStatus = true;
            }

            byte[] buffer = StringToByteArray(tempStr[1]);

            if (buffer == null || buffer.Length != 4)
            {
                ret += String.Format("\n Argument [{0}] invalid not hex value or not 4 bytes", tempStr[1]);
                return ret;
            }

            if (i_OnlyCheckValidity == true )
            {
                return ret;
            }

            //Init all the commands //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            String Command = tempStr[0];
            String RegisterAddress32bits = tempStr[1];


            // Excute the command //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////
            List<byte> ListBytes = new List<byte>();



            //Preamble
            String Preamble = "82";
            ListBytes.AddRange(StringToByteArray(Preamble));


            //Opcode
            String Opcode = "22";
            ListBytes.AddRange(StringToByteArray(Opcode));


            //Messagecounter
            ListBytes.AddRange(StringToByteArray(ReverseHexStringLittleBigEndian(MessageCounter.ToString("X4"))));


            MessageCounter++;
            //RegisterAddress
            ListBytes.AddRange(StringToByteArray(ReverseHexStringLittleBigEndian(RegisterAddress32bits)));

            //DatatoWrite
            ListBytes.AddRange(StringToByteArray(ReverseHexStringLittleBigEndian("00 00 00 00")));

            //TimeTag
            //String TimeTag = ConvertToUnixTimestamp(DateTime.Now).ToString("X4");
            String TimeTag = "00 00 00 00";
            ListBytes.AddRange(StringToByteArray(ReverseHexStringLittleBigEndian(TimeTag)));




            //Data
            byte[] DataBytes = StringToByteArray(string.Concat(Enumerable.Repeat("00", 20)));
            ListBytes.AddRange(DataBytes);



            //Calculate check sum
            UInt32 CheckSum = CalculateChecksum(ListBytes.ToArray());


            ListBytes.AddRange(StringToByteArray(CheckSum.ToString("X8")));




            if (ret == "" && i_OnlyCheckValidity == false)
            {
                //Execute the command
                PrintToSystemLogerTxMessage(i_Command);
                textBox_SendSerialPort.Text = ConvertByteArraytToString(ListBytes.ToArray());

                button_SendSerialPort_Click(null, null);

            }






            return ret;
        }

        
        /// <summary>
        /// Gil: Each command implemintation return string if the arguments doesn't valit or empty string if every thing OK.
        /// </summary>
        /// <param name="i_Command"></param>
        /// <param name="i_OnlyCheckValidity"></param>
        /// <returns></returns>
        /// 
        //async Task<String> ExectuteOrCheckValidityCommand(String i_Command,bool i_OnlyCheckValidity)
        //{
        //    String ret;
        //    FrameAnalizer = "";
        //    String[] tempStr = i_Command.Split(' ');
        //    String CommandName = tempStr[0];


        //    switch (CommandName)
        //    {
        //        case "WriteReg32":
        //            ret = await WriteReg32(i_Command,i_OnlyCheckValidity);
        //            break;

        //        case "ReadReg32":
        //            ret = ReadReg32(i_Command,i_OnlyCheckValidity);
        //            break;

        //        case "SetFullParams":
        //            ret = SetFullParams(i_Command, i_OnlyCheckValidity);
        //            break;

        //        default:
        //            ret = String.Format("[{0}] command not implemented", i_Command);
        //           // SystemLogger.LogMessage(Color.Orange, Color.LightGray, String.Format(ret, i_Command), true, true);

        //            break;

        //    }

        //    // Gil Ramon: If the is a syntax problem the command function return the message.



        //    //SystemLogger.LogMessage(Color.Blue, Color.Azure, "", New_Line = false, Show_Time = true);
        //    //SystemLogger.LogMessage(Color.Blue, Color.Azure, "Rx:>", false, false);


        //    return ret;
        //}

        void PrintToSystemLogerTxMessage(String i_Message)
        {
            SystemLogger.LogMessage(Color.Purple, Color.Yellow, "", New_Line = false, Show_Time = true);
            SystemLogger.LogMessage(Color.Purple, Color.Yellow, "Tx:>", false, false);
            SystemLogger.LogMessage(Color.Purple, Color.Yellow, i_Message, true, false);
        }

        /// <summary>
        /// Gil: Each command implemintation return string if the arguments doesn't valit or empty string if every thing OK.
        /// </summary>
        /// <param name="i_Command"></param>
        /// <param name="i_OnlyCheckValidity"></param>
        /// <returns></returns>
        /// 
        async private Task<String> ExecuteCLICommand(String i_Command, bool i_OnlyCheckValidity)
        {
            
            String[] tempStr = i_Command.Split(' ');
            String CommandName = tempStr[0];
            String ret = "";
            bool IsCommandFound = false;
            foreach (CommandClass cmd in List_AllCommands)
            {
                if(cmd.Command_name == CommandName)
                {
                    IsCommandFound = true;

                    UpdateCommandCLIHistory(i_Command);

                    //ret = await ExectuteOrCheckValidityCommand(i_Command, false);
                    switch (CommandName)
                    {
                        case "WriteReg32":
                            ret = await WriteReg32(i_Command, i_OnlyCheckValidity);
                            break;

                        case "ReadReg32":
                            ret = ReadReg32(i_Command, i_OnlyCheckValidity);
                            break;

                        case "SetFullParams":
                            ret = SetFullParams(i_Command, i_OnlyCheckValidity);
                            break;

                        default:
                            ret = String.Format("[{0}] command not implemented", i_Command);
                             SystemLogger.LogMessage(Color.Orange, Color.LightGray, ret, true, true);

                            break;

                    }


                    if (ret != "")
                    {
                        SystemLogger.LogMessage(Color.DarkOrange, Color.White, ret, New_Line = true, Show_Time = true);
                    }
                }
            }

            if (IsCommandFound == false)
            {
                ret = String.Format("[{0}] command not found", i_Command);
                SystemLogger.LogMessage(Color.Orange, Color.LightGray, ret, true, true);
                //SystemLogger.LogMessage(Color.DarkOrange, Color.White, String.Format(" command '{0}' is not found", tempStr[0]), New_Line = true, Show_Time = true);
            }

            return ret;


        }

        private async  void button_CLISend_Click(object sender, EventArgs e)
        {
            await ExecuteCLICommand(textBox_CLISendCommands.Text,false);

            if (checkBox_CLIDeleteAfterSend.Checked == true)
            {
                textBox_CLISendCommands.Text = "";
            }
        }

        private void button_DeleteCommandsHistory_Click(object sender, EventArgs e)
        {
            Monitor.Properties.Settings.Default.CLICommad_History.Clear();
            Monitor.Properties.Settings.Default.Save();

        }

        private void textBox_CLIsendperodically_TextChanged(object sender, EventArgs e)
        {
            TextBox Txtbx = (TextBox)sender;
            if (int.TryParse(Txtbx.Text,out int result) == true)
            {
                Txtbx.BackColor = Color.LightGreen;
            }
            else
            {
                Txtbx.BackColor = Color.Red;
            }
        }

        private void listBox_CLI_ALLCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_CommandHelp.Text = List_AllCommands[listBox_CLI_ALLCommands.SelectedIndex].Help;
        }

        private void listBox_CLI_ALLCommands_Click(object sender, EventArgs e)
        {
            try 
            {
                textBox_CLISendCommands.Text = List_AllCommands[listBox_CLI_ALLCommands.SelectedIndex].Example;
            }
            catch { }
            
        }

        private void textBox_CLISendCommands_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                // MessageBox.Show("Tab");
                e.IsInputKey = true;

            }
            if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                //  MessageBox.Show("Shift + Tab");
                e.IsInputKey = true;
            }
        }



        private void ComboBox_SerialPortHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_SerialPortHistory.SelectedItem != null )
            //{
            //    if (textBox_SendSerialPort.Text != comboBox_SerialPortHistory.SelectedItem.ToString())
            //    {
            //        textBox_SendSerialPort.Text = comboBox_SerialPortHistory.SelectedItem.ToString();
            //    }
            //}
        }

        private void button_LoadScriptCLI_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = openFileDialog_Local)
            {
                string initPath = Path.GetFullPath(".");
                openFileDialog.InitialDirectory = Path.GetFullPath(initPath);
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //openFileDialog.FilterIndex = 2;
                //openFileDialog.RestoreDirectory = true;
                //dlgOpen.InitialDirectory = Path.GetFullPath(initPath);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        String[] filelines = File.ReadAllLines(filePath);
                        foreach(String line in filelines)
                        {

                                MyAppendText(richTextBox_Scripts, line + "\r\n", default, default);
                        }

                        button_CheckScriptValidity_Click(null, null);



                    }
                }
            }

        }

        private void textBox_CommandActivation_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbx = (TextBox)sender;
            string WithoutSpaces = Regex.Replace(txtbx.Text, @"\s+", "");
            byte[] buffer = StringToByteArray(WithoutSpaces);

            if (buffer != null && buffer.Length == 1)
            {
                txtbx.BackColor = Color.LightGreen;
            }
            else
            {
                txtbx.BackColor = Color.Red;
            }
        }

        private void checkBox_WriteTotalbytes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void serialPort_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            //SerialPortLogger.LogMessage(Color.White, Color.Red, "SerialPort PinChanged received: ", New_Line = true, Show_Time = true);
            //SerialPortLogger.LogMessage(Color.White, Color.Red, e.EventType.ToString(), New_Line = true, Show_Time = true);
        }

        private void button_ClearScript_Click(object sender, EventArgs e)
        {
            richTextBox_Scripts.Text = "";
        }

        public void MyAppendText(RichTextBox box, string text, Color Forecolor, Color Backcolor)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = Forecolor;
            box.SelectionBackColor = Backcolor;

            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            box.ScrollToCaret();
        }

        private void textBox_TimeBetweenComands_TextChanged(object sender, EventArgs e)
        {
            TextBox Txtbx = (TextBox)sender;
            if (int.TryParse(Txtbx.Text, out int result) == true)
            {
                Txtbx.BackColor = Color.LightGreen;

                Monitor.Properties.Settings.Default.TimeBetweenCLICommands = result.ToString();

                Monitor.Properties.Settings.Default.Save();
            }
            else
            {
                Txtbx.BackColor = Color.Red;
            }
        }

        private async void button_RunScript_Click(object sender, EventArgs e)
        {
            bool IsFirstTime = false;
            int i = 0;
            if (int.TryParse(textBox_TimeBetweenComands.Text, out int Delay) == true)
            {
                button_CheckScriptValidity.PerformClick();
                //await Task.Delay(1000);

                WriteToSystemStatus(String.Format("Total Commands: [{0}]", richTextBox_Scripts.Lines.Length), 10, Color.LightBlue);

                while (checkBox_RepeatCLIScript.Checked == true || IsFirstTime == false)
                {
                    IsFirstTime = true;
                    i = 1;
                    foreach (String line in richTextBox_Scripts.Lines)
                    {
                        if (line != null && line != String.Empty)
                        {
                            //textBox_CLISendCommands.Text = line;
                            //button_CLISend_Click(null, null);
                            
                            SystemLogger.LogMessage(Color.White, Color.Black, i.ToString()+ ":  ", false, false);
                            await ExecuteCLICommand(line, false);
                            i++;
                            await Task.Delay(Delay);


                            if (serialPort.IsOpen == false)
                            {
                                return;
                            }

                            if(StopRuunScript == true)
                            {
                                StopRuunScript = false;
                                return;
                            }
                        }
                    }
                }

            }
        }

        private void richTextBox_Scripts_TextChanged(object sender, EventArgs e)
        {
            //int i = 0;
            //foreach (String line in richTextBox_Scripts.Lines)
            //{
            //    String ret = ExectuteOrCheckValidityCommand(line, true);

            //    richTextBox_Scripts.Lines[i]
            //    i++;
            //}
        }

        private void ListBox_Charts_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < listBox_Charts.Items.Count; i++)
            {

                if (listBox_Charts.GetSelected(i) == true)
                {
                    chart1.Series[i].Enabled = true;

                    textBox_graph_XY.Invoke(new EventHandler(delegate
                    {
                        textBox_graph_XY.Text = chart1.Series[i].LegendToolTip;

                    }));
                }
                else
                {
                    chart1.Series[i].Enabled = false;
                }
            }
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void button_SaveScript_Click(object sender, EventArgs e)
        {
            using (var sfd = saveFileDialog_Local)
            {
                string initPath = Path.GetFullPath(".");
                sfd.InitialDirectory = Path.GetFullPath(initPath);
                sfd.Filter = "txt files (*.txt)|*.txt";
                //sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, richTextBox_Scripts.Text);
                }
            }
        }
        void Gil_DelaySleep(int i_MiliSeconds)
        {
            for(int i =0; i< i_MiliSeconds; i++)
            {
                Thread.Sleep(1);
            }
        }
        private async void button_CheckScriptValidity_Click(object sender, EventArgs e)
        {
            String[] temp = richTextBox_Scripts.Lines;
            richTextBox_Scripts.Text = "";
            Monitor.Properties.Settings.Default.Script.Clear();
            foreach (String line in temp)
            {
                if (line != "")
                {
                    String ret = await ExecuteCLICommand(line, true);

                    if (ret != "")
                    {
                        MyAppendText(richTextBox_Scripts, line + "\r\n", Color.Black, Color.OrangeRed);

                    }
                    else
                    {
                        MyAppendText(richTextBox_Scripts, line + "\r\n", Color.Black, Color.LightGreen);
                    }
                    Monitor.Properties.Settings.Default.Script.Add(line);
                }
            }
            

            Monitor.Properties.Settings.Default.Save();



        }

        private void ResetTimer()
        {
            textBox_TimerTime.Text = TimerMemory.ToString();
            textBox_SetTimerTime.Text = "0";
            IsTimerRunning = false;
            button_StartStopTimer.BackColor = default;
        }
        bool StopRuunScript = false; 
        private void button_StopRunScrip_Click(object sender, EventArgs e)
        {
            StopRuunScript = true;
        }

        private void cmb_StopBits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox_Scripts_Click(object sender, EventArgs e)
        {


            RichTextBox m_richtext = (RichTextBox)sender;
            //m_richtext.WordWrap = false;
            int cursorPosition = m_richtext.SelectionStart;
            int lineIndex = m_richtext.GetLineFromCharIndex(cursorPosition);
            //m_richtext.WordWrap = true;
            toolTip1.Show("Line: " + (lineIndex+1).ToString(), m_richtext,2000);
        }

        private void checkBox_Debug_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ClientPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_Openall_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Openall.Checked == true)
            {
                tabControl_Main.TabPages.Add(tabPage_ServerTCP);
                tabControl_Main.TabPages.Add(tabPage_ClientTCP);
                tabControl_Main.TabPages.Add(tabPage_charts);
            }
            else
            {
                tabControl_Main.TabPages.Remove(tabPage_ServerTCP);
                tabControl_Main.TabPages.Remove(tabPage_ClientTCP);
                tabControl_Main.TabPages.Remove(tabPage_charts);
            }
        }

        private async  void button_ScriptRunFromFile_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool IsFirstTime = false;
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = openFileDialog_Local)
            {
                string initPath = Path.GetFullPath(".");
                openFileDialog.InitialDirectory = Path.GetFullPath(initPath);
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //openFileDialog.FilterIndex = 2;
                //openFileDialog.RestoreDirectory = true;
                //dlgOpen.InitialDirectory = Path.GetFullPath(initPath);
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        String[] filelines = File.ReadAllLines(filePath);

                        WriteToSystemStatus(String.Format("Total Commands: [{0}]", filelines.Length), 10, Color.LightBlue);


                        if (int.TryParse(textBox_TimeBetweenComands.Text, out int Delay) == true)
                        {
                            while (checkBox_RepeatCLIScript.Checked == true || IsFirstTime == false)
                            {
                                IsFirstTime = true;
                                i = 1;
                                foreach (String line in filelines.ToList())
                                {
                                    if (line != null && line != String.Empty)
                                    {
                                        //textBox_CLISendCommands.Text = line;
                                        //button_CLISend_Click(null, null);

                                        SystemLogger.LogMessage(Color.White, Color.Black, i.ToString() + ":  ", false, false);
                                        await ExecuteCLICommand(line, false);
                                        i++;
                                        await Task.Delay(Delay);


                                        if (serialPort.IsOpen == false)
                                        {
                                            return;
                                        }

                                        if (StopRuunScript == true)
                                        {
                                            StopRuunScript = false;
                                            return;
                                        }
                                    }
                                }
                            }
                        }



                    }
                }
            }



           
        }

        private void Button_ResetTimer_Click(object sender, EventArgs e)
        {
            ResetTimer();
        }

        //private void comboBox_SendThrough_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    switch (comboBox_SendThrough.SelectedIndex)
        //    {
        //        case (int)eComSource.GPRS:
        //            groupBox_ServerSettings.Visible = true;
        //            gbPortSettings.Visible = false;
        //            groupBox_PhoneNumber.Visible = false;
        //            break;
        //        case (int)eComSource.SerialPort:
        //            groupBox_ServerSettings.Visible = false;
        //            gbPortSettings.Visible = true;
        //            groupBox_PhoneNumber.Visible = false;
        //            break;
        //        case (int)eComSource.SMS:
        //            groupBox_ServerSettings.Visible = false;
        //            gbPortSettings.Visible = true;
        //            groupBox_PhoneNumber.Visible = true;
        //            break;
        //    }
        //}

        //private bool m_EchoResponse = false;
        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked == true)
        //    {
        //        m_EchoResponse = true;
        //    }
        //    else
        //    {
        //        m_EchoResponse = false;
        //    }
        //}


        /*Modem Registration Status = [1], RSSI = [31], Modem GPRS = [0],
         * Temperature Level = [0],Board Temperature = [31] , Sim Status = [1] ,
         * OperatorName = ["Cellcom"], Modem Voltage = [3.924000], Modem SIMIdentificationNumber = [899720201108447424] ,
         * ModemIMEI = [354869050098417], SimIMSI = [425020110844742], ModemVersion = [Cinterion,BGS2-W,REVISION 02.000,A-REVISION 01.000.08,OK,], 
         * ModemConnectionStatus = [], ModemServiceStatus = [], ModemServiceStatus2 = [], ModemErrorServiceStatus = [], ModemEUpdateCounter = [4],*/



        //private void button57_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void button71_Click(object sender, EventArgs e)
        //{

        //}

        void SetAllCLIcommands()
        {

            CommandClass WriteReg32 = new CommandClass("WriteReg32",
@"
Description: 
Write to Register 

Number of arguments:
2 or 4

Syntax 2 arguments:
WriteReg 
address [4 hex bytes] 
data [4 hex bytes]

Syntax 4 arguments:
WriteReg 
address [4 hex bytes] 
data [4 hex bytes]
mask [4 hex bytes] - if mask is set
Delay between Read and write (only when using mask) [integer decimal]

Examples:

WriteReg32 00000000 1234ABCD
    Write to Register 00000000 1234ABCD

WriteReg32 00000000 12345678 FFFF0000 1000
    Read Register 0x00000000 modify 0xXXXX5678 and write back to 0x00000000 with delay of 1000 ms between read and write

in order to see full status add _s to the Address For example:

WriteReg32 00000000_s 1234ABCD

",
"WriteReg32 00000000 1234ABCD");

            //WriteReg32.Example = "WriteReg AAAAAAAA BBBBBBBB FFFF0000 1000";

            List_AllCommands.Add(WriteReg32);





            

            CommandClass ReadReg32 = new CommandClass("ReadReg32",
@"
Description: 
Read From Register 

Num of arguments:
1

Syntax:
ReadReg address [4 hex bytes]

Example:

ReadReg32 AAAAAAAA ---> Read from Register 0xAAAAAAAA
In order to see full status add _s in the end of the address for example:
ReadReg32 AAAAAAAA_s
",
"ReadReg32 00000000");

            List_AllCommands.Add(ReadReg32);




            CommandClass SetFullParams = new CommandClass("SetFullParams",
@"
Description: 
Set all mIFRS main parameters.

Num of arguments:
12

Syntax: (all the values decimal!!)
SetFullParams 
[cmd activation] {1,2,4}
[system mode] {0-3}
[reset alarm counter] {0-1} 
[Tx frequency] {0-80}
[Tx input power] {0-3}
[Tx Duty Cycle] {0-35}
[Rx Frequency] {0-80}
[Rx CH#1 IF Attenuator] {0-20}
[Rx CH#2 IF Attenuator] {0-20}
[Rx CH#3 IF Attenuator] {0-20}
[Rx CH#4 IF Attenuator] {0-20}
[Rx GRD CH IF Attenuator] {0-20}

In order to mask the field put x int he end of the parameter.

Examples:

SetFullParams 1 0 1 80 2 35 80 20 20 20 20 20
SetFullParams 1 0 1x 80x 2x 35 80x 20x 20x 20x 20 20
SetFullParams 1_s 0 1x 80x 2x 35 80x 20x 20x 20x 20 20 (_s - Show full status)
",
"SetFullParams 1 0 1 80 2 35 80 20 20 20 20 20");

            List_AllCommands.Add(SetFullParams);







            foreach (CommandClass cmd in List_AllCommands)
            {
                listBox_CLI_ALLCommands.Items.Add(cmd.Command_name);
            }

        }

        String CLI_Help = @"
General Format:
Command arg1 arg2 arg3...
Between Command and arguments there is single ASCII space.

For example:
Command 12 abc
-----------------------------
Use the arrows Up, Down and Tab for autocomplition.


";

        void LoadDefaultSettings()
        {
            cmb_StopBits.DataSource = Enum.GetValues(typeof(StopBits));
            cmb_StopBits.SelectedIndex = (int)StopBits.One;

            cmbParity.DataSource = Enum.GetValues(typeof(Parity));
            cmbParity.SelectedIndex = (int)Parity.None;

            txtPortNo.Text = Monitor.Properties.Settings.Default.Start_Port;
            txtDataTx.Text = Monitor.Properties.Settings.Default.Default_Server_Message;
            cmbBaudRate.Text = Monitor.Properties.Settings.Default.Comport_BaudRate;
            cmbDataBits.Text = Monitor.Properties.Settings.Default.Comport_DataBits;
            cmb_StopBits.Text = Monitor.Properties.Settings.Default.Comport_StopBit;
            cmbParity.Text = Monitor.Properties.Settings.Default.Comport_Parity;
            cmb_PortName.Text = Monitor.Properties.Settings.Default.Comport_Port;
            textBox_TimeBetweenComands.Text = Monitor.Properties.Settings.Default.TimeBetweenCLICommands;
            textBox_ClientIP.Text = Monitor.Properties.Settings.Default.IP_Client;
             textBox_ClientPort.Text = Monitor.Properties.Settings.Default.Port_Client ;

            foreach (String line in Monitor.Properties.Settings.Default.Script)
            {
                MyAppendText(richTextBox_Scripts, line + "\r\n", default, default);
            }

            //button_CheckScriptValidity_Click(null, null);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {

                tabControl_Main.TabPages.RemoveAt(0);
                tabControl_Main.TabPages.RemoveAt(0);
                tabControl_Main.TabPages.RemoveAt(0);
                


                textBox_CommandHelp.Text = CLI_Help;

                SetAllCLIcommands();

                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "0.###E+0";





               // KratosProtocolLogger = new TextBox_Logger("Kratos_Protocol", richTextBox_KratosProtocol, button_ClearKratosProtocol, null, checkBox_RecordKratosProtocol, null, null, null, null);
                ServerLogger = new TextBox_Logger("Server", TextBox_Server, button_ClearServer, checkBox_ServerPause, checkBox_ServerRecord, null, null, null, checkBox_StopLogging);
                SerialPortLogger = new TextBox_Logger("Serial_Port", SerialPortLogger_TextBox, button_ClearSerialPort, checkBox_SerialPortPause, checkBox_SerialPortRecordLog, textBox_SerialPortRecognizePattern, textBox_SerialPortRecognizePattern2, textBox_SerialPortRecognizePattern3, null);
                SystemLogger = new TextBox_Logger("SystemLogger", richTextBox_SSPA, button_ClearMiniAda, checkBox_PauseMiniAda, checkBox_RecordMiniAda, textBox_CLIrecognize1, textBox_CLIrecognize2, textBox_CLIrecognize3, checkBox_StopLogging);


                ScanComports();


                LoadDefaultSettings();


                //Gil: Set Versions Names
                string path = Directory.GetCurrentDirectory();
                string lastFolderName = Path.GetFileName(path);
                //string[] dir = Directory.GetCurrentDirectory().Split('\\');
                string version = lastFolderName;
                //if (ApplicationDeployment.IsNetworkDeployed)
                //{
                //    version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                //}
                //else
                //{
                //    version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                //}
                Text = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
                label_Projectname.Text = Text;
                Text = Text + " [ " + ", Version: " + version + ", Compiled: " + RetrieveLinkerTimestamp().ToString() + " ]";
                






                UpdateSerialPortComboBox();






                foreach (Control allContrls in Controls)
                {
                    FindControls(allContrls);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //  ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }

        }
    }


}

