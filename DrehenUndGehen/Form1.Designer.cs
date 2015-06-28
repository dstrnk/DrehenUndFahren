namespace DrehenUndGehen
{
	partial class Form1
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playerTimer = new System.Windows.Forms.Timer(this.components);
            this.pbplayer1 = new System.Windows.Forms.PictureBox();
            this.pbplayer2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbplayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbplayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // playerTimer
            // 
            this.playerTimer.Interval = 25;
            this.playerTimer.Tick += new System.EventHandler(this.playerTimer_Tick);
            // 
            // pbplayer1
            // 
            this.pbplayer1.BackColor = System.Drawing.Color.Transparent;
            this.pbplayer1.Location = new System.Drawing.Point(317, 97);
            this.pbplayer1.Name = "pbplayer1";
            this.pbplayer1.Size = new System.Drawing.Size(100, 50);
            this.pbplayer1.TabIndex = 1;
            this.pbplayer1.TabStop = false;
            // 
            // pbplayer2
            // 
            this.pbplayer2.BackColor = System.Drawing.Color.Transparent;
            this.pbplayer2.Location = new System.Drawing.Point(585, 97);
            this.pbplayer2.Name = "pbplayer2";
            this.pbplayer2.Size = new System.Drawing.Size(100, 50);
            this.pbplayer2.TabIndex = 2;
            this.pbplayer2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1379, 904);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbplayer2);
            this.Controls.Add(this.pbplayer1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbplayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbplayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer playerTimer;
        private System.Windows.Forms.PictureBox pbplayer1;
        private System.Windows.Forms.PictureBox pbplayer2;
        private System.Windows.Forms.Label label1;






	}
}

