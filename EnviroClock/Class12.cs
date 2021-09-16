

// EnviroClock.Welcome
using EnviroClock;
using EnviroClock.Properties;
using log4net;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

public class Welcome : Form
{
	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	private Schedule sch = new Schedule();

	public static int Counter = 0;

	private IContainer components = null;

	private Panel panel1;

	private Timer timer1;

	private Timer synschedule;

	public Welcome()
	{
		this.InitializeComponent();
		this.timer1.Interval = 2000;
		this.timer1.Tick += this.timer1_Tick;
		this.timer1.Start();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (Welcome.Counter == 0)
		{
			Welcome.Counter++;
			
		}
		else
		{
			this.timer1.Stop();
			base.Hide();
			Dashboard dashboard = new Dashboard();
			dashboard.Show();
			Welcome.log.Info("Dashboard Form Opened Sucessfully.");
		}
	}

	private void synschedule_Tick(object sender, EventArgs e)
	{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.synschedule = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 43, 0, 0);
            this.panel1.Size = new System.Drawing.Size(801, 214);
            this.panel1.TabIndex = 2;
            // 
            // synschedule
            // 
            this.synschedule.Interval = 600000;
            this.synschedule.Tick += new System.EventHandler(this.synschedule_Tick);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 214);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWelcome";
            this.ResumeLayout(false);

	}
}
