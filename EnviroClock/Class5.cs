

// EnviroClock.CheckPassword
using EnviroClock;
using EnviroClock.Entity;
using EnviroClock.Helper;
using log4net;
using Microsoft.VisualBasic.PowerPacks;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

public class CheckPassword : Form
    //test
{
	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	private string startPath = Application.StartupPath + "\\Settings.ini";

	private IContainer components = null;

	private Panel panel1;

	private ShapeContainer shapeContainer1;

	private RectangleShape rectangleShape1;

	private TextBox txtpassfrmcheckpass;

	private Button btnfrmcheckpassok;

	private Label label2;

	public CheckPassword()
	{
		this.InitializeComponent();
	}

	private void btnfrmcheckpassok_Click(object sender, EventArgs e)
	{
		try
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			empty = CommonHelper.Encrypt(this.txtpassfrmcheckpass.Text);
			SettingParam settingParam = CommonHelper.ReaderXML();
			if (empty == settingParam.Password)
			{
				base.Close();
				FormCollection openForms = Application.OpenForms;
				foreach (Form item in openForms)
				{
					if (item.Name == "LANSetting")
					{
						item.Close();
						break;
					}
				}
				LANSetting lANSetting = new LANSetting();
				lANSetting.Show();
				CheckPassword.log.Info("LAN setting Form Opened Successfully.");
			}
			else
			{
				MessageBox.Show("Please enter the correct password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				CheckPassword.log.Info("Failed To open LAN Setting Form.");
			}
		}
		catch (Exception ex)
		{
			CheckPassword.log.Error(ex.ToString());
		}
	}

	private void txtpassfrmcheckpass_keypress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			this.btnfrmcheckpassok_Click(sender, e);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckPassword));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnfrmcheckpassok = new System.Windows.Forms.Button();
            this.txtpassfrmcheckpass = new System.Windows.Forms.TextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnfrmcheckpassok);
            this.panel1.Controls.Add(this.txtpassfrmcheckpass);
            this.panel1.Controls.Add(this.shapeContainer1);
            this.panel1.Location = new System.Drawing.Point(6, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 148);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Password:";
            // 
            // btnfrmcheckpassok
            // 
            this.btnfrmcheckpassok.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnfrmcheckpassok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfrmcheckpassok.Location = new System.Drawing.Point(211, 95);
            this.btnfrmcheckpassok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnfrmcheckpassok.Name = "btnfrmcheckpassok";
            this.btnfrmcheckpassok.Size = new System.Drawing.Size(109, 41);
            this.btnfrmcheckpassok.TabIndex = 3;
            this.btnfrmcheckpassok.Text = "OK";
            this.btnfrmcheckpassok.UseVisualStyleBackColor = false;
            this.btnfrmcheckpassok.Click += new System.EventHandler(this.btnfrmcheckpassok_Click);
            // 
            // txtpassfrmcheckpass
            // 
            this.txtpassfrmcheckpass.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtpassfrmcheckpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassfrmcheckpass.Location = new System.Drawing.Point(207, 38);
            this.txtpassfrmcheckpass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpassfrmcheckpass.Name = "txtpassfrmcheckpass";
            this.txtpassfrmcheckpass.PasswordChar = '*';
            this.txtpassfrmcheckpass.Size = new System.Drawing.Size(232, 26);
            this.txtpassfrmcheckpass.TabIndex = 2;
            this.txtpassfrmcheckpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassfrmcheckpass_keypress);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(492, 146);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "";
            this.rectangleShape1.Size = new System.Drawing.Size(0, 0);
            // 
            // CheckPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(507, 161);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckPassword";
            this.Load += new System.EventHandler(this.CheckPassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

	}

    private void CheckPassword_Load(object sender, EventArgs e)
    {

    }
}
