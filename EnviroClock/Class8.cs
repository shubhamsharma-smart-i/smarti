

// EnviroClock.LANSetting
using EnviroClock;
using EnviroClock.Properties;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.NetworkInformation;

public class LANSetting : Form
{
	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	public string IPAddressData;

	private string PortNo = string.Empty;

	private string globalportNo = Settings.Default.PortNo;

	public List<string> versionlist = new List<string>();

	private IContainer components = null;

    private TableLayoutPanel tableLayoutPanelforLANSetting;

    private TableLayoutPanel tableLayoutPanel1;

    private Panel panel1;

	private TextBox txtdeviceping;

	private Label lblpingdevice;

    private Panel panel2;

    private TextBox txtsubnetmask;

    private Label label4;

    private TextBox txtgateway;

    private Label label3;

    private Label label1;

    private Button btnnewIP;

    private TextBox txtnewip;

    private Label label5;

    private Panel panel3;

    private DataGridView grdLanSetting;

	private Button btndeviceping;

	private Button btnmanualsync;

	private TextBox txtdevicename;

	private Label label6;
    private Button button1;
    private Button btnrefreshform;
    private TextBox txtSlaveID;
    private FileStream fs;

    public LANSetting()
	{
		this.InitializeComponent();
	}

	public bool validation()
	{
		if (string.IsNullOrEmpty(this.txtnewip.Text))
		{
			MessageBox.Show("Please Enter the New IP", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return false;
		}
		if (string.IsNullOrEmpty(this.txtgateway.Text))
		{
			MessageBox.Show("Please Enter the Gateway", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return false;
		}
		if (string.IsNullOrEmpty(this.txtsubnetmask.Text))
		{
			MessageBox.Show("Please Enter the SubnetMask", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return false;
		}
		if (string.IsNullOrEmpty(this.txtdevicename.Text))
		{
			MessageBox.Show("Please Enter Device Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return false;
		}
		if (this.txtdevicename.Text.Length > 16)
		{
			MessageBox.Show("Device Name Maximum 16 Characters long.");
			return false;
		}
		return true;
	}

	public bool ValidateIPv4(string ipString)
	{
		if (string.IsNullOrWhiteSpace(ipString))
		{
			return false;
		}
		string[] array = ipString.Split('.');
		if (array.Length != 4)
		{
			return false;
		}
		byte tempForParsing;
		return array.All((string r) => byte.TryParse(r, out tempForParsing));
	}

	private void frmLANSetting_Load(object sender, EventArgs e)
	{
        button1.Enabled = false;
        btnmanualsync.Enabled = false;
        grdLanSetting.Visible = false;
        txtSlaveID.Visible = false;
        label5.Visible = false;
        btnrefreshform.Visible = false;
        txtnewip.Visible = false;
        label1.Visible = false;
        label3.Visible = false;
        txtgateway.Visible = false;
        label4.Visible = false;
        txtsubnetmask.Visible = false;
        label6.Visible = false;
        txtdevicename.Visible = false;
        btnnewIP.Visible = false;
        //btnmanualsync.Visible = false;


        //try
        //{
        //    Common.sb = new StringBuilder();
        //    string str = "$0lv,02,";
        //    byte[] bytes = Encoding.ASCII.GetBytes(str + Environment.NewLine);
        //    Common.udp_ep = new IPEndPoint(Common.ParseIPAddress("255.255.255.255"), 2001);
        //    Common.udp = new UdpClient();
        //    Common.udp.EnableBroadcast = true;
        //    Common.udp.Send(bytes, bytes.Length, Common.udp_ep);
        //    Thread.Sleep(100);
        //    Common.udp.BeginReceive(Common.UDP_IncomingData, null);
        //    Thread.Sleep(100);
        //    int num = 0;
        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("IP Address", typeof(string));
        //    dataTable.Columns.Add("Subnet Mask", typeof(string));
        //    dataTable.Columns.Add("GateWay IP", typeof(string));
        //    dataTable.Columns.Add("Device Name", typeof(string));
        //    dataTable.Columns.Add("Version", typeof(string));
        //    dataTable.Columns.Add("MAC Address", typeof(string));
        //    string[] array = null;
        //    string[] array2 = Common.sb.ToString().Split('#');
        //    object obj = Common.sb.ToString();
        //    string[] array3 = array2;
        //    foreach (object arg in array3)
        //    {
        //        LANSetting.log.Debug("\n" + arg);
        //    }
        //    num = array2.Count();
        //    num = Convert.ToInt32(num) - 1;
        //    if (array2 != null && array2.Length > 0)
        //    {
        //        for (int j = 1; j < array2.Count(); j++)
        //        {
        //            try
        //            {
        //                array = array2[j].Split(',');
        //                DataRow dataRow = dataTable.NewRow();
        //                dataRow["IP Address"] = array[21];
        //                try
        //                {
        //                    if (this.ValidateIPv4(array[21]))
        //                    {
        //                        dataRow["Subnet Mask"] = ServiceResponse.GetResponse("lu,102,", 2, array[21], array[8]);
        //                    }
        //                }
        //                catch
        //                {
        //                    dataRow["Subnet Mask"] = "";
        //                }
        //                try
        //                {
        //                    if (this.ValidateIPv4(array[21]))
        //                    {
        //                        dataRow["GateWay IP"] = ServiceResponse.GetResponse("lu,103,", 2, array[21], array[8]);
        //                    }
        //                }
        //                catch
        //                {
        //                    dataRow["GateWay IP"] = "";
        //                }
        //                dataRow["Device Name"] = array[5];
        //                dataRow["Version"] = array[4];
        //                Common.ClockVersion = Settings.Default.ClockVersion;
        //                if (array[4].ToString().ToLower().ToString()
        //                    .Contains(Common.ClockVersion.ToString().ToLower()))
        //                {
        //                    this.versionlist.Add(array[21]);
        //                }
        //                dataRow["MAC Address"] = array[20];
        //                dataTable.Rows.Add(dataRow);
        //            }
        //            catch (Exception ex)
        //            {
        //                LANSetting.log.Error(ex.ToString());
        //            }
        //        }
        //        if (dataTable != null && dataTable.Rows.Count > 0)
        //        {
        //            this.grdLanSetting.DataSource = dataTable;
        //            this.grdLanSetting.Columns[0].Visible = true;
        //            this.grdLanSetting.Columns["IP Address"].Width = 110;
        //            this.grdLanSetting.Columns["Subnet Mask"].Width = 120;
        //            this.grdLanSetting.Columns["GateWay IP"].Width = 100;
        //            this.grdLanSetting.Columns["Device Name"].Width = 130;
        //            this.grdLanSetting.Columns["Version"].Width = 100;
        //            this.grdLanSetting.Columns["MAC Address"].Width = 120;
        //        }
        //    }
        //}
        //catch (Exception ex2)
        //{
        //    LANSetting.log.Error(ex2.ToString());
        //}
	}

   

    public void IPSet()
    {


        try
        {
            Common.sb = new StringBuilder();
            string str = "$0lv,02,";
            byte[] bytes = Encoding.ASCII.GetBytes(str + Environment.NewLine);
            Common.udp_ep = new IPEndPoint(Common.ParseIPAddress(txtdeviceping.Text), 2001);
            Common.udp = new UdpClient();
            Common.udp.EnableBroadcast = true;
            Common.udp.Send(bytes, bytes.Length, Common.udp_ep);
            Thread.Sleep(100);
            Common.udp.BeginReceive(Common.UDP_IncomingData, null);
            Thread.Sleep(100);
            int num = 0;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("IP Address", typeof(string));
            dataTable.Columns.Add("Subnet Mask", typeof(string));
            dataTable.Columns.Add("GateWay IP", typeof(string));
            dataTable.Columns.Add("Device Name", typeof(string));
            dataTable.Columns.Add("Version", typeof(string));
            dataTable.Columns.Add("MAC Address", typeof(string));
            string[] array = null;
            string[] array2 = Common.sb.ToString().Split('#');
            object obj = Common.sb.ToString();
            string[] array3 = array2;
            foreach (object arg in array3)
            {
                LANSetting.log.Debug("\n" + arg);
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
                        DataRow dataRow = dataTable.NewRow();
                        dataRow["IP Address"] = array[21];
                        try
                        {
                            if (this.ValidateIPv4(array[21]))
                            {
                                dataRow["Subnet Mask"] = ServiceResponse.GetResponse("lu,102,", 2, array[21], array[8]);
                            }
                        }
                        catch
                        {
                            dataRow["Subnet Mask"] = "";
                        }
                        try
                        {
                            if (this.ValidateIPv4(array[21]))
                            {
                                dataRow["GateWay IP"] = ServiceResponse.GetResponse("lu,103,", 2, array[21], array[8]);
                            }
                        }
                        catch
                        {
                            dataRow["GateWay IP"] = "";
                        }
                        dataRow["Device Name"] = array[5];
                        dataRow["Version"] = array[4];
                        Common.ClockVersion = Settings.Default.ClockVersion;
                        if (array[4].ToString().ToLower().ToString()
                            .Contains(Common.ClockVersion.ToString().ToLower()))
                        {
                            this.versionlist.Add(array[21]);
                        }
                        dataRow["MAC Address"] = array[20];
                        dataTable.Rows.Add(dataRow);
                    }
                    catch (Exception ex)
                    {
                        LANSetting.log.Error(ex.ToString());
                    }
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.grdLanSetting.DataSource = dataTable;
                    this.grdLanSetting.Columns[0].Visible = true;
                    this.grdLanSetting.Columns["IP Address"].Width = 110;
                    this.grdLanSetting.Columns["Subnet Mask"].Width = 120;
                    this.grdLanSetting.Columns["GateWay IP"].Width = 100;
                    this.grdLanSetting.Columns["Device Name"].Width = 130;
                    this.grdLanSetting.Columns["Version"].Width = 100;
                    this.grdLanSetting.Columns["MAC Address"].Width = 120;
                }
            }
        }
        catch (Exception ex2)
        {
            LANSetting.log.Error(ex2.ToString());
        }


    
    }


    private void btnnewIP_Click(object sender, EventArgs e)
	{
		bool flag = false;
		if (this.validation())
		{
			this.SetParameter();
		}
	}

	public void SetParameter()
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		try
		{
			if (ServiceResponse.SetResponse("lu,01," + this.txtnewip.Text + ",", this.IPAddressData, this.PortNo.ToString()))
			{
				this.grdLanSetting.CurrentRow.Cells["IP Address"].Value = this.txtnewip.Text;
				LANSetting.log.Info(this.IPAddressData + "IP Address Changed. to " + this.txtnewip.Text);
			}
			else
			{
				MessageBox.Show("Failed to set IP Address. Please try again!!");
			}
			if (ServiceResponse.SetResponse("lu,03," + this.txtgateway.Text + ",", this.IPAddressData, this.PortNo.ToString()))
			{
				this.grdLanSetting.CurrentRow.Cells["GateWay IP"].Value = this.txtgateway.Text;
				LANSetting.log.Info(this.IPAddressData + "Gateway IP Changed " + this.txtgateway.Text);
			}
			else
			{
				MessageBox.Show("Failed to set GateWay. Please try again!!");
			}
			if (ServiceResponse.SetResponse("lu,02," + this.txtsubnetmask.Text + ",", this.IPAddressData, this.PortNo.ToString()))
			{
				this.grdLanSetting.CurrentRow.Cells["Subnet Mask"].Value = this.txtsubnetmask.Text;
				LANSetting.log.Info(this.IPAddressData + "Subnet Mask Changed  " + this.txtsubnetmask.Text);
			}
			else
			{
				MessageBox.Show("Failed to set Subnet Mask. Please try again!!");
			}
			if (ServiceResponse.SetResponse("lv,50," + this.txtdevicename.Text + ",", this.IPAddressData, this.PortNo.ToString()))
			{
				this.grdLanSetting.CurrentRow.Cells["Device Name"].Value = this.txtdevicename.Text;
				LANSetting.log.Info(this.IPAddressData + " Device Name Changed " + this.txtdevicename);
			}
			else
			{
				MessageBox.Show("Failed to set Device Name Please try again!!");
			}
			MessageBox.Show("Changed Settings\n IP:" + this.txtnewip.Text + "\n SubnetMask :" + this.txtsubnetmask.Text + "\n GatewayIP : " + this.txtgateway.Text + "\n Devicename : " + this.txtdevicename.Text);
			bool flag = ServiceResponse.SetResponse("lM,10,123,", this.IPAddressData, this.PortNo.ToString());
		}
		catch (Exception ex)
		{
			LANSetting.log.Error(ex.ToString());
		}
	}

    public void Main(string[] args)
    {
        try
        {
            Ping myPing = new Ping();
            PingReply reply = myPing.Send("192.168.1.3", 1000);
            if (reply != null)
            {
                //Console.WriteLine("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                ////Console.WriteLine(reply.ToString());

            }
        }
        catch(Exception ex)
        {
            MessageBox.Show("Enter valid IPAddress");
        }
        Console.ReadKey();
    }




	private void btndeviceping_Click(object sender, EventArgs e)
	{
		try
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			string str = " ping " + this.txtdeviceping.Text;
			processStartInfo.UseShellExecute = true;
			processStartInfo.FileName = "C:\\Windows\\System32\\cmd.exe";
			processStartInfo.Arguments = "/c" + str;
			Process.Start(processStartInfo);
            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send(txtdeviceping.Text, 1000);
                if (reply.Address != null)
                {
                    //Console.WriteLine("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                    ////Console.WriteLine(reply.ToString());
                    button1.Enabled = true;
                    btnmanualsync.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Enter valid IPAddress");
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter valid IPAddress");
            }
		}
		catch (Exception ex)
		{
			LANSetting.log.Error(ex.ToString());
		}
		finally
		{
			LANSetting.log.Info("Ping IP " + this.txtdeviceping.Text);
		}
	}

	private void grdLanSetting_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			this.grdLanSetting.CurrentRow.Selected = true;
			string empty = string.Empty;
			empty = this.grdLanSetting.Rows[e.RowIndex].Cells["IP Address"].FormattedValue.ToString();
			if (empty != null || empty != "")
			{
				TextBox textBox = this.txtnewip;
				string text2 = this.IPAddressData = (textBox.Text = this.grdLanSetting.Rows[e.RowIndex].Cells["IP Address"].FormattedValue.ToString());
				this.PortNo = Settings.Default.PortNo;
				this.txtgateway.Text = this.grdLanSetting.Rows[e.RowIndex].Cells["GateWay IP"].FormattedValue.ToString();
				this.txtsubnetmask.Text = this.grdLanSetting.Rows[e.RowIndex].Cells["Subnet Mask"].FormattedValue.ToString();
				this.txtdevicename.Text = this.grdLanSetting.Rows[e.RowIndex].Cells["Device Name"].FormattedValue.ToString();
			}
		}
		catch (Exception ex)
		{
			LANSetting.log.Error(ex.ToString());
		}
	}

	private void btnManualSync_Click(object sender, EventArgs e)
	{
		this.Manualsyncdata();
	}

	public void dateformat()
	{
	}

	public void Manualsyncdata()
	{
		try
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			Schedule schedule = new Schedule();
            string[] array = this.versionlist.ToArray();
            List<string> lines = System.IO.File.ReadLines(Directory.GetCurrentDirectory() + "\\TEMP.txt").ToList();
            DateTime now;
			object[] array2;
			foreach (string text in lines)
			{
				Schedule schedule2 = schedule;
				string ipAddress = text;
				string portNo = "1234";
				array2 = new object[15]
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
				object[] array3 = array2;
				now = DateTime.Now;
				array3[1] = now.Hour;
				array2[2] = ",";
				object[] array4 = array2;
				now = DateTime.Now;
				array4[3] = now.Minute;
				array2[4] = ",";
				object[] array5 = array2;
				now = DateTime.Now;
				array5[5] = now.Second;
				array2[6] = ",";
				object[] array6 = array2;
				now = DateTime.Now;
				array6[7] = now.Day;
				array2[8] = ",";
				object[] array7 = array2;
				now = DateTime.Now;
				array7[9] = now.Month;
				array2[10] = ",";
				object[] array8 = array2;
				now = DateTime.Now;
				array8[11] = now.Year;
				array2[12] = ",";
				object[] array9 = array2;
				now = DateTime.Now;
				array9[13] = now.DayOfWeek;
				array2[14] = ",";




				if (schedule2.ClockSync(0, ipAddress, portNo, string.Concat(array2)))
				{
					ILog obj = LANSetting.log;
					array2 = new object[6]
					{
						"Clock set time is :",
						null,
						null,
						null,
						null,
						null
					};
					object[] array10 = array2;
					now = DateTime.Now;
					array10[1] = now.Hour;
					array2[2] = ":";
					object[] array11 = array2;
					now = DateTime.Now;
					array11[3] = now.Minute;
					array2[4] = ":";
					object[] array12 = array2;
					now = DateTime.Now;
					array12[5] = now.Second;
					obj.Info(string.Concat(array2));
				}
			}
			now = DateTime.Now;
			int num;
			object text2;
			if (now.Minute >= 0)
			{
				now = DateTime.Now;
				if (now.Minute > 9)
				{
					goto IL_0200;
				}
				now = DateTime.Now;
				num = now.Minute;
				text2 = "0" + num.ToString();
				goto IL_023a;
			}
			goto IL_0200;
		IL_0200:
			now = DateTime.Now;
			num = now.Minute;
			text2 = num.ToString();
			goto IL_023a;
		IL_023a:
			empty = (string)text2;
			now = DateTime.Now;
			object text3;
			if (now.Second >= 0)
			{
				now = DateTime.Now;
				if (now.Second > 9)
				{
					goto IL_025f;
				}
				now = DateTime.Now;
				num = now.Second;
				text3 = "0" + num.ToString();
				goto IL_0299;
			}
			goto IL_025f;
		IL_025f:
			now = DateTime.Now;
			num = now.Second;
			text3 = num.ToString();
			goto IL_0299;
		IL_0299:
			empty2 = (string)text3;
			array2 = new object[6]
			{
				"Manually Set Time is  ",
				null,
				null,
				null,
				null,
				null
			};
			object[] array13 = array2;
			now = DateTime.Now;
			array13[1] = now.Hour;
			array2[2] = ":";
			array2[3] = empty;
			array2[4] = ":";
			array2[5] = empty2;
			MessageBox.Show(string.Concat(array2));
            
		}
		catch (Exception ex)
		{
			LANSetting.log.Error(ex.ToString());
		}
	}

	private void btnrefreshform_Click(object sender, EventArgs e)
	{
		LANSetting lANSetting = new LANSetting();
        IPSet();
		base.Close();
		lANSetting.Show();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LANSetting));
            this.tableLayoutPanelforLANSetting = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnrefreshform = new System.Windows.Forms.Button();
            this.btndeviceping = new System.Windows.Forms.Button();
            this.txtdeviceping = new System.Windows.Forms.TextBox();
            this.lblpingdevice = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSlaveID = new System.Windows.Forms.TextBox();
            this.txtdevicename = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnmanualsync = new System.Windows.Forms.Button();
            this.btnnewIP = new System.Windows.Forms.Button();
            this.txtsubnetmask = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtgateway = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnewip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdLanSetting = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelforLANSetting.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLanSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelforLANSetting
            // 
            this.tableLayoutPanelforLANSetting.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelforLANSetting.ColumnCount = 2;
            this.tableLayoutPanelforLANSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.68966F));
            this.tableLayoutPanelforLANSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.31035F));
            this.tableLayoutPanelforLANSetting.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanelforLANSetting.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanelforLANSetting.Location = new System.Drawing.Point(312, 52);
            this.tableLayoutPanelforLANSetting.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelforLANSetting.Name = "tableLayoutPanelforLANSetting";
            this.tableLayoutPanelforLANSetting.RowCount = 1;
            this.tableLayoutPanelforLANSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelforLANSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelforLANSetting.Size = new System.Drawing.Size(1299, 731);
            this.tableLayoutPanelforLANSetting.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.92946F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.07054F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 705);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btndeviceping);
            this.panel1.Controls.Add(this.txtdeviceping);
            this.panel1.Controls.Add(this.lblpingdevice);
            this.panel1.Controls.Add(this.btnmanualsync);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 252);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(24, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnrefreshform
            // 
            this.btnrefreshform.BackColor = System.Drawing.Color.SteelBlue;
            this.btnrefreshform.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnrefreshform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefreshform.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefreshform.Location = new System.Drawing.Point(26, 376);
            this.btnrefreshform.Margin = new System.Windows.Forms.Padding(4);
            this.btnrefreshform.Name = "btnrefreshform";
            this.btnrefreshform.Size = new System.Drawing.Size(193, 47);
            this.btnrefreshform.TabIndex = 3;
            this.btnrefreshform.Text = "Refersh";
            this.btnrefreshform.UseVisualStyleBackColor = false;
            this.btnrefreshform.Click += new System.EventHandler(this.btnrefreshform_Click);
            // 
            // btndeviceping
            // 
            this.btndeviceping.BackColor = System.Drawing.Color.SteelBlue;
            this.btndeviceping.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btndeviceping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeviceping.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeviceping.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btndeviceping.Location = new System.Drawing.Point(25, 138);
            this.btndeviceping.Margin = new System.Windows.Forms.Padding(4);
            this.btndeviceping.Name = "btndeviceping";
            this.btndeviceping.Size = new System.Drawing.Size(193, 47);
            this.btndeviceping.TabIndex = 2;
            this.btndeviceping.Text = "Ping";
            this.btndeviceping.UseVisualStyleBackColor = false;
            this.btndeviceping.Click += new System.EventHandler(this.btndeviceping_Click);
            // 
            // txtdeviceping
            // 
            this.txtdeviceping.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtdeviceping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdeviceping.ForeColor = System.Drawing.SystemColors.Window;
            this.txtdeviceping.Location = new System.Drawing.Point(24, 99);
            this.txtdeviceping.Margin = new System.Windows.Forms.Padding(4);
            this.txtdeviceping.Name = "txtdeviceping";
            this.txtdeviceping.Size = new System.Drawing.Size(192, 30);
            this.txtdeviceping.TabIndex = 1;
            // 
            // lblpingdevice
            // 
            this.lblpingdevice.AutoSize = true;
            this.lblpingdevice.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpingdevice.ForeColor = System.Drawing.Color.Red;
            this.lblpingdevice.Location = new System.Drawing.Point(40, 67);
            this.lblpingdevice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpingdevice.Name = "lblpingdevice";
            this.lblpingdevice.Size = new System.Drawing.Size(127, 26);
            this.lblpingdevice.TabIndex = 0;
            this.lblpingdevice.Text = "DEVICE PING";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSlaveID);
            this.panel2.Controls.Add(this.btnrefreshform);
            this.panel2.Controls.Add(this.txtdevicename);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnnewIP);
            this.panel2.Controls.Add(this.txtsubnetmask);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtgateway);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtnewip);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 264);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 437);
            this.panel2.TabIndex = 1;
            // 
            // txtSlaveID
            // 
            this.txtSlaveID.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtSlaveID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlaveID.ForeColor = System.Drawing.Color.White;
            this.txtSlaveID.Location = new System.Drawing.Point(155, 48);
            this.txtSlaveID.Margin = new System.Windows.Forms.Padding(4);
            this.txtSlaveID.Name = "txtSlaveID";
            this.txtSlaveID.Size = new System.Drawing.Size(73, 30);
            this.txtSlaveID.TabIndex = 12;
            this.txtSlaveID.Text = "0";
            // 
            // txtdevicename
            // 
            this.txtdevicename.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtdevicename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdevicename.ForeColor = System.Drawing.SystemColors.Window;
            this.txtdevicename.Location = new System.Drawing.Point(24, 281);
            this.txtdevicename.Margin = new System.Windows.Forms.Padding(4);
            this.txtdevicename.Name = "txtdevicename";
            this.txtdevicename.Size = new System.Drawing.Size(192, 30);
            this.txtdevicename.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(45, 252);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Device Name";
            // 
            // btnmanualsync
            // 
            this.btnmanualsync.BackColor = System.Drawing.Color.SteelBlue;
            this.btnmanualsync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnmanualsync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmanualsync.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmanualsync.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmanualsync.Location = new System.Drawing.Point(24, 13);
            this.btnmanualsync.Margin = new System.Windows.Forms.Padding(4);
            this.btnmanualsync.Name = "btnmanualsync";
            this.btnmanualsync.Size = new System.Drawing.Size(192, 47);
            this.btnmanualsync.TabIndex = 9;
            this.btnmanualsync.Text = "Manual Sync";
            this.btnmanualsync.UseVisualStyleBackColor = false;
            this.btnmanualsync.Click += new System.EventHandler(this.btnManualSync_Click);
            // 
            // btnnewIP
            // 
            this.btnnewIP.BackColor = System.Drawing.Color.SteelBlue;
            this.btnnewIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnnewIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnewIP.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnewIP.ForeColor = System.Drawing.Color.Black;
            this.btnnewIP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnewIP.Location = new System.Drawing.Point(25, 321);
            this.btnnewIP.Margin = new System.Windows.Forms.Padding(4);
            this.btnnewIP.Name = "btnnewIP";
            this.btnnewIP.Size = new System.Drawing.Size(192, 47);
            this.btnnewIP.TabIndex = 8;
            this.btnnewIP.Text = "SET IP";
            this.btnnewIP.UseVisualStyleBackColor = false;
            this.btnnewIP.Click += new System.EventHandler(this.btnnewIP_Click);
            // 
            // txtsubnetmask
            // 
            this.txtsubnetmask.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtsubnetmask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsubnetmask.ForeColor = System.Drawing.SystemColors.Window;
            this.txtsubnetmask.Location = new System.Drawing.Point(24, 217);
            this.txtsubnetmask.Margin = new System.Windows.Forms.Padding(4);
            this.txtsubnetmask.Name = "txtsubnetmask";
            this.txtsubnetmask.Size = new System.Drawing.Size(192, 30);
            this.txtsubnetmask.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(45, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "SubnetMask";
            // 
            // txtgateway
            // 
            this.txtgateway.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtgateway.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgateway.ForeColor = System.Drawing.SystemColors.Window;
            this.txtgateway.Location = new System.Drawing.Point(24, 159);
            this.txtgateway.Margin = new System.Windows.Forms.Padding(4);
            this.txtgateway.Name = "txtgateway";
            this.txtgateway.Size = new System.Drawing.Size(192, 30);
            this.txtgateway.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(45, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gateway";
            // 
            // txtnewip
            // 
            this.txtnewip.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtnewip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewip.ForeColor = System.Drawing.Color.White;
            this.txtnewip.Location = new System.Drawing.Point(24, 95);
            this.txtnewip.Margin = new System.Windows.Forms.Padding(4);
            this.txtnewip.Name = "txtnewip";
            this.txtnewip.Size = new System.Drawing.Size(192, 30);
            this.txtnewip.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(45, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "New IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHANGE SETTING";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.grdLanSetting);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(256, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(962, 705);
            this.panel3.TabIndex = 1;
            // 
            // grdLanSetting
            // 
            this.grdLanSetting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdLanSetting.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLanSetting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLanSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLanSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLanSetting.Location = new System.Drawing.Point(0, 0);
            this.grdLanSetting.Margin = new System.Windows.Forms.Padding(4);
            this.grdLanSetting.Name = "grdLanSetting";
            this.grdLanSetting.RowHeadersVisible = false;
            this.grdLanSetting.RowHeadersWidth = 51;
            this.grdLanSetting.Size = new System.Drawing.Size(962, 705);
            this.grdLanSetting.TabIndex = 0;
            this.grdLanSetting.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLanSetting_CellClick);
            // 
            // LANSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(255, 277);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanelforLANSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LANSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAN Setting";
            this.Load += new System.EventHandler(this.frmLANSetting_Load);
            this.tableLayoutPanelforLANSetting.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLanSetting)).EndInit();
            this.ResumeLayout(false);

	}

    private void button1_Click(object sender, EventArgs e)
    {
        FileStream currentFileStream = null;//EDIT
        string tempFilePath = Directory.GetCurrentDirectory() + "\\TEMP.txt";

        if (!File.Exists(tempFilePath))
        {
            currentFileStream = File.Create(tempFilePath);//creates temp text file
            currentFileStream.Close();//frees the file for editing/reading
        }//if file does not already exist

        File.AppendAllText(tempFilePath, txtdeviceping.Text + Environment.NewLine);//overwrites all text in temp file
        MessageBox.Show("Saved Successfully");
        //Inside your exit function:
        //if (File.Exists(tempFilePath)) File.Delete(tempFilePath);//delete temp file




    }
}
