

// EnviroClock.ChangePassword
using EnviroClock;
using EnviroClock.Entity;
using EnviroClock.Helper;
using EnviroClock.Properties;
using log4net;
using Microsoft.VisualBasic.PowerPacks;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

public class ChangePassword : Form
{
	private SettingParam obj = CommonHelper.ReaderXML();

	private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	private IContainer components = null;

	private Panel panel1;

	private TableLayoutPanel tableLayoutPanel1;

	private Panel panel2;

	private TextBox txtrepass;

	private Label label4;

	private TextBox txtmasterpass;

	private Label label3;

	private Button txtcheckpaswordOK;

	private TextBox txtNewPass;

	private Panel panel3;

	private Label lblchangepasstitle;

	private Label label7;

	private ShapeContainer shapeContainer1;

	private RectangleShape rectangleShape1;

	private ShapeContainer shapeContainer2;

	private RectangleShape rectangleShape2;

	private Button btnclear;

	private CheckBox chkmasterpasscheck;

	public ChangePassword()
	{
		this.InitializeComponent();
	}

	public bool valid()
	{
		if (string.IsNullOrEmpty(this.txtmasterpass.Text))
		{
			MessageBox.Show("Please Enter the MasterPassword", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return false;
		}
		if (string.IsNullOrEmpty(this.txtNewPass.Text))
		{
			MessageBox.Show("Please Enter the NewPassword", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return false;
		}
		if (string.IsNullOrEmpty(this.txtrepass.Text))
		{
			MessageBox.Show("Please Enter the repassword", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return false;
		}
		if (this.txtNewPass.Text.Length < 5)
		{
			MessageBox.Show("Passwords must be at least 5 characters long.");
			return false;
		}
		if (!(this.txtNewPass.Text == this.txtrepass.Text))
		{
			MessageBox.Show("Password and New Password Does Not Match:");
			return false;
		}
		return true;
	}

	private void txtcheckpaswordOK_Click(object sender, EventArgs e)
	{
		if (this.valid())
		{
			if (this.chkmasterpasscheck.Checked)
			{
				if (this.txtmasterpass.Text == Settings.Default.MasterPassword)
				{
					this.obj.Password = CommonHelper.Encrypt(this.txtNewPass.Text);
					if (CommonHelper.WriteXML(this.obj))
					{
						MessageBox.Show("Your password has been changed sucessfully");
						ChangePassword.log.Info("password has been changed sucessfully");
						base.Close();
					}
					else
					{
						MessageBox.Show("Something Weng Wrong. Please Contact To Administrator!!!");
						ChangePassword.log.Info("Something Weng Wrong. Please Contact To Administrator!!!");
					}
				}
				else
				{
					MessageBox.Show("Master Password Not Match.");
				}
			}
			else
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				if (CommonHelper.Decrypt(this.obj.Password) == this.txtmasterpass.Text.Trim())
				{
					this.obj.Password = CommonHelper.Encrypt(this.txtNewPass.Text);
					if (CommonHelper.WriteXML(this.obj))
					{
						MessageBox.Show("Your password has been changed sucessfully");
						ChangePassword.log.Info("password has been changed sucessfully");
						base.Close();
					}
					else
					{
						MessageBox.Show("Something Weng Wrong. Please Contact To Administrator!!!");
						ChangePassword.log.Info("Something Weng Wrong. Please Contact To Administrator!!!");
					}
				}
				else
				{
					MessageBox.Show("Old Password Does Not Match");
				}
			}
		}
		else
		{
			MessageBox.Show("Form Validation Not Valid.");
		}
	}

	private void btnclear_Click(object sender, EventArgs e)
	{
		this.txtmasterpass.Clear();
		this.txtNewPass.Clear();
		this.txtrepass.Clear();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkmasterpasscheck = new System.Windows.Forms.CheckBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.txtcheckpaswordOK = new System.Windows.Forms.Button();
            this.txtrepass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtmasterpass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblchangepasstitle = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 423);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.5814F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.4186F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(665, 423);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkmasterpasscheck);
            this.panel2.Controls.Add(this.btnclear);
            this.panel2.Controls.Add(this.txtcheckpaswordOK);
            this.panel2.Controls.Add(this.txtrepass);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtNewPass);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtmasterpass);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.shapeContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 112);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 307);
            this.panel2.TabIndex = 0;
            // 
            // chkmasterpasscheck
            // 
            this.chkmasterpasscheck.AutoSize = true;
            this.chkmasterpasscheck.Location = new System.Drawing.Point(216, 213);
            this.chkmasterpasscheck.Margin = new System.Windows.Forms.Padding(4);
            this.chkmasterpasscheck.Name = "chkmasterpasscheck";
            this.chkmasterpasscheck.Size = new System.Drawing.Size(18, 17);
            this.chkmasterpasscheck.TabIndex = 9;
            this.chkmasterpasscheck.UseVisualStyleBackColor = true;
            this.chkmasterpasscheck.CheckedChanged += new System.EventHandler(this.chkmasterpasscheck_CheckedChanged);
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(385, 254);
            this.btnclear.Margin = new System.Windows.Forms.Padding(4);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(135, 42);
            this.btnclear.TabIndex = 8;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // txtcheckpaswordOK
            // 
            this.txtcheckpaswordOK.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.txtcheckpaswordOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtcheckpaswordOK.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcheckpaswordOK.Location = new System.Drawing.Point(117, 255);
            this.txtcheckpaswordOK.Margin = new System.Windows.Forms.Padding(4);
            this.txtcheckpaswordOK.Name = "txtcheckpaswordOK";
            this.txtcheckpaswordOK.Size = new System.Drawing.Size(135, 42);
            this.txtcheckpaswordOK.TabIndex = 7;
            this.txtcheckpaswordOK.Text = "OK";
            this.txtcheckpaswordOK.UseVisualStyleBackColor = false;
            this.txtcheckpaswordOK.Click += new System.EventHandler(this.txtcheckpaswordOK_Click);
            // 
            // txtrepass
            // 
            this.txtrepass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrepass.Location = new System.Drawing.Point(211, 162);
            this.txtrepass.Margin = new System.Windows.Forms.Padding(4);
            this.txtrepass.Name = "txtrepass";
            this.txtrepass.PasswordChar = '*';
            this.txtrepass.Size = new System.Drawing.Size(260, 30);
            this.txtrepass.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(253, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "ReEnter Password: ";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(211, 101);
            this.txtNewPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(260, 30);
            this.txtNewPass.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(248, 76);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 23);
            this.label7.TabIndex = 3;
            this.label7.Text = "Enter New Password: ";
            // 
            // txtmasterpass
            // 
            this.txtmasterpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmasterpass.Location = new System.Drawing.Point(211, 36);
            this.txtmasterpass.Margin = new System.Windows.Forms.Padding(4);
            this.txtmasterpass.Name = "txtmasterpass";
            this.txtmasterpass.PasswordChar = '*';
            this.txtmasterpass.Size = new System.Drawing.Size(260, 30);
            this.txtmasterpass.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Enter Master Password:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(655, 305);
            this.shapeContainer1.TabIndex = 8;
            this.shapeContainer1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblchangepasstitle);
            this.panel3.Controls.Add(this.shapeContainer2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(657, 100);
            this.panel3.TabIndex = 1;
            // 
            // lblchangepasstitle
            // 
            this.lblchangepasstitle.AutoSize = true;
            this.lblchangepasstitle.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchangepasstitle.Location = new System.Drawing.Point(17, 33);
            this.lblchangepasstitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblchangepasstitle.Name = "lblchangepasstitle";
            this.lblchangepasstitle.Size = new System.Drawing.Size(182, 26);
            this.lblchangepasstitle.TabIndex = 0;
            this.lblchangepasstitle.Text = "Change Password:";
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Size = new System.Drawing.Size(655, 98);
            this.shapeContainer2.TabIndex = 4;
            this.shapeContainer2.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "";
            this.rectangleShape1.Size = new System.Drawing.Size(0, 0);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape2.Name = "";
            this.rectangleShape2.Size = new System.Drawing.Size(0, 0);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(665, 423);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

	}

    private void ChangePassword_Load(object sender, EventArgs e)
    {

    }

    private void chkmasterpasscheck_CheckedChanged(object sender, EventArgs e)
    {

    }
}
