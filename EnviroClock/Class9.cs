

// EnviroClock.Schedule
using EnviroClock;
using EnviroClock.Entity;
using EnviroClock.Helper;
using log4net;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

public class Schedule : Form
{
	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	private string schedulepara1 = string.Empty;

	private string schedulepara2 = string.Empty;

	private SettingParam obj = CommonHelper.ReaderXML();

	private IContainer components = null;

	private Timer tmrScheduleTimeZone;

	private Panel timepanel;

	private TableLayoutPanel tableLayoutPanel1;

	private TableLayoutPanel tableLayoutPanel2;

	private Panel panel1;

	private TableLayoutPanel tableLayoutPanel3;

	private Panel panel3;

	private Label lblschedule1;

	private Panel panel4;

	private DateTimePicker datetimeschedule1;

	private Panel panel5;

	private Button btnschedule1;

	private Panel panel2;

	private Label lblschedulecurrenttime;

	private TableLayoutPanel tableLayoutPanel4;

	private Panel panel6;

	private Label lblschedule2;

	private Panel panel7;

	private DateTimePicker datetimeschedule2;

	private Panel panel8;

	private Button btnschedule2;

	private Label lblscheduletime2;

	public Schedule()
	{
		this.InitializeComponent();
	}

	public bool ClockSync(int slave, string IpAddress, string PortNo, string Command)
	{
		bool flag = ServiceResponse.SetResponse(Command, IpAddress, PortNo.ToString());


        //if (ServiceResponse.SetResponse("lu,01," + this.txtnewip.Text + ",", this.IPAddressData, this.PortNo.ToString()))
        //{

        //}
            if (flag)
		{
			Schedule.log.Info(IpAddress + " Set Clock Time");
		}
		return flag;
	}

	private void btnschedule1_Click(object sender, EventArgs e)
	{
        MessageBox.Show("Schedule Time 1 Set");
		if (this.datetimeschedule1.Text != "null" || this.datetimeschedule1.Text != "")
		{
			this.obj.SceduleParam1 = this.datetimeschedule1.Text;
			if (CommonHelper.WriteXML(this.obj))
			{
				this.lblschedulecurrenttime.Text = "Schedule1 Schedule Time is" + this.obj.SceduleParam1;
				Schedule.log.Info("Schedule1 Schedule Time is" + this.obj.SceduleParam1);
			}
			else
			{
				MessageBox.Show("Something went wrong Schedule Not Set");
				Schedule.log.Info("Something went wrong Schedule Not Set");
			}
		}
	}

	private void btnschedule2_Click(object sender, EventArgs e)
	{
        MessageBox.Show("Schedule Time 2 Set");
		if (this.datetimeschedule2.Text != "null" || this.datetimeschedule1.Text != "")
		{
			this.obj.SceduleParam2 = this.datetimeschedule2.Text;
			if (CommonHelper.WriteXML(this.obj))
			{
				this.lblscheduletime2.Text = "Schedule2 Schedule Time is" + this.obj.SceduleParam2;
				Schedule.log.Info("Schedule2 Schedule Time is" + this.obj.SceduleParam2);
			}
			else
			{
				MessageBox.Show("Something went wrong Schedule Not Set");
				Schedule.log.Info("Something went wrong Schedule Not Set");
			}
		}
	}

	private void Schedule_Load(object sender, EventArgs e)
	{
		this.schedulepara1 = this.obj.SceduleParam1;
		if (this.schedulepara1 != null || this.schedulepara1 != "")
		{
			this.lblschedulecurrenttime.Text = "Schedule1 Schedule Time is " + this.schedulepara1;
		}
		this.schedulepara2 = this.obj.SceduleParam2;
		if (this.schedulepara2 != null || this.schedulepara2 != "")
		{
			this.lblscheduletime2.Text = "Schedule2 Schedule Time is " + this.schedulepara2;
		}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedule));
            this.tmrScheduleTimeZone = new System.Windows.Forms.Timer(this.components);
            this.timepanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblschedule1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.datetimeschedule1 = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblschedulecurrenttime = new System.Windows.Forms.Label();
            this.btnschedule1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblschedule2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.datetimeschedule2 = new System.Windows.Forms.DateTimePicker();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblscheduletime2 = new System.Windows.Forms.Label();
            this.btnschedule2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timepanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrScheduleTimeZone
            // 
            this.tmrScheduleTimeZone.Enabled = true;
            this.tmrScheduleTimeZone.Interval = 1000;
            this.tmrScheduleTimeZone.Tick += new System.EventHandler(this.tmrScheduleTimeZone_Tick);
            // 
            // timepanel
            // 
            this.timepanel.Controls.Add(this.tableLayoutPanel2);
            this.timepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timepanel.Location = new System.Drawing.Point(4, 4);
            this.timepanel.Margin = new System.Windows.Forms.Padding(4);
            this.timepanel.Name = "timepanel";
            this.timepanel.Size = new System.Drawing.Size(911, 329);
            this.timepanel.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 329F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(911, 329);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 321);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.63303F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.36697F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(447, 321);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblschedule1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(439, 74);
            this.panel3.TabIndex = 0;
            // 
            // lblschedule1
            // 
            this.lblschedule1.AutoSize = true;
            this.lblschedule1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblschedule1.Location = new System.Drawing.Point(76, 43);
            this.lblschedule1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblschedule1.Name = "lblschedule1";
            this.lblschedule1.Size = new System.Drawing.Size(198, 29);
            this.lblschedule1.TabIndex = 0;
            this.lblschedule1.Text = "Schedule Time 1";
            this.lblschedule1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.datetimeschedule1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 86);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(439, 47);
            this.panel4.TabIndex = 2;
            // 
            // datetimeschedule1
            // 
            this.datetimeschedule1.CustomFormat = "HH:mm:ss";
            this.datetimeschedule1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimeschedule1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeschedule1.Location = new System.Drawing.Point(73, 6);
            this.datetimeschedule1.Margin = new System.Windows.Forms.Padding(4);
            this.datetimeschedule1.Name = "datetimeschedule1";
            this.datetimeschedule1.ShowUpDown = true;
            this.datetimeschedule1.Size = new System.Drawing.Size(331, 34);
            this.datetimeschedule1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblschedulecurrenttime);
            this.panel5.Controls.Add(this.btnschedule1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 141);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(439, 176);
            this.panel5.TabIndex = 3;
            // 
            // lblschedulecurrenttime
            // 
            this.lblschedulecurrenttime.AutoSize = true;
            this.lblschedulecurrenttime.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblschedulecurrenttime.Location = new System.Drawing.Point(67, 89);
            this.lblschedulecurrenttime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblschedulecurrenttime.Name = "lblschedulecurrenttime";
            this.lblschedulecurrenttime.Size = new System.Drawing.Size(0, 23);
            this.lblschedulecurrenttime.TabIndex = 4;
            this.lblschedulecurrenttime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnschedule1
            // 
            this.btnschedule1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnschedule1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnschedule1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnschedule1.Font = new System.Drawing.Font("Engravers MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnschedule1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnschedule1.Location = new System.Drawing.Point(73, 14);
            this.btnschedule1.Margin = new System.Windows.Forms.Padding(4);
            this.btnschedule1.Name = "btnschedule1";
            this.btnschedule1.Size = new System.Drawing.Size(332, 58);
            this.btnschedule1.TabIndex = 3;
            this.btnschedule1.Text = "SET";
            this.btnschedule1.UseVisualStyleBackColor = false;
            this.btnschedule1.Click += new System.EventHandler(this.btnschedule1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(459, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 321);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel7, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel8, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.45946F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54054F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(448, 321);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblschedule2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(4, 4);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(440, 72);
            this.panel6.TabIndex = 0;
            // 
            // lblschedule2
            // 
            this.lblschedule2.AutoSize = true;
            this.lblschedule2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblschedule2.Location = new System.Drawing.Point(63, 43);
            this.lblschedule2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblschedule2.Name = "lblschedule2";
            this.lblschedule2.Size = new System.Drawing.Size(198, 29);
            this.lblschedule2.TabIndex = 1;
            this.lblschedule2.Text = "Schedule Time 2";
            this.lblschedule2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.datetimeschedule2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(4, 84);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(440, 47);
            this.panel7.TabIndex = 1;
            // 
            // datetimeschedule2
            // 
            this.datetimeschedule2.CustomFormat = "HH:mm:ss";
            this.datetimeschedule2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimeschedule2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeschedule2.Location = new System.Drawing.Point(64, 6);
            this.datetimeschedule2.Margin = new System.Windows.Forms.Padding(4);
            this.datetimeschedule2.Name = "datetimeschedule2";
            this.datetimeschedule2.ShowUpDown = true;
            this.datetimeschedule2.Size = new System.Drawing.Size(331, 34);
            this.datetimeschedule2.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblscheduletime2);
            this.panel8.Controls.Add(this.btnschedule2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(4, 139);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(440, 178);
            this.panel8.TabIndex = 2;
            // 
            // lblscheduletime2
            // 
            this.lblscheduletime2.AutoSize = true;
            this.lblscheduletime2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblscheduletime2.Location = new System.Drawing.Point(60, 89);
            this.lblscheduletime2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblscheduletime2.Name = "lblscheduletime2";
            this.lblscheduletime2.Size = new System.Drawing.Size(0, 23);
            this.lblscheduletime2.TabIndex = 6;
            this.lblscheduletime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnschedule2
            // 
            this.btnschedule2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnschedule2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnschedule2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnschedule2.Font = new System.Drawing.Font("Engravers MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnschedule2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnschedule2.Location = new System.Drawing.Point(64, 16);
            this.btnschedule2.Margin = new System.Windows.Forms.Padding(4);
            this.btnschedule2.Name = "btnschedule2";
            this.btnschedule2.Size = new System.Drawing.Size(331, 58);
            this.btnschedule2.TabIndex = 5;
            this.btnschedule2.Text = "SET";
            this.btnschedule2.UseVisualStyleBackColor = false;
            this.btnschedule2.Click += new System.EventHandler(this.btnschedule2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.94062F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.05938F));
            this.tableLayoutPanel1.Controls.Add(this.timepanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(919, 337);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(919, 337);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Schedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.Schedule_Load);
            this.timepanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

	}

    private void tmrScheduleTimeZone_Tick(object sender, EventArgs e)
    {

    }
}
