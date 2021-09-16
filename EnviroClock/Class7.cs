

// EnviroClock.Dashboard
using EnviroClock;
using EnviroClock.Entity;
using EnviroClock.Helper;
using EnviroClock.Properties;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;


public class Dashboard : Form
{
	public static int olddiscnt = 0;

	public static int newdiscnt = 0;

	public int deviceonlinedashboardcnt = 0;

	public System.Windows.Forms.Timer formtimer;

	private string[] clockIP = null;

	public int k = 0;

	public Label label = new Label();

	public List<string> versionlist = new List<string>();

	private List<string> dashversionlist = new List<string>();

	private string globalportNo = Settings.Default.PortNo;

	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	private IContainer components = null;

	private ToolStrip toolStrip1;

	private ToolStripMenuItem ExitfileMenuItem;

	private Panel panel1;

	private System.Windows.Forms.Timer HomehourTimer;

	private TableLayoutPanel tableLayoutPanel2;

	private Panel panel3;

	private Label lbltimehrs;

	private Panel panel4;

	private Label lblHomeScreenDate;

	private ToolStripDropDownButton ScheduletoolStrip;

	private ToolStripMenuItem scheduleToolStripSchedule1;

	private ToolStripDropDownButton NetworksettingstoolStrip;

	private ToolStripMenuItem LANSettingToolStripMenuItem;

	private ToolStripDropDownButton FilestoolStrip;

	private ToolStripDropDownButton HelptoolStrip;

	private ToolStripMenuItem AboutUsStripMenuItem;

    private System.Windows.Forms.Timer tmrScheduleTimeZone;

	public NotifyIcon Enviroclock;

	private ToolStripMenuItem chagePasswordToolStripMenuItem;

	private ToolStripMenuItem exitToolStripMenuItem1;
    private Label lblconnected;
    private Label lbldisconnected;
    private Label lblconnectedcount;
    private Label lblDisconnectedcount;

	private System.Windows.Forms.Timer ClockCountTimer;

	public Dashboard()
	{
		this.InitializeComponent();
		this.tmrScheduleTimeZone.Interval = Convert.ToInt32(Settings.Default.Interval);
		this.tmrScheduleTimeZone.Start();
		this.Refresh();
	}

    private void ClockCountTimer_Tick(object sender, EventArgs e)
    {
        this.sendIPtoclockcount().Count();
        this.clockcount();
        this.clockdisconnectedcount();
    }

	private void Dashboard_Load(object sender, EventArgs e)
	{
        lblconnected.Visible = false;
        lbldisconnected.Visible = false;
        lblDisconnectedcount.Visible = false;
        lblconnectedcount.Visible = false;


        this.HomehourTimer.Start();
        this.lblHomeScreenDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        string[] array = this.sendIP(this.versionlist).ToArray();
        this.clockcount();
        Dashboard.olddiscnt = Convert.ToInt32(this.lblconnectedcount.Text);
        this.lblDisconnectedcount.Text = 0.ToString();
        this.ClockCountTimer.Start();
	}

    public string clockcount()
    {
        try
        {
            if (!base.IsHandleCreated)
            {
                this.CreateHandle();
            }
            base.Invoke((Action)delegate
            {
                this.lblconnectedcount.Text = this.sendIPtoclockcount().Count().ToString();
            });
            Dashboard.newdiscnt = Convert.ToInt32(this.lblconnectedcount.Text);
        }
        catch (Exception)
        {
        }
        return this.lblconnectedcount.Text;
    }

    public void clockdisconnectedcount()
    {
        Label obj = this.lblDisconnectedcount;
        int num = Dashboard.olddiscnt - Dashboard.newdiscnt;
        obj.Text = num.ToString();
        if (Convert.ToInt32(this.lblDisconnectedcount.Text) < Convert.ToInt32(this.lblconnectedcount.Text))
        {
            Label obj2 = this.lblDisconnectedcount;
            num = 0;
            obj2.Text = num.ToString();
        }
        Dashboard.olddiscnt = Dashboard.newdiscnt;
    }

	private void HomehourTimer_Tick(object sender, EventArgs e)
	{
		this.lbltimehrs.Text = DateTime.Now.ToString("HH:mm:ss");
        
        this.HomehourTimer.Start();

        

}

    

    private void toolStripExitButton_Click(object sender, EventArgs e)
	{
		Application.Exit();
		Environment.Exit(0);
	}

	private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ChangePassword changePassword = new ChangePassword();
		changePassword.ShowDialog(this);
		Dashboard.log.Info("Change Password Form Opened Sucessfully.");
	}

	private void lANToolStripMenuItem_Click(object sender, EventArgs e)
	{
		CheckPassword checkPassword = new CheckPassword();
		checkPassword.Show();
	}

	private void changePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
	{
		ChangePassword changePassword = new ChangePassword();
		changePassword.ShowDialog(this);
	}

	private void exitToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Dashboard.log.Info("Application Exit");
		Application.Exit();
		Environment.Exit(0);
		Dashboard.log.Info("Application Close Sucessfully.");
	}

	private void AboutUsStripMenuItem_Click(object sender, EventArgs e)
	{
		AboutUs aboutUs = new AboutUs();
		aboutUs.Show();
		Dashboard.log.Info("About Form Opened Successfully.");
	}

	private void scheduleToolStripSchedule1_Click(object sender, EventArgs e)
	{
		ChangePassword1 changePassword = new ChangePassword1();
		changePassword.Show();
	}

	public IList<string> sendIPtoclockcount()
	{
		List<string> list = new List<string>();
		int num = 0;
		try
		{
			Common.sb = new StringBuilder();
			string str = "$0lv,02,";
			byte[] bytes = Encoding.ASCII.GetBytes(str + Environment.NewLine);
			Common.udp_ep = new IPEndPoint(Common.ParseIPAddress("255.255.255.255"), 2001);
			Common.udp = new UdpClient();
			Common.udp.EnableBroadcast = true;
			Common.udp.Send(bytes, bytes.Length, Common.udp_ep);
			Thread.Sleep(100);
			Common.udp.BeginReceive(Common.UDP_IncomingData, null);
			Thread.Sleep(100);
			Dashboard.log.Debug("\n sendIP command   : 255.255.255.255   :  2001 :   $0lv,02,");
			string[] array = null;
			string[] array2 = Common.sb.ToString().Split('#');
			object obj = Common.sb.ToString();
			string[] array3 = array2;
			foreach (object arg in array3)
			{
				Dashboard.log.Debug("\n" + arg);
			}
			num = array2.Count();
			num = Convert.ToInt32(num) - 1;
			if (array2 != null && array2.Length > 0)
			{
				for (int j = 1; j < array2.Count(); j++)
				{
					try
					{
						array = array2[j].Split(',');
						Common.ClockVersion = Settings.Default.ClockVersion;
						if (array[4].ToString().ToLower().ToString()
							.Contains(Common.ClockVersion.ToString().ToLower()))
						{
							list.Add(array[21]);
						}
					}
					catch (Exception ex)
					{
						Dashboard.log.Error(ex.ToString());
					}
				}
			}
			return list;
		}
		catch (Exception ex2)
		{
			Dashboard.log.Error(ex2.ToString());
			return list;
		}
	}

	public IList<string> sendIP(List<string> versionlist)
	{
		int num = 0;
		try
		{
			Common.sb = new StringBuilder();
			string str = "$0lv,02,";
			byte[] bytes = Encoding.ASCII.GetBytes(str + Environment.NewLine);
			Common.udp_ep = new IPEndPoint(Common.ParseIPAddress("255.255.255.255"), 2001);
			Common.udp = new UdpClient();
			Common.udp.EnableBroadcast = true;
			Common.udp.Send(bytes, bytes.Length, Common.udp_ep);
			Thread.Sleep(100);
			Common.udp.BeginReceive(Common.UDP_IncomingData, null);
			Thread.Sleep(100);
			Dashboard.log.Debug("\n sendIP command   : 255.255.255.255   :  2001 :   $0lv,02,");
			string[] array = null;
			string[] array2 = Common.sb.ToString().Split('#');
			object obj = Common.sb.ToString();
			string[] array3 = array2;
			foreach (object arg in array3)
			{
				Dashboard.log.Debug("\n" + arg);
			}
			num = array2.Count();
			num = Convert.ToInt32(num) - 1;
			if (array2 != null && array2.Length > 0)
			{
				for (int j = 1; j < array2.Count(); j++)
				{
					try
					{
						array = array2[j].Split(',');
						Common.ClockVersion = Settings.Default.ClockVersion;
						if (array[4].ToString().ToLower().ToString()
							.Contains(Common.ClockVersion.ToString().ToLower()))
						{
							versionlist.Add(array[21]);
						}
					}
					catch (Exception ex)
					{
						Dashboard.log.Error(ex.ToString());
					}
				}
			}
			return versionlist;
		}
		catch (Exception ex2)
		{
			Dashboard.log.Error(ex2.ToString());
			return versionlist;
		}
	}

	private void tmrScheduleTimeZone_Tick(object sender, EventArgs e)
	{
        
        this.TimerWrapper();
	}

    private void TimerWrapper()
	{
		try
		{
			SettingParam settingParam = CommonHelper.ReaderXML();
			string sceduleParam = settingParam.SceduleParam1;
			string sceduleParam2 = settingParam.SceduleParam2;
			object[] array = new object[5];
			object[] array2 = array;
			DateTime now = DateTime.Now;
			array2[0] = now.Hour;
			array[1] = ":";
			object[] array3 = array;
			now = DateTime.Now;
			array3[2] = now.Minute;
			array[3] = ":";
			object[] array4 = array;
			now = DateTime.Now;
			array4[4] = now.Second;
			string s = string.Concat(array);
			LANSetting lANSetting = new LANSetting();
            if (TimeSpan.Compare(TimeSpan.Parse(sceduleParam), TimeSpan.Parse(s)) == 0 || TimeSpan.Compare(TimeSpan.Parse(sceduleParam2), TimeSpan.Parse(s)) == 0)
			{
				Schedule schedule = new Schedule();
                LANSetting lANSetting2 = new LANSetting(); 
				string[] array5 = this.sendIP(this.versionlist).ToArray();
                List<string> lines = System.IO.File.ReadLines(Directory.GetCurrentDirectory() + "\\TEMP.txt").ToList();

                foreach (string text in lines)
				{
					Schedule schedule2 = schedule;
					string ipAddress = text;
                    string portNo = "1234";//
                    //string portNo = ConfigurationManager.AppSettings["GatePassSavePath"];

                    array = new object[15]
					{
						"lK,1,",
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					object[] array6 = array;
					now = DateTime.Now;
					array6[1] = now.Hour;
					array[2] = ",";
					object[] array7 = array;
					now = DateTime.Now;
					array7[3] = now.Minute;
					array[4] = ",";
					object[] array8 = array;
					now = DateTime.Now;
					array8[5] = now.Second;
					array[6] = ",";
					object[] array9 = array;
					now = DateTime.Now;
					array9[7] = now.Day;
					array[8] = ",";
					object[] array10 = array;
					now = DateTime.Now;
					array10[9] = now.Month;
					array[10] = ",";
					object[] array11 = array;
					now = DateTime.Now;
					array11[11] = now.Year;
					array[12] = ",";
					object[] array12 = array;
					now = DateTime.Now;
					array12[13] = now.DayOfWeek;
					array[14] = ",";
					if (schedule2.ClockSync(0, ipAddress, portNo, string.Concat(array)))
					{
						Dashboard.log.Info("Clock set time is :" + sceduleParam);
					}
				}
			}
			if (TimeSpan.Compare(TimeSpan.Parse(sceduleParam2), TimeSpan.Parse(s)) == 0)
			{
				Schedule schedule = new Schedule();
				LANSetting lANSetting2 = new LANSetting();
				string[] array5 = this.sendIP(this.versionlist).ToArray();
				foreach (string text in array5)
				{
					Schedule schedule3 = schedule;
					string ipAddress2 = text;
					string portNo2 = this.globalportNo;
					array = new object[15]
					{
						"lK,1,",
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					object[] array13 = array;
					now = DateTime.Now;
					array13[1] = now.Hour;
					array[2] = ",";
					object[] array14 = array;
					now = DateTime.Now;
					array14[3] = now.Minute;
					array[4] = ",";
					object[] array15 = array;
					now = DateTime.Now;
					array15[5] = now.Second;
					array[6] = ",";
					object[] array16 = array;
					now = DateTime.Now;
					array16[7] = now.Day;
					array[8] = ",";
					object[] array17 = array;
					now = DateTime.Now;
					array17[9] = now.Month;
					array[10] = ",";
					object[] array18 = array;
					now = DateTime.Now;
					array18[11] = now.Year;
					array[12] = ",";
					object[] array19 = array;
					now = DateTime.Now;
					array19[13] = now.DayOfWeek;
					array[14] = ",";
					if (schedule3.ClockSync(0, ipAddress2, portNo2, string.Concat(array)))
					{
						Dashboard.log.Info("Clock set time is :" + sceduleParam2);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Dashboard.log.Error(ex.ToString());
		}
	}

	private void Dashboard_Resize(object sender, EventArgs e)
	{
		bool flag = Screen.GetWorkingArea(this).Contains(Cursor.Position);
		if (base.WindowState == FormWindowState.Minimized && flag)
		{
			base.ShowInTaskbar = false;
			this.Enviroclock.Visible = true;
			base.Hide();
		}
	}

	private void Enviroclock_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		base.Show();
		base.WindowState = FormWindowState.Normal;
		this.Enviroclock.Visible = false;
	}

	private void chagePasswordToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ChangePassword changePassword = new ChangePassword();
		changePassword.ShowDialog(this);
	}

	private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
	{
		FormWindowState formWindowState = FormWindowState.Minimized;
		if (formWindowState == FormWindowState.Minimized)
		{
			base.ShowInTaskbar = true;
			this.Enviroclock.Visible = true;
			e.Cancel = true;
            //Hide();
			base.WindowState = FormWindowState.Minimized;
		}
	}

	private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		Dashboard.log.Info("Application Exit");
		Application.Exit();
		Environment.Exit(0);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.components != null)
		{
			this.components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FilestoolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.chagePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NetworksettingstoolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.LANSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduletoolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.scheduleToolStripSchedule1 = new System.Windows.Forms.ToolStripMenuItem();
            this.HelptoolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.AboutUsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HomehourTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbltimehrs = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblHomeScreenDate = new System.Windows.Forms.Label();
            this.ExitfileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrScheduleTimeZone = new System.Windows.Forms.Timer(this.components);
            this.Enviroclock = new System.Windows.Forms.NotifyIcon(this.components);
            this.ClockCountTimer = new System.Windows.Forms.Timer(this.components);
            this.lblconnected = new System.Windows.Forms.Label();
            this.lbldisconnected = new System.Windows.Forms.Label();
            this.lblDisconnectedcount = new System.Windows.Forms.Label();
            this.lblconnectedcount = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilestoolStrip,
            this.NetworksettingstoolStrip,
            this.ScheduletoolStrip,
            this.HelptoolStrip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(992, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // FilestoolStrip
            // 
            this.FilestoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FilestoolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chagePasswordToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.FilestoolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilestoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FilestoolStrip.Name = "FilestoolStrip";
            this.FilestoolStrip.Size = new System.Drawing.Size(46, 24);
            this.FilestoolStrip.Text = "File";
            // 
            // chagePasswordToolStripMenuItem
            // 
            this.chagePasswordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chagePasswordToolStripMenuItem.Image")));
            this.chagePasswordToolStripMenuItem.Name = "chagePasswordToolStripMenuItem";
            this.chagePasswordToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.chagePasswordToolStripMenuItem.Text = "Chage Password";
            this.chagePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem1.Image")));
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(192, 24);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // NetworksettingstoolStrip
            // 
            this.NetworksettingstoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NetworksettingstoolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LANSettingToolStripMenuItem});
            this.NetworksettingstoolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NetworksettingstoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NetworksettingstoolStrip.Name = "NetworksettingstoolStrip";
            this.NetworksettingstoolStrip.Size = new System.Drawing.Size(137, 24);
            this.NetworksettingstoolStrip.Text = "Network Setting";
            this.NetworksettingstoolStrip.Click += new System.EventHandler(this.NetworksettingstoolStrip_Click);
            // 
            // LANSettingToolStripMenuItem
            // 
            this.LANSettingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LANSettingToolStripMenuItem.Image")));
            this.LANSettingToolStripMenuItem.Name = "LANSettingToolStripMenuItem";
            this.LANSettingToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
            this.LANSettingToolStripMenuItem.Text = "LAN Setting";
            this.LANSettingToolStripMenuItem.Click += new System.EventHandler(this.lANToolStripMenuItem_Click);
            // 
            // ScheduletoolStrip
            // 
            this.ScheduletoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ScheduletoolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleToolStripSchedule1});
            this.ScheduletoolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScheduletoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScheduletoolStrip.Name = "ScheduletoolStrip";
            this.ScheduletoolStrip.Size = new System.Drawing.Size(84, 24);
            this.ScheduletoolStrip.Text = "Schedule";
            // 
            // scheduleToolStripSchedule1
            // 
            this.scheduleToolStripSchedule1.Image = ((System.Drawing.Image)(resources.GetObject("scheduleToolStripSchedule1.Image")));
            this.scheduleToolStripSchedule1.Name = "scheduleToolStripSchedule1";
            this.scheduleToolStripSchedule1.Size = new System.Drawing.Size(149, 24);
            this.scheduleToolStripSchedule1.Text = "Schedule1";
            this.scheduleToolStripSchedule1.Click += new System.EventHandler(this.scheduleToolStripSchedule1_Click);
            // 
            // HelptoolStrip
            // 
            this.HelptoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HelptoolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutUsStripMenuItem});
            this.HelptoolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelptoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelptoolStrip.Name = "HelptoolStrip";
            this.HelptoolStrip.Size = new System.Drawing.Size(54, 24);
            this.HelptoolStrip.Text = "Help";
            // 
            // AboutUsStripMenuItem
            // 
            this.AboutUsStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AboutUsStripMenuItem.Image")));
            this.AboutUsStripMenuItem.Name = "AboutUsStripMenuItem";
            this.AboutUsStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.AboutUsStripMenuItem.Text = "About Us";
            this.AboutUsStripMenuItem.Click += new System.EventHandler(this.AboutUsStripMenuItem_Click);
            // 
            // HomehourTimer
            // 
            this.HomehourTimer.Tick += new System.EventHandler(this.HomehourTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 665);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel2.BackgroundImage")));
            this.tableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(992, 665);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblconnectedcount);
            this.panel3.Controls.Add(this.lblDisconnectedcount);
            this.panel3.Controls.Add(this.lbldisconnected);
            this.panel3.Controls.Add(this.lblconnected);
            this.panel3.Controls.Add(this.lbltimehrs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 269);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 392);
            this.panel3.TabIndex = 0;
            // 
            // lbltimehrs
            // 
            this.lbltimehrs.AutoSize = true;
            this.lbltimehrs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltimehrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltimehrs.Location = new System.Drawing.Point(197, 0);
            this.lbltimehrs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltimehrs.Name = "lbltimehrs";
            this.lbltimehrs.Size = new System.Drawing.Size(290, 137);
            this.lbltimehrs.TabIndex = 0;
            this.lbltimehrs.Text = "time";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblHomeScreenDate);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(4, 129);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(984, 132);
            this.panel4.TabIndex = 1;
            // 
            // lblHomeScreenDate
            // 
            this.lblHomeScreenDate.AutoSize = true;
            this.lblHomeScreenDate.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomeScreenDate.Location = new System.Drawing.Point(169, 58);
            this.lblHomeScreenDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHomeScreenDate.Name = "lblHomeScreenDate";
            this.lblHomeScreenDate.Size = new System.Drawing.Size(117, 55);
            this.lblHomeScreenDate.TabIndex = 0;
            this.lblHomeScreenDate.Text = "Date";
            this.lblHomeScreenDate.Click += new System.EventHandler(this.lblHomeScreenDate_Click);
            // 
            // ExitfileMenuItem
            // 
            this.ExitfileMenuItem.Name = "ExitfileMenuItem";
            this.ExitfileMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitfileMenuItem.Text = "Exit";
            this.ExitfileMenuItem.ToolTipText = "Exit";
            // 
            // tmrScheduleTimeZone
            // 
            this.tmrScheduleTimeZone.Tick += new System.EventHandler(this.tmrScheduleTimeZone_Tick);
            // 
            // Enviroclock
            // 
            this.Enviroclock.Text = "Enviroclock";
            this.Enviroclock.Visible = true;
            this.Enviroclock.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Enviroclock_MouseDoubleClick);
            // 
            // ClockCountTimer
            // 
            this.ClockCountTimer.Interval = 60000;
            this.ClockCountTimer.Tick += new System.EventHandler(this.ClockCountTimer_Tick);
            // 
            // lblconnected
            // 
            this.lblconnected.AutoSize = true;
            this.lblconnected.Location = new System.Drawing.Point(218, 238);
            this.lblconnected.Name = "lblconnected";
            this.lblconnected.Size = new System.Drawing.Size(52, 18);
            this.lblconnected.TabIndex = 1;
            this.lblconnected.Text = "label1";
            // 
            // lbldisconnected
            // 
            this.lbldisconnected.AutoSize = true;
            this.lbldisconnected.Location = new System.Drawing.Point(542, 238);
            this.lbldisconnected.Name = "lbldisconnected";
            this.lbldisconnected.Size = new System.Drawing.Size(52, 18);
            this.lbldisconnected.TabIndex = 2;
            this.lbldisconnected.Text = "label1";
            // 
            // lblDisconnectedcount
            // 
            this.lblDisconnectedcount.AutoSize = true;
            this.lblDisconnectedcount.Location = new System.Drawing.Point(614, 238);
            this.lblDisconnectedcount.Name = "lblDisconnectedcount";
            this.lblDisconnectedcount.Size = new System.Drawing.Size(52, 18);
            this.lblDisconnectedcount.TabIndex = 3;
            this.lblDisconnectedcount.Text = "label1";
            // 
            // lblconnectedcount
            // 
            this.lblconnectedcount.AutoSize = true;
            this.lblconnectedcount.Location = new System.Drawing.Point(296, 238);
            this.lblconnectedcount.Name = "lblconnectedcount";
            this.lblconnectedcount.Size = new System.Drawing.Size(52, 18);
            this.lblconnectedcount.TabIndex = 4;
            this.lblconnectedcount.Text = "label1";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

	}

    private void NetworksettingstoolStrip_Click(object sender, EventArgs e)
    {

    }

    private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void lblconnected_Click(object sender, EventArgs e)
    {

    }

    private void lbldisconnected_Click(object sender, EventArgs e)
    {

    }

    private void lblHomeScreenDate_Click(object sender, EventArgs e)
    {

    }
}
