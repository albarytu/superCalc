namespace SuperCalc
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.operacion = new System.Windows.Forms.TextBox();
			this.run = new System.Windows.Forms.Button();
			this.clear = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.log = new System.Windows.Forms.TextBox();
			this.listaVariables = new System.Windows.Forms.TextBox();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// operacion
			// 
			this.operacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.operacion.HideSelection = false;
			this.operacion.Location = new System.Drawing.Point(93, 441);
			this.operacion.Name = "operacion";
			this.operacion.Size = new System.Drawing.Size(547, 20);
			this.operacion.TabIndex = 0;
			this.operacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// run
			// 
			this.run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.run.Location = new System.Drawing.Point(646, 433);
			this.run.Name = "run";
			this.run.Size = new System.Drawing.Size(39, 39);
			this.run.TabIndex = 2;
			this.run.Text = "=";
			this.run.UseVisualStyleBackColor = true;
			this.run.Click += new System.EventHandler(this.run_Click);
			// 
			// clear
			// 
			this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.clear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.clear.Location = new System.Drawing.Point(50, 433);
			this.clear.Name = "clear";
			this.clear.Size = new System.Drawing.Size(37, 35);
			this.clear.TabIndex = 3;
			this.clear.Text = "C";
			this.clear.UseVisualStyleBackColor = true;
			this.clear.Click += new System.EventHandler(this.clear_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.ImageIndex = 0;
			this.button1.ImageList = this.imageList1;
			this.button1.Location = new System.Drawing.Point(12, 433);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(32, 35);
			this.button1.TabIndex = 4;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "Calculator.ico");
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 12);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.listaVariables);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.log);
			this.splitContainer1.Size = new System.Drawing.Size(673, 415);
			this.splitContainer1.SplitterDistance = 68;
			this.splitContainer1.TabIndex = 7;
			// 
			// log
			// 
			this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.log.Location = new System.Drawing.Point(3, 3);
			this.log.Multiline = true;
			this.log.Name = "log";
			this.log.ReadOnly = true;
			this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.log.Size = new System.Drawing.Size(595, 409);
			this.log.TabIndex = 2;
			this.log.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// listaVariables
			// 
			this.listaVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listaVariables.BackColor = System.Drawing.Color.Cornsilk;
			this.listaVariables.Location = new System.Drawing.Point(3, 3);
			this.listaVariables.Multiline = true;
			this.listaVariables.Name = "listaVariables";
			this.listaVariables.ReadOnly = true;
			this.listaVariables.Size = new System.Drawing.Size(62, 409);
			this.listaVariables.TabIndex = 6;
			// 
			// Form1
			// 
			this.AcceptButton = this.run;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.clear;
			this.ClientSize = new System.Drawing.Size(697, 477);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.clear);
			this.Controls.Add(this.run);
			this.Controls.Add(this.operacion);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "SuperCalculadora";
			this.Activated += new System.EventHandler(this.Form1_Activated);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox operacion;
		private System.Windows.Forms.Button run;
		private System.Windows.Forms.Button clear;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox listaVariables;
		private System.Windows.Forms.TextBox log;
	}
}

