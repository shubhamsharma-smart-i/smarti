

// EnviroClock.ChangePassword1
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

public class ChangePassword1 : Form
{
	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	private IContainer components = null;

	private Label label2;

	private Button btnfrmcheckpassok;

	private TextBox txtpassfrmcheckpass;

	private ShapeContainer shapeContainer1;

	private RectangleShape rectangleShape1;

	public ChangePassword1()
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
					if (item.Name == "Schedule")
					{
						item.Close();
						break;
					}
				}
				Schedule schedule = new Schedule();
				schedule.Show();
				ChangePassword1.log.Info("Schedule Form Opened Successfully.");
			}
			else
			{
				MessageBox.Show("Please enter the correct password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ChangePassword1.log.Info("Failed to open Schedule Form.");
			}
		}
		catch (Exception ex)
		{
			ChangePassword1.log.Error(ex.ToString());
		}
	}

	private void txtpassfrmcheckpass_keydown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			this.btnfrmcheckpassok_Click(sender, e);
			e.SuppressKeyPress = true;
			e.Handled = true;
		}
	}

	private void txtpassfrmcheckpass_KeyPress(object sender, KeyPressEventArgs e)
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnfrmcheckpassok = new System.Windows.Forms.Button();
            this.txtpassfrmcheckpass = new System.Windows.Forms.TextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter Password:";
            // 
            // btnfrmcheckpassok
            // 
            this.btnfrmcheckpassok.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnfrmcheckpassok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfrmcheckpassok.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfrmcheckpassok.Location = new System.Drawing.Point(215, 78);
            this.btnfrmcheckpassok.Margin = new System.Windows.Forms.Padding(4);
            this.btnfrmcheckpassok.Name = "btnfrmcheckpassok";
            this.btnfrmcheckpassok.Size = new System.Drawing.Size(109, 41);
            this.btnfrmcheckpassok.TabIndex = 6;
            this.btnfrmcheckpassok.Text = "OK";
            this.btnfrmcheckpassok.UseVisualStyleBackColor = false;
            this.btnfrmcheckpassok.Click += new System.EventHandler(this.btnfrmcheckpassok_Click);
            // 
            // txtpassfrmcheckpass
            // 
            this.txtpassfrmcheckpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassfrmcheckpass.Location = new System.Drawing.Point(211, 28);
            this.txtpassfrmcheckpass.Margin = new System.Windows.Forms.Padding(4);
            this.txtpassfrmcheckpass.Name = "txtpassfrmcheckpass";
            this.txtpassfrmcheckpass.PasswordChar = '*';
            this.txtpassfrmcheckpass.Size = new System.Drawing.Size(232, 26);
            this.txtpassfrmcheckpass.TabIndex = 5;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(520, 140);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "";
            this.rectangleShape1.Size = new System.Drawing.Size(0, 0);
            // 
            // ChangePassword1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(520, 140);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnfrmcheckpassok);
            this.Controls.Add(this.txtpassfrmcheckpass);
            this.Controls.Add(this.shapeContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword1";
            this.Load += new System.EventHandler(this.ChangePassword1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

	}

    private void ChangePassword1_Load(object sender, EventArgs e)
    {

    }
}
