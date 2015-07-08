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
            this.btnStartTheGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbwenige = new System.Windows.Forms.RadioButton();
            this.rbnormal = new System.Windows.Forms.RadioButton();
            this.rbviele = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.rbEinfach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEinfach.Location = new System.Drawing.Point(49, 84);
            this.rbEinfach.Name = "rbEinfach";
            this.rbEinfach.Size = new System.Drawing.Size(110, 17);
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
            this.rbMittel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMittel.Location = new System.Drawing.Point(49, 132);
            this.rbMittel.Name = "rbMittel";
            this.rbMittel.Size = new System.Drawing.Size(98, 17);
            this.rbMittel.TabIndex = 3;
            this.rbMittel.TabStop = true;
            this.rbMittel.Text = "Mittel (9 X 9)";
            this.rbMittel.UseVisualStyleBackColor = false;
            this.rbMittel.CheckedChanged += new System.EventHandler(this.rbMittel_CheckedChanged);
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
            this.btnStartTheGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTheGame.Location = new System.Drawing.Point(454, 356);
            this.btnStartTheGame.Name = "btnStartTheGame";
            this.btnStartTheGame.Size = new System.Drawing.Size(116, 34);
            this.btnStartTheGame.TabIndex = 8;
            this.btnStartTheGame.Text = "Start the Game!";
            this.btnStartTheGame.UseVisualStyleBackColor = false;
            this.btnStartTheGame.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Anzahl der zu suchenden Items";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.rbwenige);
            this.groupBox1.Controls.Add(this.rbnormal);
            this.groupBox1.Controls.Add(this.rbviele);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(49, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 103);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Items";
            // 
            // rbwenige
            // 
            this.rbwenige.AutoSize = true;
            this.rbwenige.Location = new System.Drawing.Point(26, 77);
            this.rbwenige.Name = "rbwenige";
            this.rbwenige.Size = new System.Drawing.Size(68, 17);
            this.rbwenige.TabIndex = 10;
            this.rbwenige.TabStop = true;
            this.rbwenige.Text = "Wenige";
            this.rbwenige.UseVisualStyleBackColor = true;
            // 
            // rbnormal
            // 
            this.rbnormal.AutoSize = true;
            this.rbnormal.Location = new System.Drawing.Point(26, 54);
            this.rbnormal.Name = "rbnormal";
            this.rbnormal.Size = new System.Drawing.Size(64, 17);
            this.rbnormal.TabIndex = 9;
            this.rbnormal.TabStop = true;
            this.rbnormal.Text = "Normal";
            this.rbnormal.UseVisualStyleBackColor = true;
            // 
            // rbviele
            // 
            this.rbviele.AutoSize = true;
            this.rbviele.Location = new System.Drawing.Point(26, 33);
            this.rbviele.Name = "rbviele";
            this.rbviele.Size = new System.Drawing.Size(53, 17);
            this.rbviele.TabIndex = 8;
            this.rbviele.TabStop = true;
            this.rbviele.Text = "Viele";
            this.rbviele.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioButton1.BackgroundImage")));
            this.radioButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(49, 191);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(123, 17);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Schwer (11 X 11)";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 402);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartTheGame);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.RadioButton rbEinfach;
        private System.Windows.Forms.RadioButton rbSchwer;
        private System.Windows.Forms.RadioButton rbMittel;
        private System.Windows.Forms.Button btnStartTheGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbwenige;
        private System.Windows.Forms.RadioButton rbnormal;
        private System.Windows.Forms.RadioButton rbviele;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}