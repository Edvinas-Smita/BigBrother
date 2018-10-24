namespace WhosThat
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.picLiveFeed = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNewFaceName = new System.Windows.Forms.TextBox();
			this.btnAddNewFace = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblInfoAboutName = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbNames = new System.Windows.Forms.ComboBox();
			this.grbFacesInScreen = new System.Windows.Forms.GroupBox();
			this.lblNames = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.userDebugAddBlank = new System.Windows.Forms.Button();
			this.userNameTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.userAddPic = new System.Windows.Forms.Button();
			this.userPicturePanel = new System.Windows.Forms.FlowLayoutPanel();
			this.label7 = new System.Windows.Forms.Label();
			this.userLikesTextBox = new System.Windows.Forms.TextBox();
			this.userBioTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.userDebugNameCombo = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picLiveFeed)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.grbFacesInScreen.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(9, 10);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(812, 526);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.picLiveFeed);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtNewFaceName);
			this.tabPage1.Controls.Add(this.btnAddNewFace);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.grbFacesInScreen);
			this.tabPage1.Location = new System.Drawing.Point(4, 29);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage1.Size = new System.Drawing.Size(804, 493);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Kamera";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// picLiveFeed
			// 
			this.picLiveFeed.Location = new System.Drawing.Point(5, 6);
			this.picLiveFeed.Name = "picLiveFeed";
			this.picLiveFeed.Size = new System.Drawing.Size(535, 432);
			this.picLiveFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picLiveFeed.TabIndex = 5;
			this.picLiveFeed.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 448);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 22);
			this.label3.TabIndex = 4;
			this.label3.Text = "Vardas:";
			// 
			// txtNewFaceName
			// 
			this.txtNewFaceName.Location = new System.Drawing.Point(96, 446);
			this.txtNewFaceName.Margin = new System.Windows.Forms.Padding(2);
			this.txtNewFaceName.Name = "txtNewFaceName";
			this.txtNewFaceName.Size = new System.Drawing.Size(216, 27);
			this.txtNewFaceName.TabIndex = 3;
			// 
			// btnAddNewFace
			// 
			this.btnAddNewFace.Location = new System.Drawing.Point(331, 443);
			this.btnAddNewFace.Margin = new System.Windows.Forms.Padding(2);
			this.btnAddNewFace.Name = "btnAddNewFace";
			this.btnAddNewFace.Size = new System.Drawing.Size(164, 33);
			this.btnAddNewFace.TabIndex = 2;
			this.btnAddNewFace.Text = "Pridėti naują veidą";
			this.btnAddNewFace.UseVisualStyleBackColor = true;
			this.btnAddNewFace.Click += new System.EventHandler(this.btnAddNewFace_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblInfoAboutName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cmbNames);
			this.groupBox1.Location = new System.Drawing.Point(545, 255);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(259, 237);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Daugiau informacijos:";
			// 
			// lblInfoAboutName
			// 
			this.lblInfoAboutName.AutoSize = true;
			this.lblInfoAboutName.Location = new System.Drawing.Point(4, 76);
			this.lblInfoAboutName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblInfoAboutName.Name = "lblInfoAboutName";
			this.lblInfoAboutName.Size = new System.Drawing.Size(28, 22);
			this.lblInfoAboutName.TabIndex = 2;
			this.lblInfoAboutName.Text = "---";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 23);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 22);
			this.label2.TabIndex = 1;
			this.label2.Text = "Pasirink vardą";
			// 
			// cmbNames
			// 
			this.cmbNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNames.FormattingEnabled = true;
			this.cmbNames.Location = new System.Drawing.Point(9, 46);
			this.cmbNames.Margin = new System.Windows.Forms.Padding(2);
			this.cmbNames.Name = "cmbNames";
			this.cmbNames.Size = new System.Drawing.Size(246, 28);
			this.cmbNames.TabIndex = 0;
			// 
			// grbFacesInScreen
			// 
			this.grbFacesInScreen.Controls.Add(this.lblNames);
			this.grbFacesInScreen.Controls.Add(this.label1);
			this.grbFacesInScreen.Location = new System.Drawing.Point(545, 6);
			this.grbFacesInScreen.Margin = new System.Windows.Forms.Padding(2);
			this.grbFacesInScreen.Name = "grbFacesInScreen";
			this.grbFacesInScreen.Padding = new System.Windows.Forms.Padding(2);
			this.grbFacesInScreen.Size = new System.Drawing.Size(259, 244);
			this.grbFacesInScreen.TabIndex = 0;
			this.grbFacesInScreen.TabStop = false;
			this.grbFacesInScreen.Text = "Matomi veidai:";
			// 
			// lblNames
			// 
			this.lblNames.AutoSize = true;
			this.lblNames.Location = new System.Drawing.Point(9, 50);
			this.lblNames.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblNames.Name = "lblNames";
			this.lblNames.Size = new System.Drawing.Size(28, 22);
			this.lblNames.TabIndex = 1;
			this.lblNames.Text = "---";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 26);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 22);
			this.label1.TabIndex = 0;
			this.label1.Text = "Vardai:";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.userDebugAddBlank);
			this.tabPage2.Controls.Add(this.userNameTextBox);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.userAddPic);
			this.tabPage2.Controls.Add(this.userPicturePanel);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.userLikesTextBox);
			this.tabPage2.Controls.Add(this.userBioTextBox);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.userDebugNameCombo);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Location = new System.Drawing.Point(4, 29);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage2.Size = new System.Drawing.Size(804, 493);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Mano profilis";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// userDebugAddBlank
			// 
			this.userDebugAddBlank.Location = new System.Drawing.Point(404, 4);
			this.userDebugAddBlank.Name = "userDebugAddBlank";
			this.userDebugAddBlank.Size = new System.Drawing.Size(28, 28);
			this.userDebugAddBlank.TabIndex = 14;
			this.userDebugAddBlank.Text = "+";
			this.userDebugAddBlank.UseVisualStyleBackColor = true;
			this.userDebugAddBlank.Click += new System.EventHandler(this.userDebugAddBlank_Click);
			// 
			// userNameTextBox
			// 
			this.userNameTextBox.Location = new System.Drawing.Point(392, 97);
			this.userNameTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.userNameTextBox.Name = "userNameTextBox";
			this.userNameTextBox.Size = new System.Drawing.Size(363, 27);
			this.userNameTextBox.TabIndex = 13;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(388, 73);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(115, 22);
			this.label8.TabIndex = 12;
			this.label8.Text = "Tavo vardas:";
			// 
			// userAddPic
			// 
			this.userAddPic.Location = new System.Drawing.Point(163, 44);
			this.userAddPic.Name = "userAddPic";
			this.userAddPic.Size = new System.Drawing.Size(28, 28);
			this.userAddPic.TabIndex = 10;
			this.userAddPic.Text = "+";
			this.userAddPic.UseVisualStyleBackColor = true;
			this.userAddPic.Click += new System.EventHandler(this.userAddPic_Click);
			// 
			// userPicturePanel
			// 
			this.userPicturePanel.AutoScroll = true;
			this.userPicturePanel.Location = new System.Drawing.Point(9, 73);
			this.userPicturePanel.Name = "userPicturePanel";
			this.userPicturePanel.Size = new System.Drawing.Size(345, 415);
			this.userPicturePanel.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 47);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(153, 22);
			this.label7.TabIndex = 8;
			this.label7.Text = "Tavo Nuotraukos:";
			// 
			// userLikesTextBox
			// 
			this.userLikesTextBox.Location = new System.Drawing.Point(392, 240);
			this.userLikesTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.userLikesTextBox.Name = "userLikesTextBox";
			this.userLikesTextBox.Size = new System.Drawing.Size(363, 27);
			this.userLikesTextBox.TabIndex = 7;
			// 
			// userBioTextBox
			// 
			this.userBioTextBox.Location = new System.Drawing.Point(392, 170);
			this.userBioTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.userBioTextBox.Name = "userBioTextBox";
			this.userBioTextBox.Size = new System.Drawing.Size(363, 27);
			this.userBioTextBox.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(388, 217);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(133, 22);
			this.label6.TabIndex = 5;
			this.label6.Text = "Tavo pomėgiai:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(388, 146);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(148, 22);
			this.label5.TabIndex = 4;
			this.label5.Text = "Tavo aprašymas:";
			// 
			// userDebugNameCombo
			// 
			this.userDebugNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.userDebugNameCombo.FormattingEnabled = true;
			this.userDebugNameCombo.Location = new System.Drawing.Point(246, 4);
			this.userDebugNameCombo.Margin = new System.Windows.Forms.Padding(2);
			this.userDebugNameCombo.Name = "userDebugNameCombo";
			this.userDebugNameCombo.Size = new System.Drawing.Size(153, 28);
			this.userDebugNameCombo.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 6);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(237, 22);
			this.label4.TabIndex = 0;
			this.label4.Text = "Pasirink vardą (Debug only):";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(830, 546);
			this.Controls.Add(this.tabControl1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.Text = "Who\'s that?";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picLiveFeed)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.grbFacesInScreen.ResumeLayout(false);
			this.grbFacesInScreen.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNewFaceName;
		private System.Windows.Forms.Button btnAddNewFace;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblInfoAboutName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbNames;
		private System.Windows.Forms.GroupBox grbFacesInScreen;
		private System.Windows.Forms.Label lblNames;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox userDebugNameCombo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox picLiveFeed;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button userAddPic;
		private System.Windows.Forms.TextBox userLikesTextBox;
		private System.Windows.Forms.TextBox userBioTextBox;
		private System.Windows.Forms.FlowLayoutPanel userPicturePanel;
		private System.Windows.Forms.Button userDebugAddBlank;
		private System.Windows.Forms.TextBox userNameTextBox;
		private System.Windows.Forms.Label label8;
	}
}

