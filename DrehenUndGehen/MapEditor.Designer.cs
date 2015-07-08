namespace DrehenUndGehen
{
    partial class MapEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditor));
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.rbEinfach = new System.Windows.Forms.RadioButton();
            this.rbSchwer = new System.Windows.Forms.RadioButton();
            this.rbMittel = new System.Windows.Forms.RadioButton();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartTheGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMap
            // 
            this.pbMap.Location = new System.Drawing.Point(266, 12);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(251, 237);
            this.pbMap.TabIndex = 0;
            this.pbMap.TabStop = false;
            // 
            // rbEinfach
            // 
            this.rbEinfach.AutoSize = true;
            this.rbEinfach.BackColor = System.Drawing.Color.Transparent;
            this.rbEinfach.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbEinfach.BackgroundImage")));
            this.rbEinfach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rbEinfach.FlatAppearance.BorderSize = 0;
            this.rbEinfach.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rbEinfach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rbEinfach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rbEinfach.Location = new System.Drawing.Point(49, 84);
            this.rbEinfach.Name = "rbEinfach";
            this.rbEinfach.Size = new System.Drawing.Size(95, 17);
            this.rbEinfach.TabIndex = 1;
            this.rbEinfach.TabStop = true;
            this.rbEinfach.Text = "Einfach (7 X 7)";
            this.rbEinfach.UseVisualStyleBackColor = false;
            this.rbEinfach.CheckedChanged += new System.EventHandler(this.rbEinfach_CheckedChanged);
            // 
            // rbSchwer
            // 
            this.rbSchwer.AutoSize = true;
            this.rbSchwer.BackColor = System.Drawing.Color.Transparent;
            this.rbSchwer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbSchwer.BackgroundImage")));
            this.rbSchwer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rbSchwer.Location = new System.Drawing.Point(49, 191);
            this.rbSchwer.Name = "rbSchwer";
            this.rbSchwer.Size = new System.Drawing.Size(107, 17);
            this.rbSchwer.TabIndex = 2;
            this.rbSchwer.TabStop = true;
            this.rbSchwer.Text = "Schwer (11 X 11)";
            this.rbSchwer.UseVisualStyleBackColor = false;
            this.rbSchwer.CheckedChanged += new System.EventHandler(this.rbSchwer_CheckedChanged);
            // 
            // rbMittel
            // 
            this.rbMittel.AutoSize = true;
            this.rbMittel.BackColor = System.Drawing.Color.Transparent;
            this.rbMittel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbMittel.BackgroundImage")));
            this.rbMittel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rbMittel.FlatAppearance.BorderSize = 0;
            this.rbMittel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rbMittel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rbMittel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rbMittel.Location = new System.Drawing.Point(49, 132);
            this.rbMittel.Name = "rbMittel";
            this.rbMittel.Size = new System.Drawing.Size(84, 17);
            this.rbMittel.TabIndex = 3;
            this.rbMittel.TabStop = true;
            this.rbMittel.Text = "Mittel (9 X 9)";
            this.rbMittel.UseVisualStyleBackColor = false;
            this.rbMittel.CheckedChanged += new System.EventHandler(this.rbMittel_CheckedChanged);
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(247, 285);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(13, 13);
            this.lblItems.TabIndex = 4;
            this.lblItems.Text = "0";
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(266, 268);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(23, 23);
            this.btnPlus.TabIndex = 5;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(266, 297);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(23, 23);
            this.btnMinus.TabIndex = 6;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Anzahl der zu suchenden Items";
            // 
            // btnStartTheGame
            // 
            this.btnStartTheGame.BackColor = System.Drawing.Color.Transparent;
            this.btnStartTheGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStartTheGame.BackgroundImage")));
            this.btnStartTheGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartTheGame.FlatAppearance.BorderSize = 0;
            this.btnStartTheGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStartTheGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStartTheGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartTheGame.Location = new System.Drawing.Point(454, 356);
            this.btnStartTheGame.Name = "btnStartTheGame";
            this.btnStartTheGame.Size = new System.Drawing.Size(116, 34);
            this.btnStartTheGame.TabIndex = 8;
            this.btnStartTheGame.Text = "Start the Game!";
            this.btnStartTheGame.UseVisualStyleBackColor = false;
            this.btnStartTheGame.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 402);
            this.Controls.Add(this.btnStartTheGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.rbMittel);
            this.Controls.Add(this.rbSchwer);
            this.Controls.Add(this.rbEinfach);
            this.Controls.Add(this.pbMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MapEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapEditor_FormClosed);
            this.Load += new System.EventHandler(this.MapEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.RadioButton rbEinfach;
        private System.Windows.Forms.RadioButton rbSchwer;
        private System.Windows.Forms.RadioButton rbMittel;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartTheGame;
    }
}