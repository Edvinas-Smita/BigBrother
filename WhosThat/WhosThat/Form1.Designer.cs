﻿namespace WhosThat
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grbFacesInScreen = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNames = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbNames = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInfoAboutName = new System.Windows.Forms.Label();
            this.btnAddNewFace = new System.Windows.Forms.Button();
            this.txtNewFaceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNamesInProfile = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBio = new System.Windows.Forms.TextBox();
            this.txtLikes = new System.Windows.Forms.TextBox();
            this.btnShowInfo = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grbFacesInScreen.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1083, 648);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtNewFaceName);
            this.tabPage1.Controls.Add(this.btnAddNewFace);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.grbFacesInScreen);
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1075, 609);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kamera";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtLikes);
            this.tabPage2.Controls.Add(this.txtBio);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnUpdateInfo);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.cmbNamesInProfile);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1075, 609);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mano profilis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grbFacesInScreen
            // 
            this.grbFacesInScreen.Controls.Add(this.lblNames);
            this.grbFacesInScreen.Controls.Add(this.label1);
            this.grbFacesInScreen.Location = new System.Drawing.Point(727, 7);
            this.grbFacesInScreen.Name = "grbFacesInScreen";
            this.grbFacesInScreen.Size = new System.Drawing.Size(345, 300);
            this.grbFacesInScreen.TabIndex = 0;
            this.grbFacesInScreen.TabStop = false;
            this.grbFacesInScreen.Text = "Matomi veidai:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vardai:";
            // 
            // lblNames
            // 
            this.lblNames.AutoSize = true;
            this.lblNames.Location = new System.Drawing.Point(12, 62);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(33, 26);
            this.lblNames.TabIndex = 1;
            this.lblNames.Text = "---";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShowInfo);
            this.groupBox1.Controls.Add(this.lblInfoAboutName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbNames);
            this.groupBox1.Location = new System.Drawing.Point(727, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 292);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daugiau informacijos:";
            // 
            // cmbNames
            // 
            this.cmbNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNames.FormattingEnabled = true;
            this.cmbNames.Location = new System.Drawing.Point(12, 57);
            this.cmbNames.Name = "cmbNames";
            this.cmbNames.Size = new System.Drawing.Size(327, 34);
            this.cmbNames.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pasirink vardą";
            // 
            // lblInfoAboutName
            // 
            this.lblInfoAboutName.AutoSize = true;
            this.lblInfoAboutName.Location = new System.Drawing.Point(12, 172);
            this.lblInfoAboutName.Name = "lblInfoAboutName";
            this.lblInfoAboutName.Size = new System.Drawing.Size(33, 26);
            this.lblInfoAboutName.TabIndex = 2;
            this.lblInfoAboutName.Text = "---";
            // 
            // btnAddNewFace
            // 
            this.btnAddNewFace.Location = new System.Drawing.Point(441, 545);
            this.btnAddNewFace.Name = "btnAddNewFace";
            this.btnAddNewFace.Size = new System.Drawing.Size(219, 41);
            this.btnAddNewFace.TabIndex = 2;
            this.btnAddNewFace.Text = "Pridėti naują veidą";
            this.btnAddNewFace.UseVisualStyleBackColor = true;
            this.btnAddNewFace.Click += new System.EventHandler(this.btnAddNewFace_Click);
            // 
            // txtNewFaceName
            // 
            this.txtNewFaceName.Location = new System.Drawing.Point(128, 549);
            this.txtNewFaceName.Name = "txtNewFaceName";
            this.txtNewFaceName.Size = new System.Drawing.Size(286, 32);
            this.txtNewFaceName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 552);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vardas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pasirink vardą:";
            // 
            // cmbNamesInProfile
            // 
            this.cmbNamesInProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNamesInProfile.FormattingEnabled = true;
            this.cmbNamesInProfile.Location = new System.Drawing.Point(197, 4);
            this.cmbNamesInProfile.Name = "cmbNamesInProfile";
            this.cmbNamesInProfile.Size = new System.Drawing.Size(203, 34);
            this.cmbNamesInProfile.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 361);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tavo nuotraukos";
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Location = new System.Drawing.Point(646, 414);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(174, 60);
            this.btnUpdateInfo.TabIndex = 3;
            this.btnUpdateInfo.Text = "Atnaujinti";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            this.btnUpdateInfo.Click += new System.EventHandler(this.btnUpdateInfo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tavo aprašymas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tavo pomėgiai:";
            // 
            // txtBio
            // 
            this.txtBio.Location = new System.Drawing.Point(484, 180);
            this.txtBio.Name = "txtBio";
            this.txtBio.Size = new System.Drawing.Size(483, 32);
            this.txtBio.TabIndex = 6;
            // 
            // txtLikes
            // 
            this.txtLikes.Location = new System.Drawing.Point(484, 266);
            this.txtLikes.Name = "txtLikes";
            this.txtLikes.Size = new System.Drawing.Size(483, 32);
            this.txtLikes.TabIndex = 7;
            // 
            // btnShowInfo
            // 
            this.btnShowInfo.Location = new System.Drawing.Point(11, 97);
            this.btnShowInfo.Name = "btnShowInfo";
            this.btnShowInfo.Size = new System.Drawing.Size(122, 41);
            this.btnShowInfo.TabIndex = 3;
            this.btnShowInfo.Text = "Rodyti";
            this.btnShowInfo.UseVisualStyleBackColor = true;
            this.btnShowInfo.Click += new System.EventHandler(this.btnShowInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 672);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Who\'s that?";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.grbFacesInScreen.ResumeLayout(false);
            this.grbFacesInScreen.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtLikes;
        private System.Windows.Forms.TextBox txtBio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdateInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbNamesInProfile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnShowInfo;
    }
}

