

// EnviroClock.AboutUs
using EnviroClock.Properties;
using Microsoft.VisualBasic.PowerPacks;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class AboutUs : Form
{
	private IContainer components = null;

	private Panel aboutuspanel;

	private Label lblEmail;

	private Label lblSite;

	private Label label8;

	private Label lblAddress4;

	private Label lblAddress3;

	private Label lblAddress2;

	private Label lblAddress1;

	private Label label3;

	private Label lblCompanyName;

	private Label label2;

	private ShapeContainer shapeContainer1;
    private Panel panel1;
    private Label labelDateYear;
    private Label label5;
    private Label label4;
    private Label label1;

    private RectangleShape rectangleShape1;

	public AboutUs()
	{
		this.InitializeComponent();
	}

	private void label2_Click(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUs));
            this.aboutuspanel = new System.Windows.Forms.Panel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSite = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAddress4 = new System.Windows.Forms.Label();
            this.lblAddress3 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelDateYear = new System.Windows.Forms.Label();
            this.aboutuspanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutuspanel
            // 
            this.aboutuspanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.aboutuspanel.Controls.Add(this.labelDateYear);
            this.aboutuspanel.Controls.Add(this.label5);
            this.aboutuspanel.Controls.Add(this.label4);
            this.aboutuspanel.Controls.Add(this.label1);
            this.aboutuspanel.Controls.Add(this.panel1);
            this.aboutuspanel.Controls.Add(this.lblEmail);
            this.aboutuspanel.Controls.Add(this.lblSite);
            this.aboutuspanel.Controls.Add(this.label8);
            this.aboutuspanel.Controls.Add(this.lblAddress4);
            this.aboutuspanel.Controls.Add(this.lblAddress3);
            this.aboutuspanel.Controls.Add(this.lblAddress2);
            this.aboutuspanel.Controls.Add(this.lblAddress1);
            this.aboutuspanel.Controls.Add(this.label3);
            this.aboutuspanel.Controls.Add(this.lblCompanyName);
            this.aboutuspanel.Controls.Add(this.label2);
            this.aboutuspanel.Controls.Add(this.shapeContainer1);
            this.aboutuspanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutuspanel.Location = new System.Drawing.Point(0, 0);
            this.aboutuspanel.Margin = new System.Windows.Forms.Padding(4);
            this.aboutuspanel.Name = "aboutuspanel";
            this.aboutuspanel.Size = new System.Drawing.Size(560, 461);
            this.aboutuspanel.TabIndex = 0;
            this.aboutuspanel.Paint += new System.Windows.Forms.PaintEventHandler(this.aboutuspanel_Paint);
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(125, 360);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(201, 31);
            this.lblEmail.TabIndex = 104;
            this.lblEmail.Text = "enquiry@enviroworld.in";
            // 
            // lblSite
            // 
            this.lblSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSite.Location = new System.Drawing.Point(125, 385);
            this.lblSite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(336, 31);
            this.lblSite.TabIndex = 103;
            this.lblSite.Text = "https://www.enviro-technologies.com/";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 385);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 31);
            this.label8.TabIndex = 102;
            this.label8.Text = "Visit us at";
            // 
            // lblAddress4
            // 
            this.lblAddress4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress4.Location = new System.Drawing.Point(24, 308);
            this.lblAddress4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress4.Name = "lblAddress4";
            this.lblAddress4.Size = new System.Drawing.Size(207, 40);
            this.lblAddress4.TabIndex = 101;
            this.lblAddress4.Text = "Tel.: +91-02522-661500\r\nSupport : +91-7039-047-041";
            // 
            // lblAddress3
            // 
            this.lblAddress3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress3.Location = new System.Drawing.Point(23, 284);
            this.lblAddress3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress3.Name = "lblAddress3";
            this.lblAddress3.Size = new System.Drawing.Size(293, 25);
            this.lblAddress3.TabIndex = 100;
            this.lblAddress3.Text = "Bhiwandi, Thane-421302";
            // 
            // lblAddress2
            // 
            this.lblAddress2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress2.Location = new System.Drawing.Point(23, 259);
            this.lblAddress2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(304, 25);
            this.lblAddress2.TabIndex = 99;
            this.lblAddress2.Text = "Bhumi World, Pimplas Village,";
            // 
            // lblAddress1
            // 
            this.lblAddress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress1.Location = new System.Drawing.Point(23, 235);
            this.lblAddress1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(332, 25);
            this.lblAddress1.TabIndex = 98;
            this.lblAddress1.Text = "Units No 254, Second Floor, Building No D-7, ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 360);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 97;
            this.label3.Text = "E-mail";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(23, 209);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(360, 22);
            this.lblCompanyName.TabIndex = 96;
            this.lblCompanyName.Text = "ENVIRO TECHNOLOGIES";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 33);
            this.label2.TabIndex = 93;
            this.label2.Text = "ENVIRO CLOCK";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Size = new System.Drawing.Size(560, 461);
            this.shapeContainer1.TabIndex = 105;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "";
            this.rectangleShape1.Size = new System.Drawing.Size(0, 0);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(27, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 71);
            this.panel1.TabIndex = 106;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(24, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 107;
            this.label1.Text = "Version : 1.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(24, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 20);
            this.label4.TabIndex = 108;
            this.label4.Text = "Release Date : 24-08-2021\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(27, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 109;
            this.label5.Text = "CopyRight @";
            // 
            // labelDateYear
            // 
            this.labelDateYear.AutoSize = true;
            this.labelDateYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateYear.Location = new System.Drawing.Point(153, 422);
            this.labelDateYear.Name = "labelDateYear";
            this.labelDateYear.Size = new System.Drawing.Size(52, 17);
            this.labelDateYear.TabIndex = 110;
            this.labelDateYear.Text = "label6";
            // 
            // AboutUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(560, 461);
            this.Controls.Add(this.aboutuspanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutUs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AboutUs";
            this.Load += new System.EventHandler(this.AboutUs_Load);
            this.aboutuspanel.ResumeLayout(false);
            this.aboutuspanel.PerformLayout();
            this.ResumeLayout(false);

	}

    private void aboutuspanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void AboutUs_Load(object sender, EventArgs e)
    {
        labelDateYear.Text = DateTime.Now.ToString("yyyy");
    }
}
