namespace WhosThat
{
	partial class AddFaceForm
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
			this.imagePanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// imagePanel
			// 
			this.imagePanel.AccessibleName = "";
			this.imagePanel.AutoScroll = true;
			this.imagePanel.Cursor = System.Windows.Forms.Cursors.Default;
			this.imagePanel.Location = new System.Drawing.Point(12, 12);
			this.imagePanel.Name = "imagePanel";
			this.imagePanel.Size = new System.Drawing.Size(776, 426);
			this.imagePanel.TabIndex = 0;
			// 
			// AddFaceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.imagePanel);
			this.Name = "AddFaceForm";
			this.Text = "AddFaceForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel imagePanel;
	}
}